
namespace Snake
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Main_panel1 = new System.Windows.Forms.Panel();
            this.Snake_timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Main_panel1
            // 
            this.Main_panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Main_panel1.Location = new System.Drawing.Point(0, 0);
            this.Main_panel1.Name = "Main_panel1";
            this.Main_panel1.Size = new System.Drawing.Size(1000, 500);
            this.Main_panel1.TabIndex = 0;
            // 
            // Snake_timer1
            // 
            this.Snake_timer1.Enabled = true;
            this.Snake_timer1.Interval = 200;
            this.Snake_timer1.Tick += new System.EventHandler(this.Snake_timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 500);
            this.Controls.Add(this.Main_panel1);
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Main_panel1;
        private System.Windows.Forms.Timer Snake_timer1;
    }
}

