using System;
using System.Drawing;
using System.IO;

using System.Windows.Forms;

namespace Testing
{
    public partial class LabelPreview : Form
    {
        public LabelPreview()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            textBox1.Text = @"C:\Users\ali.koshar\Desktop\Format1.btw";
#endif
            txtPrinter.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (File.Exists(textBox1.Text.Trim()))
                {
                    LabelPrinting.LabelPrintingServiceClient client = new LabelPrinting.LabelPrintingServiceClient();
                    //Stream stream = File.OpenRead(textBox1.Text.Trim());
                    byte[] imgData = client.GenerateLabelPreview(File.ReadAllBytes(textBox1.Text.Trim()), txtPrinter.Text.Trim());
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Btw Files|*.btw";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBox1.Text = dialog.FileName;
            }
        }
    }
}
