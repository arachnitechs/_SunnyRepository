namespace IDScan
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSession = new System.Windows.Forms.ToolStripSeparator();
            this.autoTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.authenticationSensitivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactlessChipReadEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplexEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdkNETWinHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdkPDFProgrammersGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainWizTabControl = new System.Windows.Forms.TabControl();
            this.tabWizPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBiographic = new System.Windows.Forms.TabPage();
            this.textBoxDocumentNumber = new System.Windows.Forms.TextBox();
            this.textBoxIssueDate = new System.Windows.Forms.TextBox();
            this.textBoxExpirationDate = new System.Windows.Forms.TextBox();
            this.textBoxBirthDate = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxGender = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDocumentNumber = new System.Windows.Forms.Label();
            this.labelIssueDate = new System.Windows.Forms.Label();
            this.labelExpirationDate = new System.Windows.Forms.Label();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.tabPageRegions = new System.Windows.Forms.TabPage();
            this.treeViewRegions = new System.Windows.Forms.TreeView();
            this.tabPageFields = new System.Windows.Forms.TabPage();
            this.dataGridViewField = new System.Windows.Forms.DataGridView();
            this.fieldColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldColumnDataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAlerts = new System.Windows.Forms.TabPage();
            this.listViewAlerts = new System.Windows.Forms.ListView();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.listViewProperties = new System.Windows.Forms.ListView();
            this.propertyColumnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSQLData = new System.Windows.Forms.TabPage();
            this.lblZip = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.textDOB = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtMiddle = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblMiddle = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelLevelCaption = new System.Windows.Forms.Label();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.labelResultCaption = new System.Windows.Forms.Label();
            this.labelIssuerCaption = new System.Windows.Forms.Label();
            this.textBoxIssuer = new System.Windows.Forms.TextBox();
            this.textBoxIssue = new System.Windows.Forms.TextBox();
            this.groupBoxRegion = new System.Windows.Forms.GroupBox();
            this.pictureBoxRegion = new System.Windows.Forms.PictureBox();
            this.textBoxRegionText = new System.Windows.Forms.TextBox();
            this.labelIssueCaption = new System.Windows.Forms.Label();
            this.textBoxDocumentType = new System.Windows.Forms.TextBox();
            this.labelTypeCaption = new System.Windows.Forms.Label();
            this.tabControlImages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabWizPage2 = new System.Windows.Forms.TabPage();
            this.tabWizPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList48 = new System.Windows.Forms.ImageList(this.components);
            this.alertColumnResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertColumnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propertyColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.MainWizTabControl.SuspendLayout();
            this.tabWizPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageBiographic.SuspendLayout();
            this.tabPageRegions.SuspendLayout();
            this.tabPageFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewField)).BeginInit();
            this.tabPageAlerts.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.tabSQLData.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.groupBoxRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegion)).BeginInit();
            this.tabControlImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 868);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1053, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1053, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSampleToolStripMenuItem,
            this.triggerSampleToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveSampleToolStripMenuItem
            // 
            this.saveSampleToolStripMenuItem.Enabled = false;
            this.saveSampleToolStripMenuItem.Name = "saveSampleToolStripMenuItem";
            this.saveSampleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveSampleToolStripMenuItem.Text = "Save &Sample";
            this.saveSampleToolStripMenuItem.Click += new System.EventHandler(this.saveSampleToolStripMenuItem_Click);
            // 
            // triggerSampleToolStripMenuItem
            // 
            this.triggerSampleToolStripMenuItem.Enabled = false;
            this.triggerSampleToolStripMenuItem.Name = "triggerSampleToolStripMenuItem";
            this.triggerSampleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.triggerSampleToolStripMenuItem.Text = "&Trigger Sample...";
            this.triggerSampleToolStripMenuItem.Click += new System.EventHandler(this.triggerSampleToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartServiceToolStripMenuItem,
            this.stopServiceToolStripMenuItem,
            this.toolStripSeparatorSession,
            this.autoTriggerToolStripMenuItem,
            this.manualTriggerToolStripMenuItem,
            this.toolStripSeparator2,
            this.authenticationSensitivityToolStripMenuItem,
            this.contactlessChipReadEnabledToolStripMenuItem,
            this.duplexEnabledToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // restartServiceToolStripMenuItem
            // 
            this.restartServiceToolStripMenuItem.Name = "restartServiceToolStripMenuItem";
            this.restartServiceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.restartServiceToolStripMenuItem.Text = "&Restart Service";
            this.restartServiceToolStripMenuItem.Click += new System.EventHandler(this.restartServiceToolStripMenuItem_Click);
            // 
            // stopServiceToolStripMenuItem
            // 
            this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
            this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.stopServiceToolStripMenuItem.Text = "&Stop Service";
            this.stopServiceToolStripMenuItem.Click += new System.EventHandler(this.stopServiceToolStripMenuItem_Click);
            // 
            // toolStripSeparatorSession
            // 
            this.toolStripSeparatorSession.Name = "toolStripSeparatorSession";
            this.toolStripSeparatorSession.Size = new System.Drawing.Size(234, 6);
            // 
            // autoTriggerToolStripMenuItem
            // 
            this.autoTriggerToolStripMenuItem.Checked = true;
            this.autoTriggerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoTriggerToolStripMenuItem.Name = "autoTriggerToolStripMenuItem";
            this.autoTriggerToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.autoTriggerToolStripMenuItem.Text = "&Auto Trigger";
            this.autoTriggerToolStripMenuItem.Click += new System.EventHandler(this.autoTriggerToolStripMenuItem_Click);
            // 
            // manualTriggerToolStripMenuItem
            // 
            this.manualTriggerToolStripMenuItem.Name = "manualTriggerToolStripMenuItem";
            this.manualTriggerToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.manualTriggerToolStripMenuItem.Text = "&Manual Trigger";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(234, 6);
            // 
            // authenticationSensitivityToolStripMenuItem
            // 
            this.authenticationSensitivityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.lowToolStripMenuItem});
            this.authenticationSensitivityToolStripMenuItem.Name = "authenticationSensitivityToolStripMenuItem";
            this.authenticationSensitivityToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.authenticationSensitivityToolStripMenuItem.Text = "Authentication Sensitivity";
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.highToolStripMenuItem.Text = "High";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Checked = true;
            this.normalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.authenticationSensitivityToolStripMenuItem_Click);
            // 
            // lowToolStripMenuItem
            // 
            this.lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            this.lowToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.lowToolStripMenuItem.Text = "Low";
            // 
            // contactlessChipReadEnabledToolStripMenuItem
            // 
            this.contactlessChipReadEnabledToolStripMenuItem.Checked = true;
            this.contactlessChipReadEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contactlessChipReadEnabledToolStripMenuItem.Name = "contactlessChipReadEnabledToolStripMenuItem";
            this.contactlessChipReadEnabledToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.contactlessChipReadEnabledToolStripMenuItem.Text = "Contactless Chip Read Enabled";
            this.contactlessChipReadEnabledToolStripMenuItem.Click += new System.EventHandler(this.contactlessChipReadEnabledToolStripMenuItem_Click);
            // 
            // duplexEnabledToolStripMenuItem
            // 
            this.duplexEnabledToolStripMenuItem.Name = "duplexEnabledToolStripMenuItem";
            this.duplexEnabledToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.duplexEnabledToolStripMenuItem.Text = "Duplex Enabled";
            this.duplexEnabledToolStripMenuItem.Click += new System.EventHandler(this.duplexEnabledToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdkNETWinHelpToolStripMenuItem,
            this.sdkPDFProgrammersGuideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // sdkNETWinHelpToolStripMenuItem
            // 
            this.sdkNETWinHelpToolStripMenuItem.Name = "sdkNETWinHelpToolStripMenuItem";
            this.sdkNETWinHelpToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sdkNETWinHelpToolStripMenuItem.Text = "SDK .NET Win Help";
            this.sdkNETWinHelpToolStripMenuItem.Click += new System.EventHandler(this.sdkNETWinHelpToolStripMenuItem_Click);
            // 
            // sdkPDFProgrammersGuideToolStripMenuItem
            // 
            this.sdkPDFProgrammersGuideToolStripMenuItem.Name = "sdkPDFProgrammersGuideToolStripMenuItem";
            this.sdkPDFProgrammersGuideToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sdkPDFProgrammersGuideToolStripMenuItem.Text = "SDK PDF Programmers\' Guide";
            this.sdkPDFProgrammersGuideToolStripMenuItem.Click += new System.EventHandler(this.sdkPDFProgrammersGuideToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainWizTabControl
            // 
            this.MainWizTabControl.Controls.Add(this.tabWizPage1);
            this.MainWizTabControl.Controls.Add(this.tabWizPage2);
            this.MainWizTabControl.Controls.Add(this.tabWizPage3);
            this.MainWizTabControl.Location = new System.Drawing.Point(12, 27);
            this.MainWizTabControl.Name = "MainWizTabControl";
            this.MainWizTabControl.SelectedIndex = 0;
            this.MainWizTabControl.Size = new System.Drawing.Size(1037, 658);
            this.MainWizTabControl.TabIndex = 16;
            // 
            // tabWizPage1
            // 
            this.tabWizPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabWizPage1.Location = new System.Drawing.Point(4, 22);
            this.tabWizPage1.Name = "tabWizPage1";
            this.tabWizPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabWizPage1.Size = new System.Drawing.Size(1029, 632);
            this.tabWizPage1.TabIndex = 0;
            this.tabWizPage1.Text = "tabWizPage1";
            this.tabWizPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.83193F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.16807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1023, 531);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBiographic);
            this.tabControl.Controls.Add(this.tabPageRegions);
            this.tabControl.Controls.Add(this.tabPageFields);
            this.tabControl.Controls.Add(this.tabPageAlerts);
            this.tabControl.Controls.Add(this.tabPageProperties);
            this.tabControl.Controls.Add(this.tabSQLData);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl.Location = new System.Drawing.Point(3, 308);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1007, 199);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageBiographic
            // 
            this.tabPageBiographic.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBiographic.Controls.Add(this.textBoxDocumentNumber);
            this.tabPageBiographic.Controls.Add(this.textBoxIssueDate);
            this.tabPageBiographic.Controls.Add(this.textBoxExpirationDate);
            this.tabPageBiographic.Controls.Add(this.textBoxBirthDate);
            this.tabPageBiographic.Controls.Add(this.textBoxAge);
            this.tabPageBiographic.Controls.Add(this.textBoxGender);
            this.tabPageBiographic.Controls.Add(this.textBoxName);
            this.tabPageBiographic.Controls.Add(this.labelDocumentNumber);
            this.tabPageBiographic.Controls.Add(this.labelIssueDate);
            this.tabPageBiographic.Controls.Add(this.labelExpirationDate);
            this.tabPageBiographic.Controls.Add(this.labelBirthDate);
            this.tabPageBiographic.Controls.Add(this.labelAge);
            this.tabPageBiographic.Controls.Add(this.labelGender);
            this.tabPageBiographic.Controls.Add(this.labelName);
            this.tabPageBiographic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBiographic.Name = "tabPageBiographic";
            this.tabPageBiographic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBiographic.Size = new System.Drawing.Size(999, 173);
            this.tabPageBiographic.TabIndex = 0;
            this.tabPageBiographic.Text = "Biographic";
            // 
            // textBoxDocumentNumber
            // 
            this.textBoxDocumentNumber.Location = new System.Drawing.Point(469, 84);
            this.textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            this.textBoxDocumentNumber.ReadOnly = true;
            this.textBoxDocumentNumber.Size = new System.Drawing.Size(295, 20);
            this.textBoxDocumentNumber.TabIndex = 13;
            // 
            // textBoxIssueDate
            // 
            this.textBoxIssueDate.Location = new System.Drawing.Point(469, 58);
            this.textBoxIssueDate.Name = "textBoxIssueDate";
            this.textBoxIssueDate.ReadOnly = true;
            this.textBoxIssueDate.Size = new System.Drawing.Size(295, 20);
            this.textBoxIssueDate.TabIndex = 12;
            // 
            // textBoxExpirationDate
            // 
            this.textBoxExpirationDate.Location = new System.Drawing.Point(469, 32);
            this.textBoxExpirationDate.Name = "textBoxExpirationDate";
            this.textBoxExpirationDate.ReadOnly = true;
            this.textBoxExpirationDate.Size = new System.Drawing.Size(295, 20);
            this.textBoxExpirationDate.TabIndex = 11;
            // 
            // textBoxBirthDate
            // 
            this.textBoxBirthDate.Location = new System.Drawing.Point(66, 84);
            this.textBoxBirthDate.Name = "textBoxBirthDate";
            this.textBoxBirthDate.ReadOnly = true;
            this.textBoxBirthDate.Size = new System.Drawing.Size(295, 20);
            this.textBoxBirthDate.TabIndex = 10;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(66, 58);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.ReadOnly = true;
            this.textBoxAge.Size = new System.Drawing.Size(295, 20);
            this.textBoxAge.TabIndex = 9;
            // 
            // textBoxGender
            // 
            this.textBoxGender.Location = new System.Drawing.Point(66, 32);
            this.textBoxGender.Name = "textBoxGender";
            this.textBoxGender.ReadOnly = true;
            this.textBoxGender.Size = new System.Drawing.Size(295, 20);
            this.textBoxGender.TabIndex = 8;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(66, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(698, 20);
            this.textBoxName.TabIndex = 7;
            // 
            // labelDocumentNumber
            // 
            this.labelDocumentNumber.AutoSize = true;
            this.labelDocumentNumber.Location = new System.Drawing.Point(367, 87);
            this.labelDocumentNumber.Name = "labelDocumentNumber";
            this.labelDocumentNumber.Size = new System.Drawing.Size(96, 13);
            this.labelDocumentNumber.TabIndex = 6;
            this.labelDocumentNumber.Text = "Document Number";
            // 
            // labelIssueDate
            // 
            this.labelIssueDate.AutoSize = true;
            this.labelIssueDate.Location = new System.Drawing.Point(405, 61);
            this.labelIssueDate.Name = "labelIssueDate";
            this.labelIssueDate.Size = new System.Drawing.Size(58, 13);
            this.labelIssueDate.TabIndex = 5;
            this.labelIssueDate.Text = "Issue Date";
            // 
            // labelExpirationDate
            // 
            this.labelExpirationDate.AutoSize = true;
            this.labelExpirationDate.Location = new System.Drawing.Point(384, 35);
            this.labelExpirationDate.Name = "labelExpirationDate";
            this.labelExpirationDate.Size = new System.Drawing.Size(79, 13);
            this.labelExpirationDate.TabIndex = 4;
            this.labelExpirationDate.Text = "Expiration Date";
            // 
            // labelBirthDate
            // 
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Location = new System.Drawing.Point(6, 87);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(54, 13);
            this.labelBirthDate.TabIndex = 3;
            this.labelBirthDate.Text = "Birth Date";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(34, 61);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(26, 13);
            this.labelAge.TabIndex = 2;
            this.labelAge.Text = "Age";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(18, 35);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(42, 13);
            this.labelGender.TabIndex = 1;
            this.labelGender.Text = "Gender";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(25, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // tabPageRegions
            // 
            this.tabPageRegions.Controls.Add(this.treeViewRegions);
            this.tabPageRegions.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegions.Name = "tabPageRegions";
            this.tabPageRegions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegions.Size = new System.Drawing.Size(999, 173);
            this.tabPageRegions.TabIndex = 2;
            this.tabPageRegions.Text = "Regions";
            this.tabPageRegions.UseVisualStyleBackColor = true;
            // 
            // treeViewRegions
            // 
            this.treeViewRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRegions.Location = new System.Drawing.Point(3, 3);
            this.treeViewRegions.Name = "treeViewRegions";
            this.treeViewRegions.Size = new System.Drawing.Size(993, 167);
            this.treeViewRegions.TabIndex = 0;
            // 
            // tabPageFields
            // 
            this.tabPageFields.Controls.Add(this.dataGridViewField);
            this.tabPageFields.Location = new System.Drawing.Point(4, 22);
            this.tabPageFields.Name = "tabPageFields";
            this.tabPageFields.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFields.Size = new System.Drawing.Size(999, 173);
            this.tabPageFields.TabIndex = 1;
            this.tabPageFields.Text = "Fields";
            this.tabPageFields.UseVisualStyleBackColor = true;
            // 
            // dataGridViewField
            // 
            this.dataGridViewField.AllowUserToAddRows = false;
            this.dataGridViewField.AllowUserToDeleteRows = false;
            this.dataGridViewField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldColumnName,
            this.fieldColumnValue,
            this.fieldColumnDescription,
            this.fieldColumnDataSource});
            this.dataGridViewField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewField.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewField.MultiSelect = false;
            this.dataGridViewField.Name = "dataGridViewField";
            this.dataGridViewField.ReadOnly = true;
            this.dataGridViewField.RowHeadersVisible = false;
            this.dataGridViewField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewField.Size = new System.Drawing.Size(993, 167);
            this.dataGridViewField.StandardTab = true;
            this.dataGridViewField.TabIndex = 0;
            // 
            // fieldColumnName
            // 
            this.fieldColumnName.HeaderText = "Name";
            this.fieldColumnName.Name = "fieldColumnName";
            this.fieldColumnName.ReadOnly = true;
            this.fieldColumnName.Width = 150;
            // 
            // fieldColumnValue
            // 
            this.fieldColumnValue.HeaderText = "Value";
            this.fieldColumnValue.Name = "fieldColumnValue";
            this.fieldColumnValue.ReadOnly = true;
            this.fieldColumnValue.Width = 250;
            // 
            // fieldColumnDescription
            // 
            this.fieldColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fieldColumnDescription.HeaderText = "Description";
            this.fieldColumnDescription.Name = "fieldColumnDescription";
            this.fieldColumnDescription.ReadOnly = true;
            // 
            // fieldColumnDataSource
            // 
            this.fieldColumnDataSource.HeaderText = "Source";
            this.fieldColumnDataSource.Name = "fieldColumnDataSource";
            this.fieldColumnDataSource.ReadOnly = true;
            // 
            // tabPageAlerts
            // 
            this.tabPageAlerts.Controls.Add(this.listViewAlerts);
            this.tabPageAlerts.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlerts.Name = "tabPageAlerts";
            this.tabPageAlerts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlerts.Size = new System.Drawing.Size(999, 173);
            this.tabPageAlerts.TabIndex = 3;
            this.tabPageAlerts.Text = "Alerts";
            this.tabPageAlerts.UseVisualStyleBackColor = true;
            // 
            // listViewAlerts
            // 
            this.listViewAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAlerts.FullRowSelect = true;
            this.listViewAlerts.Location = new System.Drawing.Point(3, 3);
            this.listViewAlerts.MultiSelect = false;
            this.listViewAlerts.Name = "listViewAlerts";
            this.listViewAlerts.Size = new System.Drawing.Size(993, 167);
            this.listViewAlerts.SmallImageList = this.imageList16;
            this.listViewAlerts.TabIndex = 0;
            this.listViewAlerts.UseCompatibleStateImageBehavior = false;
            this.listViewAlerts.View = System.Windows.Forms.View.Details;
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "Unknown");
            this.imageList16.Images.SetKeyName(1, "Failed");
            this.imageList16.Images.SetKeyName(2, "Caution");
            this.imageList16.Images.SetKeyName(3, "Attention");
            this.imageList16.Images.SetKeyName(4, "Passed");
            this.imageList16.Images.SetKeyName(5, "Skipped");
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.listViewProperties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(999, 173);
            this.tabPageProperties.TabIndex = 4;
            this.tabPageProperties.Text = "Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // listViewProperties
            // 
            this.listViewProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertyColumnValue});
            this.listViewProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProperties.FullRowSelect = true;
            this.listViewProperties.Location = new System.Drawing.Point(3, 3);
            this.listViewProperties.MultiSelect = false;
            this.listViewProperties.Name = "listViewProperties";
            this.listViewProperties.Size = new System.Drawing.Size(993, 167);
            this.listViewProperties.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewProperties.TabIndex = 0;
            this.listViewProperties.UseCompatibleStateImageBehavior = false;
            this.listViewProperties.View = System.Windows.Forms.View.Details;
            // 
            // propertyColumnValue
            // 
            this.propertyColumnValue.Text = "Value";
            this.propertyColumnValue.Width = 500;
            // 
            // tabSQLData
            // 
            this.tabSQLData.Controls.Add(this.lblZip);
            this.tabSQLData.Controls.Add(this.lblState);
            this.tabSQLData.Controls.Add(this.lblCity);
            this.tabSQLData.Controls.Add(this.txtZip);
            this.tabSQLData.Controls.Add(this.txtState);
            this.tabSQLData.Controls.Add(this.txtCity);
            this.tabSQLData.Controls.Add(this.txtAddress);
            this.tabSQLData.Controls.Add(this.textDOB);
            this.tabSQLData.Controls.Add(this.textBox3);
            this.tabSQLData.Controls.Add(this.txtLast);
            this.tabSQLData.Controls.Add(this.txtMiddle);
            this.tabSQLData.Controls.Add(this.txtFirst);
            this.tabSQLData.Controls.Add(this.lblMiddle);
            this.tabSQLData.Controls.Add(this.lblFirst);
            this.tabSQLData.Controls.Add(this.lblAddress);
            this.tabSQLData.Controls.Add(this.lblDOB);
            this.tabSQLData.Controls.Add(this.label4);
            this.tabSQLData.Controls.Add(this.lblLast);
            this.tabSQLData.Location = new System.Drawing.Point(4, 22);
            this.tabSQLData.Name = "tabSQLData";
            this.tabSQLData.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQLData.Size = new System.Drawing.Size(999, 173);
            this.tabSQLData.TabIndex = 5;
            this.tabSQLData.Text = "SQLData";
            this.tabSQLData.UseVisualStyleBackColor = true;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(534, 72);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(22, 13);
            this.lblZip.TabIndex = 17;
            this.lblZip.Text = "Zip";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(401, 72);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 16;
            this.lblState.Text = "State";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(270, 72);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 15;
            this.lblCity.Text = "City";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(534, 85);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(100, 20);
            this.txtZip.TabIndex = 14;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(399, 85);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(100, 20);
            this.txtState.TabIndex = 13;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(267, 85);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 12;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(25, 86);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(221, 20);
            this.txtAddress.TabIndex = 10;
            // 
            // textDOB
            // 
            this.textDOB.Location = new System.Drawing.Point(399, 37);
            this.textDOB.Name = "textDOB";
            this.textDOB.Size = new System.Drawing.Size(110, 20);
            this.textDOB.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(682, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(267, 37);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(100, 20);
            this.txtLast.TabIndex = 5;
            // 
            // txtMiddle
            // 
            this.txtMiddle.Location = new System.Drawing.Point(146, 37);
            this.txtMiddle.Name = "txtMiddle";
            this.txtMiddle.Size = new System.Drawing.Size(100, 20);
            this.txtMiddle.TabIndex = 3;
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(25, 37);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(100, 20);
            this.txtFirst.TabIndex = 1;
            // 
            // lblMiddle
            // 
            this.lblMiddle.AutoSize = true;
            this.lblMiddle.Location = new System.Drawing.Point(149, 20);
            this.lblMiddle.Name = "lblMiddle";
            this.lblMiddle.Size = new System.Drawing.Size(38, 13);
            this.lblMiddle.TabIndex = 2;
            this.lblMiddle.Text = "Middle";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(28, 20);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(26, 13);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Text = "First";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(28, 72);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Address";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(396, 19);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(66, 13);
            this.lblDOB.TabIndex = 9;
            this.lblDOB.Text = "Date of Birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "lblFirst";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(270, 20);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(27, 13);
            this.lblLast.TabIndex = 4;
            this.lblLast.Text = "Last";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panelInfo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControlImages, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1047, 299);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.labelLevelCaption);
            this.panelInfo.Controls.Add(this.textBoxClass);
            this.panelInfo.Controls.Add(this.pictureBoxResult);
            this.panelInfo.Controls.Add(this.labelResultCaption);
            this.panelInfo.Controls.Add(this.labelIssuerCaption);
            this.panelInfo.Controls.Add(this.textBoxIssuer);
            this.panelInfo.Controls.Add(this.textBoxIssue);
            this.panelInfo.Controls.Add(this.groupBoxRegion);
            this.panelInfo.Controls.Add(this.labelIssueCaption);
            this.panelInfo.Controls.Add(this.textBoxDocumentType);
            this.panelInfo.Controls.Add(this.labelTypeCaption);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(526, 3);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(518, 345);
            this.panelInfo.TabIndex = 0;
            // 
            // labelLevelCaption
            // 
            this.labelLevelCaption.AutoSize = true;
            this.labelLevelCaption.Location = new System.Drawing.Point(237, 64);
            this.labelLevelCaption.Name = "labelLevelCaption";
            this.labelLevelCaption.Size = new System.Drawing.Size(32, 13);
            this.labelLevelCaption.TabIndex = 12;
            this.labelLevelCaption.Text = "Class";
            // 
            // textBoxClass
            // 
            this.textBoxClass.Location = new System.Drawing.Point(276, 61);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.ReadOnly = true;
            this.textBoxClass.Size = new System.Drawing.Size(100, 20);
            this.textBoxClass.TabIndex = 9;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(92, 87);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxResult.TabIndex = 8;
            this.pictureBoxResult.TabStop = false;
            // 
            // labelResultCaption
            // 
            this.labelResultCaption.AutoSize = true;
            this.labelResultCaption.Location = new System.Drawing.Point(49, 106);
            this.labelResultCaption.Name = "labelResultCaption";
            this.labelResultCaption.Size = new System.Drawing.Size(37, 13);
            this.labelResultCaption.TabIndex = 7;
            this.labelResultCaption.Text = "Result";
            // 
            // labelIssuerCaption
            // 
            this.labelIssuerCaption.AutoSize = true;
            this.labelIssuerCaption.Location = new System.Drawing.Point(51, 38);
            this.labelIssuerCaption.Name = "labelIssuerCaption";
            this.labelIssuerCaption.Size = new System.Drawing.Size(35, 13);
            this.labelIssuerCaption.TabIndex = 6;
            this.labelIssuerCaption.Text = "Issuer";
            // 
            // textBoxIssuer
            // 
            this.textBoxIssuer.Location = new System.Drawing.Point(92, 35);
            this.textBoxIssuer.Name = "textBoxIssuer";
            this.textBoxIssuer.ReadOnly = true;
            this.textBoxIssuer.Size = new System.Drawing.Size(284, 20);
            this.textBoxIssuer.TabIndex = 5;
            // 
            // textBoxIssue
            // 
            this.textBoxIssue.Location = new System.Drawing.Point(92, 61);
            this.textBoxIssue.Name = "textBoxIssue";
            this.textBoxIssue.ReadOnly = true;
            this.textBoxIssue.Size = new System.Drawing.Size(100, 20);
            this.textBoxIssue.TabIndex = 4;
            // 
            // groupBoxRegion
            // 
            this.groupBoxRegion.Controls.Add(this.pictureBoxRegion);
            this.groupBoxRegion.Controls.Add(this.textBoxRegionText);
            this.groupBoxRegion.Location = new System.Drawing.Point(6, 141);
            this.groupBoxRegion.Name = "groupBoxRegion";
            this.groupBoxRegion.Size = new System.Drawing.Size(374, 153);
            this.groupBoxRegion.TabIndex = 3;
            this.groupBoxRegion.TabStop = false;
            this.groupBoxRegion.Text = "Region";
            // 
            // pictureBoxRegion
            // 
            this.pictureBoxRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRegion.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxRegion.Name = "pictureBoxRegion";
            this.pictureBoxRegion.Size = new System.Drawing.Size(362, 102);
            this.pictureBoxRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRegion.TabIndex = 1;
            this.pictureBoxRegion.TabStop = false;
            // 
            // textBoxRegionText
            // 
            this.textBoxRegionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegionText.Location = new System.Drawing.Point(6, 127);
            this.textBoxRegionText.Name = "textBoxRegionText";
            this.textBoxRegionText.ReadOnly = true;
            this.textBoxRegionText.Size = new System.Drawing.Size(362, 20);
            this.textBoxRegionText.TabIndex = 0;
            // 
            // labelIssueCaption
            // 
            this.labelIssueCaption.AutoSize = true;
            this.labelIssueCaption.Location = new System.Drawing.Point(54, 64);
            this.labelIssueCaption.Name = "labelIssueCaption";
            this.labelIssueCaption.Size = new System.Drawing.Size(32, 13);
            this.labelIssueCaption.TabIndex = 2;
            this.labelIssueCaption.Text = "Issue";
            // 
            // textBoxDocumentType
            // 
            this.textBoxDocumentType.Location = new System.Drawing.Point(92, 9);
            this.textBoxDocumentType.Name = "textBoxDocumentType";
            this.textBoxDocumentType.ReadOnly = true;
            this.textBoxDocumentType.Size = new System.Drawing.Size(284, 20);
            this.textBoxDocumentType.TabIndex = 1;
            // 
            // labelTypeCaption
            // 
            this.labelTypeCaption.AutoSize = true;
            this.labelTypeCaption.Location = new System.Drawing.Point(3, 12);
            this.labelTypeCaption.Name = "labelTypeCaption";
            this.labelTypeCaption.Size = new System.Drawing.Size(83, 13);
            this.labelTypeCaption.TabIndex = 0;
            this.labelTypeCaption.Text = "Document Type";
            // 
            // tabControlImages
            // 
            this.tabControlImages.Controls.Add(this.tabPage1);
            this.tabControlImages.Controls.Add(this.tabPage2);
            this.tabControlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlImages.Location = new System.Drawing.Point(3, 3);
            this.tabControlImages.Name = "tabControlImages";
            this.tabControlImages.SelectedIndex = 0;
            this.tabControlImages.Size = new System.Drawing.Size(517, 345);
            this.tabControlImages.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabWizPage2
            // 
            this.tabWizPage2.Location = new System.Drawing.Point(4, 22);
            this.tabWizPage2.Name = "tabWizPage2";
            this.tabWizPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabWizPage2.Size = new System.Drawing.Size(1029, 632);
            this.tabWizPage2.TabIndex = 1;
            this.tabWizPage2.Text = "tabWizPage2";
            this.tabWizPage2.UseVisualStyleBackColor = true;
            // 
            // tabWizPage3
            // 
            this.tabWizPage3.Location = new System.Drawing.Point(4, 22);
            this.tabWizPage3.Name = "tabWizPage3";
            this.tabWizPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabWizPage3.Size = new System.Drawing.Size(1029, 632);
            this.tabWizPage3.TabIndex = 2;
            this.tabWizPage3.Text = "tabWizPage3";
            this.tabWizPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn3.HeaderText = "Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // imageList48
            // 
            this.imageList48.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList48.ImageStream")));
            this.imageList48.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList48.Images.SetKeyName(0, "Unknown");
            this.imageList48.Images.SetKeyName(1, "Failed");
            this.imageList48.Images.SetKeyName(2, "Caution");
            this.imageList48.Images.SetKeyName(3, "Attention");
            this.imageList48.Images.SetKeyName(4, "Passed");
            this.imageList48.Images.SetKeyName(5, "Skipped");
            // 
            // alertColumnResult
            // 
            this.alertColumnResult.Text = "Result";
            // 
            // alertColumnDescription
            // 
            this.alertColumnDescription.Text = "Description";
            this.alertColumnDescription.Width = 500;
            // 
            // alertColumnName
            // 
            this.alertColumnName.Text = "Name";
            this.alertColumnName.Width = 150;
            // 
            // propertyColumnName
            // 
            this.propertyColumnName.Text = "Name";
            this.propertyColumnName.Width = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 890);
            this.Controls.Add(this.MainWizTabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Sunny Inc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.MainWizTabControl.ResumeLayout(false);
            this.tabWizPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageBiographic.ResumeLayout(false);
            this.tabPageBiographic.PerformLayout();
            this.tabPageRegions.ResumeLayout(false);
            this.tabPageFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewField)).EndInit();
            this.tabPageAlerts.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabSQLData.ResumeLayout(false);
            this.tabSQLData.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.groupBoxRegion.ResumeLayout(false);
            this.groupBoxRegion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegion)).EndInit();
            this.tabControlImages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TabControl MainWizTabControl;
        private System.Windows.Forms.TabPage tabWizPage1;
        private System.Windows.Forms.TabPage tabWizPage2;
        private System.Windows.Forms.TabPage tabWizPage3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triggerSampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSession;
        private System.Windows.Forms.ToolStripMenuItem autoTriggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTriggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem authenticationSensitivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactlessChipReadEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplexEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdkNETWinHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdkPDFProgrammersGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBiographic;
        private System.Windows.Forms.TextBox textBoxDocumentNumber;
        private System.Windows.Forms.TextBox textBoxIssueDate;
        private System.Windows.Forms.TextBox textBoxExpirationDate;
        private System.Windows.Forms.TextBox textBoxBirthDate;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxGender;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelDocumentNumber;
        private System.Windows.Forms.Label labelIssueDate;
        private System.Windows.Forms.Label labelExpirationDate;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TabPage tabPageRegions;
        private System.Windows.Forms.TreeView treeViewRegions;
        private System.Windows.Forms.TabPage tabPageFields;
        private System.Windows.Forms.DataGridView dataGridViewField;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldColumnDataSource;
        private System.Windows.Forms.TabPage tabPageAlerts;
        private System.Windows.Forms.ListView listViewAlerts;
        private System.Windows.Forms.ImageList imageList16;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.ListView listViewProperties;
        private System.Windows.Forms.ColumnHeader propertyColumnValue;
        private System.Windows.Forms.TabPage tabSQLData;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox textDOB;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtMiddle;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblMiddle;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelLevelCaption;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label labelResultCaption;
        private System.Windows.Forms.Label labelIssuerCaption;
        private System.Windows.Forms.TextBox textBoxIssuer;
        private System.Windows.Forms.TextBox textBoxIssue;
        private System.Windows.Forms.GroupBox groupBoxRegion;
        private System.Windows.Forms.PictureBox pictureBoxRegion;
        private System.Windows.Forms.TextBox textBoxRegionText;
        private System.Windows.Forms.Label labelIssueCaption;
        private System.Windows.Forms.TextBox textBoxDocumentType;
        private System.Windows.Forms.Label labelTypeCaption;
        private System.Windows.Forms.TabControl tabControlImages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ImageList imageList48;
        private System.Windows.Forms.ColumnHeader alertColumnResult;
        private System.Windows.Forms.ColumnHeader alertColumnDescription;
        private System.Windows.Forms.ColumnHeader alertColumnName;
        private System.Windows.Forms.ColumnHeader propertyColumnName;
    }
}

