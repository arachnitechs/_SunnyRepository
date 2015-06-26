namespace IDScan
{
    partial class MrzCorrectionForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxOriginalMRZ = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCorrectedMRZ = new System.Windows.Forms.TextBox();
            this.labelOriginalMRZ = new System.Windows.Forms.Label();
            this.labelCorrectedMRZ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.Location = new System.Drawing.Point(12, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(528, 31);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "In order to read the Smartcard data from the document, the MRZ value needs to be " +
    "corrected.  Please enter or correct the MRZ value, select OK, and then reinsert " +
    "the document to process it again.";
            // 
            // textBoxOriginalMRZ
            // 
            this.textBoxOriginalMRZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOriginalMRZ.Location = new System.Drawing.Point(98, 43);
            this.textBoxOriginalMRZ.Name = "textBoxOriginalMRZ";
            this.textBoxOriginalMRZ.ReadOnly = true;
            this.textBoxOriginalMRZ.Size = new System.Drawing.Size(442, 20);
            this.textBoxOriginalMRZ.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(202, 95);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(283, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCorrectedMRZ
            // 
            this.textBoxCorrectedMRZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCorrectedMRZ.Location = new System.Drawing.Point(98, 69);
            this.textBoxCorrectedMRZ.Name = "textBoxCorrectedMRZ";
            this.textBoxCorrectedMRZ.Size = new System.Drawing.Size(442, 20);
            this.textBoxCorrectedMRZ.TabIndex = 4;
            // 
            // labelOriginalMRZ
            // 
            this.labelOriginalMRZ.AutoSize = true;
            this.labelOriginalMRZ.Location = new System.Drawing.Point(23, 46);
            this.labelOriginalMRZ.Name = "labelOriginalMRZ";
            this.labelOriginalMRZ.Size = new System.Drawing.Size(69, 13);
            this.labelOriginalMRZ.TabIndex = 5;
            this.labelOriginalMRZ.Text = "Original MRZ";
            // 
            // labelCorrectedMRZ
            // 
            this.labelCorrectedMRZ.AutoSize = true;
            this.labelCorrectedMRZ.Location = new System.Drawing.Point(12, 72);
            this.labelCorrectedMRZ.Name = "labelCorrectedMRZ";
            this.labelCorrectedMRZ.Size = new System.Drawing.Size(80, 13);
            this.labelCorrectedMRZ.TabIndex = 6;
            this.labelCorrectedMRZ.Text = "Corrected MRZ";
            // 
            // MrzCorrectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 127);
            this.Controls.Add(this.labelCorrectedMRZ);
            this.Controls.Add(this.labelOriginalMRZ);
            this.Controls.Add(this.textBoxCorrectedMRZ);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxOriginalMRZ);
            this.Controls.Add(this.labelMessage);
            this.Name = "MrzCorrectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MRZ Correction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxOriginalMRZ;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCorrectedMRZ;
        private System.Windows.Forms.Label labelOriginalMRZ;
        private System.Windows.Forms.Label labelCorrectedMRZ;
    }
}