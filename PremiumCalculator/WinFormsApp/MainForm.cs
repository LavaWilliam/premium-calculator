namespace WinFormsApp
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using PremiumCalculator.Core;
    using PremiumCalculator.Core.Models;
    using PremiumCalculator.Core.Validators;

    public partial class MainForm : Form
    {
        private enum EditMode
        {
            Policy = 0,
            Driver = 1,
        }

        private EditMode editMode = EditMode.Driver;
        private Driver currentDriver = null;
        private Calculator premiumCalculator = null;

        public MainForm()
        {
            this.InitializeComponent();
            this.resultTextLabel.Text = string.Empty;
            this.ChangeMode();

            this.premiumCalculator = new Calculator()
            {
                StartingPoint = 500M
            };

            this.premiumCalculator.Validate += Validators.ValidateDriverClaimCount;
            this.premiumCalculator.Validate += Validators.ValidateStartDate;
            this.premiumCalculator.Validate += Validators.DriverIsChauffeur;
            this.premiumCalculator.Validate += Validators.DriverIsAccountant;
            this.premiumCalculator.Validate += Validators.ValidateAgeYoungestDriver;
            this.premiumCalculator.Validate += Validators.ValidateAgeOldestDriver;
            this.premiumCalculator.Validate += Validators.ValidatePreviousClaims;
        }

        private void AddDriverButtonClick(object sender, EventArgs e)
        {
            this.ChangeMode();
        }

        private void CalculateButtonClick(object sender, EventArgs e)
        {
            var details = new PolicyDetails()
            {
                StartDate = this.startDateTimePicker.Value.Date,
                Drivers = this.driversList.Items.OfType<Driver>()
            };

            this.premiumCalculator.CalculatePremium(details);

            if (details.IsApproved)
            {
                this.resultTextLabel.Text = $"Approved: Premium is £ {details.Premium.ToString("0.00")}";
            }
            else
            {
                this.resultTextLabel.Text = $"Declined: {details.ReasonDeclined}";
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.ChangeMode();
        }

        private void ChangeMode()
        {
            this.SuspendLayout();

            if (this.editMode == EditMode.Policy)
            {
                this.editMode = EditMode.Driver;

                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }

                this.driverGroupBox.Enabled = true;

                foreach (Control control in this.driverGroupBox.Controls)
                {
                    control.Enabled = true;
                    if (control is TextBox)
                    {
                        ((TextBox)control).Text = string.Empty;
                    }
                }
            }
            else
            {
                this.editMode = EditMode.Policy;

                foreach (Control control in this.driverGroupBox.Controls)
                {
                    control.Enabled = false;
                    if (control is TextBox)
                    {
                        ((TextBox)control).Text = string.Empty;
                    }
                }

                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }

                this.driverGroupBox.Enabled = false;
                this.editButton.Enabled = false;
                this.deleteButton.Enabled = false;

                this.driversList.ClearSelected();
            }

            this.ResumeLayout();
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            this.startDateTimePicker.Value = DateTime.Now.Date;
            this.driversList.Items.Clear();
            this.resultTextLabel.Text = string.Empty;
        }

        private void DateTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)
                || e.KeyChar == '/' || e.KeyChar == '-'
                || e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            e.Handled = true;
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (this.driversList.SelectedIndices.Count > 0)
            {
                foreach (var driver in new List<Driver>(this.driversList.SelectedItems.Cast<Driver>()))
                {
                    this.driversList.Items.Remove(driver);
                }
            }
        }

        private void DriversListSelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.driversList.SelectedIndices.Count;

            this.deleteButton.Enabled = count > 0;
            this.editButton.Enabled = count == 1;
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            if (this.driversList.SelectedIndices.Count == 1)
            {
                this.currentDriver = this.driversList.SelectedItems[0] as Driver;

                if (this.currentDriver != null)
                {
                    this.ChangeMode();

                    this.nameTextBox.Text = this.currentDriver.Name;
                    this.occupationTextBox.Text = this.currentDriver.Occupation;
                    this.dateOfBirthTextBox.Text = this.currentDriver.DateOfBirth.ToString("dd/MM/yyyy");

                    if (this.currentDriver.PreviousClaims != null)
                    {
                        int index = 0;
                        foreach (var claim in this.currentDriver.PreviousClaims.OrderBy(x => x.ClaimDate))
                        {
                            ++index;
                            string controlName = $"previousClaim{index.ToString()}";
                            var controls = this.driverGroupBox.Controls.Find(controlName, false);
                            if ((controls?.Count() ?? 0) == 1)
                            {
                                ((TextBox)controls[0]).Text = claim.ClaimDate.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
            }
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateButtonClick(object sender, EventArgs e)
        {
            this.ClearButtonClick(sender, e);

            Driver[] data = new Driver[]
            {
                new Driver()
                {
                    Name = "William Orr",
                    Occupation = "Software Developer",
                    DateOfBirth = new DateTime(1962, 6, 21),
                },

                new Driver()
                {
                    Name = "Margaret Orr",
                    Occupation = "Accountant",
                    DateOfBirth = new DateTime(1962, 12, 21),
                    PreviousClaims = new Claim[]
                    {
                        new Claim() { ClaimDate = DateTime.Now.AddMonths(-14).Date }
                    }
                },

                new Driver()
                {
                    Name = "Lisa Young",
                    Occupation = "Student",
                    DateOfBirth = DateTime.Now.AddYears(-19).AddDays(19).Date
                },

                new Driver()
                {
                    Name = "Old Man John",
                    Occupation = "Retired",
                    DateOfBirth = DateTime.Now.AddYears(-75).AddDays(-40).Date,
                    PreviousClaims = new Claim[]
                    {
                        new Claim() { ClaimDate = DateTime.Now.AddYears(-2).Date },
                        new Claim() { ClaimDate = DateTime.Now.AddYears(-2).AddDays(-50).Date },
                        new Claim() { ClaimDate = DateTime.Now.AddYears(-6).AddMonths(5).Date }
                    }
                },

                new Driver()
                {
                    Name = "Frank Driver",
                    Occupation = "Chauffeur",
                    DateOfBirth = DateTime.Now.AddYears(-42).AddDays(127).Date
                }
            };

            this.driversList.Items.AddRange(data);
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            string name = this.nameTextBox.Text?.Trim();
            string occupation = this.occupationTextBox.Text?.Trim();
            string dobString = this.dateOfBirthTextBox.Text?.Trim();

            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(occupation)
                || string.IsNullOrEmpty(dobString))
            {
                MessageBox.Show("Name, occupation and date of birth fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dob = DateTime.MinValue;
            if (!DateTime.TryParse(dobString, out dob))
            {
                MessageBox.Show("Date of birth field is not a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DateTime> claimDates = new List<DateTime>();
            foreach (TextBox textBox in this.driverGroupBox.Controls
                .OfType<TextBox>()
                .Where(x => x.Name.StartsWith("previousClaim"))
                .OrderBy(x => x.Name))
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    DateTime value = DateTime.MinValue;
                    if (DateTime.TryParse(textBox.Text, out value)
                        && value > DateTime.MinValue)
                    {
                        claimDates.Add(value);
                    }
                    else
                    {
                        MessageBox.Show("One or more claim dates are not valid dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.SuspendLayout();

            if (this.currentDriver == null)
            {
                this.currentDriver = new Driver();
                this.driversList.Items.Add(this.currentDriver);
            }

            this.currentDriver.Name = name;
            this.currentDriver.Occupation = occupation;
            this.currentDriver.DateOfBirth = dob;
            this.currentDriver.PreviousClaims = claimDates
                .Select(x => new Claim() { ClaimDate = x });

            // To force the list to re-evaluate object's ToString() method.
            this.driversList.Items[this.driversList.Items.IndexOf(this.currentDriver)] = this.currentDriver;

            this.ChangeMode();
        }
    }
}
