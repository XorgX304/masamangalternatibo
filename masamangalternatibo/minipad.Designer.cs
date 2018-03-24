namespace masamangalternatibo {
    partial class minipad {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mprtb = new System.Windows.Forms.RichTextBox();
            this.btnCompileScript = new System.Windows.Forms.LinkLabel();
            this.btnPassShell = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // mprtb
            // 
            this.mprtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mprtb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.mprtb.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mprtb.ForeColor = System.Drawing.Color.White;
            this.mprtb.Location = new System.Drawing.Point(-1, 0);
            this.mprtb.Name = "mprtb";
            this.mprtb.Size = new System.Drawing.Size(512, 265);
            this.mprtb.TabIndex = 0;
            this.mprtb.Text = "";
            this.mprtb.WordWrap = false;
            // 
            // btnCompileScript
            // 
            this.btnCompileScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompileScript.AutoSize = true;
            this.btnCompileScript.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.btnCompileScript.LinkColor = System.Drawing.Color.White;
            this.btnCompileScript.Location = new System.Drawing.Point(413, 270);
            this.btnCompileScript.Name = "btnCompileScript";
            this.btnCompileScript.Size = new System.Drawing.Size(91, 13);
            this.btnCompileScript.TabIndex = 1;
            this.btnCompileScript.TabStop = true;
            this.btnCompileScript.Text = "[Continue Build]";
            // 
            // btnPassShell
            // 
            this.btnPassShell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPassShell.AutoSize = true;
            this.btnPassShell.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.btnPassShell.LinkColor = System.Drawing.Color.White;
            this.btnPassShell.Location = new System.Drawing.Point(300, 270);
            this.btnPassShell.Name = "btnPassShell";
            this.btnPassShell.Size = new System.Drawing.Size(107, 13);
            this.btnPassShell.TabIndex = 2;
            this.btnPassShell.TabStop = true;
            this.btnPassShell.Text = "[Pass to Shell Code]";
            // 
            // minipad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(509, 289);
            this.Controls.Add(this.btnPassShell);
            this.Controls.Add(this.btnCompileScript);
            this.Controls.Add(this.mprtb);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "minipad";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Notepad";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.LinkLabel btnPassShell;
        public System.Windows.Forms.RichTextBox mprtb;
        public System.Windows.Forms.LinkLabel btnCompileScript;
    }
}