using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
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
                //Needs to be a dialog to block and ecept a yes or no answer
                DialogResult results = MessageBox.Show("You shopping List is unsaved! Are you sure you want to exit?", "Shopping List", MessageBoxButtons.YesNo);
                if (results == DialogResult.No)
                {
                    //Call the save dialog and once saved exit
                    MessageBox.Show("Okay please save your work", "Shopping List");
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
                MessageBox.Show("Oops you forgot to select and item!");
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
        }

        private void newShoppingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unsaved)
            {
                MessageBox.Show("shopping List is unsaved");
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
    }
}
