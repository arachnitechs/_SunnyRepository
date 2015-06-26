


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using AssureTec.AssureID.SDK;
using AssureTec.AssureID.SDK.Events;
using AssureTec.AssureID.SDK.TransactionDocument;

using IDScan.WizardLib;
using IDScan.Data.DAL;


namespace IDScan.AppForms
{
    public class AssureTech : ExteriorWizardPage
    {


        #region private objects
        /// <summary>
        /// Form displayed to user when AssureID Engine requests document flip.
        /// See Session_DocumentFlip for additional details.
        /// </summary>
        //private DocumentFlipForm m_DocumentFlipForm = null;

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl;
        private TabPage tabPageBiographic;
        private TextBox textBoxDocumentNumber;
        private TextBox textBoxIssueDate;
        private TextBox textBoxExpirationDate;
        private TextBox textBoxBirthDate;
        private TextBox textBoxAge;
        private TextBox textBoxGender;
        private TextBox textBoxName;
        private Label labelDocumentNumber;
        private Label labelIssueDate;
        private Label labelExpirationDate;
        private Label labelBirthDate;
        private Label labelAge;
        private Label labelGender;
        private Label labelName;
        private TabPage tabPageRegions;
        private TreeView treeViewRegions;
        private TabPage tabPageFields;
        private DataGridView dataGridViewField;
        private DataGridViewTextBoxColumn fieldColumnName;
        private DataGridViewTextBoxColumn fieldColumnValue;
        private DataGridViewTextBoxColumn fieldColumnDescription;
        private DataGridViewTextBoxColumn fieldColumnDataSource;
        private TabPage tabPageAlerts;
        private ListView listViewAlerts;
        private TabPage tabPageProperties;
        private ListView listViewProperties;
        private ColumnHeader propertyColumnValue;
        private TabPage tabSQLData;
        private Label lblZip;
        private Label lblState;
        private Label lblCity;
        private TextBox txtZip;
        private TextBox txtState;
        private TextBox txtCity;
        private TextBox textDOB;
        private TextBox textBox3;
        private TextBox txtLast;
        private TextBox txtMiddle;
        private TextBox txtFirst;
        private Label lblMiddle;
        private Label lblFirst;
        private Label lblDOB;
        private Label label4;
        private Label lblLast;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panelInfo;
        private Label labelLevelCaption;
        private TextBox textBoxClass;
        private PictureBox pictureBoxResult;
        private Label labelResultCaption;
        private Label labelIssuerCaption;
        private TextBox textBoxIssuer;
        private TextBox textBoxIssue;
        private GroupBox groupBoxRegion;
        private PictureBox pictureBoxRegion;
        private TextBox textBoxRegionText;
        private Label labelIssueCaption;
        private TextBox textBoxDocumentType;
        private Label labelTypeCaption;
        private TabControl tabControlImages;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private StatusStrip statusStrip;
        private ImageList imageList16;
        private ImageList imageList48;


        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveSampleToolStripMenuItem;
        private ToolStripMenuItem triggerSampleToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem sessionToolStripMenuItem;
        private ToolStripMenuItem restartServiceToolStripMenuItem;
        private ToolStripMenuItem stopServiceToolStripMenuItem;
        private ToolStripSeparator toolStripSeparatorSession;


        private ToolStripMenuItem autoTriggerToolStripMenuItem;
        private ToolStripMenuItem manualTriggerToolStripMenuItem;


        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem authenticationSensitivityToolStripMenuItem;
        private ToolStripMenuItem highToolStripMenuItem;
        private ToolStripMenuItem normalToolStripMenuItem;
        private ToolStripMenuItem lowToolStripMenuItem;
        private ToolStripMenuItem contactlessChipReadEnabledToolStripMenuItem;
        private ToolStripMenuItem duplexEnabledToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem sdkNETWinHelpToolStripMenuItem;
        private ToolStripMenuItem sdkPDFProgrammersGuideToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MenuStrip menuStrip;

        #endregion

        //SessionData

        //private ToolStripStatusLabel toolStripStatusLabel;
		private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Form displayed to user when AssureID Engine requests document flip.
        /// See Session_DocumentFlip for additional details.
        /// </summary>
        //private DocumentFlipForm m_DocumentFlipForm = null;



        //scandata scanData = new scandata();
        //membership memberShip = new membership();

        /// <summary>
        /// The instance of the AssureTec AssureID SDK Session.
        /// </summary>
        /// <remarks>
        /// The AssureID Session instance could have been added and configured in the
        /// Visual Studio designer, but was done here instead so as to allow for
        /// instructive comments to be included.
        /// </remarks>
        private readonly AssureIDSession Session = new AssureIDSession();

        /// <summary>
        /// The "About" dialog for the application.
        /// </summary>
        private AboutForm m_AboutForm = null;

        /// <summary>
        /// Form displayed to user when AssureID Engine requests document flip.
        /// See Session_DocumentFlip for additional details.
        /// </summary>
        private DocumentFlipForm m_DocumentFlipForm = null;
        private TextBox txtAddress;
        private Label lblAddress;

        /// <summary>
        /// Form displayed to allow user to review and correct the document MRZ. This is used
        /// if the AssureID Engine cannot open the document's smart card using the MRZ value
        /// extracted from the document. If not OCR'd correctly, this can prevent the engine 
        /// from opening the smart card.
        /// </summary>
        private MrzCorrectionForm m_MrzCorrectionForm = null;

        
        public AssureTech()
		{
            InitializeComponent();

            //*************************************************************************
            //wd - Initialize this new seesion with our Guid
            //SessionData.sessionid = Guid.NewGuid();
            //SessionData.clubid = 1; // need to provide this from appsettings
            //*************************************************************************



            // Specify comparer to sort nodes in region TreeView.
            treeViewRegions.TreeViewNodeSorter = new TreeNodeComparer();

            // Instruct the Session to automatically dispose of resources (ie Bitmap objects).
            Session.AutoDispose = true;

            // Instruct the Session to automatically correct the orientation of images.
            // Note that AssureID can only do this once the document has been classified.
            // It is possible that the SDK will return images to this application (via the
            // ImageAdded event) before the document has been classified. As such, you need
            // to check each image returned to see if it has had its orientation corrected
            // in order to be able to correctly display it right-side-up. This application
            // will show you how to accomplish this.
            Session.OrientationCorrection = true;

            // Instruct the Session to dispatch SDK events on the UI thread. This allows us to make
            // and necessary user interface updates directly in the event handler.
            // Note that this property may ONLY be set before the AssureIDSession has been opened.
            Session.ThreadingModel = ThreadModel.SingleThreaded;

            // Register for the Session events required by your application. We've included
            // almost all available events for pedagogligical purposes. Many real-world
            // applications will not necessarily need to handle all of the available events.
            // See descriptions below for additional details, as well as the SDK documentation.
            Session.DocumentAlertAdded += new DocumentAlertEventHandler(Session_DocumentAlertAdded);
            Session.DocumentClassified += new DocumentEventHandler(Session_DocumentClassified);
            Session.DocumentComplete += new DocumentEventHandler(Session_DocumentComplete);
            Session.DocumentError += new DocumentEventHandler(Session_DocumentError);
            Session.DocumentFieldChanged += new DocumentFieldEventHandler(Session_DocumentFieldChanged);
            Session.DocumentFlip += new AssureIDSessionEventHandler(Session_DocumentFlip);
            Session.DocumentImageAdded += new DocumentImageEventHandler(Session_DocumentImageAdded);

            Session.DocumentNew += new DocumentEventHandler(Session_DocumentNew);

            Session.DocumentRegionAdded += new DocumentRegionEventHandler(Session_DocumentRegionAdded);
            Session.PlatformStatusChanged += new PlatformStatusEventHandler(Session_PlatformStatusChanged);
            Session.ReaderDocumentInserted += new AssureIDSessionEventHandler(Session_ReaderDocumentInserted);
            Session.ReaderDocumentMayBeRemoved += new AssureIDSessionEventHandler(Session_ReaderDocumentMayBeRemoved);
            Session.ReaderKeyRequest += new ReaderKeyRequestEventHandler(Session_ReaderKeyRequest);

            Session.ReaderStatusChanged += new ReaderStatusEventHandler(Session_ReaderStatusChanged);

            Session.TransactionComplete += new TransactionEventHandler(Session_TransactionComplete);
            Session.TransactionNew += new TransactionEventHandler(Session_TransactionNew);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>pictureboxregion
        /// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        /// 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssureTech));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBiographic = new System.Windows.Forms.TabPage();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
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
            this.textDOB = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtMiddle = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblMiddle = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.imageList48 = new System.Windows.Forms.ImageList(this.components);
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(173, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 577);
            this.panel1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(998, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.83193F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.16807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 572);
            this.tableLayoutPanel1.TabIndex = 4;
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
            this.tabControl.Location = new System.Drawing.Point(3, 333);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(995, 215);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageBiographic
            // 
            this.tabPageBiographic.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBiographic.Controls.Add(this.txtAddress);
            this.tabPageBiographic.Controls.Add(this.lblAddress);
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
            this.tabPageBiographic.Size = new System.Drawing.Size(987, 189);
            this.tabPageBiographic.TabIndex = 0;
            this.tabPageBiographic.Text = "Bio/Demographics";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(66, 130);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(698, 20);
            this.txtAddress.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(11, 134);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 15;
            this.lblAddress.Text = "Address";
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
            this.tabPageRegions.Size = new System.Drawing.Size(987, 189);
            this.tabPageRegions.TabIndex = 2;
            this.tabPageRegions.Text = "Regions";
            this.tabPageRegions.UseVisualStyleBackColor = true;
            // 
            // treeViewRegions
            // 
            this.treeViewRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRegions.Location = new System.Drawing.Point(3, 3);
            this.treeViewRegions.Name = "treeViewRegions";
            this.treeViewRegions.Size = new System.Drawing.Size(981, 183);
            this.treeViewRegions.TabIndex = 0;
            // 
            // tabPageFields
            // 
            this.tabPageFields.Controls.Add(this.dataGridViewField);
            this.tabPageFields.Location = new System.Drawing.Point(4, 22);
            this.tabPageFields.Name = "tabPageFields";
            this.tabPageFields.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFields.Size = new System.Drawing.Size(987, 189);
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
            this.dataGridViewField.Size = new System.Drawing.Size(981, 183);
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
            this.tabPageAlerts.Size = new System.Drawing.Size(987, 189);
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
            this.listViewAlerts.Size = new System.Drawing.Size(981, 183);
            this.listViewAlerts.TabIndex = 0;
            this.listViewAlerts.UseCompatibleStateImageBehavior = false;
            this.listViewAlerts.View = System.Windows.Forms.View.Details;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.listViewProperties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(987, 189);
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
            this.listViewProperties.Size = new System.Drawing.Size(981, 183);
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
            this.tabSQLData.Controls.Add(this.textDOB);
            this.tabSQLData.Controls.Add(this.textBox3);
            this.tabSQLData.Controls.Add(this.txtLast);
            this.tabSQLData.Controls.Add(this.txtMiddle);
            this.tabSQLData.Controls.Add(this.txtFirst);
            this.tabSQLData.Controls.Add(this.lblMiddle);
            this.tabSQLData.Controls.Add(this.lblFirst);
            this.tabSQLData.Controls.Add(this.lblDOB);
            this.tabSQLData.Controls.Add(this.label4);
            this.tabSQLData.Controls.Add(this.lblLast);
            this.tabSQLData.Location = new System.Drawing.Point(4, 22);
            this.tabSQLData.Name = "tabSQLData";
            this.tabSQLData.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQLData.Size = new System.Drawing.Size(987, 189);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1047, 324);
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
            this.panelInfo.Size = new System.Drawing.Size(518, 347);
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
            this.tabControlImages.Size = new System.Drawing.Size(517, 347);
            this.tabControlImages.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 654);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1280, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
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
            // 
            // triggerSampleToolStripMenuItem
            // 
            this.triggerSampleToolStripMenuItem.Enabled = false;
            this.triggerSampleToolStripMenuItem.Name = "triggerSampleToolStripMenuItem";
            this.triggerSampleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.triggerSampleToolStripMenuItem.Text = "&Trigger Sample...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
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
            // 
            // stopServiceToolStripMenuItem
            // 
            this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
            this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.stopServiceToolStripMenuItem.Text = "&Stop Service";
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
            // 
            // duplexEnabledToolStripMenuItem
            // 
            this.duplexEnabledToolStripMenuItem.Name = "duplexEnabledToolStripMenuItem";
            this.duplexEnabledToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.duplexEnabledToolStripMenuItem.Text = "Duplex Enabled";
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
            // 
            // sdkPDFProgrammersGuideToolStripMenuItem
            // 
            this.sdkPDFProgrammersGuideToolStripMenuItem.Name = "sdkPDFProgrammersGuideToolStripMenuItem";
            this.sdkPDFProgrammersGuideToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sdkPDFProgrammersGuideToolStripMenuItem.Text = "SDK PDF Programmers\' Guide";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // menuStrip
            // 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(12, 129);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(147, 24);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // AssureTech
            // 
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AssureTech";
            this.Size = new System.Drawing.Size(1280, 676);
            this.Load += new System.EventHandler(this.FirstPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

        protected override bool OnSetActive()
        {
            if (!base.OnSetActive())
                return false;

            //// Enable only the Cancel button on the this page until ID is validated    
            //Wizard.SetWizardButtons(WizardButton.Cancel);
            Wizard.SetWizardButtons( WizardButton.Next | WizardButton.Cancel);

            return true;
        }

        private class TreeNodeComparer : IComparer
        {
            #region IComparer Members

            public int Compare(object x, object y)
            {
                int compare = 0;
                if ((x is TreeNode) && (y is TreeNode))
                {
                    compare = String.Compare((x as TreeNode).Text, (y as TreeNode).Text);
                }
                return compare;
            }

            #endregion
        }

        /// <summary>
        /// Runs when the main form loads. Opens the AssureID session for use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void FirstPage_Load(object sender, EventArgs e)
        {
            ResetIDForm();

            // Need to open the AssureID session for use.
            Session.Open();
        }


        ///// <summary>
        ///// Runs when the main form is closing. Closes the AssureID session.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void FirstPage_Closing(object sender, FormClosingEventArgs e)
        {
            // Close the AssureID session when we're done.
            Session.Close();
        }


        private void ResetIDForm()
        {
            tabControlImages.TabPages.Clear();

            textBoxDocumentType.Text = String.Empty;
            textBoxIssuer.Text = String.Empty;
            textBoxIssue.Text = String.Empty;
            textBoxClass.Text = String.Empty;
            pictureBoxResult.Image = null;
            pictureBoxRegion.Image = null;
            textBoxRegionText.Text = String.Empty;
            toolStripStatusLabel.Text = String.Empty;

            treeViewRegions.Nodes.Clear();
            dataGridViewField.Rows.Clear();
            listViewAlerts.Items.Clear();
            listViewProperties.Items.Clear();
        }

        /// <summary>
        /// This handler is invoked each time an Alert (Document Authentication) is added to the
        /// document currently being processed. The callback tells you which alert/authentication
        /// is being added along with its result (passed, failed, etc).
        /// This example displays some of the DocumentAlert information in a ListView control.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentAlertAdded(DocumentAlertEventArgs e)
        {
            ListViewItem item = listViewAlerts.Items.Add(String.Empty, e.Alert.Result.ToString());
            item.SubItems.Add(e.Alert.DisplayName);
            item.SubItems.Add(e.Alert.Description);
        }

        /// <summary>
        /// This handler is invoked once the document has been successfully classified.
        /// Because we instructed the SDK to automatically correct image orientation
        /// (which can only happen once the current document has been classified), we need
        /// to adjust any images already returned by the SDK if they require it.
        /// The way to do this is to simply redraw the images from the current document.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentClassified(DocumentEventArgs e)
        {
            // Display some document type information in the user interface.
            textBoxDocumentType.Text = e.Document.DocumentInfo.DocumentType.ToString();
            textBoxIssuer.Text = e.Document.DocumentInfo.IssuerName;
            textBoxIssue.Text = e.Document.DocumentInfo.Issue;
            textBoxClass.Text = e.Document.DocumentInfo.ClassName;

            // Because we've set the AssureID session to automatically correct the orientation
            // and/or the presentation of captured images, and the engine can do so only once 
            // the document has been classified, we can now correct the orientation and/or presentation
            // of any images we may have drawn already (if necessary). We do this by reusing the 
            // DocumentImage that was stored when we got the original image. The SDK has, as instructed, 
            // already corrected the image orientation. We simply need to update the UI.
            if (e.Document.DocumentInfo.OrientationChanged || e.Document.DocumentInfo.PresentationChanged)
            {
                foreach (TabPage tab in tabControlImages.TabPages)
                {
                    PictureBox pictureBox = tab.Controls["image"] as PictureBox;
                    string id = pictureBox.Tag as string;
                    DocumentImage image = e.Document.Images.OfType<DocumentImage>().SingleOrDefault(i => i.Id == id);
                    if (image != null)
                    {
                        if (e.Document.DocumentInfo.OrientationChanged)
                        {
                            pictureBox.Image = image.Bitmap;  // reapply the saved/corrected image.
                        }

                        if (e.Document.DocumentInfo.PresentationChanged)
                        {
                            tab.Text = String.Format("{0}{1}", image.Lighting,
                                (image.Side == DocumentSide.Back) ? " (back)" : String.Empty);
                            if ((image.Lighting == "White") && (image.Side == DocumentSide.Front))
                            {
                                tabControlImages.SelectedTab = tab;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Handles the document complete event. Displays the overall document result.
        /// Once the document has been completely processed, any document properties become
        /// available. If there are any, they are displayed in the Properties list.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentComplete(DocumentEventArgs e)
        {
            if (m_DocumentFlipForm != null)
            {
                m_DocumentFlipForm.Hide();
            }

            switch (e.Document.DocumentInfo.CompletionStatus)
            {
                case DocumentCompletionStatus.Success:


                    string[] lookupFields = new string[]{
                        "Full Name",
                        "Surname",
                        "Given Name",
                        "Sex",
                        "Birth Date",
                        "Expiration Date",
                        "Issue Date", 
                        "Document Number"};
                    DocumentField[] df = e.Document.Fields.OfType<DocumentField>().ToArray();
                    bool hasFoundAny = false;

                    for (int outter = 0; outter < df.Count() && !hasFoundAny; outter++)
                        for (int inner = 0; inner < lookupFields.Count() && !hasFoundAny; inner++)
                            hasFoundAny = df[outter].DisplayName == lookupFields[inner];

                    if (!hasFoundAny)
                        ClearBiographics();


                    Wizard.SetWizardButtons(WizardButton.Next | WizardButton.Cancel);
                    //Wizard.SetWizardButtons(WizardButton.Cancel);
;

                    //MessageBox.Show("Press Next to continue");
                    WizardForm parentForm = (WizardForm)this.Parent;
                    parentForm.SetMessageBarText("Press Next to continue", true);
                   // parentForm.SetMessageBarText("Scan is incomplete please scan identification again", true);
                    
                    break;


                case DocumentCompletionStatus.Cancelled:



                case DocumentCompletionStatus.Error:


                    ClearBiographics();
                    break;
                default:
                    break;
            }

            // Display the icon corresponding to the overall document result.
            AuthenticationResult authenticationResult = e.Document.DocumentInfo.Result;
            String result = authenticationResult.ToString();
            pictureBoxResult.Image = imageList48.Images[result];

            // Once AssureID has completed processing the document, any alerts raised for the document
            // are sorted by importance by AssureID. Reload the alerts to see their relative importance.
            // The item's icon is specified by the alert's Result value.
            listViewAlerts.Items.Clear();
            if (Session.LicenseInfo.HasAuthenticationSupport)
            {
                foreach (DocumentAlert alert in e.Document.Alerts)
                {
                    ListViewItem item = listViewAlerts.Items.Add(String.Empty, alert.Result.ToString());
                    item.SubItems.Add(alert.DisplayName);
                    item.SubItems.Add(alert.Description);
                }
            }

            // Once AssureID has completed processing the document, its properties are available.
            // This example shows them displayed using a ListView control.
            foreach (DocumentProperty property in e.Document.Properties)
            {
                ListViewItem item = listViewProperties.Items.Add(property.Name);
                String value = GetValueAsString(property.Value);
                item.SubItems.Add(value);
            }

            // If a document sample is available, enable the File/"Save Sample" menu item.
            saveSampleToolStripMenuItem.Enabled = e.Document.IsSampleAvailable;
        }

        /// <summary>
        /// Handles any document error notification.
        /// This example displays the error text in a message box.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentError(DocumentEventArgs e)
        {
            MessageBox.Show(e.Document.DocumentInfo.DocumentError);
            ClearBiographics();
        }



        //string origString = "Wayne O'Daugherty ^&$#@()!";
        //string newString1 = RemoveSpecialCharacters(origString);
        //newString1 = newString1.Trim()

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9')
                    || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z')
                    || c == ' ' || c == '-'
                    || c == '.' || c == '_'
                    || c == '\'')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }



        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //public class parseAddress
        //{
        //    public string number { get; set; }
        //    public string street { get; set; }
        //    public string address1 { get; set; }
        //    public string address2 { get; set; }
        //    public string city { get; set; }
        //    public string state { get; set; }
        //    public string zipcode { get; set; }




        //}

        //public parseAddress ParseAddress(string fullAddress)
        //{
        //    //char[] charArray = s.ToCharArray();
        //    //Array.Reverse(charArray);
        //    //return new string(charArray);
        //    parseAddress addr = new parseAddress();
            
        ////3540 RIDGEWAY DR BETHEL PARK PA 151024 IK
        ////3082 DARA DRIVE SOUTH PARK PA 15129

        ////    //   ([^\d]|^)\d{5}([^\d]|$)
            
        ////    //addr.address1 = fullAddress

        ////    //addr.address2
        ////    //addr.street
        ////    //addr.city
        ////    //addr.state
        ////addr.zipcode = fullAddress



        //}




        /// <summary>
        /// Handles notification of the addition/change of a document field.
        /// This examples displays any document fields in a DataGridView control.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentFieldChanged(DocumentFieldEventArgs e)
        {
            // If not in Fields table, add it.
            String name = e.Field.Name;

            Console.Write(e.Field.Name);

            // bad ...MessageBox.Show(name);

            String value = GetValueAsString(e.Field.Value);
            String description = e.Field.Description;
            String dataSource = e.Field.DataSource.ToString();

            int index = dataGridViewField.Rows.Add(new object[] { name, value, description, dataSource });
            DataGridViewRow row = dataGridViewField.Rows[index];

            row.Tag = e.Field;  // Save DocumentField object reference for use later.

            //wd
            string origValue = GetValueAsString(e.Field.Value).Trim();
            string fldValue = RemoveSpecialCharacters(origValue).Trim();

            //string reverseString = ReverseString(fldValue);

            //string fldValue = "WAYNE DAUGHERTY";

            //find the spaces to parse with
            int spc1 = fldValue.IndexOf(" ");
            int spc2 = fldValue.IndexOf(" ", spc1 + 1);
            int spc3 = fldValue.IndexOf(" ", spc2 + 1);

            int spc4 = fldValue.IndexOf(" ", spc3 + 1);
            int spc5 = fldValue.IndexOf(" ", spc4 + 1);
            int spc6 = fldValue.IndexOf(" ", spc5 + 1);

            DateTime expireDate;

            switch (e.Field.Name)
            {
                case "Full Name":
                    //
                    if (spc1 > 0 && spc2 > 0)
                    {
                        txtFirst.Text = fldValue.Substring(0, spc1).Trim();
                        txtMiddle.Text = fldValue.Substring(spc1 + 1, spc2 - spc1).Trim();
                        txtLast.Text = fldValue.Substring(spc2 + 1).Trim();
                        SessionData.first = fldValue.Substring(0, spc1).Trim();
                        SessionData.middle = fldValue.Substring(spc1 + 1, spc2 - spc1).Trim();
                        SessionData.last = fldValue.Substring(spc2 + 1).Trim();
                    }

                    else
                    {
                        if (spc1 > 0 && spc2 < 0)
                        {
                            txtFirst.Text = fldValue.Substring(0, spc1);
                            txtLast.Text = fldValue.Substring(spc1 + 1);
                            SessionData.first = fldValue.Substring(0, spc1);
                            SessionData.last = fldValue.Substring(spc1 + 1);
                        }
                    }

                    break;

                case "Sex":
                    textBoxGender.Text = fldValue;
                    SessionData.gender = fldValue;
                    //scanData.gender = fldValue;
                    break;

                case "Expiration Date":

                    textBoxExpirationDate.Text = fldValue;
                    SessionData.expirationdate = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;
                    //scanData.expiredate = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;

                    if (SessionData.expirationdate < System.DateTime.Now)
                    {
                        
                        
                        MessageBox.Show("Sorry, The expiration date is past due,  this document is invalid");

                        WizardForm parentForm = (WizardForm)this.Parent;
                        parentForm.SetMessageBarText("Sorry, The expiration date is past due,  this document is invalid", true);

                        Application.Restart();
                    }

                    break;

                case "Birth Date":
                    textBoxAge.Text = (e.Field.Value is DateTime) ? (CalculateAge((DateTime)e.Field.Value)).ToString() : String.Empty;
                    textBoxBirthDate.Text = fldValue;

                    SessionData.dob = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;
                    textDOB.Text = SessionData.dob.ToString();

                    if (CalculateAge((DateTime)e.Field.Value) < 21)
                    {
                        MessageBox.Show("Sorry, Date of Birth does not meet age requirements,  this document is invalid");

                        WizardForm parentForm = (WizardForm)this.Parent;
                        parentForm.SetMessageBarText("Sorry, Date of Birth does not meet age requirements,  this document is invalid", true);

                        Application.Restart();
                    }

                    break;

                case "Issue Date":
                    textBoxIssueDate.Text = fldValue;
                    SessionData.issuedate = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;
                    //scanData.issuedate = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;
                    break;

                case "Document Number":
                    textBoxDocumentNumber.Text = fldValue;
                    SessionData.documentid = fldValue;
                    //scanData.documentid = fldValue;
                    break;

                case "Document Class Code":
                    textBoxDocumentNumber.Text = fldValue;
                    SessionData.documenttype = fldValue;
                    break;

                case "Address":
                    //???
                    SessionData.address1 = fldValue;
                    txtAddress.Text = fldValue;
                    SessionData.address1 = fldValue;
                    break;

                case "Address Line 1":

                    SessionData.address2 = fldValue;
                    break;

                case "City":
                    SessionData.city = fldValue;
                    break;

                case "Address State":
                    SessionData.stateprov = fldValue;
                    break;

                case "Address Postal Code":
                    SessionData.zip = fldValue; //???
                    break;

                //case "Zip":
                //    //SessionData.zip = fldValue;
                //    break;

                case "ImagePath":
                    SessionData.imagepath = fldValue;
                    break;


                case "CreateDate":
                    SessionData.createddate = System.DateTime.Now;
                    break;
            }


            // use model data to do a search in the membership db...if exists > display ... else ... insert into db and display



            // If one of the "Biometrics" fields, update the appropriate UI control.
            // The set of available fields vary by document type and are defined in the
            // AssureID Document Library. (See DocumentFieldCollection in SDK documentation).
            //switch (e.Field.Name)
            //{
            //    case "Full Name":
            //        textBoxName.Text = GetValueAsString(e.Field.Value);
            //        break;
            //    case "Sex":
            //        textBoxGender.Text = GetValueAsString(e.Field.Value);
            //        break;
            //    case "Expiration Date":
            //        textBoxExpirationDate.Text = GetValueAsString(e.Field.Value);
            //        break;
            //    case "Birth Date":
            //        textBoxAge.Text = (e.Field.Value is DateTime) ? (CalculateAge((DateTime)e.Field.Value)).ToString() : String.Empty;
            //        textBoxBirthDate.Text = GetValueAsString(e.Field.Value);
            //        break;
            //    case "Issue Date":
            //        textBoxIssueDate.Text = GetValueAsString(e.Field.Value);
            //        break;
            //    case "Document Number":
            //        textBoxDocumentNumber.Text = GetValueAsString(e.Field.Value);
            //        break;
            //}


        }

        private void ClearBiographics()
        {
            textBoxName.Text = string.Empty;
            textBoxAge.Text = string.Empty;
            textBoxBirthDate.Text = string.Empty;
            textBoxGender.Text = string.Empty;
            textBoxExpirationDate.Text = string.Empty;
            textBoxIssueDate.Text = string.Empty;
            textBoxDocumentNumber.Text = string.Empty;
        }

        /// <summary>
        /// Calculates age (in years) of the specified datetime (i.e. date-of-birth).
        /// Ignores time, considers only date.
        /// Uses localized date (i.e. DateTime.Now vs. DateTime.UtcNow).
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private static int CalculateAge(DateTime datetime)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - datetime.Year;
            if ((now.Month < datetime.Month) || ((now.Month == datetime.Month) && (now.Day < datetime.Day))) age--;
            return (age < 0) ? 0 : age;
        }

        /// <summary>
        /// Returns a string representation of the specified document field value, which is
        /// based on the data type of the specified value object.
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        private static String GetValueAsString(object fieldValue)
        {
            String value = String.Empty;
            switch (fieldValue.GetType().FullName)
            {
                case "System.Boolean":
                    value = ((System.Boolean)fieldValue).ToString();
                    break;
                case "System.Byte[]":
                    value = ((System.Byte[])fieldValue).ToString();
                    break;
                case "System.DateTime":
                    value = ((System.DateTime)fieldValue).ToShortDateString();
                    break;
                case "System.Decimal":
                    value = ((System.Decimal)fieldValue).ToString();
                    break;
                case "System.Drawing.Bitmap":
                    value = "[image]";
                    break;
                case "System.Int32":
                    value = ((System.Int32)fieldValue).ToString();
                    break;
                case "System.String":
                    value = (System.String)fieldValue;
                    break;
            }
            return value;
        }

        /// <summary>
        /// This handler is called if the Engine needs to request the user to flip the current
        /// document over in the reader (for document with a defined back-side on readers that
        /// support duplex capture).
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentFlip(AssureIDSessionEventArgs e)
        {
            if (m_DocumentFlipForm == null)
            {
                m_DocumentFlipForm = new DocumentFlipForm();
                m_DocumentFlipForm.ContinueDocumentFlip += DocumentFlipForm_ContinueDocumentFlip;
                m_DocumentFlipForm.CancelDocumentFlip += DocumentFlipForm_CancelDocumentFlip;
            }
            m_DocumentFlipForm.Show();
        }

        void DocumentFlipForm_ContinueDocumentFlip(object sender, EventArgs e)
        {
            Session.ContinueDocument();
        }

        /// <summary>
        /// Called if user cancels the document flip request. It tells the Session that the
        /// user has cancelled the Session's request for a document flip so the Session doesn't
        /// wait for the flip detection.
        /// </summary>
        void DocumentFlipForm_CancelDocumentFlip(object sender, EventArgs e)
        {
            Session.CancelDocumentFlip();
        }

        /// <summary>
        /// Called when a new DocumentImage has been captured and added to the currently
        /// processing document. Adds a new tab for each added image to display the image.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentImageAdded(DocumentImageEventArgs e)
        {
            String text = String.Format("{0}{1}", e.Image.Lighting,
                (e.Image.Side == DocumentSide.Back) ? " (back)" : String.Empty);

            TabPage tabPage = new TabPage(text);
            tabControlImages.TabPages.Add(tabPage);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "image";
            pictureBox.Dock = DockStyle.Fill;

            pictureBox.Image = e.Image.Bitmap;

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Tag = e.Image.Id;  // Keep reference to the DocumentImage for use later.

            tabPage.Controls.Add(pictureBox);

            // For the convenience of the operator, automatically display the White/Front image.
            if ((e.Image.Lighting == "White") && (e.Image.Side == DocumentSide.Front))
            {
                tabControlImages.SelectedTab = tabPage;
            }
        }

        private void Session_DocumentNew(DocumentEventArgs e)
        {
            toolStripStatusLabel.Text = "New Document";
        }

        /// <summary>
        /// Handles notification that a new DocumentRegion object has been added to the
        /// current document being processed.
        /// </summary>
        /// <param name="e"></param>
        private void Session_DocumentRegionAdded(DocumentRegionEventArgs e)
        {
            String name = e.Region.Name;
            Rectangle rectangle = e.Region.Rectangle;
            String text = e.Region.Text.Text;

            // Add a new tree node for the new DocumentRegion.
            // Add the region's rectangle and text data as children (if applicable).
            TreeNode node = treeViewRegions.Nodes.Add(name);
            node.Tag = e.Region;  // save original DocumentRegion object for later use
            node.Nodes.Add(rectangle.ToString());
            if (String.IsNullOrEmpty(text) == false)
            {
                node.Nodes.Add(text);
            }
        }

        /// <summary>
        /// Handles notification of platform status change.
        /// </summary>
        /// <param name="e"></param>
        private void Session_PlatformStatusChanged(PlatformStatusEventArgs e)
        {
            //toolStripStatusLabel.Text = e.NewPlatformStatus.ToString();

            autoTriggerToolStripMenuItem.Enabled = (Session.PlatformStatus == PlatformState.Ready);
            contactlessChipReadEnabledToolStripMenuItem.Enabled = (Session.PlatformStatus == PlatformState.Ready);
            duplexEnabledToolStripMenuItem.Enabled = (Session.PlatformStatus == PlatformState.Ready);
            triggerSampleToolStripMenuItem.Enabled = (Session.PlatformStatus == PlatformState.Ready);

            // When the platform status changes, update the list of active readers displayed
            // in the "Manual Trigger" menu. This is also handled in the ReaderStatusChanged
            // event. This code is here to handle the case of first-time application startup
            // where connected readers have already come online before this application has started.
            if (e.NewPlatformStatus == PlatformState.Ready)
            {
                if (manualTriggerToolStripMenuItem.DropDown.Items.Count == 0)
                {
                    ReaderInfoCollection readers = Session.GetActiveReaders();
                    foreach (ReaderInfo reader in readers)
                    {
                        ToolStripItem item = manualTriggerToolStripMenuItem.DropDown.Items.Add(
                            reader.DeviceName, null, manualTriggerDeviceToolStripMenuItem_Click);
                        item.Name = reader.DeviceName;
                        item.Enabled = (reader.ReaderStatus == ReaderStatus.Online);
                    }
                }
                manualTriggerToolStripMenuItem.Enabled = true;

                // Update the AuthenticationSensitivity menu setting.
                highToolStripMenuItem.Checked = (Session.AuthenticationSensitivity == AuthenticationSensitivityType.High);
                normalToolStripMenuItem.Checked = (Session.AuthenticationSensitivity == AuthenticationSensitivityType.Normal);
                lowToolStripMenuItem.Checked = (Session.AuthenticationSensitivity == AuthenticationSensitivityType.Low);

                autoTriggerToolStripMenuItem.Checked = Session.DocumentTriggerMode == DocumentTriggerType.AutoTrigger;
                contactlessChipReadEnabledToolStripMenuItem.Checked = Session.ContactlessChipReadEnabled;
                duplexEnabledToolStripMenuItem.Checked = Session.DuplexMode == DuplexModeType.Duplex;

                tabPageAlerts.Enabled = Session.LicenseInfo.HasAuthenticationSupport;
            }
            else
            {
                manualTriggerToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Fired when a document is inserted into the document reader.
        /// </summary>
        /// <param name="e"></param>
        private void Session_ReaderDocumentInserted(AssureIDSessionEventArgs e)
        {
            if (m_MrzCorrectionForm != null)
            {
                m_MrzCorrectionForm.Hide();
            }

            if ((m_DocumentFlipForm != null) && (Session.DocumentTriggerMode == DocumentTriggerType.AutoTrigger))
            {
                m_DocumentFlipForm.Hide();
            }
        }

        /// <summary>
        /// Once all document captures have been performed (post document classification),
        /// the Engine sends this message to inform the application that it is safe to 
        /// remove the current document from the active reader.
        /// </summary>
        /// <param name="e"></param>
        private void Session_ReaderDocumentMayBeRemoved(AssureIDSessionEventArgs e)
        {
            //toolStripStatusLabel.Text = "Document may be removed from reader.";
        }

        /// <summary>
        /// This handler is called if the AssureID Engine cannot open the document's smart card
        /// based upon the Machine Readable Zone (MRZ) number read from the document. It gives
        /// the user the opportunity to review the extracted MRZ and correct it if necessary.
        /// </summary>
        /// <param name="e"></param>
        private void Session_ReaderKeyRequest(ReaderKeyRequestEventArgs e)
        {
            if (m_MrzCorrectionForm == null)
            {
                m_MrzCorrectionForm = new MrzCorrectionForm();
            }
            // set current MRZ code
            m_MrzCorrectionForm.OriginalMRZ = e.UncorrectedKey;
            if (m_MrzCorrectionForm.ShowDialog() == DialogResult.OK)
            {
                // get corrected MRZ code
                String mrz = m_MrzCorrectionForm.CorrectedMRZ;
                Session.SetReaderAccessKey(mrz);
            }
        }

        /// <summary>
        /// Handles notifications of change in status of connected document readers.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>
        /// Adds or removes the reporting document reader to or from the "Manual Trigger"
        /// submenu, used to trigger manual document captures for available readers.
        /// </remarks>
        private void Session_ReaderStatusChanged(ReaderStatusEventArgs e)
        {
            ToolStripItem item;
            String name = e.ReaderInfo.DeviceName;

            switch (e.ReaderStatus)
            {
                case ReaderStatus.Online:
                case ReaderStatus.Jammed:
                    {
                        if (manualTriggerToolStripMenuItem.DropDown.Items.ContainsKey(name) == false)
                        {
                            // If the reporting reader is coming online, add it to the list of available...
                            item = manualTriggerToolStripMenuItem.DropDown.Items.Add(name, null,
                                manualTriggerDeviceToolStripMenuItem_Click);
                            item.Name = name;
                        }
                        else
                        {
                            item = manualTriggerToolStripMenuItem.DropDown.Items[name];
                        }

                        item.Enabled = (e.ReaderStatus == ReaderStatus.Online);

                        // Handle possible document jam notification.
                        if (e.ReaderStatus == ReaderStatus.Jammed)
                        {
                            if (MessageBox.Show(String.Format("Reader {0} may be jammed. Would you like to attempt to reset the device?", name),
                                "Reader Jammed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                Session.ResetDevice(name);
                            }
                        }
                    }

                    break;
                case ReaderStatus.Offline:
                    // ...otherwise remove it from the list
                    manualTriggerToolStripMenuItem.DropDown.Items.RemoveByKey(name);
                    break;
            }
        }

        private void Session_TransactionComplete(TransactionEventArgs e)
        {
            AssureIDSessionEventType eventType = e.EventType;
        }

        /// <summary>
        /// Called when a new transaction is beginning. Resets the form for the new transaction.
        /// </summary>
        /// <param name="e"></param>
        private void Session_TransactionNew(TransactionEventArgs e)
        {
            ResetIDForm();
            saveSampleToolStripMenuItem.Enabled = false;
            //toolStripStatusLabel.Text = "New Transaction";
        }



        void saveSampleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Document document = e.Argument as Document;
            if (document != null)
            {
                // Place new document sample file on user's desktop.
                // Generate a file name for the sample based on the document itself.
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string documentType = String.IsNullOrEmpty(document.DocumentInfo.Name)
                    ? "Unknown" : document.DocumentInfo.Name;
                string sampleType = String.IsNullOrEmpty(document.DocumentInfo.Issue)
                    ? documentType
                    : String.Format(CultureInfo.CurrentCulture, "{0} ({1})",
                        documentType, document.DocumentInfo.Issue);
                string sampleName = String.Format(CultureInfo.CurrentCulture, "{0} {{{1}}}.sample",
                    sampleType, document.DocumentInfo.Id);
                string samplePath = Path.Combine(desktop, sampleName);
                try
                {
                    while (File.Exists(samplePath))
                    {
                        File.Delete(samplePath);
                    }
                    using (FileStream fs = new FileStream(samplePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        document.SaveSample(fs);
                    }
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(x);
                }
            }
        }

        void saveSampleWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            saveSampleToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Remotely restarts the AssureID service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.RestartService();
        }

        /// <summary>
        /// Remotely stops the AssureID service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.StopService();
        }

        /// <summary>
        /// Triggers a new AssureID transaction on the most recently used document reader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.TriggerNewDocument();
        }

        /// <summary>
        /// Triggers a new AssureID transaction of the specified document reader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manualTriggerDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            String deviceName = item.Text;
            try
            {
                // Marshal long-running task to a background thread to keep UI responsive.
                ThreadPool.QueueUserWorkItem(new WaitCallback((object _target) =>
                {
                    // Triggers new AssureID transaction on the specified device.
                    string _deviceName = _target as string;
                    Session.TriggerNewDocumentOnDevice(_deviceName);
                }), deviceName);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(x);
            }
        }

        /// <summary>
        /// Displays the SDK programmers' guide PDF.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void sdkPDFProgrammersGuideToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Process.Start("AssureID Professional SDK Programmers Guide.pdf");
        //}

        /// <summary>
        /// Handles selection change events from the regions TreeView control.
        /// Displays the bitmap (and optional text) of the selected DocumentRegion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewRegions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocumentRegion region = e.Node.Tag as DocumentRegion;
            if (region != null)
            {
                pictureBoxRegion.Image = region.Bitmap;
                textBoxRegionText.Text = ((region.Text == null) ? String.Empty : region.Text.Text);
            }
        }

        /// <summary>
        /// Handles selection change events from the Field DataGridView control.
        /// Gets any related DocumentRegion objects from the selected DocumentField
        /// and displays bitmap (and optional text) of the related region.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewField_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewField.SelectedRows.Count == 1)
            {
                DataGridViewRow dgvRow = dataGridViewField.SelectedRows[0];
                DocumentField field = dgvRow.Tag as DocumentField;

                // Get set of related DocumentRegion objects, if any.
                Bitmap regionBitmap = null;
                String regionText = String.Empty;
                if (field != null)
                {
                    DocumentObjectCollection references = field.GetReferences(typeof(DocumentRegion));
                    if (references.Count > 0)
                    {
                        // Display the first related document region.
                        DocumentRegion region = references[0] as DocumentRegion;
                        regionBitmap = region.Bitmap;
                        regionText = ((region.Text == null) ? String.Empty : region.Text.Text);
                    }
                }
                pictureBoxRegion.Image = regionBitmap;
                textBoxRegionText.Text = regionText;
            }
        }


                
    }
}

