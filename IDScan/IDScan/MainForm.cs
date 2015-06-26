//****************************************************************************

//****************************************************************************

using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AssureTec.AssureID.SDK;
using AssureTec.AssureID.SDK.Events;
using AssureTec.AssureID.SDK.TransactionDocument;

using System.Collections.Generic;
using System.Text;
using IDScan.Data.DAL;
using IDScan.WizardLib;


namespace IDScan
{
    /// <summary>

    /// </summary>

    public partial class MainForm : Form
    {

        //scandata scanData = new scandata();
        membership memberShip = new membership();
        
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

        /// <summary>
        /// Form displayed to allow user to review and correct the document MRZ. This is used
        /// if the AssureID Engine cannot open the document's smart card using the MRZ value
        /// extracted from the document. If not OCR'd correctly, this can prevent the engine 
        /// from opening the smart card.
        /// </summary>
        private MrzCorrectionForm m_MrzCorrectionForm = null;

        //*****************************
        //private bool debugOn = true;
        //*****************************

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {

            //if (debugOn)
            //    Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);

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
        /// Comparer class used to sort tree nodes. Instance specified to sort Region TreeView nodes.
        /// </summary>
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
        private void MainForm_Load(object sender, EventArgs e)
        {

            ResetForm();

            // Need to open the AssureID session for use.
            Session.Open();
        }

        /// <summary>
        /// Runs when the main form is closing. Closes the AssureID session.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the AssureID session when we're done.
            Session.Close();
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
            // The item's icon is specified by the alert's Result value.
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
//wd
                    //string origString = "Wayne O'Daugherty ^&$#@()!";
                    //string newString1 = RemoveSpecialCharacters(origString);
                    //newString1 = newString1.Trim()

                    //***********************************************************************
                    //***********************************************************************

                    MembershipEntities model = new MembershipEntities();

                    //scanData.clubid = 1;

                    //should be looking in model.memberships
                    //IQueryable<scandata> search = from scan in model.scandatas
                    //             where scan.clubid == scanData.clubid
                    //                   && scan.first == scanData.first
                    //                   && scan.middle == scanData.middle
                    //                   && scan.last == scanData.last
                    //                   && scan.dob == scanData.dob
                    //             select scan;

                    // **********************************************
                    // **********************************************
                    
//                    model.scandatas.Add(scanData);
//                    model.SaveChanges();

                    // **********************************************

                    //if (search.Count() > 0)
                    //{
                    //    MessageBox.Show("Success - Found:  " + scanData.first + " " + scanData.last);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("FAILED - NOT FOUND:  " + scanData.first + " " + scanData.last);

                    //    //model.scandatas.Add(scanData);
                    //    //model.SaveChanges();

                    //}

                    //
 
                    string[] lookupFields = new string[]{
                        "Full Name",
                        "Surname",
                        "Given Name",
                        "Sex",
                        "Birth Date",
                        "Expiration Date",
                        "Issue Date", 
                        "Document Number"};
                    DocumentField[] df =  e.Document.Fields.OfType<DocumentField>().ToArray();
                    bool hasFoundAny = false;

                    for (int outter = 0; outter < df.Count() && !hasFoundAny; outter++)
                        for (int inner = 0; inner < lookupFields.Count() && !hasFoundAny; inner++)
                            hasFoundAny = df[outter].DisplayName == lookupFields[inner];
    
                    if(!hasFoundAny)
                        ClearBiographics();
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

            switch (e.Field.Name)
            {
                case "Full Name":
                    //
                    if (spc1 > 0 && spc2 > 0)
                    {
                        txtFirst.Text = fldValue.Substring(0, spc1).Trim();
                        txtMiddle.Text = fldValue.Substring(spc1 + 1, spc2 - spc1).Trim();
                        txtLast.Text = fldValue.Substring(spc2 + 1).Trim();

                        scanData.first = fldValue.Substring(0, spc1).Trim();
                        scanData.middle = fldValue.Substring(spc1 + 1, spc2 - spc1).Trim();
                        scanData.last = fldValue.Substring(spc2 + 1).Trim();
                    }

                    else
                    {
                        if (spc1 > 0 && spc2 < 0)
                        {
                            txtFirst.Text = fldValue.Substring(0, spc1);
                            txtLast.Text = fldValue.Substring(spc1 + 1);

                            scanData.first = fldValue.Substring(0, spc1);
                            scanData.last = fldValue.Substring(spc1 + 1);
                        }
                    }

                    break;

                case "Sex":
                    textBoxGender.Text = fldValue;
                    scanData.gender = fldValue;
                    break;

                case "Expiration Date":
                    textBoxExpirationDate.Text = fldValue;
                    scanData.expiredate = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;
                    break;

                case "Birth Date":
                    textBoxAge.Text = (e.Field.Value is DateTime) ? (CalculateAge((DateTime)e.Field.Value)).ToString() : String.Empty;
                    textBoxBirthDate.Text = fldValue;
                    
                    scanData.dob = (e.Field.Value is DateTime?) ? (DateTime?) e.Field.Value : null;

                    textDOB.Text = scanData.dob.ToString();
 
                    break;

                case "Issue Date":
                    textBoxIssueDate.Text = fldValue;
                    scanData.issuedate = (e.Field.Value is DateTime?) ? (DateTime?)e.Field.Value : null;
                    break;

                case "Document Number":
                    textBoxDocumentNumber.Text = fldValue;
                    scanData.documentid = fldValue;
                    break;

                case "Document Class Code":
                    textBoxDocumentNumber.Text = fldValue;
                    scanData.documenttype = fldValue;
                    break;

                case "Address":

                    scanData.address = fldValue;

                    //            string reverseString = ReverseString(fldValue);

                    //string x = reverseString;

                    //if (spc1 > 0 && spc2 > 0)
                    //{
                    //    txtAddress.Text = fldValue.Substring(0, spc1).Trim();
                    //    txtCity.Text = fldValue.Substring(spc1 + 1, spc2 - spc1).Trim();
                    //    txtState.Text = fldValue.Substring(spc2 + 1).Trim();
                    //    txtZip.Text = fldValue.Substring(spc2 + 1).Trim();

                    //    scanData.address1 = fldValue.Substring(0, spc1).Trim();
                    //    scanData.city = fldValue.Substring(spc1 + 1, spc2 - spc1).Trim();
                    //    scanData.stateprov = fldValue.Substring(spc2 + 1).Trim();
                    //    scanData.zip = fldValue.Substring(spc2 + 1).Trim();
                    //}

                    //else
                    //{
                    //    if (spc1 > 0 && spc2 < 0)
                    //    {
                    //        txtFirst.Text = fldValue.Substring(0, spc1);
                    //        txtLast.Text = fldValue.Substring(spc1 + 1);

                    //        scanData.first = fldValue.Substring(0, spc1);
                    //        scanData.last = fldValue.Substring(spc1 + 1);
                    //    }
                    //}

                    //scanData.address1 = fldValue;
                    //scanData.address1 = fldValue.Substring(0, spc3);
                    break;

                case "Address Line 1":
                    
                    scanData.address1 = fldValue;
                    break;

                case "City":
                    scanData.city = fldValue;
                    break;

                case "Address State":
                    scanData.stateprov = fldValue;
                    break;

                case "Address Postal Code":
                    scanData.zip = fldValue; //???
                    break;

                case "Zip":
                    scanData.zip = fldValue;
                    break;

                case "ImagePath":
                    scanData.imagepath = fldValue;
                    break;


                case "CreateDate":
                    scanData.creatdate = System.DateTime.Now;
                    break;
            }


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
            toolStripStatusLabel.Text = e.NewPlatformStatus.ToString();

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
            toolStripStatusLabel.Text = "Document may be removed from reader.";
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
            ResetForm();
            saveSampleToolStripMenuItem.Enabled = false;
            toolStripStatusLabel.Text = "New Transaction";
        }

        /// <summary>
        /// Resets the controls in the form for a new AssureID transaction.
        /// </summary>
        private void ResetForm()
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
        /// Saves a document sample (.sample file) of the current document, if available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Session.CurrentDocument != null) && (Session.CurrentDocument.IsSampleAvailable))
            {
                saveSampleToolStripMenuItem.Enabled = false;

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(saveSampleWorker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(saveSampleWorker_RunWorkerCompleted);
                worker.RunWorkerAsync(Session.CurrentDocument);
            }
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
                catch (Exception x)
                {
                    Debug.WriteLine(x);
                }
            }
        }

        void saveSampleWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            saveSampleToolStripMenuItem.Enabled = true;
        }

        private void triggerSampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Sample|*.sample|All|*.*",
                Title = "Select document sample..."
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                var filename = dialog.FileName;
                if (File.Exists(filename))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            Session.TriggerNewDocumentFromSample(fs);
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(this, String.Format("Error trying to trigger from sample {0}: {1}", filename, x.Message));
                    }
                }
                else
                {
                    MessageBox.Show(this, String.Format("Could not find selected file: {0}", filename));
                }
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        /// Toggles the session's document trigger mode between automatic and manual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoTriggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the DocumentTriggerMode.
            autoTriggerToolStripMenuItem.Checked = !autoTriggerToolStripMenuItem.Checked;
            // Tell the AssureID session what the new value is.
            Session.DocumentTriggerMode = autoTriggerToolStripMenuItem.Checked ? DocumentTriggerType.AutoTrigger : DocumentTriggerType.ManualTrigger;
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
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }
        }

        /// <summary>
        /// Displays the "About" dialog. Creates the dialog form if necessary, specifying
        /// the AssureID Session, from which the dialog gets software version information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_AboutForm == null)
            {
                m_AboutForm = new AboutForm();
                m_AboutForm.EngineVersion = Session.SoftwareVersion;
            }
            // The Library version isn't known until the session is connected,
            // so we set the library version each time we're about to show About.
            m_AboutForm.LibraryVersion = Session.LibraryVersion;
            m_AboutForm.LicenseInfo = Session.IsConnected ? Session.LicenseInfo : null;
            m_AboutForm.ShowDialog(this);
        }

        /// <summary>
        /// Displays the SDK help view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sdkNETWinHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("AssureID .NET Platform SDK.chm");
        }

        /// <summary>
        /// Displays the SDK programmers' guide PDF.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sdkPDFProgrammersGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("AssureID Professional SDK Programmers Guide.pdf");
        }

        private void authenticationSensitivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripMenuItem)
            {
                highToolStripMenuItem.Checked = ((sender as ToolStripMenuItem) == highToolStripMenuItem);
                normalToolStripMenuItem.Checked = ((sender as ToolStripMenuItem) == normalToolStripMenuItem);
                lowToolStripMenuItem.Checked = ((sender as ToolStripMenuItem) == lowToolStripMenuItem);

                if ((sender as ToolStripMenuItem) == highToolStripMenuItem)
                {
                    Session.AuthenticationSensitivity = AuthenticationSensitivityType.High;
                }
                else if ((sender as ToolStripMenuItem) == normalToolStripMenuItem)
                {
                    Session.AuthenticationSensitivity = AuthenticationSensitivityType.Normal;
                }
                else if ((sender as ToolStripMenuItem) == lowToolStripMenuItem)
                {
                    Session.AuthenticationSensitivity = AuthenticationSensitivityType.Low;
                }
            }
        }

        private void contactlessChipReadEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the ContactlessChipReadEnabled.
            contactlessChipReadEnabledToolStripMenuItem.Checked = !contactlessChipReadEnabledToolStripMenuItem.Checked;
            // Tell the AssureID session what the new value is.
            Session.ContactlessChipReadEnabled = contactlessChipReadEnabledToolStripMenuItem.Checked;
        }

        private void duplexEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the DuplexEnabled.
            duplexEnabledToolStripMenuItem.Checked = !duplexEnabledToolStripMenuItem.Checked;
            // Tell the AssureID session what the new value is.
            Session.DuplexMode = duplexEnabledToolStripMenuItem.Checked ? DuplexModeType.Duplex : DuplexModeType.Simplex;
        }

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
