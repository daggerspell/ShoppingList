namespace Grampys_Shopping_List
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printOrShareShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importXLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemView = new System.Windows.Forms.ListView();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            this.shoppingList = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataImportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newShoppingListToolStripMenuItem,
            this.openShoppingListToolStripMenuItem,
            this.closeShoppingListToolStripMenuItem,
            this.toolStripSeparator1,
            this.printOrShareShoppingListToolStripMenuItem,
            this.toolStripSeparator2,
            this.addNewItemToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.removeItemToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newShoppingListToolStripMenuItem
            // 
            this.newShoppingListToolStripMenuItem.Name = "newShoppingListToolStripMenuItem";
            this.newShoppingListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newShoppingListToolStripMenuItem.Text = "&New Shopping List";
            this.newShoppingListToolStripMenuItem.Click += new System.EventHandler(this.newShoppingListToolStripMenuItem_Click);
            // 
            // openShoppingListToolStripMenuItem
            // 
            this.openShoppingListToolStripMenuItem.Name = "openShoppingListToolStripMenuItem";
            this.openShoppingListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openShoppingListToolStripMenuItem.Text = "&Open Shopping List";
            // 
            // closeShoppingListToolStripMenuItem
            // 
            this.closeShoppingListToolStripMenuItem.Name = "closeShoppingListToolStripMenuItem";
            this.closeShoppingListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.closeShoppingListToolStripMenuItem.Text = "Close Shopping List";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // printOrShareShoppingListToolStripMenuItem
            // 
            this.printOrShareShoppingListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printShoppingListToolStripMenuItem,
            this.emailShoppingListToolStripMenuItem});
            this.printOrShareShoppingListToolStripMenuItem.Name = "printOrShareShoppingListToolStripMenuItem";
            this.printOrShareShoppingListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.printOrShareShoppingListToolStripMenuItem.Text = "Print or Share Shopping List";
            // 
            // printShoppingListToolStripMenuItem
            // 
            this.printShoppingListToolStripMenuItem.Name = "printShoppingListToolStripMenuItem";
            this.printShoppingListToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.printShoppingListToolStripMenuItem.Text = "&Print Shopping List";
            // 
            // emailShoppingListToolStripMenuItem
            // 
            this.emailShoppingListToolStripMenuItem.Name = "emailShoppingListToolStripMenuItem";
            this.emailShoppingListToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.emailShoppingListToolStripMenuItem.Text = "Email Shopping List";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(217, 6);
            // 
            // addNewItemToolStripMenuItem
            // 
            this.addNewItemToolStripMenuItem.Name = "addNewItemToolStripMenuItem";
            this.addNewItemToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.addNewItemToolStripMenuItem.Text = "Add Item";
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.editItemToolStripMenuItem.Text = "Edit Item";
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(217, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataImportToolStripMenuItem
            // 
            this.dataImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importXLSToolStripMenuItem});
            this.dataImportToolStripMenuItem.Name = "dataImportToolStripMenuItem";
            this.dataImportToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.dataImportToolStripMenuItem.Text = "Data Import";
            // 
            // importXLSToolStripMenuItem
            // 
            this.importXLSToolStripMenuItem.Name = "importXLSToolStripMenuItem";
            this.importXLSToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.importXLSToolStripMenuItem.Text = "Import XLS";
            this.importXLSToolStripMenuItem.Click += new System.EventHandler(this.importXLSToolStripMenuItem_Click);
            // 
            // itemView
            // 
            this.itemView.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemView.HideSelection = false;
            this.itemView.Location = new System.Drawing.Point(0, 24);
            this.itemView.MultiSelect = false;
            this.itemView.Name = "itemView";
            this.itemView.Size = new System.Drawing.Size(278, 575);
            this.itemView.TabIndex = 3;
            this.itemView.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(284, 164);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 49);
            this.btnAddToList.TabIndex = 5;
            this.btnAddToList.Text = "Add To Shopping List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Location = new System.Drawing.Point(284, 312);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(75, 64);
            this.btnRemoveFromList.TabIndex = 6;
            this.btnRemoveFromList.Text = "Remove from Shopping List";
            this.btnRemoveFromList.UseVisualStyleBackColor = true;
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);
            // 
            // shoppingList
            // 
            this.shoppingList.Dock = System.Windows.Forms.DockStyle.Right;
            this.shoppingList.HideSelection = false;
            this.shoppingList.Location = new System.Drawing.Point(366, 24);
            this.shoppingList.MultiSelect = false;
            this.shoppingList.Name = "shoppingList";
            this.shoppingList.Size = new System.Drawing.Size(278, 575);
            this.shoppingList.TabIndex = 7;
            this.shoppingList.UseCompatibleStateImageBehavior = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 599);
            this.Controls.Add(this.shoppingList);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.itemView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Grampy\'s Shopping List";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView itemView;
        private System.Windows.Forms.ToolStripMenuItem dataImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importXLSToolStripMenuItem;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newShoppingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openShoppingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeShoppingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printOrShareShoppingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printShoppingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailShoppingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addNewItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveFromList;
        private System.Windows.Forms.ListView shoppingList;
    }
}

