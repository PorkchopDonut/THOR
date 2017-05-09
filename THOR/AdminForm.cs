using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using THOR;
using System.IO;
using System.Runtime.Serialization.Json;

namespace THOR
{
    public partial class AdminForm : Form
    {
        public List<OWC> OWCs = new List<OWC>();
        public DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<OWC>));
        public MemoryStream memoryStream = new MemoryStream();
        public FileStream fileStream;

        public AdminForm()
        {
            InitializeComponent();
            Initializations();
        }

        public void Initializations()
        {
            if (File.Exists(Application.StartupPath + "\\OWCs.json"))
                LoadOWCs();
        }

        public void LoadOWCs()
        {
            fileStream = new FileStream(Application.StartupPath + "\\OWCs.json", FileMode.Open, FileAccess.Read);

            OWCs = (List<OWC>)jsonSerializer.ReadObject(fileStream);
            PopulateOWCList();

            fileStream.Close();
        }

        public void PopulateOWCList()
        {
            OWCListbox.Items.Clear();

            foreach (OWC owc in OWCs)
                OWCListbox.Items.Add(owc.description);

            OWCInfoPanel.Visible = false;
        }

        private void TextboxUpdated(object sender, EventArgs e)
        {
            if (OWCCodeTextbox.Text != "" && OWCDescriptionTextbox.Text != "" && OfficeSymbolTextbox.Text != "" && ContactTextbox.Text != "" && PhoneNumberTextbox.Text != "" && AddressTextbox.Text != "")
                UpdateButton.Enabled = true;
            else
                UpdateButton.Enabled = false;
        }

        private void NewOWCButton_Click(object sender, EventArgs e)
        {
            OWCs.Add(new OWC() { description = "New OWC" });

            PopulateOWCList();

            OWCListbox.SelectedIndex = OWCs.Count - 1;
        }

        private void DeleteOWCButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete {OWCListbox.SelectedItem}?", "Delete confirmation...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OWCs.RemoveAt(OWCListbox.SelectedIndex);
                PopulateOWCList();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            fileStream = new FileStream(Application.StartupPath + "\\OWCs.json", FileMode.Create, System.IO.FileAccess.Write);

            jsonSerializer.WriteObject(fileStream, OWCs);

            fileStream.Close();
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            OWCs[OWCListbox.SelectedIndex] = new OWC()
            {
                code = OWCCodeTextbox.Text,
                description = OWCDescriptionTextbox.Text,
                officeSymbol = OfficeSymbolTextbox.Text,
                contact = ContactTextbox.Text,
                phoneNumber = PhoneNumberTextbox.Text,
                address = AddressTextbox.Text
            };

            PopulateOWCList();
        }

        public void ClearOWCTextboxes()
        {
            OWCCodeTextbox.Text = "";
            OWCDescriptionTextbox.Text = "";
            OfficeSymbolTextbox.Text = "";
            ContactTextbox.Text = "";
            PhoneNumberTextbox.Text = "";
            AddressTextbox.Text = "";
        }

        private void OWCListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearOWCTextboxes();

            if (OWCListbox.SelectedIndex != -1)
            {
                int i = OWCListbox.SelectedIndex;

                OWCCodeTextbox.Text = OWCs[i].code;
                OWCDescriptionTextbox.Text = OWCs[i].description;
                OfficeSymbolTextbox.Text = OWCs[i].officeSymbol;
                ContactTextbox.Text = OWCs[i].contact;
                PhoneNumberTextbox.Text = OWCs[i].phoneNumber;
                AddressTextbox.Text = OWCs[i].address;

                OWCInfoPanel.Visible = true;
            }
            else
                OWCInfoPanel.Visible = false;
        }
    }
}
