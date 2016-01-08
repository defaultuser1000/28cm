namespace _28cm
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.saveButton_form2 = new System.Windows.Forms.Button();
            this.exitButton_form2 = new System.Windows.Forms.Button();
            this.textBox_group = new System.Windows.Forms.TextBox();
            this.textBox_year = new System.Windows.Forms.TextBox();
            this.groupName_form2 = new System.Windows.Forms.Label();
            this.Year_form2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton_form2
            // 
            this.saveButton_form2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton_form2.Location = new System.Drawing.Point(32, 118);
            this.saveButton_form2.Name = "saveButton_form2";
            this.saveButton_form2.Size = new System.Drawing.Size(67, 23);
            this.saveButton_form2.TabIndex = 0;
            this.saveButton_form2.Text = "Добавить";
            this.saveButton_form2.UseVisualStyleBackColor = true;
            this.saveButton_form2.Click += new System.EventHandler(this.saveButton_form2_Click);
            // 
            // exitButton_form2
            // 
            this.exitButton_form2.Location = new System.Drawing.Point(105, 118);
            this.exitButton_form2.Name = "exitButton_form2";
            this.exitButton_form2.Size = new System.Drawing.Size(68, 23);
            this.exitButton_form2.TabIndex = 1;
            this.exitButton_form2.Text = "Отмена";
            this.exitButton_form2.UseVisualStyleBackColor = true;
            this.exitButton_form2.Click += new System.EventHandler(this.exitButton_form2_Click);
            // 
            // textBox_group
            // 
            this.textBox_group.Location = new System.Drawing.Point(32, 35);
            this.textBox_group.Name = "textBox_group";
            this.textBox_group.Size = new System.Drawing.Size(141, 20);
            this.textBox_group.TabIndex = 2;
            // 
            // textBox_year
            // 
            this.textBox_year.Location = new System.Drawing.Point(32, 79);
            this.textBox_year.Name = "textBox_year";
            this.textBox_year.Size = new System.Drawing.Size(141, 20);
            this.textBox_year.TabIndex = 3;
            // 
            // groupName_form2
            // 
            this.groupName_form2.AutoSize = true;
            this.groupName_form2.BackColor = System.Drawing.Color.Transparent;
            this.groupName_form2.Location = new System.Drawing.Point(32, 16);
            this.groupName_form2.Name = "groupName_form2";
            this.groupName_form2.Size = new System.Drawing.Size(42, 13);
            this.groupName_form2.TabIndex = 4;
            this.groupName_form2.Text = "Группа";
            // 
            // Year_form2
            // 
            this.Year_form2.AutoSize = true;
            this.Year_form2.BackColor = System.Drawing.Color.Transparent;
            this.Year_form2.Location = new System.Drawing.Point(32, 60);
            this.Year_form2.Name = "Year_form2";
            this.Year_form2.Size = new System.Drawing.Size(78, 13);
            this.Year_form2.TabIndex = 5;
            this.Year_form2.Text = "Учебные года";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(206, 162);
            this.Controls.Add(this.Year_form2);
            this.Controls.Add(this.groupName_form2);
            this.Controls.Add(this.textBox_year);
            this.Controls.Add(this.textBox_group);
            this.Controls.Add(this.exitButton_form2);
            this.Controls.Add(this.saveButton_form2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить группу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton_form2;
        private System.Windows.Forms.Button exitButton_form2;
        private System.Windows.Forms.TextBox textBox_group;
        private System.Windows.Forms.TextBox textBox_year;
        private System.Windows.Forms.Label groupName_form2;
        private System.Windows.Forms.Label Year_form2;
    }
}