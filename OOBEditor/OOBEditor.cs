using OOBEditor.Helper;
using OOBEditor.Model;
using OOBEditor.Model.Enum;
using OOBEditor.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OOBEditor
{
    public partial class OOBEditor : Form
    {
        #region 声明
        PathInfo pathInfo = new PathInfo();
        PathHelper pathHelper = new PathHelper();
        string scenariosStr = "";
        List<CountryInfo> countryList = new List<CountryInfo>();
        List<OOBInfo> oobList = new List<OOBInfo>();
        string countryCode = "";
        LocalisationInfo localisationModel = new LocalisationInfo();
        List<LeaderInfo> leaderList = new List<LeaderInfo>();
        List<MilitaryTypeInfo> militaryTypeList = new List<MilitaryTypeInfo>();
        /// <summary>
        /// 附属部队数量
        /// </summary>
        int acNum = 0;
        /// <summary>
        /// 存放在建军队字符串
        /// </summary>
        string constructionStr = "";
        int lastOOBID = 0;
        //是否保存
        bool isSuccess = false;

        public List<OOBInfo> publicOOBList { get; set; }
        List<string> traitList = new List<string>();
        List<LeaderTraitInfo> leaderTraitList = new List<LeaderTraitInfo>();
        #endregion

        Dictionary<string, bool> NodesStatus = new Dictionary<string, bool>();
        string SelectNodeFullPath;

        public OOBEditor()
        {
            InitializeComponent();
            AutoLoad();
        }

        private void 加载文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoLoad();
        }
        private void AutoLoad()
        {
            string errorMessage = "";
            pathInfo = pathHelper.checkDirectory(out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ShowErrorMessage(errorMessage);
                return;
            }
            //加载剧本
            this.ccb_SelectScenarios.Items.Clear();
            this.ccb_SelectCountry.Items.Clear();
            BindSelectScenarios();
        }
        private void 设置路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingFolderPath path = new SettingFolderPath();
            path.Show();
        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!((string)ccb_SelectScenarios.SelectedItem).Equals("请选择") && !((string)ccb_SelectCountry.SelectedItem).Equals("请选择") && ccb_SelectScenarios.SelectedItem != null && ccb_SelectCountry.SelectedItem != null)
                {
                    GenerateServices gerateServices = new GenerateServices(pathInfo, oobList, countryCode, scenariosStr, constructionStr);
                    bool isGenerate = gerateServices.GenerateCode();
                    if (isGenerate)
                    {
                        ShowErrorMessage("生成成功，路径为History下OOBEditor文件夹");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("生成失败:" + ex.Message);
            }
        }

        #region 选择剧本事件
        private void BindSelectScenarios()
        {
            ccb_SelectScenarios.Items.Add("请选择");

            string[] files = Directory.GetFiles(pathInfo.OOBPath);
            foreach (string file in files)
            {
                string extension = file.Split('.')[1];
                string scenariosStr = file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0];
                if (extension.Equals("txt") && scenariosStr.Contains("GER"))
                {
                    string scenariosCode = scenariosStr.Substring(scenariosStr.LastIndexOf('_') + 1);
                    ccb_SelectScenarios.Items.Add(scenariosCode);
                }
            }
            //ccb_SelectScenarios.Items.Add("其他剧本"); 屏蔽其他剧本加载
            this.ccb_SelectScenarios.SelectedIndex = 0;
            //将combobox控件的selectedindexchanged 事件拖管到combobox_SelectedIndexChanged事件中
            ccb_SelectScenarios.SelectedIndexChanged += new EventHandler(ccb_SelectScenarios_SelectedIndexChanged);
        }

        private void ccb_SelectScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (ccb_SelectScenarios.SelectedItem != null && !((string)ccb_SelectScenarios.SelectedItem).Equals("请选择"))
            {
                this.ccb_SelectCountry.Items.Clear();
                string scenariosStr = (string)ccb_SelectScenarios.SelectedItem;//获取当前选中项
                this.scenariosStr = scenariosStr;
                ccb_SelectCountry.SelectedIndexChanged -= new EventHandler(ccb_SelectCountry_SelectedIndexChanged);
                BindSelectCountry(scenariosStr);
            }

        }
        #endregion

        #region 选择国家事件
        private void BindSelectCountry(string scenariosStr)
        {
            try
            {
                ccb_SelectCountry.Items.Add("请选择");
                LoadDataServices loadData = new LoadDataServices(pathInfo);
                countryList = loadData.LoadCountry();
                if (scenariosStr != "其他剧本")
                {
                    foreach (CountryInfo c in countryList)
                    {
                        if (File.Exists(string.Concat(pathInfo.OOBPath, c.countryCode, "_", scenariosStr, ".txt")))
                        {
                            ccb_SelectCountry.Items.Add(c.name);
                        }
                    }
                }
                //else 屏蔽其他剧本加载
                //{
                //    string[] files = Directory.GetFiles(pathInfo.OOBPath);
                //    foreach (string file in files)
                //    {
                //        if (file.Split('.')[1].Equals("txt") && file.Split('.')[0].IndexOf('_') < 0)
                //        {
                //            string str = file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0];
                //            ccb_SelectCountry.Items.Add(str);
                //        }
                //    }
                //}

                this.ccb_SelectCountry.SelectedIndex = 0;
                //将combobox控件的selectedindexchanged 事件拖管到combobox_SelectedIndexChanged事件中
                ccb_SelectCountry.SelectedIndexChanged += new EventHandler(ccb_SelectCountry_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("绑定剧本失败:" + ex.Message);
            }
        }

        private void ccb_SelectCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox combobox = sender as ComboBox;
                if (combobox != null && !((string)ccb_SelectCountry.SelectedItem).Equals("请选择"))
                {
                    string countryStr = (string)ccb_SelectCountry.SelectedItem;//获取当前选中项
                    CountryInfo countryInfo = countryList.Find(c => c.name == countryStr);
                    LoadDataServices loadData = new LoadDataServices(pathInfo, countryInfo.countryCode);
                    if (!string.IsNullOrEmpty(scenariosStr))
                    {
                        Bind(countryInfo, loadData);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("绑定国家失败:" + ex.Message);
            }

        }
        #endregion

        private void Bind(CountryInfo countryInfo, LoadDataServices loadData)
        {
            try
            {
                localisationModel.ProvinceList = loadData.LoadProvince();
                localisationModel.UnitList = loadData.LoadUnit();
                leaderList = loadData.LoadLeaderInfo();
                countryCode = countryInfo.countryCode;
                this.tv_Military.Nodes.Clear();
                List<OOBInfo> list = loadData.LoadOOB(scenariosStr, out constructionStr);
                militaryTypeList = loadData.LoadMilitaryType(localisationModel, countryCode);
                oobList = list;
                publicOOBList = list;
                BindTree(0, list);
                leaderTraitList = loadData.LoadTraits(localisationModel.UnitList);

                tv_Military.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("加载失败:" + ex.Message);
            }
        }

        #region 绑定TreeView
        private void BindTree(int parentId, List<OOBInfo> data)
        {
            try
            {
                List<OOBInfo> list = data.FindAll(e => e.parentID == parentId && e.id != parentId).OrderBy(o => o.id).ToList();
                if (list.Count > 0)
                {
                    bool isRebuild = false;
                    if (tv_Military.Nodes.Count > 0)
                        isRebuild = true;
                    if (isRebuild)
                        GetTreeNodesStatus(tv_Military.Nodes);
                    tv_Military.Nodes.Clear();
                    TreeNode oobNode = new TreeNode();
                    oobNode.Text = data[0].name.ToString();
                    oobNode.Name = data[0].id.ToString();
                    this.tv_Military.Nodes.Add(oobNode);

                    for (int i = 0; i < list.Count; i++)
                    {
                        TreeNode node = new TreeNode();

                        node.Text = string.Concat(list[i].name.ToString(), "    [", GetOOBType(list[i].armyType), "]");
                        node.Name = list[i].id.ToString();
                        oobNode.Nodes.Add(node);
                        BindNode(node, data);
                    }
                    if (isRebuild)
                        SetTreeNodesStatus(tv_Military.Nodes);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("保存失败:" + ex.Message);
            }
        }

        private void BindNode(TreeNode nd, List<OOBInfo> data)
        {
            try
            {
                List<OOBInfo> list = data.FindAll(e => e.parentID == Convert.ToInt32(nd.Name)).OrderBy(o => o.id).ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = string.Concat(list[i].name.ToString(), "    [", GetOOBType(list[i].armyType), "]");
                    node.Name = list[i].id.ToString();

                    nd.Nodes.Add(node);

                    BindNode(node, data);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("保存失败:" + ex.Message);
            }
        }

        #region 保存Treeview 状态
        private void GetTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded)
                {
                    NodesStatus[node.FullPath] = true;
                }
                else
                {
                    NodesStatus.Remove(node.FullPath);
                }
                if (node.IsSelected)
                {
                    SelectNodeFullPath = node.FullPath;
                }
                GetTreeNodesStatus(node.Nodes);
            }
        }
        private void SetTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (NodesStatus.ContainsKey(node.FullPath))
                {
                    if (NodesStatus[node.FullPath] != null)
                    {
                        node.Expand();
                    }
                    if (node.FullPath == SelectNodeFullPath)
                    {
                        tv_Military.SelectedNode = node;
                    }
                    SetTreeNodesStatus(node.Nodes);
                }
            }
        }
        #endregion

        #endregion

        #region TreeView 事件
        /// <summary>
        /// treeView点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_Military_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
                if (isSuccess)
                {
                    if (ShowErrorMessageIsCancel("修改尚未保存，是否继续？") == DialogResult.OK)
                    {
                        BindDetail(oobID);
                    }
                }
                acNum = 0;//每次绑定前，附属部队数量清零
                BindDetail(oobID);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("加载失败:" + ex.Message);
            }

        }

        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_Military_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right) return;
                if (e.Node == null) return;
                this.tv_Military.SelectedNode = e.Node;

                contextMenuStrip1.Show(tv_Military, e.X, e.Y);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 绑定具体信息
        /// </summary>
        /// <param name="oobID"></param>
        private void BindDetail(int oobID)
        {
            if (oobID == 0)
            {
                return;
            }
            ClearBaseInformation();
            ClearLeaderInformation();
            OOBInfo oobModel = oobList.Find(o => o.id == oobID);
            if (oobModel.armyType == ArmyTypeEnum.Regiment || oobModel.armyType == ArmyTypeEnum.Ship || oobModel.armyType == ArmyTypeEnum.Wing)
            {
                int parentID = oobModel.parentID;
                oobModel = oobList.Find(o => o.id == parentID);
                oobID = oobModel.id;
            }

            #region 绑定基本信息
            txt_BasicID.Text = oobID.ToString();
            txt_BasicName.Text = oobModel.name;
            txt_BasicType.Text = GetOOBType(oobModel.armyType);
            string flagPath = RetuenPath(string.Concat(pathInfo.gfxPath, "flags\\", countryCode, ".tga"));

            Bitmap m_bmp = DevIL.DevIL.LoadBitmap(flagPath);
            pb_CountryFlag.Image = m_bmp;
            string provinceName = "";
            if (!string.IsNullOrEmpty(oobModel.location))
            {
                provinceName = string.Concat(localisationModel.ProvinceList.Find(p => p.id == oobModel.location).name, "(", oobModel.location, ")");
            }
            else
            {
                OOBInfo parentOOBModel = oobList.Find(o => o.id == oobModel.parentID);
                provinceName = string.Concat(localisationModel.ProvinceList.Find(p => p.id == parentOOBModel.location).name, "(", parentOOBModel.location, ")");
            }
            txt_BasicLocation.Text = provinceName;

            if (oobModel.is_reserve == null)
            {
                cb_Reserve.Enabled = false;
            }
            else
            {
                cb_Reserve.Enabled = true;
                cb_Reserve.Checked = oobModel.is_reserve.Value;
            }
            #endregion

            BindLeader(oobModel);

            this.panel1.Controls.Clear();
            foreach (OOBInfo oobInfo in oobList.FindAll(o => o.parentID == oobID))
            {
                if (oobInfo.armyType == ArmyTypeEnum.Regiment || oobInfo.armyType == ArmyTypeEnum.Ship || oobInfo.armyType == ArmyTypeEnum.Wing)
                {
                    ShowUserControl(oobInfo);
                    acNum++;
                }
            }
        }

        #region 绑定将领信息
        /// <summary>
        /// 绑定将领信息
        /// </summary>
        /// <param name="oobModel"></param>
        private void BindLeader(OOBInfo oobModel)
        {
            if (!string.IsNullOrEmpty(oobModel.leader))
            {
                LeaderInfo leaderInfo = leaderList.Find(l => l.ID.ToString() == oobModel.leader);
                if (leaderInfo != null)
                {
                    string leaderPath = RetuenPath(string.Concat(pathInfo.gfxPath, "pictures\\portraits\\", leaderInfo.picture, ".tga"));

                    Bitmap m_bmpLeader = DevIL.DevIL.LoadBitmap(leaderPath);
                    pb_Leader.Image = m_bmpLeader;
                    txt_LeaderID.Text = leaderInfo.ID.ToString();
                    txt_LeaderName.Text = leaderInfo.name;
                    txt_LeaderSkill.Text = leaderInfo.skill.ToString();
                    txt_LeaderMaxSkill.Text = leaderInfo.max_skill.ToString();
                    int num = leaderInfo.add_trait.Count;
                    if (num > 0)
                    {
                        pictureBox_trait1.Image = showTraitImage(leaderInfo.add_trait[0]);
                        traitList.Add(leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[0]).traitName);
                    }
                    if (num > 1)
                    {
                        pictureBox_trait2.Image = showTraitImage(leaderInfo.add_trait[1]);
                        traitList.Add(leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[1]).traitName);
                    }
                    if (num > 2)
                    {
                        pictureBox_trait3.Image = showTraitImage(leaderInfo.add_trait[2]);
                        traitList.Add(leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[2]).traitName);
                    }
                    if (num > 3)
                    {
                        pictureBox_trait4.Image = showTraitImage(leaderInfo.add_trait[3]);
                        traitList.Add(leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[3]).traitName);
                    }
                }
                else
                {
                    string leaderPath = RetuenPath(string.Concat(pathInfo.gfxPath, "pictures\\portraits\\empty_position.tga"));

                    Bitmap m_bmpLeader = DevIL.DevIL.LoadBitmap(leaderPath);
                    pb_Leader.Image = m_bmpLeader;
                }
            }
            else
            {
                string leaderPath = RetuenPath(string.Concat(pathInfo.gfxPath, "pictures\\portraits\\empty_position.tga"));

                Bitmap m_bmpLeader = DevIL.DevIL.LoadBitmap(leaderPath);
                pb_Leader.Image = m_bmpLeader;
            }
        }
        #endregion

        /// <summary>
        /// 绑定附属部队
        /// </summary>
        /// <param name="oobInfo"></param>
        /// <param name="acNum"></param>
        private void ShowUserControl(OOBInfo oobInfo)
        {
            try
            {
                AttachmentControl ac = new AttachmentControl(oobInfo, localisationModel, pathInfo, countryCode, militaryTypeList);
                ac.Parent = this.panel1;
                int pointy = acNum == 0 ? (acNum * 105) : (acNum * 105);
                ac.Location = new Point(5, pointy);
                ac.Height = 100;
                this.panel1.Controls.Add(ac);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("附属部队绑定失败:" + ex.Message);
            }
        }

        #endregion

        #region 清除将领和基本信息
        private void ClearBaseInformation()
        {
            txt_BasicID.Text = "";
            txt_BasicName.Text = "";
            txt_BasicType.Text = "";
            pb_CountryFlag.Image = null;
            txt_BasicLocation.Text = "";
            cb_Reserve.Enabled = false;
            cb_Reserve.Checked = false;
        }

        private void ClearLeaderInformation()
        {
            string leaderPath = RetuenPath(string.Concat(pathInfo.gfxPath, "pictures\\portraits\\empty_position.tga"));

            Bitmap m_bmpLeader = DevIL.DevIL.LoadBitmap(leaderPath);
            pb_Leader.Image = m_bmpLeader;
            txt_LeaderID.Text = "";
            txt_LeaderName.Text = "";
            txt_LeaderSkill.Text = "";
            txt_LeaderMaxSkill.Text = "";
            pictureBox_trait1.Image = null;
            pictureBox_trait2.Image = null;
            pictureBox_trait3.Image = null;
            pictureBox_trait4.Image = null;
            //lbl_TraitText.Visible = false;
        }
        #endregion

        #region 保存方法

        private void Save(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(txt_BasicID.Text);

                OOBInfo oobUpdateInfo = oobList.Find(o => o.id == ID);
                //移除当前的oob
                //oobList.Remove(oobUpdateInfo);

                #region 赋值基本信息
                if (!string.IsNullOrEmpty(txt_BasicName.Text))
                {
                    oobUpdateInfo.name = txt_BasicName.Text;
                    this.tv_Military.SelectedNode.Text = txt_BasicName.Text;
                }
                if (!string.IsNullOrEmpty(txt_BasicLocation.Text))
                {
                    Regex reg = new Regex(@"[0-9][0-9,.]*");
                    MatchCollection mc = reg.Matches(txt_BasicLocation.Text);
                    if (mc.Count > 0)
                    {
                        if (oobUpdateInfo.armyType != ArmyTypeEnum.Navy && oobUpdateInfo.armyType != ArmyTypeEnum.Air)
                        {
                            oobUpdateInfo.location = mc[0].Value;
                        }
                        else
                        {
                            oobUpdateInfo.location = mc[0].Value;
                            oobUpdateInfo.baseID = mc[0].Value;
                        }
                    }
                }
                if (cb_Reserve.Enabled && oobUpdateInfo.armyType == ArmyTypeEnum.Division)
                {
                    oobUpdateInfo.is_reserve = cb_Reserve.Checked;
                }
                if (!string.IsNullOrEmpty(txt_LeaderID.Text))
                {
                    oobUpdateInfo.leader = txt_LeaderID.Text.Trim();
                }
                //oobList.Add(oobUpdateInfo);
                #endregion

                #region 赋值附属部队的信息
                int currentAcNum = oobList.FindAll(att => att.parentID == ID
            && (att.armyType == ArmyTypeEnum.Regiment || att.armyType == ArmyTypeEnum.Ship || att.armyType == ArmyTypeEnum.Wing)).Count;
                int num = 0;
                foreach (Control c in this.panel1.Controls)
                {
                    if (num < currentAcNum)
                    {
                        AttachmentControl ac = (AttachmentControl)c;
                        TextBox txt_AttID = (TextBox)ac.Controls[0].Controls.Find("txt_AttID", false)[0];
                        int attID = Convert.ToInt32(txt_AttID.Text);
                        OOBInfo oobAttUpdateInfo = oobList.Find(o => o.id == attID);
                        //oobList.Remove(oobAttUpdateInfo);

                        TextBox txt_AttName = (TextBox)ac.Controls[0].Controls.Find("txt_AttName", false)[0];
                        if (!string.IsNullOrEmpty(txt_AttName.Text))
                        {
                            oobAttUpdateInfo.name = txt_AttName.Text;
                        }
                        TextBox txt_AttExp = (TextBox)ac.Controls[0].Controls.Find("txt_AttExp", false)[0];
                        if (!string.IsNullOrEmpty(txt_AttExp.Text))
                        {
                            oobAttUpdateInfo.experience = txt_AttExp.Text;
                        }
                        ComboBox cbb_AttType = (ComboBox)ac.Controls[0].Controls.Find("cbb_AttType", false)[0];
                        if (cbb_AttType.SelectedItem != null)
                        {
                            MilitaryTypeInfo militaryTypeInfo = militaryTypeList.Find(m => m.name == cbb_AttType.SelectedItem.ToString());
                            oobAttUpdateInfo.type = militaryTypeInfo.type;
                        }
                        ComboBox cbb_AttModel = (ComboBox)ac.Controls[0].Controls.Find("cbb_AttModel", false)[0];
                        if (cbb_AttModel.SelectedItem != null)
                        {
                            MilitaryTypeInfo militaryTypeInfo = militaryTypeList.Find(m => m.name == cbb_AttType.SelectedItem.ToString());
                            if (militaryTypeInfo.unitModelList != null || militaryTypeInfo.unitModelList.Count > 0)
                            {
                                oobAttUpdateInfo.historical_model = militaryTypeInfo.unitModelList.Find(uml => uml.name == cbb_AttModel.SelectedItem.ToString()).modelNum;
                            }
                        }
                        //oobList.Add(oobAttUpdateInfo);
                    }
                    else
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
                        if (oobUpdateInfo.armyType == ArmyTypeEnum.Navy)
                        {
                            oobAttAddInfo.armyType = ArmyTypeEnum.Ship;
                        }
                        else if (oobUpdateInfo.armyType == ArmyTypeEnum.Air)
                        {
                            oobAttAddInfo.armyType = ArmyTypeEnum.Wing;
                        }
                        else
                        {
                            oobAttAddInfo.armyType = ArmyTypeEnum.Regiment;
                        }
                        oobList.Add(oobAttAddInfo);
                    }
                    num++;
                }
                #endregion

                //this.tv_Military.Nodes.Clear();
                BindTree(0, oobList);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("保存失败:" + ex.Message);
            }
        }
        #endregion

        #region 右键菜单
        private void 添加新部队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
                int lastOOBID = oobList.FindAll(l => l.id > -1).Max(m => m.id);
                OOBInfo parentOOBInfo = oobList.Find(o => o.id == oobID);
                AddMilitaryForm addMilitaryForm = new AddMilitaryForm(localisationModel, pathInfo, countryCode, militaryTypeList, oobID, lastOOBID, parentOOBInfo.armyType);
                addMilitaryForm.add_military += new AddMilitaryForm.Add_military(alreadyAddMilitary);
                addMilitaryForm.Show();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("添加新部队失败:" + ex.Message);
            }
        }

        private void alreadyAddMilitary(List<OOBInfo> oobAddList)
        {
            try
            {
                oobList.AddRange(oobAddList);
                //if (ShowErrorMessageOK("添加新部队成功") == DialogResult.OK)
                //{
                this.tv_Military.Nodes.Clear();
                BindTree(0, oobList);
                //}
            }
            catch (Exception ex)
            {
                ShowErrorMessage("添加新部队失败:" + ex.Message);
            }
        }

        private void 删除当前部队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
                if (oobID == 0)
                {
                    return;
                }
                OOBInfo oobModel = oobList.Find(o => o.id == oobID);
                oobList.Remove(oobModel);
                //if (ShowErrorMessageOK("删除当前部队成功") == DialogResult.OK)
                //{
                this.tv_Military.Nodes.Clear();
                BindTree(0, oobList);
                //}
            }
            catch (Exception ex)
            {
                ShowErrorMessage("删除当前部队失败:" + ex.Message);
            }
        }

        private void 添加将领ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
                OOBInfo oobInfo = oobList.Find(o => o.id == oobID);
                if (oobInfo.armyType != ArmyTypeEnum.Regiment && oobInfo.armyType != ArmyTypeEnum.Ship && oobInfo.armyType != ArmyTypeEnum.Wing)
                {
                    SelectLeaderForm selectLeaderForm = new SelectLeaderForm(oobList, pathInfo, countryCode, 0, leaderTraitList, leaderList, oobInfo.armyType);
                    selectLeaderForm.change_Leader += new SelectLeaderForm.Change_Leader(changeLeaderID);
                    selectLeaderForm.Show();
                }
                else
                {
                    ShowErrorMessage("旅级部队不支持选择将领");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("添加将领失败:" + ex.Message);
            }
        }

        private void changeLeaderID(string leaderID)
        {
            try
            {
                int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
                OOBInfo leaderOOBInfo = oobList.Find(o => o.leader == leaderID);
                if (leaderOOBInfo != null)
                {
                    leaderOOBInfo.leader = "";
                }
                OOBInfo oobInfo = oobList.Find(o => o.id == oobID);
                oobInfo.leader = leaderID;

                BindLeader(oobInfo);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("添加将领失败:" + ex.Message);
            }
        }

        private void 变更将领ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
                OOBInfo oobInfo = oobList.Find(o => o.id == oobID);
                if (oobInfo.armyType != ArmyTypeEnum.Regiment && oobInfo.armyType != ArmyTypeEnum.Ship && oobInfo.armyType != ArmyTypeEnum.Wing)
                {
                    int leaderID = string.IsNullOrEmpty(oobInfo.leader) ? 0 : Convert.ToInt32(oobInfo.leader);
                    SelectLeaderForm selectLeaderForm = new SelectLeaderForm(oobList, pathInfo, countryCode, leaderID, leaderTraitList, leaderList, oobInfo.armyType);
                    selectLeaderForm.change_Leader += new SelectLeaderForm.Change_Leader(changeLeaderID);
                    selectLeaderForm.Show();
                }
                else
                {
                    ShowErrorMessage("旅级部队不支持选择将领");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("变更将领失败:" + ex.Message);
            }
        }

        private void 删除当前将领ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int oobID = Convert.ToInt32(tv_Military.SelectedNode.Name.ToString());
            if (oobID == 0)
            {
                return;
            }
            OOBInfo oobModel = oobList.Find(o => o.id == oobID);
            if (oobModel.armyType == ArmyTypeEnum.Regiment || oobModel.armyType == ArmyTypeEnum.Ship || oobModel.armyType == ArmyTypeEnum.Wing)
            {
                int parentID = oobModel.parentID;
                oobModel = oobList.Find(o => o.id == parentID);
                oobID = oobModel.id;
            }
            oobModel.leader = "";
            //if (ShowErrorMessageOK("删除当前将领成功") == DialogResult.OK)
            //{
            BindDetail(oobID);
            //}
        }
        #endregion

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

        /// <summary>
        /// 传入文件路径判断是否存在，如果不存在判断移除MOD名字之后判断移除TFH文件夹名字
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string RetuenPath(string path)
        {
            string returnPath = path;
            if (!File.Exists(path))
            {
                if (!string.IsNullOrEmpty(pathInfo.modName))
                {
                    if (path.ToLower().IndexOf(pathInfo.modName) > -1)
                    {
                        returnPath = path.Remove(path.ToLower().IndexOf(pathInfo.modName), pathInfo.modName.Length + 1).Remove(path.ToLower().IndexOf(pathInfo.modName), 4);
                    }
                }
                if (!File.Exists(returnPath) && path.ToLower().IndexOf("tfh") > -1)
                {
                    returnPath = path.Remove(path.ToLower().IndexOf("tfh"), 4);
                }

            }
            return returnPath;
        }
        #endregion

        /// <summary>
        /// 添加附属部队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddAttBriage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_BasicID.Text))
            {
                ShowErrorMessage("请先选择部队");
                return;
            }
            int parentID = Convert.ToInt32(this.txt_BasicID.Text.Trim());
            int listLastOOBID = oobList.FindAll(l => l.id > -1).Max(m => m.id);
            if (lastOOBID < listLastOOBID)
            {
                lastOOBID = listLastOOBID;
            }
            OOBInfo oobInfo = new OOBInfo();
            //if (lastOOBID == 0)
            //{
            //    lastOOBID = oobList.FindAll(l => l.id > -1).Max(m => m.id);
            //}
            lastOOBID++;
            oobInfo.id = lastOOBID;
            if (acNum == 0)
            {
                oobInfo.name = this.txt_BasicName.Text.Trim();
            }
            OOBInfo parentOOBInfo = oobList.Find(p => p.id == parentID);
            if (parentOOBInfo.armyType == ArmyTypeEnum.Navy)
            {
                oobInfo.type = "destroyer";
            }
            else if (parentOOBInfo.armyType == ArmyTypeEnum.Air)
            {
                oobInfo.type = "multi_role";
            }
            else
            {
                oobInfo.type = "hq_brigade";
            }
            AddShowUserControl(oobInfo);
        }

        /// <summary>
        /// 绑定附属部队
        /// </summary>
        /// <param name="oobInfo"></param>
        /// <param name="acNum"></param>
        private void AddShowUserControl(OOBInfo oobInfo)
        {
            try
            {
                Add_AttachmentControl aac = new Add_AttachmentControl(oobInfo, localisationModel, pathInfo, countryCode, militaryTypeList);
                //aac.Parent = this.panel1;
                Point point = this.panel1.Controls[this.panel1.Controls.Count - 1].Location;
                aac.Location = new Point(70, point.Y + 105);
                aac.Height = 100;
                this.panel1.Controls.Add(aac);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("添加附属部队失败:" + ex.Message);
            }
        }

        #region 将领技能显示
        private Bitmap showTraitImage(string traitName)
        {
            string traitPath = RetuenPath(string.Concat(pathInfo.gfxPath, "interface\\icon_", traitName, ".dds"));

            Bitmap m_bmpTrait = DevIL.DevIL.LoadBitmap(traitPath);
            return m_bmpTrait;
        }

        private void pictureBox_trait1_MouseHover(object sender, EventArgs e)
        {
            if (traitList != null)
            {
                lbl_TraitText.Visible = true;
                lbl_TraitText.Text = traitList[0];
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                Point groupBox_Location = this.groupBox4.Location;
                int poingX = formPoint.X - groupBox_Location.X;
                int poingY = formPoint.Y - groupBox_Location.Y;
                Point point = new Point(poingX + 10, poingY - 5);
                lbl_TraitText.Location = point;

            }
        }

        private void pictureBox_trait1_MouseLeave(object sender, EventArgs e)
        {
            lbl_TraitText.Visible = false;
        }

        private void pictureBox_trait2_MouseHover(object sender, EventArgs e)
        {
            if (traitList.Count > 1)
            {
                lbl_TraitText.Visible = true;
                lbl_TraitText.Text = traitList[1];
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                Point groupBox_Location = this.groupBox4.Location;
                int poingX = formPoint.X - groupBox_Location.X;
                int poingY = formPoint.Y - groupBox_Location.Y;
                Point point = new Point(poingX + 10, poingY - 5);
                lbl_TraitText.Location = point;
            }
        }

        private void pictureBox_trait2_MouseLeave(object sender, EventArgs e)
        {
            lbl_TraitText.Visible = false;
        }

        private void pictureBox_trait3_MouseHover(object sender, EventArgs e)
        {
            if (traitList.Count > 2)
            {
                lbl_TraitText.Visible = true;
                lbl_TraitText.Text = traitList[2];
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                Point groupBox_Location = this.groupBox4.Location;
                int poingX = formPoint.X - groupBox_Location.X;
                int poingY = formPoint.Y - groupBox_Location.Y;
                Point point = new Point(poingX + 10, poingY - 5);
                lbl_TraitText.Location = point;
            }
        }

        private void pictureBox_trait3_MouseLeave(object sender, EventArgs e)
        {
            lbl_TraitText.Visible = false;
        }

        private void pictureBox_trait4_MouseHover(object sender, EventArgs e)
        {
            if (traitList.Count > 3)
            {
                lbl_TraitText.Visible = true;
                lbl_TraitText.Text = traitList[3];
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                Point groupBox_Location = this.groupBox4.Location;
                int poingX = formPoint.X - groupBox_Location.X;
                int poingY = formPoint.Y - groupBox_Location.Y;
                Point point = new Point(poingX + 10, poingY - 5);
                lbl_TraitText.Location = point;
            }
        }

        private void pictureBox_trait4_MouseLeave(object sender, EventArgs e)
        {
            lbl_TraitText.Visible = false;
        }
        #endregion
    }
}
