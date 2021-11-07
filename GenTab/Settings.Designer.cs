
namespace GenTab
{
    partial class Settings
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblmenutype = new System.Windows.Forms.Label();
            this.Tournament1v1checkbox = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // lblmenutype
            // 
            this.lblmenutype.Location = new System.Drawing.Point(12, 9);
            this.lblmenutype.Name = "lblmenutype";
            this.lblmenutype.Size = new System.Drawing.Size(102, 25);
            this.lblmenutype.TabIndex = 1;
            this.lblmenutype.Text = "Menu Type:";
            this.lblmenutype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Tournament1v1checkbox
            // 
            this.Tournament1v1checkbox.Location = new System.Drawing.Point(12, 72);
            this.Tournament1v1checkbox.Name = "Tournament1v1checkbox";
            this.Tournament1v1checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Tournament1v1checkbox.Size = new System.Drawing.Size(122, 24);
            this.Tournament1v1checkbox.TabIndex = 4;
            this.Tournament1v1checkbox.Text = "Tournament";
            this.Tournament1v1checkbox.UseVisualStyleBackColor = true;
            this.Tournament1v1checkbox.CheckedChanged += new System.EventHandler(this.Tournament1v1checkbox_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(138, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(183, 28);
            this.comboBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "1v1 Menu Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 450);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tournament1v1checkbox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblmenutype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblmenutype;
        private System.Windows.Forms.CheckBox Tournament1v1checkbox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
    }
}