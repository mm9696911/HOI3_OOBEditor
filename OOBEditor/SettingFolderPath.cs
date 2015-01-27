using OOBEditor.Helper;
using System;
using System.Windows.Forms;

namespace OOBEditor
{
    public partial class SettingFolderPath : Form
    {

        public SettingFolderPath()
        {
            InitializeComponent();
            XmlHelper xmlHelper = new XmlHelper();
            string folderPath = xmlHelper.GetXmlValue("GamePath");
            if (string.IsNullOrEmpty(folderPath))
            {
                txt_FolderPath.Text = "X:\\Hearts of Iron III\\tfh";
            }
            else
            {
                txt_FolderPath.Text = folderPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.txt_FolderPath.Text = path.SelectedPath;

            if (!string.IsNullOrEmpty(this.txt_FolderPath.Text))
            {
                XmlHelper xmlHelper = new XmlHelper();
                bool isSuccess = xmlHelper.SaveToXML("GamePath", path.SelectedPath);
                if (isSuccess)
                {
                    MessageBox.Show("设置路径成功");
                }
                else
                {
                    MessageBox.Show("设置路径错误");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
