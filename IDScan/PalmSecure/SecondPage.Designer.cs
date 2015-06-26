namespace PalmSecure
{
    partial class psWindowMain
	{

		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
            PalmSecure_FinishLibrary();
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows FormControls


		private void InitializeComponent()
		{
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ImagePic = new System.Windows.Forms.PictureBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.WorkMsgLabel = new System.Windows.Forms.Label();
            this.GuidanceLabel = new System.Windows.Forms.Label();
            this.EnrollBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.VerifyBtn = new System.Windows.Forms.Button();
            this.IdentifyBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListLabel = new System.Windows.Forms.Label();
            this.IDListBox = new System.Windows.Forms.ListBox();
            this.IDNumTextBox = new System.Windows.Forms.TextBox();
            this.IDNumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePic)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModeLabel
            // 
            this.ModeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModeLabel.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ModeLabel.Location = new System.Drawing.Point(141, 10);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(703, 33);
            this.ModeLabel.TabIndex = 1;
            this.ModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImagePic
            // 
            this.ImagePic.Location = new System.Drawing.Point(141, 60);
            this.ImagePic.Name = "ImagePic";
            this.ImagePic.Size = new System.Drawing.Size(319, 276);
            this.ImagePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePic.TabIndex = 2;
            this.ImagePic.TabStop = false;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(7, 13);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(16, 13);
            this.IDLabel.TabIndex = 3;
            this.IDLabel.Text = "   ";
            // 
            // WorkMsgLabel
            // 
            this.WorkMsgLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WorkMsgLabel.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WorkMsgLabel.Location = new System.Drawing.Point(141, 350);
            this.WorkMsgLabel.Name = "WorkMsgLabel";
            this.WorkMsgLabel.Size = new System.Drawing.Size(319, 38);
            this.WorkMsgLabel.TabIndex = 9;
            // 
            // GuidanceLabel
            // 
            this.GuidanceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GuidanceLabel.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GuidanceLabel.Location = new System.Drawing.Point(141, 405);
            this.GuidanceLabel.Name = "GuidanceLabel";
            this.GuidanceLabel.Size = new System.Drawing.Size(559, 116);
            this.GuidanceLabel.TabIndex = 10;
            // 
            // EnrollBtn
            // 
            this.EnrollBtn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EnrollBtn.Location = new System.Drawing.Point(737, 61);
            this.EnrollBtn.Name = "EnrollBtn";
            this.EnrollBtn.Size = new System.Drawing.Size(129, 65);
            this.EnrollBtn.TabIndex = 11;
            this.EnrollBtn.UseVisualStyleBackColor = true;
            this.EnrollBtn.Click += new System.EventHandler(this.EnrollBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteBtn.Location = new System.Drawing.Point(738, 132);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(128, 66);
            this.DeleteBtn.TabIndex = 12;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // VerifyBtn
            // 
            this.VerifyBtn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.VerifyBtn.Location = new System.Drawing.Point(738, 218);
            this.VerifyBtn.Name = "VerifyBtn";
            this.VerifyBtn.Size = new System.Drawing.Size(128, 66);
            this.VerifyBtn.TabIndex = 13;
            this.VerifyBtn.UseVisualStyleBackColor = true;
            this.VerifyBtn.Click += new System.EventHandler(this.VerifyBtn_Click);
            // 
            // IdentifyBtn
            // 
            this.IdentifyBtn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IdentifyBtn.Location = new System.Drawing.Point(737, 290);
            this.IdentifyBtn.Name = "IdentifyBtn";
            this.IdentifyBtn.Size = new System.Drawing.Size(128, 66);
            this.IdentifyBtn.TabIndex = 14;
            this.IdentifyBtn.UseVisualStyleBackColor = true;
            this.IdentifyBtn.Click += new System.EventHandler(this.IdentifyBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CancelBtn.Location = new System.Drawing.Point(737, 375);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(128, 66);
            this.CancelBtn.TabIndex = 15;
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EndBtn.Location = new System.Drawing.Point(737, 447);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(128, 66);
            this.EndBtn.TabIndex = 16;
            this.EndBtn.UseVisualStyleBackColor = true;
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.IDTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.IDTextBox.Location = new System.Drawing.Point(29, 10);
            this.IDTextBox.MaxLength = 16;
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(190, 20);
            this.IDTextBox.TabIndex = 4;
            this.IDTextBox.TextChanged += new System.EventHandler(this.IDTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.IDTextBox);
            this.panel1.Controls.Add(this.IDLabel);
            this.panel1.Location = new System.Drawing.Point(469, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 43);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ListLabel);
            this.panel2.Controls.Add(this.IDListBox);
            this.panel2.Controls.Add(this.IDNumTextBox);
            this.panel2.Controls.Add(this.IDNumLabel);
            this.panel2.Location = new System.Drawing.Point(471, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 279);
            this.panel2.TabIndex = 19;
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Location = new System.Drawing.Point(9, 28);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(22, 13);
            this.ListLabel.TabIndex = 8;
            this.ListLabel.Text = "     ";
            // 
            // IDListBox
            // 
            this.IDListBox.FormattingEnabled = true;
            this.IDListBox.Location = new System.Drawing.Point(8, 49);
            this.IDListBox.Name = "IDListBox";
            this.IDListBox.Size = new System.Drawing.Size(213, 212);
            this.IDListBox.Sorted = true;
            this.IDListBox.TabIndex = 7;
            // 
            // IDNumTextBox
            // 
            this.IDNumTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.IDNumTextBox.Location = new System.Drawing.Point(172, 21);
            this.IDNumTextBox.Name = "IDNumTextBox";
            this.IDNumTextBox.ReadOnly = true;
            this.IDNumTextBox.Size = new System.Drawing.Size(49, 20);
            this.IDNumTextBox.TabIndex = 6;
            this.IDNumTextBox.TabStop = false;
            // 
            // IDNumLabel
            // 
            this.IDNumLabel.AutoSize = true;
            this.IDNumLabel.Location = new System.Drawing.Point(90, 24);
            this.IDNumLabel.Name = "IDNumLabel";
            this.IDNumLabel.Size = new System.Drawing.Size(22, 13);
            this.IDNumLabel.TabIndex = 5;
            this.IDNumLabel.Text = "     ";
            // 
            // psWindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.IdentifyBtn);
            this.Controls.Add(this.VerifyBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EnrollBtn);
            this.Controls.Add(this.GuidanceLabel);
            this.Controls.Add(this.WorkMsgLabel);
            this.Controls.Add(this.ImagePic);
            this.Controls.Add(this.ModeLabel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "psWindowMain";
            this.Size = new System.Drawing.Size(1280, 558);
            this.Load += new System.EventHandler(this.psWindowMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label ModeLabel;
		private System.Windows.Forms.PictureBox ImagePic;
        private System.Windows.Forms.Label IDLabel;
		private System.Windows.Forms.Label WorkMsgLabel;
		private System.Windows.Forms.Label GuidanceLabel;
		private System.Windows.Forms.Button EnrollBtn;
		private System.Windows.Forms.Button DeleteBtn;
		private System.Windows.Forms.Button VerifyBtn;
		private System.Windows.Forms.Button IdentifyBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button EndBtn;
		private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.ListBox IDListBox;
        private System.Windows.Forms.TextBox IDNumTextBox;
        private System.Windows.Forms.Label IDNumLabel;
	}
}

