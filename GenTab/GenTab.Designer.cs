
namespace GenTab
{
    partial class GenTab
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Modifier = new System.Windows.Forms.Button();
            this.GameInfo = new System.Windows.Forms.Label();
            this.Players = new System.Windows.Forms.ListBox();
            this.CheckForGameThread = new System.ComponentModel.BackgroundWorker();
            this.OperateWithGensThread = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.OperateWithStreamGUI = new System.ComponentModel.BackgroundWorker();
            this.GUI1v1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Modifier
            // 
            this.Modifier.Enabled = false;
            this.Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Modifier.Location = new System.Drawing.Point(416, 10);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(220, 50);
            this.Modifier.TabIndex = 0;
            this.Modifier.Text = "GetPlayers";
            this.Modifier.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Modifier.UseVisualStyleBackColor = true;
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // GameInfo
            // 
            this.GameInfo.BackColor = System.Drawing.Color.White;
            this.GameInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameInfo.Location = new System.Drawing.Point(7, 10);
            this.GameInfo.Name = "GameInfo";
            this.GameInfo.Size = new System.Drawing.Size(394, 50);
            this.GameInfo.TabIndex = 1;
            this.GameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Players
            // 
            this.Players.Font = new System.Drawing.Font("Consolas", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Players.FormattingEnabled = true;
            this.Players.IntegralHeight = false;
            this.Players.ItemHeight = 23;
            this.Players.Location = new System.Drawing.Point(7, 66);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(787, 219);
            this.Players.TabIndex = 2;
            // 
            // CheckForGameThread
            // 
            this.CheckForGameThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckForGameThread_DoWork);
            // 
            // OperateWithGensThread
            // 
            this.OperateWithGensThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OperateWithGensThread_DoWork);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(642, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Settings";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OperateWithStreamGUI
            // 
            this.OperateWithStreamGUI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OperateWithStreamGUI_DoWork);
            // 
            // GUI1v1
            // 
            this.GUI1v1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GUI1v1.Location = new System.Drawing.Point(7, 291);
            this.GUI1v1.Name = "GUI1v1";
            this.GUI1v1.Size = new System.Drawing.Size(254, 58);
            this.GUI1v1.TabIndex = 4;
            this.GUI1v1.Text = "1v1 Menu";
            this.GUI1v1.UseVisualStyleBackColor = true;
            this.GUI1v1.Click += new System.EventHandler(this.GUI1v1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(267, 291);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 26);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(267, 323);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(254, 26);
            this.textBox2.TabIndex = 8;
            // 
            // GenTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 360);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GUI1v1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Players);
            this.Controls.Add(this.GameInfo);
            this.Controls.Add(this.Modifier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GenTab";
            this.Text = "GenTab";
            this.Load += new System.EventHandler(this.GenTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Modifier;
        private System.Windows.Forms.Label GameInfo;
        private System.Windows.Forms.ListBox Players;
        private System.ComponentModel.BackgroundWorker CheckForGameThread;
        private System.ComponentModel.BackgroundWorker OperateWithGensThread;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker OperateWithStreamGUI;
        private System.Windows.Forms.Button GUI1v1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

