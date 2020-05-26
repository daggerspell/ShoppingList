using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib;

namespace Grampys_Shopping_List
{
    public partial class frmMain : Form
    {
        private DatabaseConnector databaseConnector = new DatabaseConnector();
        private ExcelDataImporter dataImporter;
        private List<Item> availableItems = new List<Item>();
        private bool unsaved = true;
        private List<ShoppingListItem> shoppingListItems = new List<ShoppingListItem>();
        private List<ShoppingListItem> remainingToPrint = new List<ShoppingListItem>();
        public decimal TaxRate = 0.0825M;

        public frmMain()
        {
            InitializeComponent();

            updateAvailableItems();
            UpdateShoppingListItems();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (unsaved)
            {
                //Needs to be a dialog to block
                DialogResult results = MessageBox.Show("You shopping List is unsaved! Are you sure you want to exit?", "Shopping List", MessageBoxButtons.YesNo);
                if (results == DialogResult.No)
                {
                    ToolStripMenuSave_Click(this, e);
                }
            }
        }

        private void updateAvailableItems()
        {
            itemView.View = View.Details;
            itemView.Clear();
            availableItems.Clear();
            availableItems = databaseConnector.GetAllItems();
            //Setup columns
            if (itemView.Columns.Count <= 0)
            {
                itemView.Columns.Add("Item Name");
                itemView.Columns.Add("Price");
                itemView.Columns[1].TextAlign = HorizontalAlignment.Right;
            }
            foreach (Item item in availableItems)
            {
                itemView.Items.Add(new ListViewItem(new string[] { item.Name, @String.Format("{0:C}", item.Price) }));
            }
            if (itemView.Items.Count <= 0)
            {
                itemView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                itemView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void importXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = ".";
                fileDialog.Filter = "xls files (*.xls)|*.xls";
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataImporter = new ExcelDataImporter(fileDialog.FileName);
                }
            }

            List<Item> insertData = dataImporter.ImportData();

            foreach (Item item in insertData)
            {
                databaseConnector.InsertNewItem(item);
            }

            updateAvailableItems();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if(itemView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Oops you forgot to select an item!");
            }
            else
            {
                //TODO: Check if already in the shopping List
                ShoppingListItem foundItemInList = null;
                
                foreach (ShoppingListItem item in shoppingListItems)
                {
                    if(item.item.Name == availableItems[itemView.SelectedIndices[0]].Name)
                    {
                        item.AddQuanity();
                        foundItemInList = item;
                    }
                }
                
                if (foundItemInList == null)
                {
                    ShoppingListItem newItem = new ShoppingListItem(availableItems[itemView.SelectedIndices[0]], 1);
                    shoppingListItems.Add(newItem);
                    
                }

                unsaved = true;
            }

            UpdateShoppingListItems();
        }

        private void UpdateShoppingListItems()
        {
            decimal subtotal = 0M;
            decimal tax = 0M;
            shoppingList.View = View.Details;
            shoppingList.Items.Clear();

            if (shoppingList.Columns.Count <= 0)
            {
                shoppingList.Columns.Add("Item Name");
                shoppingList.Columns.Add("Quanity");
                shoppingList.Columns.Add("Total Item Price");
            }
            
            foreach (ShoppingListItem item in shoppingListItems)
            {
                string itemName = item.item.Name;
                string itemQuanity = item.Quanity.ToString();
                string itemPrice = @String.Format("{0:C}", item.SetTotalPrice());
                shoppingList.Items.Add(new ListViewItem(new string[] { itemName, itemQuanity, itemPrice }));
                subtotal += item.SetTotalPrice();
                if(item.item.Taxable)
                {
                    tax += item.SetTotalPrice() * TaxRate;
                }
            }

            //TODO: add sub total, Tax, and Total
            if (shoppingList.Items.Count >= 1)
            {
                shoppingList.Items.Add(new ListViewItem(new string[] { "", "Sub-Total", String.Format("{0:C}", subtotal) }));
                shoppingList.Items.Add(new ListViewItem(new string[] { "", "Tax (" + TaxRate + ")", String.Format("{0:C}", tax) }));
                shoppingList.Items.Add(new ListViewItem(new string[] { "", "Total", String.Format("{0:C}", subtotal + tax) }));
            }

            if (shoppingList.Items.Count > 0)
            {
                shoppingList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                shoppingList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            shoppingList.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            shoppingList.Columns[1].TextAlign = HorizontalAlignment.Right;
            shoppingList.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            shoppingList.Columns[2].TextAlign = HorizontalAlignment.Right;

            remainingToPrint.Clear();
            remainingToPrint.AddRange(shoppingListItems);

        }

        private void newShoppingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unsaved)
            {
                DialogResult result = MessageBox.Show("Would you like to save the current shopping list", "Unsaved Shopping List",MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    ToolStripMenuSave_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    unsaved = true;
                    shoppingListItems.Clear();
                    shoppingList.Items.Clear();
                }
            }
            else
            {
                unsaved = true;
                shoppingListItems.Clear();
                shoppingList.Items.Clear();
            }
        }

        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            // First check to see if something is selected
            if(shoppingList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Oops you forgot to select the item you want to remove");
                return;
            }

            if (shoppingListItems[shoppingList.SelectedIndices[0]].Quanity <= 1)
            {
                shoppingListItems.Remove(shoppingListItems[shoppingList.SelectedIndices[0]]);
            }
            else
            {
                shoppingListItems[shoppingList.SelectedIndices[0]].RemoveQuanity();
            }

            UpdateShoppingListItems();

            unsaved = true;
        }

        private void addNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm("Add");
            DialogResult dialogResult = itemForm.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                //Add Item
                databaseConnector.InsertNewItem(itemForm.currentItem);
                availableItems.Add(itemForm.currentItem);
                updateAvailableItems();
            }
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(itemView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("No item selected");
                return;
            }
            else
            {
                ItemForm itemForm = new ItemForm("Edit", availableItems[itemView.SelectedIndices[0]]);
                DialogResult dialogResult = itemForm.ShowDialog();
                if(dialogResult == DialogResult.OK)
                {
                    //TODO: update database record
                    databaseConnector.UpdateRecord(itemForm.currentItem);
                    updateAvailableItems();
                }
            }
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (itemView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("No item selected");
                return;
            }
            else
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + availableItems[itemView.SelectedIndices[0]].Name + " from database?", "Remove Item", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //TODO: update database record
                    databaseConnector.RemoveRecord(availableItems[itemView.SelectedIndices[0]]);
                    updateAvailableItems();
                }
            }
        }

        private void printOrShareShoppingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            previewDialog.Document = this.printDoc;
            previewDialog.PrintPreviewControl.Zoom = 1.0f;
            Form previewDialogForm = previewDialog as Form;
            previewDialogForm.WindowState = FormWindowState.Maximized;
            DialogResult results = previewDialogForm.ShowDialog();
        }

        private int[] FindColumnWidths(Graphics gr, Font headerFont, Font bodyFont, string [] headers, List<ShoppingListItem> values)
        {
            int[] widths = new int[headers.Length];

            for (int col = 0; col < widths.Length; col++)
            {
                widths[col] = (int)gr.MeasureString(headers[col], headerFont).Width;

                for (int row = 0; row < values.Count; row++)
                {
                    int valueWidth = 0;
                    switch (col)
                    {
                        case 0:
                            valueWidth = (int)gr.MeasureString(values[row].item.Name, bodyFont).Width;
                            break;
                        case 1:
                            valueWidth = (int)gr.MeasureString(values[row].Quanity.ToString(), bodyFont).Width;
                            break;
                        case 2:
                            valueWidth = (int)gr.MeasureString(String.Format("{0:C}", values[row].SetTotalPrice()), bodyFont).Width;
                            break;
                    }                    
                    if (widths[col] < valueWidth)
                        widths[col] = valueWidth;
                }
                widths[col] += 20;
            }
            return widths;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string[] newHeaders = new string[] { "Item Name", "Quantity", "Item Price" };

            using (Font headerFont = new Font("Times New Roman", 16, FontStyle.Bold))
            {
                using (Font bodyFont = new Font("Times New Roman", 12))
                {
                    int lineSpacing = 20;

                    int[] column_widths = FindColumnWidths(e.Graphics, headerFont, bodyFont, newHeaders, remainingToPrint);

                    int x = e.MarginBounds.Left;
                    float pageHeight = e.MarginBounds.Height;
                    int col = 0;
                    int y = e.MarginBounds.Top;

                    ///TODO: Print the column headers
                    for (col = 0; col < 3; col++)
                    {
                        if (col == 2)
                        {
                            int testing = (int)e.Graphics.MeasureString(newHeaders[col], headerFont).Width;
                            e.Graphics.DrawString(newHeaders[col], headerFont, Brushes.Black, x + (column_widths[col] - testing), y);
                        }
                        else
                        {
                            e.Graphics.DrawString(newHeaders[col], headerFont, Brushes.Black, x, y);
                        }
                        x += column_widths[col];
                    }

                    y += 20;
                    int index = 0;
                    while (index < remainingToPrint.Count)
                    //foreach (ShoppingListItem item in remainingToPrint)
                    {
                        y += lineSpacing;
                        x = e.MarginBounds.Left;
                        if (y + lineSpacing >= pageHeight && remainingToPrint.Count > 0)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                        else
                        {
                            int testing = (int)e.Graphics.MeasureString(String.Format("{0:C}", remainingToPrint[index].SetTotalPrice()), bodyFont).Width;
                            e.Graphics.DrawString(remainingToPrint[index].item.Name, bodyFont, Brushes.Black, x, y);
                            x += column_widths[0];
                            e.Graphics.DrawString(remainingToPrint[index].Quanity.ToString(), bodyFont, Brushes.Black, x + (int)(column_widths[1] / 2), y);
                            x += column_widths[1];
                            e.Graphics.DrawString(String.Format("{0:C}", remainingToPrint[index].SetTotalPrice()), bodyFont, Brushes.Black, x + (column_widths[2] - testing), y);
                            remainingToPrint.RemoveAt(index);
                        }

                        if (remainingToPrint.Count <= 0)
                        {
                            //Add subtotal, tax, and total
                            decimal subtotal = 0M;
                            decimal tax = 0M;
                            foreach (ShoppingListItem item in shoppingListItems)
                            {
                                subtotal += item.SetTotalPrice();
                                if (item.item.Taxable)
                                    tax += item.SetTotalPrice() * TaxRate;
                            }
                            x = e.MarginBounds.Left + (column_widths[0]);
                            y += lineSpacing;
                            int testing = (int)e.Graphics.MeasureString(String.Format("{0:C}", subtotal), bodyFont).Width;
                            e.Graphics.DrawString("Subtotal:", bodyFont, Brushes.Black, x + (int)(column_widths[1] / 2), y);
                            x += column_widths[1];
                            e.Graphics.DrawString(String.Format("{0:C}", subtotal), bodyFont, Brushes.Black, x + (column_widths[2] - testing), y);

                            x = e.MarginBounds.Left + (column_widths[0]);
                            y += lineSpacing;
                            testing = (int)e.Graphics.MeasureString(String.Format("{0:C}", tax), bodyFont).Width;
                            e.Graphics.DrawString("Tax (8.25%):", bodyFont, Brushes.Black, x + (int)(column_widths[1] / 2), y);
                            x += column_widths[1];
                            e.Graphics.DrawString(String.Format("{0:C}", tax), bodyFont, Brushes.Black, x + (column_widths[2] - testing), y);

                            x = e.MarginBounds.Left + (column_widths[0]);
                            y += lineSpacing;
                            testing = (int)e.Graphics.MeasureString(String.Format("{0:C}", subtotal + tax), bodyFont).Width;
                            e.Graphics.DrawString("Total:", bodyFont, Brushes.Black, x + (int)(column_widths[1] / 2), y);
                            x += column_widths[1];
                            e.Graphics.DrawString(String.Format("{0:C}", subtotal + tax), bodyFont, Brushes.Black, x + (column_widths[2] - testing), y);

                        }
                    }
                }
            }
        }

        private void ToolStripMenuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File|*.csv";
            saveFileDialog.Title = "Save Shopping List";
            saveFileDialog.ShowDialog();

            if(saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();
                StringBuilder csvOutput = new StringBuilder();

                csvOutput.AppendLine("Item Name,Quantity,Total Item Price");

                foreach (ShoppingListItem item in shoppingListItems)
                {
                    csvOutput.AppendLine(item.item.Name + "," + item.Quanity.ToString() + "," + item.SetTotalPrice().ToString());
                }

                fs.Write(new UTF8Encoding().GetBytes(csvOutput.ToString()), 0, new UTF8Encoding().GetByteCount(csvOutput.ToString()));

                fs.Flush();
                fs.Close();

                unsaved = false;
            }
        }

        private void openShoppingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV File|*.csv";
            openFileDialog.Title = "Open Shopping List";

            openFileDialog.ShowDialog();

            if(openFileDialog.FileName != "")
            {
                List<ShoppingListItem> shoppingListInput = new List<ShoppingListItem>();

                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                foreach (string line in lines)
                {
                    string[] spiltLine = line.Split(',');
                    //TODO: verify that the item is in available Items
                    foreach (Item item in availableItems)
                    {
                        if(spiltLine[0] == item.Name)
                        {
                            shoppingListInput.Add(new ShoppingListItem(item, int.Parse(spiltLine[1])));
                            break;
                        }
                    }
                }

                shoppingListItems.Clear();
                shoppingListItems.AddRange(shoppingListInput);

                UpdateShoppingListItems();

                unsaved = false;
            }


        }
    }
}
