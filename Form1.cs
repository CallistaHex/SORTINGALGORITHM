        private void Displaywaterbillbutt_Click(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count == 0)
            {
                Warn("Please select a water bill from the list.");
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dgvBills.SelectedRows[0];
                
                // Get values from the selected grid row
                string soaNumber = selectedRow.Cells["SOA Number"].Value.ToString();
                string customerName = selectedRow.Cells["Customer Name"].Value.ToString();
                string serviceAddress = selectedRow.Cells["Customer Address"].Value.ToString();
                string meterNo = selectedRow.Cells["Meter No"].Value.ToString();
                DateTime readingDate = (DateTime)selectedRow.Cells["Reading Date"].Value;
                decimal consumptionValue = Convert.ToDecimal(selectedRow.Cells["Consumption (cu.m)"].Value);
                DateTime billingStart = (DateTime)selectedRow.Cells["Billing Start"].Value;
                DateTime billingEnd = (DateTime)selectedRow.Cells["Billing End"].Value;
                decimal totalAmount = Convert.ToDecimal(selectedRow.Cells["Total Amount Due"].Value);
                DateTime paymentDueDate = (DateTime)selectedRow.Cells["Payment Due Date"].Value;

                // Fetch additional details from the database
                using (SqlConnection con = new SqlConnection(DbConn))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT c.contractAccountNo, c.tin, c.rateClass, c.businessArea, 
                                 m.mruNo, m.seqNo, m.presentReading, m.previousReading,
                                 p.basicCharge, p.environmentalCharge, p.maintenanceCharge,
                                 p.totalBeforeTaxes, p.governmentTaxes
                          FROM paymentTbl p
                          INNER JOIN meterTbl m ON p.meterID = m.meterID
                          INNER JOIN customerInfoTbl c ON m.customerID = c.customerID
                          WHERE c.soaNumber = @soa AND m.readingDate = @readDate
                          ORDER BY p.paymentID DESC;", con))
                    {
                        cmd.Parameters.AddWithValue("@soa", soaNumber);
                        cmd.Parameters.AddWithValue("@readDate", readingDate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate service information
                                txtSOA.Text = soaNumber;
                                txtCAN.Text = reader["contractAccountNo"].ToString();
                                txtName.Text = customerName;
                                txtAddress.Text = serviceAddress;
                                txtTIN.Text = reader["tin"].ToString();
                                cboRate.SelectedItem = reader["rateClass"].ToString();
                                txtBizArea.Text = reader["businessArea"].ToString();

                                // Populate metering information
                                txtMeter.Text = meterNo;
                                txtMRU.Text = reader["mruNo"].ToString();
                                txtSeq.Text = reader["seqNo"].ToString();
                                dtpRead.Value = readingDate;
                                
                                decimal presentRead = Convert.ToDecimal(reader["presentReading"]);
                                decimal previousRead = Convert.ToDecimal(reader["previousReading"]);
                                txtPresent.Text = presentRead.ToString("0.00");
                                txtPrevious.Text = previousRead.ToString("0.00");
                                txtConsumption.Text = consumptionValue.ToString("0.00");

                                // Populate billing information
                                dtpFrom.Value = billingStart;
                                lblPeriodEnd.Text = billingEnd.ToString("MM/dd/yyyy");
                                
                                lblBasic.Text = Convert.ToDecimal(reader["basicCharge"]).ToString("N2");
                                lblEnv.Text = Convert.ToDecimal(reader["environmentalCharge"]).ToString("N2");
                                lblMSC.Text = Convert.ToDecimal(reader["maintenanceCharge"]).ToString("N2");
                                lblBefore.Text = Convert.ToDecimal(reader["totalBeforeTaxes"]).ToString("N2");
                                lblTax.Text = Convert.ToDecimal(reader["governmentTaxes"]).ToString("N2");
                                lblTotal.Text = "PHP " + totalAmount.ToString("N2");
                                dtpDue.Value = paymentDueDate;

                                MessageBox.Show("Water bill displayed successfully.", "Success", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Warn("Could not find the detailed bill information.");
                            }
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
