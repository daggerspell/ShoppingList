namespace Grampys_Shopping_List
{
    partial class ItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numUDPrice = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 16);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Cost:";
            // 
            // numUDPrice
            // 
            this.numUDPrice.DecimalPlaces = 2;
            this.numUDPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUDPrice.Location = new System.Drawing.Point(76, 53);
            this.numUDPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDPrice.Name = "numUDPrice";
            this.numUDPrice.Size = new System.Drawing.Size(71, 20);
            this.numUDPrice.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTrue);
            this.groupBox1.Controls.Add(this.rbFalse);
            this.groupBox1.Location = new System.Drawing.Point(15, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 49);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Taxable";
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Location = new System.Drawing.Point(131, 19);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(63, 17);
            this.rbTrue.TabIndex = 1;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "Taxable";
            this.rbTrue.UseVisualStyleBackColor = true;
            // 
            // rbFalse
            // 
            this.rbFalse.AutoSize = true;
            this.rbFalse.Location = new System.Drawing.Point(6, 19);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(86, 17);
            this.rbFalse.TabIndex = 0;
            this.rbFalse.TabStop = true;
            this.rbFalse.Text = "Non-Taxable";
            this.rbFalse.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Location = new System.Drawing.Point(15, 158);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(162, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ItemForm
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(254, 193);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numUDPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemForm";
            this.Text = "ItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.numUDPrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUDPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTrue;
        private System.Windows.Forms.RadioButton rbFalse;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
    }
}