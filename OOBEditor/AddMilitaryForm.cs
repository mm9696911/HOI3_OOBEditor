using OOBEditor.Model;
using OOBEditor.Model.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OOBEditor
{
    public partial class AddMilitaryForm : Form
    {
        int acNum = 0;
        int parentID = 0;
        int lastOobID = 0;
        LocalisationInfo localisationModel = new LocalisationInfo();
        string countryCode = "";
        PathInfo pathInfo = new PathInfo();
        List<MilitaryTypeInfo> militaryTypeList = new List<MilitaryTypeInfo>();
        OOBInfo parentOOBInfo = new OOBInfo();
        ArmyTypeEnum armyType;

        public delegate void Add_military(List<OOBInfo> oobList);
        public event Add_military add_military;
        public AddMilitaryForm(LocalisationInfo localisationModel, PathInfo pathInfo, string countryCode, List<MilitaryTypeInfo> militaryTypeList, int parentID, int lastOobID, ArmyTypeEnum armyType)
        {
            this.parentID = parentID;
            this.lastOobID = lastOobID;
            this.localisationModel = localisationModel;
            this.countryCode = countryCode;
            this.pathInfo = pathInfo;
            this.militaryTypeList = militaryTypeList;
            this.armyType = armyType;
            InitializeComponent();
            BindCbb_BasicType();
            this.cb_Reserve.Enabled = false;
            this.lastOobID++;
            this.txt_BasicID.Text = this.lastOobID.ToString();
        }

        private void BindCbb_BasicType()
        {
            if (armyType.Equals(ArmyTypeEnum.Theatre))
            {
                cbb_BasicType.Items.Add(ArmyTypeEnum.ArmyGroup.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Army.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Corps.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Division.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Navy.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Air.ToString());
            }
            if (armyType.Equals(ArmyTypeEnum.ArmyGroup))
            {
                cbb_BasicType.Items.Add(ArmyTypeEnum.Army.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Corps.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Division.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Navy.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Air.ToString());
            }
            if (armyType.Equals(ArmyTypeEnum.Army))
            {
                cbb_BasicType.Items.Add(ArmyTypeEnum.Corps.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Division.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Navy.ToString());
                cbb_BasicType.Items.Add(ArmyTypeEnum.Air.ToString());
            }
            if (armyType.Equals(ArmyTypeEnum.Corps))
            {
                this.cb_Reserve.Enabled = true;
                cbb_BasicType.Items.Add(ArmyTypeEnum.Division.ToString());
            }
        }

        private void btn_AddAttachment_Click(object sender, EventArgs e)
        {
            //OOBInfo 

            OOBInfo oobInfo = new OOBInfo();
            this.lastOobID++;
            oobInfo.id = lastOobID;
            if (acNum == 0)
            {
                oobInfo.name = this.txt_BasicName.Text.Trim();
            }
            string basicTypeName = (string)cbb_BasicType.SelectedItem;//获取当前选中项
            ArmyTypeEnum armyTypeEnum = ConvertArmyTypeStringToEnum(basicTypeName);
            if (armyTypeEnum.Equals(ArmyTypeEnum.Navy))
            {
                oobInfo.type = "destroyer";
            }
            else if (armyTypeEnum.Equals(ArmyTypeEnum.Air))
            {
                oobInfo.type = "interceptor";
            }
            else
            {
                oobInfo.type = "hq_brigade";
            }

            ShowUserControl(oobInfo);
            acNum++;
        }
        /// <summary>
        /// 绑定附属部队
        /// </summary>
        /// <param name="oobInfo"></param>
        /// <param name="acNum"></param>
        private void ShowUserControl(OOBInfo oobInfo)
        {
            try
            {
                Add_AttachmentControl aac = new Add_AttachmentControl(oobInfo, localisationModel, pathInfo, countryCode, militaryTypeList);

                if (this.panel1.Controls.Count > 0)
                {
                    Point point = this.panel1.Controls[this.panel1.Controls.Count - 1].Location;
                    aac.Location = new Point(-5, point.Y + 105);
                }
                else
                {
                    int pointy = acNum == 0 ? (acNum * 105) : (acNum * 105);
                    aac.Location = new Point(-5, pointy);
                }
                aac.Parent = this.panel1;
                aac.Height = 100;
                this.panel1.Controls.Add(aac);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("添加附属部队失败:" + ex.Message);
            }
        }
        #region 通用方法
        private string GetOOBType(ArmyTypeEnum at)
        {
            switch (at)
            {
                case ArmyTypeEnum.Theatre:
                    return "战区";
                case ArmyTypeEnum.ArmyGroup:
                    return "集团军群";
                case ArmyTypeEnum.Army:
                    return "集团军";
                case ArmyTypeEnum.Corps:
                    return "军";
                case ArmyTypeEnum.Division:
                    return "师";
                case ArmyTypeEnum.Regiment:
                    return "旅";
                case ArmyTypeEnum.Navy:
                    return "舰队";
                case ArmyTypeEnum.Ship:
                    return "战舰";
                case ArmyTypeEnum.Air:
                    return "航空联队";
                case ArmyTypeEnum.Wing:
                    return "飞机";
                default:
                    return "";
            }
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResult ShowErrorMessageIsCancel(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public DialogResult ShowErrorMessageOK(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                List<OOBInfo> oobList = new List<OOBInfo>();
                int ID = Convert.ToInt32(txt_BasicID.Text);

                OOBInfo oobAddInfo = new OOBInfo();

                #region 赋值基本信息
                oobAddInfo.id = ID;
                oobAddInfo.parentID = parentID;
                if (!((string)cbb_BasicType.SelectedItem).Equals("请选择"))
                {
                    string attTypeName = (string)cbb_BasicType.SelectedItem;//获取当前选中项
                    oobAddInfo.armyType = ConvertArmyTypeStringToEnum(attTypeName);
                }
                if (!string.IsNullOrEmpty(txt_BasicName.Text))
                {
                    oobAddInfo.name = txt_BasicName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txt_BasicLocation.Text))
                {
                    Regex reg = new Regex(@"[0-9][0-9,.]*");
                    MatchCollection mc = reg.Matches(txt_BasicLocation.Text);
                    if (mc.Count > 0)
                    {
                        if (oobAddInfo.armyType != ArmyTypeEnum.Navy && oobAddInfo.armyType != ArmyTypeEnum.Air)
                        {
                            oobAddInfo.location = mc[0].Value;
                        }
                        else
                        {
                            oobAddInfo.location = mc[0].Value;
                            oobAddInfo.baseID = mc[0].Value;
                        }
                    }
                }
                if (cb_Reserve.Enabled && oobAddInfo.armyType == ArmyTypeEnum.Division)
                {
                    oobAddInfo.is_reserve = cb_Reserve.Checked;
                }
                oobList.Add(oobAddInfo);
                #endregion

                #region 赋值附属部队的信息
                foreach (Control c in this.panel1.Controls)
                {
                    Add_AttachmentControl aac = (Add_AttachmentControl)c;
                    TextBox txt_AttID = (TextBox)aac.Controls[0].Controls.Find("txt_AttID", false)[0];
                    int attID = Convert.ToInt32(txt_AttID.Text);
                    OOBInfo oobAttAddInfo = new OOBInfo();
                    oobAttAddInfo.id = attID;
                    oobAttAddInfo.parentID = ID;
                    TextBox txt_AttName = (TextBox)aac.Controls[0].Controls.Find("txt_AttName", false)[0];
                    if (!string.IsNullOrEmpty(txt_AttName.Text))
                    {
                        oobAttAddInfo.name = txt_AttName.Text;
                    }
                    TextBox txt_AttExp = (TextBox)aac.Controls[0].Controls.Find("txt_AttExp", false)[0];
                    if (!string.IsNullOrEmpty(txt_AttExp.Text))
                    {
                        oobAttAddInfo.experience = txt_AttExp.Text;
                    }
                    ComboBox cbb_AttType = (ComboBox)aac.Controls[0].Controls.Find("cbb_AttType", false)[0];
                    if (cbb_AttType.SelectedItem != null)
                    {
                        MilitaryTypeInfo militaryTypeInfo = militaryTypeList.Find(m => m.name == cbb_AttType.SelectedItem.ToString());
                        oobAttAddInfo.type = militaryTypeInfo.type;
                    }
                    ComboBox cbb_AttModel = (ComboBox)aac.Controls[0].Controls.Find("cbb_AttModel", false)[0];
                    if (cbb_AttModel.SelectedItem != null)
                    {
                        MilitaryTypeInfo militaryTypeInfo = militaryTypeList.Find(m => m.name == cbb_AttType.SelectedItem.ToString());
                        if (militaryTypeInfo.unitModelList != null || militaryTypeInfo.unitModelList.Count > 0)
                        {
                            oobAttAddInfo.historical_model = militaryTypeInfo.unitModelList.Find(uml => uml.name == cbb_AttModel.SelectedItem.ToString()).modelNum;
                        }
                    }
                    if (oobAddInfo.armyType == ArmyTypeEnum.Navy)
                    {
                        oobAttAddInfo.armyType = ArmyTypeEnum.Ship;
                    }
                    else if (oobAddInfo.armyType == ArmyTypeEnum.Air)
                    {
                        oobAttAddInfo.armyType = ArmyTypeEnum.Wing;
                    }
                    else
                    {
                        oobAttAddInfo.armyType = ArmyTypeEnum.Regiment;
                    }
                    oobList.Add(oobAttAddInfo);
                }
                #endregion

                this.Close();
                this.add_military(oobList);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("保存失败:" + ex.Message);
            }
        }

        private ArmyTypeEnum ConvertArmyTypeStringToEnum(string armyTypeString)
        {
            ArmyTypeEnum armyTypeEnum;
            Enum.TryParse(armyTypeString, true, out armyTypeEnum);
            return armyTypeEnum;
        }
    }
}
