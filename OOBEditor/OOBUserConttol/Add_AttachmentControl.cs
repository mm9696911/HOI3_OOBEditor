using OOBEditor.Model;
using OOBEditor.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OOBEditor
{
    public partial class Add_AttachmentControl : UserControl
    {
        OOBInfo oobInfo = new OOBInfo();
        LocalisationInfo localisationModel = new LocalisationInfo();
        PathInfo pathInfo = new PathInfo();
        string countryCode = "";
        List<MilitaryTypeInfo> militaryTypeList = new List<MilitaryTypeInfo>();

        public Add_AttachmentControl(OOBInfo oobInfo, LocalisationInfo localisationModel, PathInfo pathInfo, string countryCode, List<MilitaryTypeInfo> militaryTypeList)
        {
            InitializeComponent();
            this.oobInfo = oobInfo;
            this.localisationModel = localisationModel;
            this.pathInfo = pathInfo;
            this.countryCode = countryCode;
            this.militaryTypeList = militaryTypeList;
            Bind();
            BindAttType();
        }

        private void Bind()
        {
            txt_AttName.Text = oobInfo.name;
            txt_AttID.Text = oobInfo.id.ToString();
        }

        private void BindAttType()
        {
            cbb_AttType.Items.Clear();
            LoadDataServices loadData = new LoadDataServices(pathInfo, countryCode);
            //militaryTypeList = loadData.LoadMilitaryType(localisationModel, countryCode);
            MilitaryTypeInfo militaryTypeInfo = militaryTypeList.Find(m => m.type == oobInfo.type);
            foreach (MilitaryTypeInfo m in militaryTypeList)
            {
                if (m.bigType == militaryTypeInfo.bigType)
                {
                    cbb_AttType.Items.Add(m.name);
                }
            }
            cbb_AttType.SelectedIndexChanged += new EventHandler(cbb_AttType_SelectedIndexChanged);
            cbb_AttType.SelectedItem = militaryTypeInfo.name;
        }

        private void cbb_AttType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox != null && !((string)cbb_AttType.SelectedItem).Equals("请选择"))
            {
                string attTypeName = (string)cbb_AttType.SelectedItem;//获取当前选中项

                BindAttModel(attTypeName);
            }
        }

        private void BindAttModel(string attTypeName)
        {
            cbb_AttModel.Items.Clear();
            MilitaryTypeInfo militaryTypeInfo = militaryTypeList.Find(m => m.name == attTypeName);
            if (militaryTypeInfo.unitModelList == null || militaryTypeInfo.unitModelList.Count == 0)
            {
                cbb_AttModel.Enabled = false;
            }
            else
            {
                cbb_AttModel.Enabled = true;
                foreach (UnitModelInfo u in militaryTypeInfo.unitModelList)
                {
                    cbb_AttModel.Items.Add(u.name);
                    if (u.modelNum == oobInfo.historical_model)
                    {
                        cbb_AttModel.SelectedItem = u.name;
                    }
                }
            }
        }


        private string GetFileStream(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            //创建文件流，path为文本文件路径  
            StreamReader file = new StreamReader(path, Encoding.Default);
            string fileText = file.ReadToEnd();
            file.Dispose();
            return fileText;
        }
    }
}
