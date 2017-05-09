using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace THOR
{
    public partial class MainForm : Form
    {
        public Report currentReport;
        public Calibration currentCalibration;
        public Step currentStep;
        public string CertifyingLab = "96 MXS/MXMD\r\n201 E Daytona Rd\r\nBldg 78\r\nEglin AFB, FL, 32542";

        public List<OWC> OWCs;
        public List<Standard> Standards;

        public List<Label> OWCLabels, EditLabels;
        public List<TextBox> OWCTextboxes, EditTextboxes;
        public List<string> EditLabelContents, Variables;

        public XmlSerializer xmlSerializer;
        public XmlReader xmlReader;

        public DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<OWC>));
        public MemoryStream memoryStream = new MemoryStream();
        public FileStream fileStream;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        public bool EditMode = false;

        public MainForm()
        {
            InitializeComponent();
            Initializations();
        }

        public void Initializations()
        {
            #region Other Variables...
            if (File.Exists(Application.StartupPath + "\\OWCs.json"))
                LoadOWCs();
            else
            {
                OWCs = new List<OWC>();
                OWCCombobox.Items.Add("");
            }

            Standards = new List<Standard>();

            Standards.Add(new THOR.Standard()
            {
                serialNumber = "115261",
                idNumber = "M488936",
                testLoad = "2500 LB"
            });

            Standards.Add(new THOR.Standard()
            {
                serialNumber = "114519",
                idNumber = "M488937",
                testLoad = "10000 LB"
            });

            Standards.Add(new THOR.Standard()
            {
                serialNumber = "114979",
                idNumber = "M488935",
                testLoad = "30000 LB"
            });

            Standards.Add(new THOR.Standard()
            {
                serialNumber = "114816",
                idNumber = "M488934",
                testLoad = "60000 LB"
            });

            Standards.Add(new THOR.Standard()
            {
                serialNumber = "114354",
                idNumber = "J291260",
                testLoad = "100000 LB"
            });
            #endregion

            OWCLabels = new List<Label>()
            {
                OWCLabel,
                OfficeSymbolLabel,
                ContactLabel,
                PhoneNumberLabel,
                AddressLabel
            };

            OWCTextboxes = new List<TextBox>()
            {
                OWCTextbox,
                OfficeSymbolTextbox,
                ContactTextbox,
                PhoneNumberTextbox,
                AddressTextbox
            };

            EditLabels = new List<Label>()
            {
                ModelNumberLabel,
                SerialNumberLabel,
                IDNumberLabel,
                CapacityLabel,
                TechnicianLabel,
                TemperatureLabel,
                HumidityLabel,
                CalibrationTOLabel,
                DateCalibratedLabel,
                DateDueLabel,
                OWCLabel,
                OfficeSymbolLabel,
                ContactLabel,
                PhoneNumberLabel,
                OWCAddressLabel,
                StandardLabel,
                TestLoadLabel,
                DirectionLabel,
                OutputLabel,
                NonLinearityLabel,
                HysteresisLabel,
                SEBOutputLabel,
                SEBLabel,
                CEBLabel,
                ExcitationVoltageLabel,
                NonRepeatabilityLabel,
                CommentsLabel
            };

            EditLabelContents = new List<string>()
            {
                "Model Number: ",
                "Serial Number: ",
                "ID Number: ",
                "Capacity (LBF): ",
                "Technician: ",
                "Temperature (°F): ",
                "Humidity (%): ",
                "Calibration TO: ",
                "Date Calibrated: ",
                "Date Due: ",
                "OWC: ",
                "Office Symbol: ",
                "Contact: ",
                "Phone Number: ",
                "",
                "Standard: ",
                "Test Load: ",
                "Direction: ",
                "Output (mV/V): ",
                "Non-Linearity (%): ",
                "Hysteresis (%): ",
                "SEB Output (mV/V): ",
                "SEB (%): ",
                "CEB (%): ",
                "Excitation Voltage (VDC): ",
                "Non-Repeatability (%): ",
                "Comments: "
            };

            EditTextboxes = new List<TextBox>()
            {
                ModelNumberTextbox,
                SerialNumberTextbox,
                IDNumberTextbox,
                CapacityTextbox,
                TechnicianTextbox,
                TemperatureTextbox,
                HumidityTextbox,
                CalibrationTOTextbox,
                DateCalibratedTextbox,
                DateDueTextbox,
                OWCTextbox,
                OfficeSymbolTextbox,
                ContactTextbox,
                PhoneNumberTextbox,
                AddressTextbox,
                StandardTextbox,
                TestLoadTextbox,
                DirectionTextbox,
                OutputTextbox,
                NonLinearityTextbox,
                HysteresisTextbox,
                SEBOutputTextbox,
                SEBTextbox,
                CEBTextbox,
                ExcitationVoltageTextbox,
                NonRepeatabilityTextbox,
                CommentsTextbox
            };

            SwitchEditMode(true);

            if (!Directory.Exists(Application.StartupPath + "\\Archive"))
                Directory.CreateDirectory(Application.StartupPath + "\\Archive");
        }

        #region Program Functions
        public void LoadOWCs()
        {
            OWCCombobox.Items.Clear();
            OWCCombobox.Items.Add("");

            fileStream = new FileStream(Application.StartupPath + "\\OWCs.json", FileMode.Open, FileAccess.Read);

            OWCs = (List<OWC>)jsonSerializer.ReadObject(fileStream);

            fileStream.Close();

            foreach (OWC owc in OWCs)
                OWCCombobox.Items.Add(owc.description);
        }

        public void SwitchEditMode(bool EditState)
        {
            if (!EditState)
                for (int i = 0; i < EditLabels.Count(); i++)
                    EditLabels[i].Text += EditTextboxes[i].Text;
            else
                for (int i = 0; i < EditLabels.Count(); i++)
                    EditLabels[i].Text = EditLabelContents[i];

            foreach (TextBox textbox in EditTextboxes)
                textbox.Visible = EditState;

            TestPointDisplay.ClearSelection();

            Application.DoEvents();
        }

        public void ImportReport()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath;
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(openFile.FileName);
                AnalyzeText(lines);
                PopulateAllTextboxes();
            }
        }

        public void AnalyzeText(string[] lines)
        {
            /*  Kids...  Don't try this at home; I've written a lot of
             *  text manipulation scripts, but this is by far the most
             *  dangerous one; If this report format changes even a little
             *  bit, all of these variables will be out of sync and this
             *  program will become obsolete quicker than the latest 
             *  iPhone will be in a few months...   */

            List<string> preList;
            List<string[]> delimitedLines = new List<string[]>();
            Dictionary<int, List<int>> calSteps = new Dictionary<int, List<int>>();
            List<int> calLines = new List<int>();

            foreach (string line in lines)
            {
                preList = line.Split('\t').ToList<string>();
                preList.RemoveAll(s => s.Equals(""));

                delimitedLines.Add(preList.ToArray<string>());
            }

            int currentCalLine = 0;

            for (int i = 0; i < delimitedLines.Count - 1; i++)
            {
                if (delimitedLines[i].Count() > 0 && delimitedLines[i][0].Equals("# CAL"))
                {
                    calSteps.Add(i, new List<int>());
                    currentCalLine = i;
                }
                else if (delimitedLines[i].Count() > 0 && delimitedLines[i][0].Equals("# STEP"))
                    calSteps[currentCalLine].Add(i);
            };

            currentReport = new Report();

            currentReport.serialNumber = delimitedLines[4][2];
            currentReport.modelNumber = delimitedLines[6][2];
            currentReport.capacity = delimitedLines[7][2];

            foreach (KeyValuePair<int, List<int>> cal in calSteps)
            {
                Calibration newCal = new Calibration();

                if (currentReport.idNumber == null || currentReport.idNumber == "")
                    try { currentReport.idNumber = delimitedLines[cal.Key + 5][2]; } catch { currentReport.idNumber = ""; }

                try { newCal.technician = delimitedLines[cal.Key + 2][2]; } catch { newCal.technician = "Unknown"; }
                try { newCal.standard = FindStandard(delimitedLines[cal.Key + 3][2]); } catch {  }
                try { newCal.temperature = int.Parse(delimitedLines[cal.Key + 4][2]);} catch {  }
                try { newCal.humidity = int.Parse(delimitedLines[cal.Key + 7][2]);} catch {  }
                try { newCal.excitationVoltage = Double.Parse(delimitedLines[cal.Key + 6][2]); } catch {  }

                foreach (int step in cal.Value)
                {
                    Step newStep = new Step();

                    int endPoint = TestPointBounds(delimitedLines, step);

                    newStep.name = delimitedLines[step + 1][1];
                    newStep.comments = delimitedLines[step + 2][1];
                    newCal.dateCal = DateTime.Parse(delimitedLines[step + 3][1]).ToString("dd MMM yyyy");
                    newStep.directon = delimitedLines[step + 4][1];

                    for (int i = 7; i < endPoint; i++)
                    {
                        newStep.testPoints.Add(new TestPoint()
                        {
                            load = delimitedLines[step + i][1],
                            test = delimitedLines[step + i][3],
                            normal = delimitedLines[step + i][4]
                        });
                    }

                    endPoint += step;

                    newStep.output = Double.Parse(delimitedLines[endPoint + 3][2]);
                    newStep.nonLinearity = Double.Parse(delimitedLines[endPoint + 4][2]);
                    newStep.hysteresis = Double.Parse(delimitedLines[endPoint + 5][2]);
                    newStep.seb = Double.Parse(delimitedLines[endPoint + 6][2]);
                    newStep.sebOutput = Double.Parse(delimitedLines[endPoint + 7][2]);
                    newStep.ceb = Double.Parse(delimitedLines[endPoint + 8][2]);
                    newStep.nonRepeatability = Double.Parse(delimitedLines[endPoint + 9][2]);

                    newCal.steps.Add(newStep);
                }

                currentReport.cals.Add(newCal);
            }

            PopulateCalCombobox();
        }

        private int TestPointBounds(List<string[]> strings, int startPoint)
        {
            int endPoint = 7;

            while (strings[startPoint + endPoint].Count() != 0)
            {
                endPoint++;
            }

            return endPoint;
        }

        public void PopulateCalCombobox()
        {
            CalibrationCombobox.Items.Clear();

            currentReport.cals.ForEach(cal => CalibrationCombobox.Items.Add(cal.dateCal));
            CalibrationCombobox.SelectedIndex = 0;
        }

        public void PopulateStepCombobox()
        {
            StepCombobox.Items.Clear();

            currentReport.cals[0].steps.ForEach(step => StepCombobox.Items.Add(step.name));
            StepCombobox.SelectedIndex = 0;
        }

        public void ClearOWCLabels()
        {
            OWCTextboxes.ForEach(textbox => textbox.Text = "");
        }

        public void PopulateOWCLabels(int index)
        {
            OWC workCenter = OWCs[index];

            OWCTextbox.Text = workCenter.code;
            OfficeSymbolTextbox.Text = workCenter.officeSymbol;
            ContactTextbox.Text = workCenter.contact;
            PhoneNumberTextbox.Text = workCenter.phoneNumber;
            AddressTextbox.Text = workCenter.address;
        }

        public void PopulateAllTextboxes()
        {
            SaveReportButton.Enabled = true;
            PrintButton.Enabled = true;

            LoadVariables();

            for (int i = 0; i < EditTextboxes.Count; i++)
            {
                if (Variables[i] != null)
                    EditTextboxes[i].Text = Variables[i];
                else
                    EditTextboxes[i].Text = "";
            }

            PopulateTestPointList();
        }

        private void PopulateTestPointList()
        {
            TestPointDisplay.Rows.Clear();

            foreach (TestPoint tp in currentStep.testPoints)
            {
                /*string[] testPoint = new string[4];

                testPoint[1] = tp.load.ToString();
                testPoint[2] = tp.test.ToString();
                testPoint[3] = tp.normal.ToString();

                ListViewItem item = new ListViewItem(testPoint);
                TestPointsList.Items.Add(item); */

                TestPointDisplay.Rows.Add(new string[] { tp.load.ToString(), tp.test.ToString(), tp.normal.ToString() });
            }
        }

        public void LoadVariables()
        {
            Variables = new List<string>()
            {
                currentReport.modelNumber,
                currentReport.serialNumber,
                currentReport.idNumber,
                currentReport.capacity,
                currentCalibration.technician,
                currentCalibration.temperature.ToString(),
                currentCalibration.humidity.ToString(),
                currentCalibration.calTO,
                currentCalibration.dateCal,
                currentCalibration.dateDue,
                currentReport.owc.code,
                currentReport.owc.officeSymbol,
                currentReport.owc.contact,
                currentReport.owc.phoneNumber,
                currentReport.owc.address,
                currentCalibration.standard.idNumber,
                currentCalibration.standard.testLoad,
                currentStep.directon,
                currentStep.output.ToString(),
                currentStep.nonLinearity.ToString(),
                currentStep.hysteresis.ToString(),
                currentStep.sebOutput.ToString(),
                currentStep.seb.ToString(),
                currentStep.ceb.ToString(),
                currentCalibration.excitationVoltage.ToString(),
                currentStep.nonRepeatability.ToString(),
                currentStep.comments
            };
        }

        public Standard FindStandard(string s)
        {
            Standard newStandard = new Standard();
            int standardIndex;

            newStandard.serialNumber = s;

            try
            {
                standardIndex = Standards.FindIndex(standard => standard.serialNumber.Equals(newStandard.serialNumber));
                newStandard.idNumber = Standards[standardIndex].idNumber;
                newStandard.testLoad = Standards[standardIndex].testLoad;
            }
            catch
            {
                newStandard.idNumber = "Unavailable";
                newStandard.testLoad = "Unavailable";
            }

            return newStandard;
        }

        public void SaveReport()
        {
            currentReport.modelNumber = ModelNumberTextbox.Text;
            currentReport.serialNumber = SerialNumberTextbox.Text;
            currentReport.idNumber = IDNumberTextbox.Text;
            currentReport.capacity = CapacityTextbox.Text;
            currentCalibration.technician = TechnicianTextbox.Text;
            currentCalibration.temperature = int.Parse(TemperatureTextbox.Text);
            currentCalibration.humidity = int.Parse(HumidityTextbox.Text);
            currentCalibration.dateCal = DateCalibratedTextbox.Text;
            currentCalibration.dateDue = DateDueTextbox.Text;
            currentCalibration.calTO = CalibrationTOTextbox.Text;
            if (OWCCombobox.SelectedIndex != 0)
                currentReport.owc = OWCs[OWCCombobox.SelectedIndex - 1];
            currentStep.directon = DirectionTextbox.Text;
            currentStep.output = double.Parse(OutputTextbox.Text);
            currentStep.nonLinearity = double.Parse(NonLinearityTextbox.Text);
            currentStep.hysteresis = double.Parse(HysteresisTextbox.Text);
            currentStep.sebOutput = double.Parse(SEBOutputTextbox.Text);
            currentStep.seb = double.Parse(SEBTextbox.Text);
            currentStep.ceb = double.Parse(CEBTextbox.Text);
            currentCalibration.excitationVoltage = double.Parse(ExcitationVoltageTextbox.Text);
            currentStep.nonRepeatability = double.Parse(NonRepeatabilityTextbox.Text);
            currentStep.comments = CommentsTextbox.Text;

            xmlSerializer = new XmlSerializer(typeof(Report));

            try
            {
                string filePath = Application.StartupPath + "\\Archive\\" + currentReport.idNumber + ".xml";

                XmlWriter Writer = XmlWriter.Create(new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));

                xmlSerializer.Serialize(Writer, currentReport);

                MessageBox.Show("File saved successfully!");
            }
            catch
            {
                MessageBox.Show("Something went wrong...");
            }
        }

        public void LoadReport()
        {
            string filePath = null;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileName = @"";
            fileDialog.DefaultExt = "xml";
            fileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Archive\\";

            if (fileDialog.ShowDialog() != DialogResult.Cancel)
            {
                filePath = fileDialog.FileName;
            }

            if (filePath != null && filePath != "")
            {
                try
                {
                    xmlSerializer = new XmlSerializer(typeof(Report));
                    xmlReader = XmlReader.Create(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                    currentReport = (Report)xmlSerializer.Deserialize(xmlReader);

                    xmlReader.Close();

                    PopulateCalCombobox();

                    PopulateAllTextboxes();

                    MessageBox.Show("Report successfully loaded!");
                }
                catch
                {
                    MessageBox.Show("An error occurred...");
                }
            }
            else if (filePath == "" || filePath == null) { }
            else
            {
                MessageBox.Show("Please use a valid file...\n\n" +
                    "You must use an Inventory.xml file...");
            }
        }

        #region Printing Functions
        private void CaptureScreen()
        {
            memoryImage = new Bitmap(ReportPanel.Width, ReportPanel.Height);
            ReportPanel.DrawToBitmap(memoryImage, new Rectangle(Point.Empty, memoryImage.Size));

            Bitmap CombinedImage = new Bitmap(memoryImage.Width, memoryImage.Height + Properties.Resources.Letterhead.Height + Properties.Resources.TraceabilityStatement.Height);
            using (Graphics graphics = Graphics.FromImage(CombinedImage))
            {
                graphics.DrawImage(Properties.Resources.Letterhead, 0, 0);
                graphics.DrawImage(memoryImage, 0, Properties.Resources.Letterhead.Height);
                graphics.DrawImage(Properties.Resources.TraceabilityStatement, 0, Properties.Resources.Letterhead.Height + memoryImage.Height);
            }

            memoryImage = CombinedImage;
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, new Rectangle(new Point((e.PageSettings.PaperSize.Width - memoryImage.Width) / 2, 0), memoryImage.Size));
        }
        #endregion

        #endregion

        #region Form Functions
        private void ImportButton_Click(object sender, EventArgs e)
        {
            ImportReport();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            SwitchEditMode(false);
            CaptureScreen();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
            SwitchEditMode(true);
        }

        private void CalibrationCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCalibration = currentReport.cals[CalibrationCombobox.SelectedIndex];
            PopulateStepCombobox();
        }

        private void StepCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStep = currentCalibration.steps[StepCombobox.SelectedIndex];
            PopulateAllTextboxes();
        }

        private void ManageOWCsButton_Click(object sender, EventArgs e)
        {
            Form owcManagementForm = new AdminForm();
            owcManagementForm.ShowDialog();
            LoadOWCs();
            OWCCombobox.SelectedIndex = 0;
        }

        private void OWCCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OWCCombobox.SelectedIndex == 0)
            {
                ClearOWCLabels();
            }
            else
            {
                PopulateOWCLabels(OWCCombobox.SelectedIndex - 1);
            }
        }

        private void SaveReportButton_Click(object sender, EventArgs e)
        {
            SaveReport();
        }

        private void LoadReportButton_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        #endregion
    }
}
