using IDScan.WizardLib;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using IDScan.Model;


namespace IDScan.AppForms
{
    public class SecondPage : ExteriorWizardPage
	{
    //    private System.Windows.Forms.Label label1;
    //    private System.Windows.Forms.Label label2;
    //    private System.Windows.Forms.RadioButton radioButton1;
    //    private System.Windows.Forms.RadioButton radioButton2;
    //    private System.ComponentModel.IContainer components = null;

    //    public SecondPage()
    //    {
    //        // This call is required by the Windows Form Designer.
    //        InitializeComponent();

    //        // TODO: Add any initialization after the InitializeComponent call
    //    }

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    protected override void Dispose( bool disposing )
    //    {
    //        if( disposing )
    //        {
    //            if (components != null) 
    //            {
    //                components.Dispose();
    //            }
    //        }
    //        base.Dispose( disposing );
    //    }

    //    #region Designer generated code
    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.radioButton1 = new System.Windows.Forms.RadioButton();
    //        this.radioButton2 = new System.Windows.Forms.RadioButton();
    //        ((System.ComponentModel.ISupportInitialize)(this.m_watermarkPicture)).BeginInit();
    //        this.SuspendLayout();
    //        // 
    //        // m_titleLabel
    //        // 
    //        this.m_titleLabel.Text = "First Interior Page";
    //        //this.m_titleLabel.Click += new System.EventHandler(this.m_titleLabel_Click);
    //        // 
    //        // label1
    //        // 
    //        this.label1.Location = new System.Drawing.Point(41, 73);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(412, 26);
    //        this.label1.TabIndex = 5;
    //        this.label1.Text = "This page inherits from InteriorWizardPage to demonstrate the Wizard 97 look && f" +
    //"eel for interior pages of such a wizard.";
    //        // 
    //        // label2
    //        // 
    //        this.label2.Location = new System.Drawing.Point(41, 110);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(412, 13);
    //        this.label2.TabIndex = 6;
    //        this.label2.Text = "Select which page you would like to go to next.";
    //        // 
    //        // radioButton1
    //        // 
    //        this.radioButton1.Checked = true;
    //        this.radioButton1.Location = new System.Drawing.Point(41, 134);
    //        this.radioButton1.Name = "radioButton1";
    //        this.radioButton1.Size = new System.Drawing.Size(152, 19);
    //        this.radioButton1.TabIndex = 7;
    //        this.radioButton1.TabStop = true;
    //        this.radioButton1.Text = "&Second Interior Page";
    //        // 
    //        // radioButton2
    //        // 
    //        this.radioButton2.Location = new System.Drawing.Point(41, 153);
    //        this.radioButton2.Name = "radioButton2";
    //        this.radioButton2.Size = new System.Drawing.Size(152, 19);
    //        this.radioButton2.TabIndex = 8;
    //        this.radioButton2.Text = "&Final Wizard Page";
    //        // 
    //        // SecondPage
    //        // 
    //        this.Name = "SecondPage";
    //        ((System.ComponentModel.ISupportInitialize)(this.m_watermarkPicture)).EndInit();
    //        this.ResumeLayout(false);

    //    }
    //    #endregion

    //    protected override bool OnSetActive()
    //    {
    //        if( !base.OnSetActive() )
    //            return false;
            
    //        // Enable both the Next and Back buttons on this page    
    //        //Wizard.SetWizardButtons( WizardButton.Back | WizardButton.Next );

    //        Wizard.SetWizardButtons(WizardButton.Back | WizardButton.Cancel);


    //        return true;
    //    }
 
    //    protected override string OnWizardNext()
    //    {
    //        return radioButton1.Checked ? "ThirdPage" : "FourthPage";
    //    }
    }
}

