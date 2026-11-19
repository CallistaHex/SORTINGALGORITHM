using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SORTINGALGORITHM
{
    public partial class Form1 : Form
    {
        const decimal RatePerCuM = 23.52m;
        const decimal EnvPercent = 0.20m;
        const decimal MSC = 1.53m;
        const decimal TaxPercent = 0.025m;

        const string ServerConn = "Server=localhost;Database=master;User Id=sa;Password=B1Admin123@;TrustServerCertificate=True;";
        const string DbConn = "Server=localhost;Database=WaterBillDB;User Id=sa;Password=B1Admin123@;TrustServerCertificate=True;";

        const string GridSql =
            @"SELECT p.paymentID AS [Payment ID],
                     c.soaNumber AS [SOA Number],
                     c.customerName AS [Customer Name],
                     c.serviceAddress AS [Customer Address],
                     m.meterNo AS [Meter No],
                     m.readingDate AS [Reading Date],
                     m.consumption AS [Consumption (cu.m)],
                     p.billingStart AS [Billing Start],
                     p.billingEnd AS [Billing End],
                     p.totalAmountDue AS [Total Amount Due],
                     p.paymentDueDate AS [Payment Due Date]
              FROM paymentTbl p
              INNER JOIN meterTbl m ON p.meterID = m.meterID
              INNER JOIN customerInfoTbl c ON m.customerID = c.customerID
              ORDER BY p.paymentID;";

        decimal presentReading, previousReading, consumption;
        decimal basic, env, beforeTax, tax, total;

  
        private bool _seeded = false;

        public Form1()
        {
            InitializeComponent();
            cboRate.SelectedIndex = 0;
            dgvBills.CellDoubleClick += dgvBills_CellDoubleClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maynilad_logo.png");
            if (File.Exists(logoPath))
            {
                picLogo.Image = Image.FromFile(logoPath);
            }

            try
            {
                SetupDatabase();
                SeedData();          
                LoadGrid();
                SetupSortingControls();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to database.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void SetupDatabase()
        {
            using (SqlConnection con = new SqlConnection(ServerConn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "IF DB_ID('WaterBillDB') IS NULL CREATE DATABASE WaterBillDB;", con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            string tables = @"
IF OBJECT_ID('customerInfoTbl') IS NULL
CREATE TABLE customerInfoTbl (
    customerID INT IDENTITY(1,1) PRIMARY KEY,
    soaNumber NVARCHAR(50) NOT NULL,
    contractAccountNo NVARCHAR(50) NOT NULL,
    customerName NVARCHAR(100) NOT NULL,
    serviceAddress NVARCHAR(200),
    tin NVARCHAR(50),
    rateClass NVARCHAR(30),
    businessArea NVARCHAR(100)
);

IF OBJECT_ID('meterTbl') IS NULL
CREATE TABLE meterTbl (
    meterID INT IDENTITY(1,1) PRIMARY KEY,
    customerID INT NOT NULL FOREIGN KEY REFERENCES customerInfoTbl(customerID),
    meterNo NVARCHAR(50),
    mruNo NVARCHAR(50),
    seqNo NVARCHAR(50),
    readingDate DATE,
    presentReading DECIMAL(12,2),
    previousReading DECIMAL(12,2),
    consumption DECIMAL(12,2)
);

IF OBJECT_ID('paymentTbl') IS NULL
CREATE TABLE paymentTbl (
    paymentID INT IDENTITY(1,1) PRIMARY KEY,
    meterID INT NOT NULL FOREIGN KEY REFERENCES meterTbl(meterID),
    billingStart DATE,
    billingEnd DATE,
    basicCharge DECIMAL(12,2),
    environmentalCharge DECIMAL(12,2),
    maintenanceCharge DECIMAL(12,2),
    totalBeforeTaxes DECIMAL(12,2),
    governmentTaxes DECIMAL(12,2),
    totalAmountDue DECIMAL(12,2),
    paymentDueDate DATE
);";

            using (SqlConnection con = new SqlConnection(DbConn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(tables, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

   
        private void SeedData()
        {
            if (_seeded) return;

            using (SqlConnection con = new SqlConnection(DbConn))
            {
                con.Open();

               
                int existing = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM paymentTbl;", con))
                {
                    existing = (int)cmd.ExecuteScalar();
                }

                if (existing >= 500)
                {
                    _seeded = true;
                    return;
                }

                int toCreate = 500 - existing;

                string[] firstNames = { "Juan", "Maria", "Jose", "Ana", "Pedro", "Rosa", "Luis", "Carmen",
                                        "Miguel", "Elena", "Carlos", "Sofia", "Rafael", "Lucia", "Andres",
                                        "Isabel", "Fernando", "Teresa", "Antonio", "Beatriz" };
                string[] lastNames = { "Dela Cruz", "Santos", "Reyes", "Garcia", "Bautista", "Ocampo",
                                        "Mendoza", "Torres", "Flores", "Ramos", "Villanueva", "Castro",
                                        "Aquino", "Domingo", "Navarro", "Salazar", "Pascual", "Lim",
                                        "Tan", "Go" };
                string[] areas = { "Quezon City", "Makati", "Pasay", "Paranaque", "Las Pinas",
                                        "Muntinlupa", "Caloocan", "Valenzuela", "Navotas", "Malabon" };
                string[] rates = { "Residential", "Commercial", "Industrial" };

                Random rnd = new Random(2025);

                using (SqlTransaction tx = con.BeginTransaction())
                {
                    for (int i = 0; i < toCreate; i++)
                    {
                        string name = firstNames[rnd.Next(firstNames.Length)] + " " +
                                      lastNames[rnd.Next(lastNames.Length)];
                        string area = areas[rnd.Next(areas.Length)];
                        string rate = rates[rnd.Next(rates.Length)];
                        string soa = "SOA-" + DateTime.Now.Year + "-" + (existing + i + 1).ToString("D6");
                        string can = "CAN-" + rnd.Next(100000, 999999).ToString();
                        string addr = rnd.Next(1, 999) + " " + area + " Street";
                        string tin = rnd.Next(100, 999) + "-" + rnd.Next(100, 999) + "-" + rnd.Next(100, 999) + "-000";

                        int customerId;
                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO customerInfoTbl (soaNumber, contractAccountNo, customerName, serviceAddress, tin, rateClass, businessArea)
                              VALUES (@soa, @can, @name, @addr, @tin, @rate, @biz);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@soa", soa);
                            cmd.Parameters.AddWithValue("@can", can);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@addr", addr);
                            cmd.Parameters.AddWithValue("@tin", tin);
                            cmd.Parameters.AddWithValue("@rate", rate);
                            cmd.Parameters.AddWithValue("@biz", area);
                            customerId = (int)cmd.ExecuteScalar();
                        }
                
                        decimal prev = rnd.Next(100, 5000);
                        decimal pres = prev + rnd.Next(1, 200);
                        decimal cons = pres - prev;
                        DateTime readDate = DateTime.Today.AddDays(-rnd.Next(0, 365));

                        int meterId;
                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO meterTbl (customerID, meterNo, mruNo, seqNo, readingDate, presentReading, previousReading, consumption)
                              VALUES (@cid, @meter, @mru, @seq, @read, @pres, @prev, @cons);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@cid", customerId);
                            cmd.Parameters.AddWithValue("@meter", "MTR-" + rnd.Next(100000, 999999));
                            cmd.Parameters.AddWithValue("@mru", "MRU-" + rnd.Next(1000, 9999));
                            cmd.Parameters.AddWithValue("@seq", rnd.Next(1, 999).ToString());
                            cmd.Parameters.AddWithValue("@read", readDate);
                            cmd.Parameters.AddWithValue("@pres", pres);
                            cmd.Parameters.AddWithValue("@prev", prev);
                            cmd.Parameters.AddWithValue("@cons", cons);
                            meterId = (int)cmd.ExecuteScalar();
                        }

                        decimal bBasic = Math.Round(cons * RatePerCuM, 2);
                        decimal bEnv = Math.Round(bBasic * EnvPercent, 2);
                        decimal bMsc = MSC;
                        decimal bBefore = bBasic + bEnv + bMsc;
                        decimal bTax = Math.Round(bBefore * TaxPercent, 2);
                        decimal bTotal = bBefore + bTax;

                        DateTime bStart = readDate.AddMonths(-1);
                        DateTime bEnd = readDate;
                        DateTime bDue = readDate.AddDays(30);

                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO paymentTbl (meterID, billingStart, billingEnd, basicCharge, environmentalCharge, maintenanceCharge, totalBeforeTaxes, governmentTaxes, totalAmountDue, paymentDueDate)
                              VALUES (@mid, @start, @end, @basic, @env, @msc, @before, @tax, @total, @due);", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@mid", meterId);
                            cmd.Parameters.AddWithValue("@start", bStart);
                            cmd.Parameters.AddWithValue("@end", bEnd);
                            cmd.Parameters.AddWithValue("@basic", bBasic);
                            cmd.Parameters.AddWithValue("@env", bEnv);
                            cmd.Parameters.AddWithValue("@msc", bMsc);
                            cmd.Parameters.AddWithValue("@before", bBefore);
                            cmd.Parameters.AddWithValue("@tax", bTax);
                            cmd.Parameters.AddWithValue("@total", bTotal);
                            cmd.Parameters.AddWithValue("@due", bDue);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
            }
            _seeded = true;
        }

        private void LoadGrid()
        {
            using (SqlConnection con = new SqlConnection(DbConn))
            using (SqlDataAdapter da = new SqlDataAdapter(GridSql, con))
            {
                DataTable table = new DataTable();
                da.Fill(table);
                dgvBills.DataSource = table;
                if (dgvBills.Columns.Contains("Payment ID"))
                    dgvBills.Columns["Payment ID"].Visible = false;
            }
        }

    
        private void SetupSortingControls()
        {
            
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[]
            {
                "Bubble Sort",
                "Selection Sort",
                "Insertion Sort",
                "Merge Sort",
                "Quick Sort"
            });
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

   
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new object[] { "Ascending", "Descending" });
            comboBox4.SelectedIndex = 0;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

       
            comboBox3.Items.Clear();
            foreach (DataGridViewColumn col in dgvBills.Columns)
            {
                if (col.Visible)
                    comboBox3.Items.Add(col.HeaderText);
            }
            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            
            comboBox2.Visible = false;
        }

      
        private bool ComputeBill()
        {
            if (string.IsNullOrWhiteSpace(txtSOA.Text) ||
                string.IsNullOrWhiteSpace(txtCAN.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                Warn("Please enter the SOA #, Contract Account No., and Account Name.");
                return false;
            }

            if (!decimal.TryParse(txtPresent.Text, out presentReading) ||
                !decimal.TryParse(txtPrevious.Text, out previousReading))
            {
                Warn("Present and Previous Reading must be numbers.");
                return false;
            }

            if (presentReading < previousReading)
            {
                Warn("Present Reading cannot be less than Previous Reading.");
                return false;
            }

            consumption = presentReading - previousReading;
            basic = Math.Round(consumption * RatePerCuM, 2);
            env = Math.Round(basic * EnvPercent, 2);
            beforeTax = basic + env + MSC;
            tax = Math.Round(beforeTax * TaxPercent, 2);
            total = beforeTax + tax;
            return true;
        }

        private void ShowBill()
        {
            txtConsumption.Text = consumption.ToString("0.00");
            lblPeriodEnd.Text = dtpRead.Value.ToString("MM/dd/yyyy");
            lblBasic.Text = basic.ToString("N2");
            lblEnv.Text = env.ToString("N2");
            lblMSC.Text = MSC.ToString("N2");
            lblBefore.Text = beforeTax.ToString("N2");
            lblTax.Text = tax.ToString("N2");
            lblTotal.Text = "PHP " + total.ToString("N2");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (!ComputeBill()) return;
            ShowBill();

            Dictionary<string, string> d = new Dictionary<string, string>
            {
                { "SOA", txtSOA.Text.Trim() },
                { "CAN", txtCAN.Text.Trim() },
                { "Name", txtName.Text.Trim() },
                { "Address", txtAddress.Text.Trim() },
                { "TIN", txtTIN.Text.Trim() },
                { "Rate", cboRate.SelectedItem.ToString() },
                { "Biz", txtBizArea.Text.Trim() },
                { "Month", dtpRead.Value.ToString("MMMM yyyy") },
                { "Meter", txtMeter.Text.Trim() },
                { "MRU", txtMRU.Text.Trim() },
                { "Seq", txtSeq.Text.Trim() },
                { "ReadDate", dtpRead.Value.ToString("MM/dd/yyyy") },
                { "Present", presentReading.ToString("0.00") },
                { "Previous", previousReading.ToString("0.00") },
                { "Consumption", consumption.ToString("0.00") },
                { "PeriodFrom", dtpFrom.Value.ToString("MM/dd/yyyy") },
                { "PeriodTo", dtpRead.Value.ToString("MM/dd/yyyy") },
                { "Basic", basic.ToString("N2") },
                { "Env", env.ToString("N2") },
                { "MSC", MSC.ToString("N2") },
                { "Before", beforeTax.ToString("N2") },
                { "Tax", tax.ToString("N2") },
                { "Total", total.ToString("N2") },
                { "DueDate", dtpDue.Value.ToString("MM/dd/yyyy") }
            };

            using (BillForm form = new BillForm(d))
            {
                form.ShowDialog(this);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ComputeBill()) return;
            ShowBill();

            try
            {
                using (SqlConnection con = new SqlConnection(DbConn))
                {
                    con.Open();
                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        int customerId;
                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO customerInfoTbl (soaNumber, contractAccountNo, customerName, serviceAddress, tin, rateClass, businessArea)
                              VALUES (@soa, @can, @name, @addr, @tin, @rate, @biz);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@soa", txtSOA.Text.Trim());
                            cmd.Parameters.AddWithValue("@can", txtCAN.Text.Trim());
                            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@tin", txtTIN.Text.Trim());
                            cmd.Parameters.AddWithValue("@rate", cboRate.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@biz", txtBizArea.Text.Trim());
                            customerId = (int)cmd.ExecuteScalar();
                        }

                        int meterId;
                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO meterTbl (customerID, meterNo, mruNo, seqNo, readingDate, presentReading, previousReading, consumption)
                              VALUES (@cid, @meter, @mru, @seq, @read, @pres, @prev, @cons);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@cid", customerId);
                            cmd.Parameters.AddWithValue("@meter", txtMeter.Text.Trim());
                            cmd.Parameters.AddWithValue("@mru", txtMRU.Text.Trim());
                            cmd.Parameters.AddWithValue("@seq", txtSeq.Text.Trim());
                            cmd.Parameters.AddWithValue("@read", dtpRead.Value.Date);
                            cmd.Parameters.AddWithValue("@pres", presentReading);
                            cmd.Parameters.AddWithValue("@prev", previousReading);
                            cmd.Parameters.AddWithValue("@cons", consumption);
                            meterId = (int)cmd.ExecuteScalar();
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO paymentTbl (meterID, billingStart, billingEnd, basicCharge, environmentalCharge, maintenanceCharge, totalBeforeTaxes, governmentTaxes, totalAmountDue, paymentDueDate)
                              VALUES (@mid, @start, @end, @basic, @env, @msc, @before, @tax, @total, @due);", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@mid", meterId);
                            cmd.Parameters.AddWithValue("@start", dtpFrom.Value.Date);
                            cmd.Parameters.AddWithValue("@end", dtpRead.Value.Date);
                            cmd.Parameters.AddWithValue("@basic", basic);
                            cmd.Parameters.AddWithValue("@env", env);
                            cmd.Parameters.AddWithValue("@msc", MSC);
                            cmd.Parameters.AddWithValue("@before", beforeTax);
                            cmd.Parameters.AddWithValue("@tax", tax);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@due", dtpDue.Value.Date);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                LoadGrid();
                SetupSortingControls();
                MessageBox.Show("The bill is saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save bill.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int paymentId = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["Payment ID"].Value);
            ShowSavedBill(paymentId);
        }

        private void ShowSavedBill(int paymentId)
        {
            const string sql = @"
                SELECT c.soaNumber, c.contractAccountNo, c.customerName, c.serviceAddress,
                       c.tin, c.rateClass, c.businessArea,
                       m.meterNo, m.mruNo, m.seqNo, m.readingDate,
                       m.presentReading, m.previousReading, m.consumption,
                       p.billingStart, p.billingEnd, p.basicCharge, p.environmentalCharge,
                       p.maintenanceCharge, p.totalBeforeTaxes, p.governmentTaxes,
                       p.totalAmountDue, p.paymentDueDate
                FROM paymentTbl p
                INNER JOIN meterTbl m ON p.meterID = m.meterID
                INNER JOIN customerInfoTbl c ON m.customerID = c.customerID
                WHERE p.paymentID = @id;";

            try
            {
                using (SqlConnection con = new SqlConnection(DbConn))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", paymentId);
                    con.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            Warn("Could not find the bill.");
                            return;
                        }

                        DateTime readDate = Convert.ToDateTime(r["readingDate"]);

                        Dictionary<string, string> d = new Dictionary<string, string>
                        {
                            { "SOA", r["soaNumber"].ToString() },
                            { "CAN", r["contractAccountNo"].ToString() },
                            { "Name", r["customerName"].ToString() },
                            { "Address", r["serviceAddress"].ToString() },
                            { "TIN", r["tin"].ToString() },
                            { "Rate", r["rateClass"].ToString() },
                            { "Biz", r["businessArea"].ToString() },
                            { "Month", readDate.ToString("MMMM yyyy") },
                            { "Meter", r["meterNo"].ToString() },
                            { "MRU", r["mruNo"].ToString() },
                            { "Seq", r["seqNo"].ToString() },
                            { "ReadDate", readDate.ToString("MM/dd/yyyy") },
                            { "Present", Convert.ToDecimal(r["presentReading"]).ToString("0.00") },
                            { "Previous", Convert.ToDecimal(r["previousReading"]).ToString("0.00") },
                            { "Consumption", Convert.ToDecimal(r["consumption"]).ToString("0.00") },
                            { "PeriodFrom", Convert.ToDateTime(r["billingStart"]).ToString("MM/dd/yyyy") },
                            { "PeriodTo", Convert.ToDateTime(r["billingEnd"]).ToString("MM/dd/yyyy") },
                            { "Basic", Convert.ToDecimal(r["basicCharge"]).ToString("N2") },
                            { "Env", Convert.ToDecimal(r["environmentalCharge"]).ToString("N2") },
                            { "MSC", Convert.ToDecimal(r["maintenanceCharge"]).ToString("N2") },
                            { "Before", Convert.ToDecimal(r["totalBeforeTaxes"]).ToString("N2") },
                            { "Tax", Convert.ToDecimal(r["governmentTaxes"]).ToString("N2") },
                            { "Total", Convert.ToDecimal(r["totalAmountDue"]).ToString("N2") },
                            { "DueDate", Convert.ToDateTime(r["paymentDueDate"]).ToString("MM/dd/yyyy") }
                        };

                        using (BillForm form = new BillForm(d))
                        {
                            form.ShowDialog(this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not display the bill.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnBubble_Click(object sender, EventArgs e) { comboBox1.SelectedItem = "Bubble Sort"; }
        private void btnSelection_Click(object sender, EventArgs e) { comboBox1.SelectedItem = "Selection Sort"; }
        private void btnInsertion_Click(object sender, EventArgs e) { comboBox1.SelectedItem = "Insertion Sort"; }
        private void btnQuick_Click(object sender, EventArgs e) { comboBox1.SelectedItem = "Quick Sort"; }

        private void btnSort_Click_Click(object sender, EventArgs e)
        {
            
            object source = dgvBills.DataSource;
            if (source == null)
            {
                Warn("No records found.");
                return;
            }

            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                Warn("Please choose algorithm, sort field and sort order.");
                return;
            }

            
            BindingSource bs = source as BindingSource;
            if (bs == null)
            {
                bs = new BindingSource();
                bs.DataSource = source;
                dgvBills.DataSource = bs;
            }

            
            List<object> records = new List<object>();
            foreach (var item in bs.List)
            {
                records.Add(item);
            }

            if (records.Count == 0) return;

            string column = comboBox3.SelectedItem.ToString();
            PropertyDescriptor property = TypeDescriptor.GetProperties(records[0]).Find(column, true);

            if (property == null)
            {
                Warn("Sorting field not found: " + column);
                return;
            }

            Comparison<object> compare = (a, b) =>
            {
                object x = property.GetValue(a);
                object y = property.GetValue(b);
                if (x == null || x == DBNull.Value) return (y == null || y == DBNull.Value) ? 0 : -1;
                if (y == null || y == DBNull.Value) return 1;
                return Comparer.DefaultInvariant.Compare(x, y);
            };

            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Bubble Sort": BubbleSort(records, compare); break;
                case "Selection Sort": SelectionSort(records, compare); break;
                case "Insertion Sort": InsertionSort(records, compare); break;
                case "Merge Sort": MergeSort(records, 0, records.Count - 1, compare); break;
                case "Quick Sort": QuickSort(records, 0, records.Count - 1, compare); break;
            }

          
            if (comboBox4.SelectedItem.ToString() == "Descending")
            {
                records.Reverse();
            }

            bs.DataSource = records;
            dgvBills.DataSource = bs;
        }

        private void BubbleSort(List<object> records, Comparison<object> compare)
        {
            int n = records.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (compare(records[j], records[j + 1]) > 0)
                    {
                        object temp = records[j];
                        records[j] = records[j + 1];
                        records[j + 1] = temp;
                    }
        }

        private void SelectionSort(List<object> records, Comparison<object> compare)
        {
            int n = records.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                    if (compare(records[j], records[min]) < 0)
                        min = j;
                object temp = records[i];
                records[i] = records[min];
                records[min] = temp;
            }
        }

        private void InsertionSort(List<object> records, Comparison<object> compare)
        {
            for (int i = 1; i < records.Count; i++)
            {
                object key = records[i];
                int j = i - 1;
                while (j >= 0 && compare(records[j], key) > 0)
                {
                    records[j + 1] = records[j];
                    j--;
                }
                records[j + 1] = key;
            }
        }

        private void MergeSort(List<object> records, int left, int right, Comparison<object> compare)
        {
            if (left >= right) return;
            int mid = left + (right - left) / 2;
            MergeSort(records, left, mid, compare);
            MergeSort(records, mid + 1, right, compare);
            object[] temp = new object[right - left + 1];
            int i = left, j = mid + 1, k = 0;
            while (i <= mid && j <= right)
            {
                if (compare(records[i], records[j]) <= 0) temp[k++] = records[i++];
                else temp[k++] = records[j++];
            }
            while (i <= mid) temp[k++] = records[i++];
            while (j <= right) temp[k++] = records[j++];
            for (int x = 0; x < temp.Length; x++) records[left + x] = temp[x];
        }

        private void QuickSort(List<object> records, int low, int high, Comparison<object> compare)
        {
            if (low >= high) return;
            int pivotIndex = Partition(records, low, high, compare);
            QuickSort(records, low, pivotIndex - 1, compare);
            QuickSort(records, pivotIndex + 1, high, compare);
        }

        private int Partition(List<object> records, int low, int high, Comparison<object> compare)
        {
            object pivot = records[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (compare(records[j], pivot) <= 0)
                {
                    i++;
                    object temp = records[i];
                    records[i] = records[j];
                    records[j] = temp;
                }
            }
            object swap = records[i + 1];
            records[i + 1] = records[high];
            records[high] = swap;
            return i + 1;
        }


        private void Warn(string message)
        {
            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    
        private void txtConsumption_TextChanged(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}