using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Testing
{
    public partial class frmServiceTestingClient : Form
    {
        public frmServiceTestingClient()
        {
            InitializeComponent();
        }

        private void frmServiceTestingClient_Load(object sender, EventArgs e)
        {
#if debud
            txtPrinterNamePrintFile.Text="HP LaserJet P3011/P3015 PCL6";
            txtPrinter.Text=txtPrinterNamePrintFile.Text;
#endif
            lstPreviewParams.Items.Add("Name\t-\tValue");
        }

        private void btnBrowsePrms_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Btw Files|*.btw";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                txtBrowseLabelParameters.Text = dialog.FileName;
                txtBrowsePrintFile.Text = dialog.FileName;
                txtParamBrowse.Text = dialog.FileName;
            }
        }

        private void btnDisplayPrms_Click(object sender, EventArgs e)
        {
            LabelPrintingServiceClient client = new LabelPrintingServiceClient();
            IEnumerable<string> prms = client.GetLabelParameters(File.ReadAllBytes(txtBrowseLabelParameters.Text.Trim()), txtPrinter.Text.Trim());
            foreach (string prm in prms)
            {
                lstPrms.Items.Add(prm);
            }
        }

        private void btnDisplayPrintersInstalledPrinters_Click(object sender, EventArgs e)
        {
            LabelPrintingServiceClient client = new LabelPrintingServiceClient();
            IEnumerable<string> prms = client.GetInstalledPrinters();
            foreach (string prm in prms)
            {
                lstInstalledPrinters.Items.Add(prm);
            }
        }

        private void btnIsDefaultPrinter_Click(object sender, EventArgs e)
        {
            LabelPrintingServiceClient client = new LabelPrintingServiceClient();
            if (client.IsPrinterInstalled(txtIsDefaultPrinter.Text.Trim()))
            {
                MessageBox.Show("Printer is installed.");
            }
            else
            {
                MessageBox.Show("Printe is not installed.");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LabelPrintingServiceClient client = new LabelPrintingServiceClient();
            LabelPrinting.PrintResult result = client.PrintLabel(File.ReadAllBytes(txtBrowsePrintFile.Text.Trim()), txtPrinterNamePrintFile.Text.Trim());
            if (result.Success)
            {
                MessageBox.Show("Print successfully.");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtParamName.Text.Trim().IndexOf("img", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    txtParamValue.Text = dialog.FileName;
                }
            }
            lstPreviewParams.Items.Add(txtParamName.Text.Trim() + "\t" + txtParamValue.Text.Trim());
            txtParamValue.Text = txtParamName.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (File.Exists(txtParamBrowse.Text.Trim()))
                {
                    LabelPrintingServiceClient client = new LabelPrintingServiceClient();
                    byte[] imgData = null;
                    if (lstPreviewParams.Items.Count > 1)
                    {
                        List<LabelPrinting.LabelParameters> param = new List<LabelPrinting.LabelParameters>();
                        foreach (string str in lstPreviewParams.Items)
                        {
                            string[] arr = str.Split('\t');
                            if (arr[0].IndexOf("img", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                param.Add(new LabelPrinting.LabelParameters { ParamName = arr[0], ParamValue = File.ReadAllBytes(arr[1]) });
                            }
                            else
                            {
                                param.Add(new LabelPrinting.LabelParameters { ParamName = arr[0], ParamValue = arr[1] });
                            }
                        }
                        imgData = client.GenerateCustomeLabelPreview(File.ReadAllBytes(txtParamBrowse.Text.Trim()),
                             param.ToArray(), txtPrinter.Text.Trim());
                    }
                    else
                    {
                        imgData = client.GenerateLabelPreview(File.ReadAllBytes(txtParamBrowse.Text.Trim()), txtPrinter.Text.Trim());
                    }
                    pictureBox1.Image = ByteArrayToImage(imgData);
                }
                else
                {
                    MessageBox.Show("Please select a valid file first.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length))
            {
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);
            }
            return returnImage;
        }

        private void btnclearItems_Click(object sender, EventArgs e)
        {
            lstPreviewParams.Items.Clear();
            lstPreviewParams.Items.Add("Name\t-\tValue");
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(txtParamBrowse.Text.Trim()))
            {
                LabelPrintingServiceClient client = new LabelPrintingServiceClient();
                LabelPrinting.PrintResult result = null;
                if (lstPreviewParams.Items.Count > 1)
                {
                    List<LabelPrinting.LabelParameters> param = new List<LabelPrinting.LabelParameters>();
                    foreach (string str in lstPreviewParams.Items)
                    {
                        string[] arr = str.Split('\t');
                        if (arr[0].IndexOf("img", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            param.Add(new LabelPrinting.LabelParameters { ParamName = arr[0], ParamValue = File.ReadAllBytes(arr[1]) });
                        }
                        else
                        {
                            param.Add(new LabelPrinting.LabelParameters { ParamName = arr[0], ParamValue = arr[1] });
                        }
                    }

                    result = client.PrintCustomeLabel(File.ReadAllBytes(txtBrowsePrintFile.Text.Trim()), param.ToArray(), txtParamPrinterName.Text.Trim());
                }
                else
                {
                    result = client.PrintLabel(File.ReadAllBytes(txtParamBrowse.Text.Trim()), txtParamPrinterName.Text.Trim());
                }
                if (result.Success)
                {
                    MessageBox.Show("Print successfully.");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }

            }
        }

        private void btnPrintJob_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.;database=assettracking;uid=sa;pwd=password@1");
            SqlCommand com = new SqlCommand("select FK_ID_PrintJob,FK_ID_AssetType,FK_ID_Asset from printjobdetail where FK_ID_PrintJob = 3", con);

            LabelPrintingServiceClient client = new LabelPrintingServiceClient();
            List<LabelPrinting.PrintJobParameters> lst = new List<LabelPrinting.PrintJobParameters>();
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                LabelPrinting.PrintJobParameters jobParam = new LabelPrinting.PrintJobParameters();
                LabelPrinting.AssetParameters param = new LabelPrinting.AssetParameters();
                param.AssetID = reader.GetInt32(2);
                jobParam.AssetTypeID = reader.GetInt32(1);
                jobParam.inputBTWFile = File.ReadAllBytes(@"D:\Projects\Omni-ID\Bartender Images\Disk_525.btw");
                param.lstLabelParameters = null;
                List<LabelPrinting.AssetParameters> lst2 = new List<LabelPrinting.AssetParameters>();
                lst2.Add(param);

                jobParam.lstAssetParameters = lst2.ToArray();
                lst.Add(jobParam);
            }
            con.Close();
            MessageBox.Show(client.PrintBatchJob("Test Job1", txtParamPrinterName.Text.Trim(), lst.ToArray()).Message);

        }
    }
}