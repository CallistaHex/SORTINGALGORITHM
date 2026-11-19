using System.Drawing;
using System.Windows.Forms;

namespace SORTINGALGORITHM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblCompany;
        private Label lblStatement;

        private GroupBox grpService;
        private Label lblSOACap;
        private Label lblCANCap;
        private Label lblNameCap;
        private Label lblAddressCap;
        private Label lblTINCap;
        private Label lblRateCap;
        private Label lblBizCap;
        private TextBox txtSOA;
        private TextBox txtCAN;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtTIN;
        private ComboBox cboRate;
        private TextBox txtBizArea;

        private GroupBox grpMetering;
        private Label lblMeterCap;
        private Label lblMRUCap;
        private Label lblSeqCap;
        private Label lblReadCap;
        private Label lblPresentCap;
        private Label lblPrevCap;
        private Label lblConsCap;
        private TextBox txtMeter;
        private TextBox txtMRU;
        private TextBox txtSeq;
        private DateTimePicker dtpRead;
        private TextBox txtPresent;
        private TextBox txtPrevious;
        private TextBox txtConsumption;

        private GroupBox grpBilling;
        private Label lblFromCap;
        private Label lblToCap;
        private Label lblBasicCap;
        private Label lblEnvCap;
        private Label lblMSCCap;
        private Label lblBeforeCap;
        private Label lblTaxCap;
        private Label lblTotalCap;
        private Label lblDueCap;
        private DateTimePicker dtpFrom;
        private Label lblPeriodEnd;
        private Label lblBasic;
        private Label lblEnv;
        private Label lblMSC;
        private Label lblBefore;
        private Label lblTax;
        private Label lblTotal;
        private DateTimePicker dtpDue;

        private GroupBox grpHistory;
        private Label lblHistory;

        private DataGridView dgvBills;

        private Button btnDisplay;
        private Button btnSave;
        private Button btnBubble;
        private Button btnSelection;
        private Button btnInsertion;
        private Button btnQuick;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblStatement = new System.Windows.Forms.Label();
            this.grpService = new System.Windows.Forms.GroupBox();
            this.lblSOACap = new System.Windows.Forms.Label();
            this.txtSOA = new System.Windows.Forms.TextBox();
            this.lblCANCap = new System.Windows.Forms.Label();
            this.txtCAN = new System.Windows.Forms.TextBox();
            this.lblNameCap = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAddressCap = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblTINCap = new System.Windows.Forms.Label();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.lblRateCap = new System.Windows.Forms.Label();
            this.cboRate = new System.Windows.Forms.ComboBox();
            this.lblBizCap = new System.Windows.Forms.Label();
            this.txtBizArea = new System.Windows.Forms.TextBox();
            this.grpMetering = new System.Windows.Forms.GroupBox();
            this.lblMeterCap = new System.Windows.Forms.Label();
            this.txtMeter = new System.Windows.Forms.TextBox();
            this.lblMRUCap = new System.Windows.Forms.Label();
            this.txtMRU = new System.Windows.Forms.TextBox();
            this.lblSeqCap = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.lblReadCap = new System.Windows.Forms.Label();
            this.dtpRead = new System.Windows.Forms.DateTimePicker();
            this.lblPresentCap = new System.Windows.Forms.Label();
            this.txtPresent = new System.Windows.Forms.TextBox();
            this.lblPrevCap = new System.Windows.Forms.Label();
            this.txtPrevious = new System.Windows.Forms.TextBox();
            this.lblConsCap = new System.Windows.Forms.Label();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.grpBilling = new System.Windows.Forms.GroupBox();
            this.lblFromCap = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblToCap = new System.Windows.Forms.Label();
            this.lblPeriodEnd = new System.Windows.Forms.Label();
            this.lblBasicCap = new System.Windows.Forms.Label();
            this.lblBasic = new System.Windows.Forms.Label();
            this.lblEnvCap = new System.Windows.Forms.Label();
            this.lblEnv = new System.Windows.Forms.Label();
            this.lblMSCCap = new System.Windows.Forms.Label();
            this.lblMSC = new System.Windows.Forms.Label();
            this.lblBeforeCap = new System.Windows.Forms.Label();
            this.lblBefore = new System.Windows.Forms.Label();
            this.lblTaxCap = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotalCap = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDueCap = new System.Windows.Forms.Label();
            this.dtpDue = new System.Windows.Forms.DateTimePicker();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBubble = new System.Windows.Forms.Button();
            this.btnSelection = new System.Windows.Forms.Button();
            this.btnInsertion = new System.Windows.Forms.Button();
            this.btnQuick = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSort_Click = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpService.SuspendLayout();
            this.grpMetering.SuspendLayout();
            this.grpBilling.SuspendLayout();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1372, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(143, 44);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(151, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "MAYNILAD WATER SERVICES";
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompany.Location = new System.Drawing.Point(20, 70);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(940, 48);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Maynilad Water Services, Inc.\r\n8390 DR A SANTOS AVE BF HOMES, PARANAQUE CITY\r\nVAT" +
    " Reg TIN 005-393-442-0000";
            // 
            // lblStatement
            // 
            this.lblStatement.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblStatement.Location = new System.Drawing.Point(0, 122);
            this.lblStatement.Name = "lblStatement";
            this.lblStatement.Size = new System.Drawing.Size(980, 24);
            this.lblStatement.TabIndex = 2;
            this.lblStatement.Text = "STATEMENT OF ACCOUNT";
            this.lblStatement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpService
            // 
            this.grpService.Controls.Add(this.lblSOACap);
            this.grpService.Controls.Add(this.txtSOA);
            this.grpService.Controls.Add(this.lblCANCap);
            this.grpService.Controls.Add(this.txtCAN);
            this.grpService.Controls.Add(this.lblNameCap);
            this.grpService.Controls.Add(this.txtName);
            this.grpService.Controls.Add(this.lblAddressCap);
            this.grpService.Controls.Add(this.txtAddress);
            this.grpService.Controls.Add(this.lblTINCap);
            this.grpService.Controls.Add(this.txtTIN);
            this.grpService.Controls.Add(this.lblRateCap);
            this.grpService.Controls.Add(this.cboRate);
            this.grpService.Controls.Add(this.lblBizCap);
            this.grpService.Controls.Add(this.txtBizArea);
            this.grpService.Location = new System.Drawing.Point(20, 155);
            this.grpService.Name = "grpService";
            this.grpService.Size = new System.Drawing.Size(460, 260);
            this.grpService.TabIndex = 3;
            this.grpService.TabStop = false;
            this.grpService.Text = "SERVICE INFORMATION";
            // 
            // lblSOACap
            // 
            this.lblSOACap.AutoSize = true;
            this.lblSOACap.Location = new System.Drawing.Point(12, 32);
            this.lblSOACap.Name = "lblSOACap";
            this.lblSOACap.Size = new System.Drawing.Size(43, 15);
            this.lblSOACap.TabIndex = 0;
            this.lblSOACap.Text = "SOA #:";
            // 
            // txtSOA
            // 
            this.txtSOA.Location = new System.Drawing.Point(190, 28);
            this.txtSOA.Name = "txtSOA";
            this.txtSOA.Size = new System.Drawing.Size(250, 23);
            this.txtSOA.TabIndex = 1;
            // 
            // lblCANCap
            // 
            this.lblCANCap.AutoSize = true;
            this.lblCANCap.Location = new System.Drawing.Point(12, 62);
            this.lblCANCap.Name = "lblCANCap";
            this.lblCANCap.Size = new System.Drawing.Size(123, 15);
            this.lblCANCap.TabIndex = 2;
            this.lblCANCap.Text = "Contract Account No:";
            // 
            // txtCAN
            // 
            this.txtCAN.Location = new System.Drawing.Point(190, 58);
            this.txtCAN.Name = "txtCAN";
            this.txtCAN.Size = new System.Drawing.Size(250, 23);
            this.txtCAN.TabIndex = 3;
            // 
            // lblNameCap
            // 
            this.lblNameCap.AutoSize = true;
            this.lblNameCap.Location = new System.Drawing.Point(12, 92);
            this.lblNameCap.Name = "lblNameCap";
            this.lblNameCap.Size = new System.Drawing.Size(90, 15);
            this.lblNameCap.TabIndex = 4;
            this.lblNameCap.Text = "Account Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(190, 88);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            this.txtName.TabIndex = 5;
            // 
            // lblAddressCap
            // 
            this.lblAddressCap.AutoSize = true;
            this.lblAddressCap.Location = new System.Drawing.Point(12, 122);
            this.lblAddressCap.Name = "lblAddressCap";
            this.lblAddressCap.Size = new System.Drawing.Size(92, 15);
            this.lblAddressCap.TabIndex = 6;
            this.lblAddressCap.Text = "Service Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(190, 118);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 23);
            this.txtAddress.TabIndex = 7;
            // 
            // lblTINCap
            // 
            this.lblTINCap.AutoSize = true;
            this.lblTINCap.Location = new System.Drawing.Point(12, 152);
            this.lblTINCap.Name = "lblTINCap";
            this.lblTINCap.Size = new System.Drawing.Size(28, 15);
            this.lblTINCap.TabIndex = 8;
            this.lblTINCap.Text = "TIN:";
            // 
            // txtTIN
            // 
            this.txtTIN.Location = new System.Drawing.Point(190, 148);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(250, 23);
            this.txtTIN.TabIndex = 9;
            // 
            // lblRateCap
            // 
            this.lblRateCap.AutoSize = true;
            this.lblRateCap.Location = new System.Drawing.Point(12, 182);
            this.lblRateCap.Name = "lblRateCap";
            this.lblRateCap.Size = new System.Drawing.Size(63, 15);
            this.lblRateCap.TabIndex = 10;
            this.lblRateCap.Text = "Rate Class:";
            // 
            // cboRate
            // 
            this.cboRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRate.Items.AddRange(new object[] {
            "Residential",
            "Commercial",
            "Industrial"});
            this.cboRate.Location = new System.Drawing.Point(190, 178);
            this.cboRate.Name = "cboRate";
            this.cboRate.Size = new System.Drawing.Size(250, 23);
            this.cboRate.TabIndex = 11;
            // 
            // lblBizCap
            // 
            this.lblBizCap.AutoSize = true;
            this.lblBizCap.Location = new System.Drawing.Point(12, 212);
            this.lblBizCap.Name = "lblBizCap";
            this.lblBizCap.Size = new System.Drawing.Size(82, 15);
            this.lblBizCap.TabIndex = 12;
            this.lblBizCap.Text = "Business Area:";
            // 
            // txtBizArea
            // 
            this.txtBizArea.Location = new System.Drawing.Point(190, 208);
            this.txtBizArea.Name = "txtBizArea";
            this.txtBizArea.Size = new System.Drawing.Size(250, 23);
            this.txtBizArea.TabIndex = 13;
            // 
            // grpMetering
            // 
            this.grpMetering.Controls.Add(this.lblMeterCap);
            this.grpMetering.Controls.Add(this.txtMeter);
            this.grpMetering.Controls.Add(this.lblMRUCap);
            this.grpMetering.Controls.Add(this.txtMRU);
            this.grpMetering.Controls.Add(this.lblSeqCap);
            this.grpMetering.Controls.Add(this.txtSeq);
            this.grpMetering.Controls.Add(this.lblReadCap);
            this.grpMetering.Controls.Add(this.dtpRead);
            this.grpMetering.Controls.Add(this.lblPresentCap);
            this.grpMetering.Controls.Add(this.txtPresent);
            this.grpMetering.Controls.Add(this.lblPrevCap);
            this.grpMetering.Controls.Add(this.txtPrevious);
            this.grpMetering.Controls.Add(this.lblConsCap);
            this.grpMetering.Controls.Add(this.txtConsumption);
            this.grpMetering.Location = new System.Drawing.Point(500, 155);
            this.grpMetering.Name = "grpMetering";
            this.grpMetering.Size = new System.Drawing.Size(460, 260);
            this.grpMetering.TabIndex = 4;
            this.grpMetering.TabStop = false;
            this.grpMetering.Text = "METERING INFORMATION";
            // 
            // lblMeterCap
            // 
            this.lblMeterCap.AutoSize = true;
            this.lblMeterCap.Location = new System.Drawing.Point(12, 32);
            this.lblMeterCap.Name = "lblMeterCap";
            this.lblMeterCap.Size = new System.Drawing.Size(60, 15);
            this.lblMeterCap.TabIndex = 0;
            this.lblMeterCap.Text = "Meter No:";
            // 
            // txtMeter
            // 
            this.txtMeter.Location = new System.Drawing.Point(190, 28);
            this.txtMeter.Name = "txtMeter";
            this.txtMeter.Size = new System.Drawing.Size(250, 23);
            this.txtMeter.TabIndex = 1;
            // 
            // lblMRUCap
            // 
            this.lblMRUCap.AutoSize = true;
            this.lblMRUCap.Location = new System.Drawing.Point(12, 62);
            this.lblMRUCap.Name = "lblMRUCap";
            this.lblMRUCap.Size = new System.Drawing.Size(55, 15);
            this.lblMRUCap.TabIndex = 2;
            this.lblMRUCap.Text = "MRU No:";
            // 
            // txtMRU
            // 
            this.txtMRU.Location = new System.Drawing.Point(190, 58);
            this.txtMRU.Name = "txtMRU";
            this.txtMRU.Size = new System.Drawing.Size(250, 23);
            this.txtMRU.TabIndex = 3;
            // 
            // lblSeqCap
            // 
            this.lblSeqCap.AutoSize = true;
            this.lblSeqCap.Location = new System.Drawing.Point(12, 92);
            this.lblSeqCap.Name = "lblSeqCap";
            this.lblSeqCap.Size = new System.Drawing.Size(48, 15);
            this.lblSeqCap.TabIndex = 4;
            this.lblSeqCap.Text = "Seq No:";
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(190, 88);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(250, 23);
            this.txtSeq.TabIndex = 5;
            // 
            // lblReadCap
            // 
            this.lblReadCap.AutoSize = true;
            this.lblReadCap.Location = new System.Drawing.Point(12, 122);
            this.lblReadCap.Name = "lblReadCap";
            this.lblReadCap.Size = new System.Drawing.Size(80, 15);
            this.lblReadCap.TabIndex = 6;
            this.lblReadCap.Text = "Reading Date:";
            // 
            // dtpRead
            // 
            this.dtpRead.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRead.Location = new System.Drawing.Point(190, 118);
            this.dtpRead.Name = "dtpRead";
            this.dtpRead.Size = new System.Drawing.Size(250, 23);
            this.dtpRead.TabIndex = 7;
            // 
            // lblPresentCap
            // 
            this.lblPresentCap.AutoSize = true;
            this.lblPresentCap.Location = new System.Drawing.Point(12, 152);
            this.lblPresentCap.Name = "lblPresentCap";
            this.lblPresentCap.Size = new System.Drawing.Size(95, 15);
            this.lblPresentCap.TabIndex = 8;
            this.lblPresentCap.Text = "Present Reading:";
            // 
            // txtPresent
            // 
            this.txtPresent.Location = new System.Drawing.Point(190, 148);
            this.txtPresent.Name = "txtPresent";
            this.txtPresent.Size = new System.Drawing.Size(250, 23);
            this.txtPresent.TabIndex = 9;
            // 
            // lblPrevCap
            // 
            this.lblPrevCap.AutoSize = true;
            this.lblPrevCap.Location = new System.Drawing.Point(12, 182);
            this.lblPrevCap.Name = "lblPrevCap";
            this.lblPrevCap.Size = new System.Drawing.Size(101, 15);
            this.lblPrevCap.TabIndex = 10;
            this.lblPrevCap.Text = "Previous Reading:";
            // 
            // txtPrevious
            // 
            this.txtPrevious.Location = new System.Drawing.Point(190, 178);
            this.txtPrevious.Name = "txtPrevious";
            this.txtPrevious.Size = new System.Drawing.Size(250, 23);
            this.txtPrevious.TabIndex = 11;
            // 
            // lblConsCap
            // 
            this.lblConsCap.AutoSize = true;
            this.lblConsCap.Location = new System.Drawing.Point(12, 212);
            this.lblConsCap.Name = "lblConsCap";
            this.lblConsCap.Size = new System.Drawing.Size(121, 15);
            this.lblConsCap.TabIndex = 12;
            this.lblConsCap.Text = "Consumption (cu.m):";
            // 
            // txtConsumption
            // 
            this.txtConsumption.Location = new System.Drawing.Point(190, 208);
            this.txtConsumption.Name = "txtConsumption";
            this.txtConsumption.ReadOnly = true;
            this.txtConsumption.Size = new System.Drawing.Size(250, 23);
            this.txtConsumption.TabIndex = 13;
            this.txtConsumption.TextChanged += new System.EventHandler(this.txtConsumption_TextChanged);
            // 
            // grpBilling
            // 
            this.grpBilling.Controls.Add(this.lblFromCap);
            this.grpBilling.Controls.Add(this.dtpFrom);
            this.grpBilling.Controls.Add(this.lblToCap);
            this.grpBilling.Controls.Add(this.lblPeriodEnd);
            this.grpBilling.Controls.Add(this.lblBasicCap);
            this.grpBilling.Controls.Add(this.lblBasic);
            this.grpBilling.Controls.Add(this.lblEnvCap);
            this.grpBilling.Controls.Add(this.lblEnv);
            this.grpBilling.Controls.Add(this.lblMSCCap);
            this.grpBilling.Controls.Add(this.lblMSC);
            this.grpBilling.Controls.Add(this.lblBeforeCap);
            this.grpBilling.Controls.Add(this.lblBefore);
            this.grpBilling.Controls.Add(this.lblTaxCap);
            this.grpBilling.Controls.Add(this.lblTax);
            this.grpBilling.Controls.Add(this.lblTotalCap);
            this.grpBilling.Controls.Add(this.lblTotal);
            this.grpBilling.Controls.Add(this.lblDueCap);
            this.grpBilling.Controls.Add(this.dtpDue);
            this.grpBilling.Location = new System.Drawing.Point(20, 425);
            this.grpBilling.Name = "grpBilling";
            this.grpBilling.Size = new System.Drawing.Size(460, 320);
            this.grpBilling.TabIndex = 5;
            this.grpBilling.TabStop = false;
            this.grpBilling.Text = "BILLING SUMMARY";
            // 
            // lblFromCap
            // 
            this.lblFromCap.AutoSize = true;
            this.lblFromCap.Location = new System.Drawing.Point(12, 32);
            this.lblFromCap.Name = "lblFromCap";
            this.lblFromCap.Size = new System.Drawing.Size(111, 15);
            this.lblFromCap.TabIndex = 0;
            this.lblFromCap.Text = "Billing Period From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(190, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(250, 23);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblToCap
            // 
            this.lblToCap.AutoSize = true;
            this.lblToCap.Location = new System.Drawing.Point(12, 62);
            this.lblToCap.Name = "lblToCap";
            this.lblToCap.Size = new System.Drawing.Size(95, 15);
            this.lblToCap.TabIndex = 2;
            this.lblToCap.Text = "Billing Period To:";
            // 
            // lblPeriodEnd
            // 
            this.lblPeriodEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPeriodEnd.Location = new System.Drawing.Point(190, 58);
            this.lblPeriodEnd.Name = "lblPeriodEnd";
            this.lblPeriodEnd.Size = new System.Drawing.Size(250, 22);
            this.lblPeriodEnd.TabIndex = 3;
            this.lblPeriodEnd.Text = "-";
            this.lblPeriodEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBasicCap
            // 
            this.lblBasicCap.AutoSize = true;
            this.lblBasicCap.Location = new System.Drawing.Point(12, 92);
            this.lblBasicCap.Name = "lblBasicCap";
            this.lblBasicCap.Size = new System.Drawing.Size(78, 15);
            this.lblBasicCap.TabIndex = 4;
            this.lblBasicCap.Text = "Basic Charge:";
            // 
            // lblBasic
            // 
            this.lblBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBasic.Location = new System.Drawing.Point(190, 88);
            this.lblBasic.Name = "lblBasic";
            this.lblBasic.Size = new System.Drawing.Size(250, 22);
            this.lblBasic.TabIndex = 5;
            this.lblBasic.Text = "0.00";
            this.lblBasic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEnvCap
            // 
            this.lblEnvCap.AutoSize = true;
            this.lblEnvCap.Location = new System.Drawing.Point(12, 122);
            this.lblEnvCap.Name = "lblEnvCap";
            this.lblEnvCap.Size = new System.Drawing.Size(120, 15);
            this.lblEnvCap.TabIndex = 6;
            this.lblEnvCap.Text = "Environmental (20%):";
            // 
            // lblEnv
            // 
            this.lblEnv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnv.Location = new System.Drawing.Point(190, 118);
            this.lblEnv.Name = "lblEnv";
            this.lblEnv.Size = new System.Drawing.Size(250, 22);
            this.lblEnv.TabIndex = 7;
            this.lblEnv.Text = "0.00";
            this.lblEnv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMSCCap
            // 
            this.lblMSCCap.AutoSize = true;
            this.lblMSCCap.Location = new System.Drawing.Point(12, 152);
            this.lblMSCCap.Name = "lblMSCCap";
            this.lblMSCCap.Size = new System.Drawing.Size(160, 15);
            this.lblMSCCap.TabIndex = 8;
            this.lblMSCCap.Text = "Maintenance Service Charge:";
            // 
            // lblMSC
            // 
            this.lblMSC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMSC.Location = new System.Drawing.Point(190, 148);
            this.lblMSC.Name = "lblMSC";
            this.lblMSC.Size = new System.Drawing.Size(250, 22);
            this.lblMSC.TabIndex = 9;
            this.lblMSC.Text = "0.00";
            this.lblMSC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBeforeCap
            // 
            this.lblBeforeCap.AutoSize = true;
            this.lblBeforeCap.Location = new System.Drawing.Point(12, 182);
            this.lblBeforeCap.Name = "lblBeforeCap";
            this.lblBeforeCap.Size = new System.Drawing.Size(149, 15);
            this.lblBeforeCap.TabIndex = 10;
            this.lblBeforeCap.Text = "Total Charges Before Taxes:";
            // 
            // lblBefore
            // 
            this.lblBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBefore.Location = new System.Drawing.Point(190, 178);
            this.lblBefore.Name = "lblBefore";
            this.lblBefore.Size = new System.Drawing.Size(250, 22);
            this.lblBefore.TabIndex = 11;
            this.lblBefore.Text = "0.00";
            this.lblBefore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaxCap
            // 
            this.lblTaxCap.AutoSize = true;
            this.lblTaxCap.Location = new System.Drawing.Point(12, 212);
            this.lblTaxCap.Name = "lblTaxCap";
            this.lblTaxCap.Size = new System.Drawing.Size(143, 15);
            this.lblTaxCap.TabIndex = 12;
            this.lblTaxCap.Text = "Government Taxes (2.5%):";
            // 
            // lblTax
            // 
            this.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTax.Location = new System.Drawing.Point(190, 208);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(250, 22);
            this.lblTax.TabIndex = 13;
            this.lblTax.Text = "0.00";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCap
            // 
            this.lblTotalCap.AutoSize = true;
            this.lblTotalCap.Location = new System.Drawing.Point(12, 242);
            this.lblTotalCap.Name = "lblTotalCap";
            this.lblTotalCap.Size = new System.Drawing.Size(121, 15);
            this.lblTotalCap.TabIndex = 14;
            this.lblTotalCap.Text = "TOTAL AMOUNT DUE:";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(190, 238);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(250, 22);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "PHP 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDueCap
            // 
            this.lblDueCap.AutoSize = true;
            this.lblDueCap.Location = new System.Drawing.Point(12, 272);
            this.lblDueCap.Name = "lblDueCap";
            this.lblDueCap.Size = new System.Drawing.Size(108, 15);
            this.lblDueCap.TabIndex = 16;
            this.lblDueCap.Text = "Payment Due Date:";
            // 
            // dtpDue
            // 
            this.dtpDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDue.Location = new System.Drawing.Point(190, 268);
            this.dtpDue.Name = "dtpDue";
            this.dtpDue.Size = new System.Drawing.Size(250, 23);
            this.dtpDue.TabIndex = 17;
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.lblHistory);
            this.grpHistory.Location = new System.Drawing.Point(500, 425);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(460, 320);
            this.grpHistory.TabIndex = 6;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "BILL & PAYMENT HISTORY";
            // 
            // lblHistory
            // 
            this.lblHistory.Location = new System.Drawing.Point(12, 28);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(436, 280);
            this.lblHistory.TabIndex = 0;
            this.lblHistory.Text = resources.GetString("lblHistory.Text");
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvBills.Location = new System.Drawing.Point(20, 760);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(1254, 164);
            this.dgvBills.TabIndex = 7;
            this.dgvBills.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBills_CellContentClick);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.ForeColor = System.Drawing.Color.White;
            this.btnDisplay.Location = new System.Drawing.Point(20, 930);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(150, 36);
            this.btnDisplay.TabIndex = 8;
            this.btnDisplay.Text = "DISPLAY WATER BILL";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(178, 930);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 36);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBubble
            // 
            this.btnBubble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBubble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBubble.ForeColor = System.Drawing.Color.White;
            this.btnBubble.Location = new System.Drawing.Point(336, 930);
            this.btnBubble.Name = "btnBubble";
            this.btnBubble.Size = new System.Drawing.Size(150, 36);
            this.btnBubble.TabIndex = 10;
            this.btnBubble.Text = "BUBBLE SORT";
            this.btnBubble.UseVisualStyleBackColor = false;
            this.btnBubble.Click += new System.EventHandler(this.btnBubble_Click);
            // 
            // btnSelection
            // 
            this.btnSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelection.ForeColor = System.Drawing.Color.White;
            this.btnSelection.Location = new System.Drawing.Point(494, 930);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(150, 36);
            this.btnSelection.TabIndex = 11;
            this.btnSelection.Text = "SELECTION SORT";
            this.btnSelection.UseVisualStyleBackColor = false;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // btnInsertion
            // 
            this.btnInsertion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInsertion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertion.ForeColor = System.Drawing.Color.White;
            this.btnInsertion.Location = new System.Drawing.Point(652, 930);
            this.btnInsertion.Name = "btnInsertion";
            this.btnInsertion.Size = new System.Drawing.Size(150, 36);
            this.btnInsertion.TabIndex = 12;
            this.btnInsertion.Text = "INSERTION SORT";
            this.btnInsertion.UseVisualStyleBackColor = false;
            this.btnInsertion.Click += new System.EventHandler(this.btnInsertion_Click);
            // 
            // btnQuick
            // 
            this.btnQuick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnQuick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuick.ForeColor = System.Drawing.Color.White;
            this.btnQuick.Location = new System.Drawing.Point(810, 930);
            this.btnQuick.Name = "btnQuick";
            this.btnQuick.Size = new System.Drawing.Size(150, 36);
            this.btnQuick.TabIndex = 13;
            this.btnQuick.Text = "QUICK SORT";
            this.btnQuick.UseVisualStyleBackColor = false;
            this.btnQuick.Click += new System.EventHandler(this.btnQuick_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1013, 239);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 14;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(1163, 239);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 16;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(1013, 287);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1021, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Sorting Alogrithm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1170, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Sortby";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1021, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Sorting order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1170, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 22;
            // 
            // btnSort_Click
            // 
            this.btnSort_Click.Location = new System.Drawing.Point(1163, 287);
            this.btnSort_Click.Name = "btnSort_Click";
            this.btnSort_Click.Size = new System.Drawing.Size(121, 23);
            this.btnSort_Click.TabIndex = 23;
            this.btnSort_Click.Text = "Applysorting";
            this.btnSort_Click.UseVisualStyleBackColor = true;
            this.btnSort_Click.Click += new System.EventHandler(this.btnSort_Click_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1013, 239);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1372, 985);
            this.Controls.Add(this.btnSort_Click);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblStatement);
            this.Controls.Add(this.grpService);
            this.Controls.Add(this.grpMetering);
            this.Controls.Add(this.grpBilling);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBubble);
            this.Controls.Add(this.btnSelection);
            this.Controls.Add(this.btnInsertion);
            this.Controls.Add(this.btnQuick);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maynilad Water Bill";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpService.ResumeLayout(false);
            this.grpService.PerformLayout();
            this.grpMetering.ResumeLayout(false);
            this.grpMetering.PerformLayout();
            this.grpBilling.ResumeLayout(false);
            this.grpBilling.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSort_Click;
        private ComboBox comboBox2;
    }
}