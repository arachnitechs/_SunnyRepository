namespace IDScan
{
    partial class AboutForm
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelEngineVersion = new System.Windows.Forms.Label();
            this.labelLibraryVersion = new System.Windows.Forms.Label();
            this.labelLicense = new System.Windows.Forms.Label();
            this.labelTransactions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(244, 238);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(12, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(307, 34);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Sunny Inc";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(12, 47);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(260, 23);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Application Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEngineVersion
            // 
            this.labelEngineVersion.Location = new System.Drawing.Point(12, 70);
            this.labelEngineVersion.Name = "labelEngineVersion";
            this.labelEngineVersion.Size = new System.Drawing.Size(260, 23);
            this.labelEngineVersion.TabIndex = 3;
            this.labelEngineVersion.Text = "Version";
            this.labelEngineVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLibraryVersion
            // 
            this.labelLibraryVersion.Location = new System.Drawing.Point(12, 93);
            this.labelLibraryVersion.Name = "labelLibraryVersion";
            this.labelLibraryVersion.Size = new System.Drawing.Size(260, 23);
            this.labelLibraryVersion.TabIndex = 4;
            this.labelLibraryVersion.Text = "Library Version";
            this.labelLibraryVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLicense
            // 
            this.labelLicense.Location = new System.Drawing.Point(12, 116);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(260, 23);
            this.labelLicense.TabIndex = 5;
            this.labelLicense.Text = "License";
            this.labelLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTransactions
            // 
            this.labelTransactions.Location = new System.Drawing.Point(12, 139);
            this.labelTransactions.Name = "labelTransactions";
            this.labelTransactions.Size = new System.Drawing.Size(260, 23);
            this.labelTransactions.TabIndex = 6;
            this.labelTransactions.Text = "Transactions";
            this.labelTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(331, 273);
            this.Controls.Add(this.labelTransactions);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.labelLibraryVersion);
            this.Controls.Add(this.labelEngineVersion);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelEngineVersion;
        private System.Windows.Forms.Label labelLibraryVersion;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.Label labelTransactions;
    }
}