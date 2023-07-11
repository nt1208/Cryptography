namespace DA_NT106
{
    partial class Server
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
            this.serverBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverBtn
            // 
            this.serverBtn.Location = new System.Drawing.Point(314, 196);
            this.serverBtn.Name = "serverBtn";
            this.serverBtn.Size = new System.Drawing.Size(155, 67);
            this.serverBtn.TabIndex = 0;
            this.serverBtn.Text = "Start Server";
            this.serverBtn.UseVisualStyleBackColor = true;
            this.serverBtn.Click += new System.EventHandler(this.serverBtn_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.serverBtn);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button serverBtn;
    }
}