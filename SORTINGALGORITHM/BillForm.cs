using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SORTINGALGORITHM
{
    public class BillForm : Form
    {
        int y;

        public BillForm(Dictionary<string, string> d)
        {
            Text = "Water Bill - " + d["CAN"];
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.FromArgb(160, 25, 40) };
            PictureBox logo = new PictureBox
            {
                Location = new Point(14, 12),
                Size = new Size(56, 56),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maynilad_logo.png");
            if (File.Exists(logoPath))
            {
                logo.Image = Image.FromFile(logoPath);
            }
            header.Controls.Add(logo);
            header.Controls.Add(new Label
            {
                Text = "MAYNILAD WATER SERVICES",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(80, 24)
            });
            Controls.Add(header);

            y = 90;
            Controls.Add(new Label
            {
                Text = "Maynilad Water Services, Inc.\r\n8390 DR A SANTOS AVE BF HOMES, PARANAQUE CITY\r\nVAT Reg TIN 005-393-442-0000",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(20, y),
                Size = new Size(520, 48)
            });
            y += 56;

            Controls.Add(new Label
            {
                Text = "STATEMENT OF ACCOUNT",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(0, y),
                Size = new Size(560, 26),
                TextAlign = ContentAlignment.MiddleCenter
            });
            y += 26;

            Controls.Add(new Label
            {
                Text = "For the Month of: " + d["Month"],
                Location = new Point(0, y),
                Size = new Size(560, 20),
                TextAlign = ContentAlignment.MiddleCenter
            });
            y += 30;

            
            AddSection("SERVICE INFORMATION");
            AddRow("SOA #:", d["SOA"]);
            AddRow("Contract Account No:", d["CAN"], true);
            AddRow("Account Name:", d["Name"]);
            AddRow("Service Address:", d["Address"]);
            AddRow("TIN:", d["TIN"]);
            AddRow("Rate Class:", d["Rate"]);
            AddRow("Business Area:", d["Biz"]);

           
            AddSection("METERING INFORMATION");
            AddRow("Meter No:", d["Meter"]);
            AddRow("MRU No:", d["MRU"]);
            AddRow("Seq No:", d["Seq"]);
            AddRow("Reading Date:", d["ReadDate"]);
            AddRow("Present Reading:", d["Present"]);
            AddRow("Previous Reading:", d["Previous"]);
            AddRow("Consumption (cu.m):", d["Consumption"]);

         
            AddSection("BILLING SUMMARY");
            AddRow("Billing Period:", d["PeriodFrom"] + "  TO  " + d["PeriodTo"]);
            AddRow("Basic Charge (23.52 x consumption):", d["Basic"], false, true);
            AddRow("Environmental Charges (20% of Basic):", d["Env"], false, true);
            AddRow("Maintenance Service Charge (MSC):", d["MSC"], false, true);
            AddRow("Total Charges Before Taxes:", d["Before"], false, true);
            AddRow("Government Taxes (2.5%):", d["Tax"], false, true);
            AddDivider();
            AddRow("TOTAL AMOUNT DUE:", "PHP " + d["Total"], true, true);
            AddRow("PAYMENT DUE DATE:", d["DueDate"], true, true);

       
            AddSection("BILL & PAYMENT HISTORY");
            Controls.Add(new Label
            {
                Text = "Description: WB-Water Bill, GD-Guarantee Deposit, MISC-Reopening Fee, Connection Fee, Metering Charge",
                Location = new Point(24, y),
                Size = new Size(510, 20)
            });
            y += 26;
            Controls.Add(new Label
            {
                Text = "No payments recorded yet.",
                Location = new Point(24, y),
                AutoSize = true
            });
            y += 30;

         
           

            Button close = new Button
            {
                Text = "CLOSE",
                Location = new Point(410, y),
                Size = new Size(120, 34),
                BackColor = Color.FromArgb(160, 25, 40),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            close.Click += (s, e) => Close();
            Controls.Add(close);

            ClientSize = new Size(560, y + 50);
        }

        void AddSection(string title)
        {
            y += 8;
            Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(20, y),
                AutoSize = true
            });
            y += 26;
            AddDivider();
        }

        void AddDivider()
        {
            Controls.Add(new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(20, y),
                Size = new Size(520, 2)
            });
            y += 8;
        }

     
        void AddRow(string caption, string value, bool bold = false, bool right = false)
        {
            FontStyle style = bold ? FontStyle.Bold : FontStyle.Regular;

            Controls.Add(new Label
            {
                Text = caption,
                Font = new Font("Segoe UI", 9F, style),
                Location = new Point(24, y),
                Size = new Size(right ? 300 : 230, 20)
            });

            Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 9F, style),
                Location = right ? new Point(330, y) : new Point(260, y),
                Size = right ? new Size(206, 20) : new Size(276, 20),
                TextAlign = right ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft
            });

            y += 22;
        }
    }
}