namespace ADO_NET_ДЗ_Модуль_03_часть_01
{
    partial class FormForDeleteData
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
            this.button_OK_delete = new System.Windows.Forms.Button();
            this.textBox_for_delete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_delete_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_OK_delete
            // 
            this.button_OK_delete.Location = new System.Drawing.Point(28, 61);
            this.button_OK_delete.Name = "button_OK_delete";
            this.button_OK_delete.Size = new System.Drawing.Size(150, 23);
            this.button_OK_delete.TabIndex = 0;
            this.button_OK_delete.Text = "OK";
            this.button_OK_delete.UseVisualStyleBackColor = true;
            this.button_OK_delete.Click += new System.EventHandler(this.button_OK_delete_Click);
            // 
            // textBox_for_delete
            // 
            this.textBox_for_delete.Location = new System.Drawing.Point(232, 24);
            this.textBox_for_delete.Name = "textBox_for_delete";
            this.textBox_for_delete.Size = new System.Drawing.Size(92, 20);
            this.textBox_for_delete.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите Имя продукта для удаления: ";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(91, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btn_delete_cancel
            // 
            this.btn_delete_cancel.Location = new System.Drawing.Point(189, 61);
            this.btn_delete_cancel.Name = "btn_delete_cancel";
            this.btn_delete_cancel.Size = new System.Drawing.Size(150, 23);
            this.btn_delete_cancel.TabIndex = 0;
            this.btn_delete_cancel.Text = "CANCEL";
            this.btn_delete_cancel.UseVisualStyleBackColor = true;
            this.btn_delete_cancel.Click += new System.EventHandler(this.btn_delete_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DataBase: ";
            // 
            // FormForDeleteData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 144);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_for_delete);
            this.Controls.Add(this.btn_delete_cancel);
            this.Controls.Add(this.button_OK_delete);
            this.Name = "FormForDeleteData";
            this.Text = "Удаление данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK_delete;
        private System.Windows.Forms.TextBox textBox_for_delete;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_delete_cancel;
        private System.Windows.Forms.Label label2;
    }
}