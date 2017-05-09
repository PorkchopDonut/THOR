namespace THOR
{
    partial class AdminForm
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
            this.OWCListbox = new System.Windows.Forms.ListBox();
            this.OWCInfoPanel = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.PhoneNumberTextbox = new System.Windows.Forms.TextBox();
            this.ContactTextbox = new System.Windows.Forms.TextBox();
            this.DeleteOWCButton = new System.Windows.Forms.Button();
            this.OfficeSymbolTextbox = new System.Windows.Forms.TextBox();
            this.OWCCodeTextbox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.OfficeSymbolLabel = new System.Windows.Forms.Label();
            this.OWCCodeLabel = new System.Windows.Forms.Label();
            this.AddOWCButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OWCDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.OWCDesciptionLabel = new System.Windows.Forms.Label();
            this.OWCInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OWCListbox
            // 
            this.OWCListbox.FormattingEnabled = true;
            this.OWCListbox.Location = new System.Drawing.Point(12, 12);
            this.OWCListbox.Name = "OWCListbox";
            this.OWCListbox.Size = new System.Drawing.Size(120, 147);
            this.OWCListbox.TabIndex = 0;
            this.OWCListbox.SelectedIndexChanged += new System.EventHandler(this.OWCListbox_SelectedIndexChanged);
            // 
            // OWCInfoPanel
            // 
            this.OWCInfoPanel.Controls.Add(this.OWCDesciptionLabel);
            this.OWCInfoPanel.Controls.Add(this.OWCDescriptionTextbox);
            this.OWCInfoPanel.Controls.Add(this.UpdateButton);
            this.OWCInfoPanel.Controls.Add(this.AddressTextbox);
            this.OWCInfoPanel.Controls.Add(this.PhoneNumberTextbox);
            this.OWCInfoPanel.Controls.Add(this.ContactTextbox);
            this.OWCInfoPanel.Controls.Add(this.DeleteOWCButton);
            this.OWCInfoPanel.Controls.Add(this.OfficeSymbolTextbox);
            this.OWCInfoPanel.Controls.Add(this.OWCCodeTextbox);
            this.OWCInfoPanel.Controls.Add(this.AddressLabel);
            this.OWCInfoPanel.Controls.Add(this.PhoneNumberLabel);
            this.OWCInfoPanel.Controls.Add(this.ContactLabel);
            this.OWCInfoPanel.Controls.Add(this.OfficeSymbolLabel);
            this.OWCInfoPanel.Controls.Add(this.OWCCodeLabel);
            this.OWCInfoPanel.Location = new System.Drawing.Point(138, 12);
            this.OWCInfoPanel.Name = "OWCInfoPanel";
            this.OWCInfoPanel.Size = new System.Drawing.Size(220, 313);
            this.OWCInfoPanel.TabIndex = 1;
            this.OWCInfoPanel.Visible = false;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(107, 220);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 23);
            this.UpdateButton.TabIndex = 16;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.Location = new System.Drawing.Point(107, 145);
            this.AddressTextbox.Multiline = true;
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.Size = new System.Drawing.Size(100, 69);
            this.AddressTextbox.TabIndex = 15;
            this.AddressTextbox.TextChanged += new System.EventHandler(this.TextboxUpdated);
            // 
            // PhoneNumberTextbox
            // 
            this.PhoneNumberTextbox.Location = new System.Drawing.Point(107, 119);
            this.PhoneNumberTextbox.Name = "PhoneNumberTextbox";
            this.PhoneNumberTextbox.Size = new System.Drawing.Size(100, 20);
            this.PhoneNumberTextbox.TabIndex = 14;
            this.PhoneNumberTextbox.TextChanged += new System.EventHandler(this.TextboxUpdated);
            // 
            // ContactTextbox
            // 
            this.ContactTextbox.Location = new System.Drawing.Point(107, 93);
            this.ContactTextbox.Name = "ContactTextbox";
            this.ContactTextbox.Size = new System.Drawing.Size(100, 20);
            this.ContactTextbox.TabIndex = 13;
            this.ContactTextbox.TextChanged += new System.EventHandler(this.TextboxUpdated);
            // 
            // DeleteOWCButton
            // 
            this.DeleteOWCButton.Location = new System.Drawing.Point(107, 249);
            this.DeleteOWCButton.Name = "DeleteOWCButton";
            this.DeleteOWCButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteOWCButton.TabIndex = 17;
            this.DeleteOWCButton.Text = "Delete OWC";
            this.DeleteOWCButton.UseVisualStyleBackColor = true;
            this.DeleteOWCButton.Click += new System.EventHandler(this.DeleteOWCButton_Click);
            // 
            // OfficeSymbolTextbox
            // 
            this.OfficeSymbolTextbox.Location = new System.Drawing.Point(107, 67);
            this.OfficeSymbolTextbox.Name = "OfficeSymbolTextbox";
            this.OfficeSymbolTextbox.Size = new System.Drawing.Size(100, 20);
            this.OfficeSymbolTextbox.TabIndex = 12;
            this.OfficeSymbolTextbox.TextChanged += new System.EventHandler(this.TextboxUpdated);
            // 
            // OWCCodeTextbox
            // 
            this.OWCCodeTextbox.Location = new System.Drawing.Point(107, 15);
            this.OWCCodeTextbox.Name = "OWCCodeTextbox";
            this.OWCCodeTextbox.Size = new System.Drawing.Size(100, 20);
            this.OWCCodeTextbox.TabIndex = 10;
            this.OWCCodeTextbox.TextChanged += new System.EventHandler(this.TextboxUpdated);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(50, 148);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(51, 13);
            this.AddressLabel.TabIndex = 6;
            this.AddressLabel.Text = "Address: ";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Location = new System.Drawing.Point(17, 122);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(84, 13);
            this.PhoneNumberLabel.TabIndex = 5;
            this.PhoneNumberLabel.Text = "Phone Number: ";
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(51, 96);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(50, 13);
            this.ContactLabel.TabIndex = 4;
            this.ContactLabel.Text = "Contact: ";
            // 
            // OfficeSymbolLabel
            // 
            this.OfficeSymbolLabel.AutoSize = true;
            this.OfficeSymbolLabel.Location = new System.Drawing.Point(23, 70);
            this.OfficeSymbolLabel.Name = "OfficeSymbolLabel";
            this.OfficeSymbolLabel.Size = new System.Drawing.Size(78, 13);
            this.OfficeSymbolLabel.TabIndex = 3;
            this.OfficeSymbolLabel.Text = "Office Symbol: ";
            // 
            // OWCCodeLabel
            // 
            this.OWCCodeLabel.AutoSize = true;
            this.OWCCodeLabel.Location = new System.Drawing.Point(34, 18);
            this.OWCCodeLabel.Name = "OWCCodeLabel";
            this.OWCCodeLabel.Size = new System.Drawing.Size(67, 13);
            this.OWCCodeLabel.TabIndex = 1;
            this.OWCCodeLabel.Text = "OWC Code: ";
            // 
            // AddOWCButton
            // 
            this.AddOWCButton.Location = new System.Drawing.Point(23, 165);
            this.AddOWCButton.Name = "AddOWCButton";
            this.AddOWCButton.Size = new System.Drawing.Size(98, 23);
            this.AddOWCButton.TabIndex = 1;
            this.AddOWCButton.Text = "Add OWC";
            this.AddOWCButton.UseVisualStyleBackColor = true;
            this.AddOWCButton.Click += new System.EventHandler(this.NewOWCButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(23, 234);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OWCDescriptionTextbox
            // 
            this.OWCDescriptionTextbox.Location = new System.Drawing.Point(107, 41);
            this.OWCDescriptionTextbox.Name = "OWCDescriptionTextbox";
            this.OWCDescriptionTextbox.Size = new System.Drawing.Size(100, 20);
            this.OWCDescriptionTextbox.TabIndex = 11;
            this.OWCDescriptionTextbox.TextChanged += new System.EventHandler(this.TextboxUpdated);
            // 
            // OWCDesciptionLabel
            // 
            this.OWCDesciptionLabel.AutoSize = true;
            this.OWCDesciptionLabel.Location = new System.Drawing.Point(6, 44);
            this.OWCDesciptionLabel.Name = "OWCDesciptionLabel";
            this.OWCDesciptionLabel.Size = new System.Drawing.Size(95, 13);
            this.OWCDesciptionLabel.TabIndex = 2;
            this.OWCDesciptionLabel.Text = "OWC Description: ";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 337);
            this.ControlBox = false;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddOWCButton);
            this.Controls.Add(this.OWCInfoPanel);
            this.Controls.Add(this.OWCListbox);
            this.Name = "AdminForm";
            this.Text = "OWC Management";
            this.OWCInfoPanel.ResumeLayout(false);
            this.OWCInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox OWCListbox;
        private System.Windows.Forms.Panel OWCInfoPanel;
        private System.Windows.Forms.Label OfficeSymbolLabel;
        private System.Windows.Forms.Label OWCCodeLabel;
        private System.Windows.Forms.Button DeleteOWCButton;
        private System.Windows.Forms.Button AddOWCButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.TextBox PhoneNumberTextbox;
        private System.Windows.Forms.TextBox ContactTextbox;
        private System.Windows.Forms.TextBox OfficeSymbolTextbox;
        private System.Windows.Forms.TextBox OWCCodeTextbox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label OWCDesciptionLabel;
        private System.Windows.Forms.TextBox OWCDescriptionTextbox;
    }
}