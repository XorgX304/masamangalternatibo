namespace masamangalternatibo {
    partial class buildPayload {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFinBuild = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb64bit = new System.Windows.Forms.RadioButton();
            this.rb32bit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFkExt = new System.Windows.Forms.TextBox();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.tbFlNm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnFinBuild);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 202);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::masamangalternatibo.Properties.Resources.delete16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(95, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 19);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(4, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 1);
            this.panel2.TabIndex = 17;
            // 
            // btnFinBuild
            // 
            this.btnFinBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinBuild.BackColor = System.Drawing.Color.Transparent;
            this.btnFinBuild.FlatAppearance.BorderSize = 0;
            this.btnFinBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinBuild.Image = global::masamangalternatibo.Properties.Resources.cogs16;
            this.btnFinBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinBuild.Location = new System.Drawing.Point(166, 176);
            this.btnFinBuild.Name = "btnFinBuild";
            this.btnFinBuild.Size = new System.Drawing.Size(98, 19);
            this.btnFinBuild.TabIndex = 16;
            this.btnFinBuild.Text = "Finish Build";
            this.btnFinBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinBuild.UseVisualStyleBackColor = false;
            this.btnFinBuild.Click += new System.EventHandler(this.btnFinBuild_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb64bit);
            this.groupBox2.Controls.Add(this.rb32bit);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(4, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 42);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Architecture";
            // 
            // rb64bit
            // 
            this.rb64bit.AutoSize = true;
            this.rb64bit.Location = new System.Drawing.Point(57, 17);
            this.rb64bit.Name = "rb64bit";
            this.rb64bit.Size = new System.Drawing.Size(42, 17);
            this.rb64bit.TabIndex = 3;
            this.rb64bit.Text = "x64";
            this.rb64bit.UseVisualStyleBackColor = true;
            // 
            // rb32bit
            // 
            this.rb32bit.AutoSize = true;
            this.rb32bit.Checked = true;
            this.rb32bit.Location = new System.Drawing.Point(9, 17);
            this.rb32bit.Name = "rb32bit";
            this.rb32bit.Size = new System.Drawing.Size(42, 17);
            this.rb32bit.TabIndex = 2;
            this.rb32bit.TabStop = true;
            this.rb32bit.Text = "x86";
            this.rb32bit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbFkExt);
            this.groupBox1.Controls.Add(this.tbPreview);
            this.groupBox1.Controls.Add(this.tbFlNm);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payload Export Name";
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = true;
            this.btnPreview.LinkColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(174, 95);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(78, 13);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.TabStop = true;
            this.btnPreview.Text = "Preview/Reset";
            this.btnPreview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPreview_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Export Name:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(6, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 1);
            this.panel3.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fake Extension";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = ".exe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = ".";
            // 
            // tbFkExt
            // 
            this.tbFkExt.Location = new System.Drawing.Point(120, 21);
            this.tbFkExt.Name = "tbFkExt";
            this.tbFkExt.Size = new System.Drawing.Size(100, 22);
            this.tbFkExt.TabIndex = 3;
            // 
            // tbPreview
            // 
            this.tbPreview.Location = new System.Drawing.Point(82, 71);
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(170, 22);
            this.tbPreview.TabIndex = 4;
            // 
            // tbFlNm
            // 
            this.tbFlNm.Location = new System.Drawing.Point(8, 21);
            this.tbFlNm.Name = "tbFlNm";
            this.tbFlNm.Size = new System.Drawing.Size(100, 22);
            this.tbFlNm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Build Payload";
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // buildPayload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(277, 229);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "buildPayload";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Build Payload";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.buildPayload_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buildPayload_MouseMove);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb64bit;
        private System.Windows.Forms.RadioButton rb32bit;
        private System.Windows.Forms.LinkLabel btnPreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.Button btnFinBuild;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox tbFkExt;
        public System.Windows.Forms.TextBox tbFlNm;
        private System.Windows.Forms.Label label6;
    }
}