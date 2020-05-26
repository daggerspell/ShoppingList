using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grampys_Shopping_List
{
    public partial class ItemForm : Form
    {
        public string Mode = "Edit";
        public Item currentItem = null;
        public ItemForm()
        {
            InitializeComponent();
        }

        public ItemForm(string formMode)
        {
            Mode = formMode;
            this.Text = Mode + " Item";
            InitializeComponent();
        }

        public ItemForm(string formMode, Item inputItem)
        {
            Mode = formMode;
            this.Text = Mode + " Item";
            currentItem = inputItem;
            InitializeComponent();

            //TODO: after initialize load Item into fields
            txtName.Text = currentItem.Name;
            numUDPrice.Value = currentItem.Price;
            if(currentItem.Taxable)
            {
                rbTrue.Checked = true;
            }
            else
            {
                rbFalse.Checked = true;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            bool taxable = false;
            if (rbTrue.Checked)
                taxable = true;
            currentItem = null;
            currentItem = new Item(txtName.Text, "", numUDPrice.Value, taxable, "");
        }
    }
}
