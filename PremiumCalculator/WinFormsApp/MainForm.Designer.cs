namespace WinFormsApp
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
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.driversLabel = new System.Windows.Forms.Label();
            this.driversList = new System.Windows.Forms.ListBox();
            this.addDriverButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTextLabel = new System.Windows.Forms.Label();
            this.driverGroupBox = new System.Windows.Forms.GroupBox();
            this.previousClaimDatesLabel = new System.Windows.Forms.Label();
            this.previousClaim5 = new System.Windows.Forms.TextBox();
            this.previousClaim4 = new System.Windows.Forms.TextBox();
            this.previousClaim3 = new System.Windows.Forms.TextBox();
            this.previousClaim2 = new System.Windows.Forms.TextBox();
            this.previousClaim1 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dateOfBirthLabel = new System.Windows.Forms.Label();
            this.occupationLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.dateOfBirthTextBox = new System.Windows.Forms.TextBox();
            this.occupationTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.populateButton = new System.Windows.Forms.Button();
            this.driverGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(27, 19);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(58, 13);
            this.startDateLabel.TabIndex = 0;
            this.startDateLabel.Text = "Start Date";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(88, 15);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.startDateTimePicker.TabIndex = 1;
            // 
            // driversLabel
            // 
            this.driversLabel.AutoSize = true;
            this.driversLabel.Location = new System.Drawing.Point(27, 58);
            this.driversLabel.Name = "driversLabel";
            this.driversLabel.Size = new System.Drawing.Size(45, 13);
            this.driversLabel.TabIndex = 2;
            this.driversLabel.Text = "Drivers:";
            // 
            // driversList
            // 
            this.driversList.FormattingEnabled = true;
            this.driversList.Location = new System.Drawing.Point(30, 74);
            this.driversList.Name = "driversList";
            this.driversList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.driversList.Size = new System.Drawing.Size(459, 121);
            this.driversList.TabIndex = 3;
            this.driversList.SelectedIndexChanged += new System.EventHandler(this.DriversListSelectedIndexChanged);
            // 
            // addDriverButton
            // 
            this.addDriverButton.Location = new System.Drawing.Point(495, 74);
            this.addDriverButton.Name = "addDriverButton";
            this.addDriverButton.Size = new System.Drawing.Size(75, 23);
            this.addDriverButton.TabIndex = 4;
            this.addDriverButton.Text = "Add";
            this.addDriverButton.UseVisualStyleBackColor = true;
            this.addDriverButton.Click += new System.EventHandler(this.AddDriverButtonClick);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(495, 170);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(495, 229);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButtonClick);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(30, 212);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(42, 13);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.Text = "Result:";
            // 
            // resultTextLabel
            // 
            this.resultTextLabel.BackColor = System.Drawing.SystemColors.Window;
            this.resultTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.resultTextLabel.Location = new System.Drawing.Point(30, 229);
            this.resultTextLabel.Name = "resultTextLabel";
            this.resultTextLabel.Size = new System.Drawing.Size(459, 23);
            this.resultTextLabel.TabIndex = 8;
            this.resultTextLabel.Text = "PROGRAMATICALLY DISPLAYED CALCULATION RESULT";
            this.resultTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // driverGroupBox
            // 
            this.driverGroupBox.Controls.Add(this.previousClaimDatesLabel);
            this.driverGroupBox.Controls.Add(this.previousClaim5);
            this.driverGroupBox.Controls.Add(this.previousClaim4);
            this.driverGroupBox.Controls.Add(this.previousClaim3);
            this.driverGroupBox.Controls.Add(this.previousClaim2);
            this.driverGroupBox.Controls.Add(this.previousClaim1);
            this.driverGroupBox.Controls.Add(this.saveButton);
            this.driverGroupBox.Controls.Add(this.cancelButton);
            this.driverGroupBox.Controls.Add(this.dateOfBirthLabel);
            this.driverGroupBox.Controls.Add(this.occupationLabel);
            this.driverGroupBox.Controls.Add(this.nameLabel);
            this.driverGroupBox.Controls.Add(this.dateOfBirthTextBox);
            this.driverGroupBox.Controls.Add(this.occupationTextBox);
            this.driverGroupBox.Controls.Add(this.nameTextBox);
            this.driverGroupBox.Location = new System.Drawing.Point(585, 19);
            this.driverGroupBox.Name = "driverGroupBox";
            this.driverGroupBox.Size = new System.Drawing.Size(245, 351);
            this.driverGroupBox.TabIndex = 9;
            this.driverGroupBox.TabStop = false;
            this.driverGroupBox.Text = "Driver Details";
            // 
            // previousClaimDatesLabel
            // 
            this.previousClaimDatesLabel.AutoSize = true;
            this.previousClaimDatesLabel.Location = new System.Drawing.Point(76, 152);
            this.previousClaimDatesLabel.Name = "previousClaimDatesLabel";
            this.previousClaimDatesLabel.Size = new System.Drawing.Size(113, 13);
            this.previousClaimDatesLabel.TabIndex = 13;
            this.previousClaimDatesLabel.Text = "Previous claim dates:";
            // 
            // previousClaim5
            // 
            this.previousClaim5.Location = new System.Drawing.Point(79, 280);
            this.previousClaim5.Name = "previousClaim5";
            this.previousClaim5.Size = new System.Drawing.Size(160, 22);
            this.previousClaim5.TabIndex = 12;
            this.previousClaim5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBoxKeyPress);
            // 
            // previousClaim4
            // 
            this.previousClaim4.Location = new System.Drawing.Point(79, 252);
            this.previousClaim4.Name = "previousClaim4";
            this.previousClaim4.Size = new System.Drawing.Size(160, 22);
            this.previousClaim4.TabIndex = 11;
            this.previousClaim4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBoxKeyPress);
            // 
            // previousClaim3
            // 
            this.previousClaim3.Location = new System.Drawing.Point(79, 224);
            this.previousClaim3.Name = "previousClaim3";
            this.previousClaim3.Size = new System.Drawing.Size(160, 22);
            this.previousClaim3.TabIndex = 10;
            this.previousClaim3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBoxKeyPress);
            // 
            // previousClaim2
            // 
            this.previousClaim2.Location = new System.Drawing.Point(79, 196);
            this.previousClaim2.Name = "previousClaim2";
            this.previousClaim2.Size = new System.Drawing.Size(160, 22);
            this.previousClaim2.TabIndex = 9;
            this.previousClaim2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBoxKeyPress);
            // 
            // previousClaim1
            // 
            this.previousClaim1.Location = new System.Drawing.Point(79, 168);
            this.previousClaim1.Name = "previousClaim1";
            this.previousClaim1.Size = new System.Drawing.Size(160, 22);
            this.previousClaim1.TabIndex = 8;
            this.previousClaim1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBoxKeyPress);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(128, 319);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(35, 319);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Location = new System.Drawing.Point(6, 118);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(73, 13);
            this.dateOfBirthLabel.TabIndex = 5;
            this.dateOfBirthLabel.Text = "Date of Birth";
            // 
            // occupationLabel
            // 
            this.occupationLabel.AutoSize = true;
            this.occupationLabel.Location = new System.Drawing.Point(6, 80);
            this.occupationLabel.Name = "occupationLabel";
            this.occupationLabel.Size = new System.Drawing.Size(67, 13);
            this.occupationLabel.TabIndex = 4;
            this.occupationLabel.Text = "Occupation";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 42);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(36, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            // 
            // dateOfBirthTextBox
            // 
            this.dateOfBirthTextBox.Location = new System.Drawing.Point(79, 115);
            this.dateOfBirthTextBox.Name = "dateOfBirthTextBox";
            this.dateOfBirthTextBox.Size = new System.Drawing.Size(160, 22);
            this.dateOfBirthTextBox.TabIndex = 2;
            this.dateOfBirthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBoxKeyPress);
            // 
            // occupationTextBox
            // 
            this.occupationTextBox.Location = new System.Drawing.Point(79, 77);
            this.occupationTextBox.Name = "occupationTextBox";
            this.occupationTextBox.Size = new System.Drawing.Size(160, 22);
            this.occupationTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(79, 39);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(160, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(495, 338);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(495, 138);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(495, 106);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 12;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButtonClick);
            // 
            // populateButton
            // 
            this.populateButton.Location = new System.Drawing.Point(495, 15);
            this.populateButton.Name = "populateButton";
            this.populateButton.Size = new System.Drawing.Size(75, 23);
            this.populateButton.TabIndex = 13;
            this.populateButton.Text = "Populate";
            this.populateButton.UseVisualStyleBackColor = true;
            this.populateButton.Click += new System.EventHandler(this.PopulateButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 387);
            this.Controls.Add(this.populateButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.driverGroupBox);
            this.Controls.Add(this.resultTextLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addDriverButton);
            this.Controls.Add(this.driversList);
            this.Controls.Add(this.driversLabel);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.startDateLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Premium Calculator Test";
            this.driverGroupBox.ResumeLayout(false);
            this.driverGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label driversLabel;
        private System.Windows.Forms.ListBox driversList;
        private System.Windows.Forms.Button addDriverButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label resultTextLabel;
        private System.Windows.Forms.GroupBox driverGroupBox;
        private System.Windows.Forms.Label previousClaimDatesLabel;
        private System.Windows.Forms.TextBox previousClaim5;
        private System.Windows.Forms.TextBox previousClaim4;
        private System.Windows.Forms.TextBox previousClaim3;
        private System.Windows.Forms.TextBox previousClaim2;
        private System.Windows.Forms.TextBox previousClaim1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label dateOfBirthLabel;
        private System.Windows.Forms.Label occupationLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox dateOfBirthTextBox;
        private System.Windows.Forms.TextBox occupationTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button populateButton;
    }
}