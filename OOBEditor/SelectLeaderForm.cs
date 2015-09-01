using OOBEditor.Model;
using OOBEditor.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOBEditor
{
    public partial class SelectLeaderForm : Form
    {
        List<OOBInfo> oobList = new List<OOBInfo>();
        string countryCode = "";
        PathInfo pathInfo = new PathInfo();
        int leaderID = 0;
        List<LeaderTraitInfo> leaderTraitList = new List<LeaderTraitInfo>();
        List<LeaderInfo> leaderList = new List<LeaderInfo>();
        List<LeaderInfo> bindLeaderList = new List<LeaderInfo>();
        ArmyTypeEnum armyTypeEnum;
        List<string> traitList = new List<string>();

        public delegate void Change_Leader(string leaderID);
        public event Change_Leader change_Leader;

        public SelectLeaderForm(List<OOBInfo> oobList, PathInfo pathInfo, string countryCode, int leaderID, List<LeaderTraitInfo> leaderTraitList, List<LeaderInfo> leaderList, ArmyTypeEnum armyTypeEnum)
        {
            this.leaderID = leaderID;
            this.oobList = oobList;
            this.countryCode = countryCode;
            this.pathInfo = pathInfo;
            this.leaderTraitList = leaderTraitList;
            this.leaderList = leaderList;
            this.armyTypeEnum = armyTypeEnum;
            InitializeComponent();
            BindDetail();
            DataGridViewBind();
            BindLeaderMaxSkill();
            BindLeaderTrait();
            //SizeColumnsToContent(dataGridView1, leaderList.Count);
        }

        private void BindLeaderMaxSkill()
        {
            cbb_MaxSkill.Items.Add("请选择");
            for (int skill = 1; skill <= 9; skill++)
            {
                cbb_MaxSkill.Items.Add(skill);
            }
        }

        private void BindLeaderTrait()
        {
            cbb_LeaderTrait.Items.Add("请选择");
            foreach (LeaderTraitInfo leaderTrait in leaderTraitList)
            {
                cbb_LeaderTrait.Items.Add(leaderTrait.traitName);
            }
        }

        private void BindDetail()
        {
            if (leaderID != 0)
            {
                LeaderInfo leaderInfo = leaderList.Find(l => l.ID == leaderID);
                string leaderPath = ReturnLeaderPicturePath(leaderInfo.picture);

                Bitmap m_bmpLeader = DevIL.DevIL.LoadBitmap(leaderPath);
                picture_Leader.Image = m_bmpLeader;
                lbl_Name.Text = leaderInfo.name;
                lbl_Skill.Text = leaderInfo.skill.ToString();
                lbl_MaxSkill.Text = leaderInfo.max_skill.ToString();
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
                lbl_Name.Text = "无将领";
            }
        }

        public void DataGridViewBind(string leaderName = null, string leaderMaxSkill = null, string leaderTraitCode = null)
        {
            bindLeaderList = leaderList;
            DataTable dt = new DataTable();
            #region 创建列
            DataColumn dtc = new DataColumn("图片", typeof(Bitmap));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("ID", typeof(Int32));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("姓名", typeof(string));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("隶属", typeof(string));
            dt.Columns.Add(dtc);
            //dtc = new DataColumn("类型", typeof(string));
            //dt.Columns.Add(dtc);
            dtc = new DataColumn("技能", typeof(Int32));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("最大", typeof(Int32));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("技能1", typeof(string));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("技能2", typeof(string));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("技能3", typeof(string));
            dt.Columns.Add(dtc);
            dtc = new DataColumn("技能4", typeof(string));
            dt.Columns.Add(dtc);
            #endregion
            string oobType = GetOOBType(armyTypeEnum);
            bindLeaderList = bindLeaderList.FindAll(l => l.type == oobType);
            if (!string.IsNullOrEmpty(leaderName))
            {
                bindLeaderList = bindLeaderList.FindAll(l => l.name.Contains(leaderName));
            }
            if (!string.IsNullOrEmpty(leaderMaxSkill))
            {
                int maxSkill = Convert.ToInt32(leaderMaxSkill);
                bindLeaderList = bindLeaderList.FindAll(l => l.max_skill == maxSkill);
            }
            if (!string.IsNullOrEmpty(leaderTraitCode))
            {
                List<LeaderInfo> newLeaderList = new List<LeaderInfo>();
                foreach (LeaderInfo l in bindLeaderList)
                {
                    if (l.add_trait.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(l.add_trait.Find(at => at == leaderTraitCode)))
                        {
                            newLeaderList.Add(l);
                        }
                    }
                }
                bindLeaderList = newLeaderList;
            }
            foreach (LeaderInfo leaderInfo in bindLeaderList)
            {
                DataRow dr = dt.NewRow();
                string leaderPath = ReturnLeaderPicturePath(leaderInfo.picture);

                Bitmap m_bmpLeader = DevIL.DevIL.LoadBitmap(leaderPath);
                dr["图片"] = m_bmpLeader;
                dr["ID"] = leaderInfo.ID;
                dr["姓名"] = leaderInfo.name.Trim();
                OOBInfo oobInfo = oobList.Find(o => o.leader == leaderInfo.ID.ToString());
                dr["隶属"] = oobInfo == null ? "" : oobInfo.name;
                //dr["类型"] = leaderInfo.type;
                dr["技能"] = leaderInfo.skill;
                dr["最大"] = leaderInfo.max_skill;
                int num = leaderInfo.add_trait.Count;
                if (num > 0)
                    dr["技能1"] = leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[0]).traitName;
                if (num > 1)
                    dr["技能2"] = leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[1]).traitName;
                if (num > 2)
                    dr["技能3"] = leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[2]).traitName;
                if (num > 3)
                    dr["技能4"] = leaderTraitList.Find(t => t.traitCode == leaderInfo.add_trait[3]).traitName;

                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false; //去掉最左边的空列
        }

        private string GetOOBType(ArmyTypeEnum at)
        {
            switch (at)
            {
                case ArmyTypeEnum.Theatre:
                    return "land";
                case ArmyTypeEnum.ArmyGroup:
                    return "land";
                case ArmyTypeEnum.Army:
                    return "land";
                case ArmyTypeEnum.Corps:
                    return "land";
                case ArmyTypeEnum.Division:
                    return "land";
                case ArmyTypeEnum.Navy:
                    return "sea";
                case ArmyTypeEnum.Air:
                    return "air";
                default:
                    return "";
            }
        }

        private Bitmap showTraitImage(string traitName)
        {
            string traitPath = RetuenPath(string.Concat(pathInfo.gfxPath, "interface\\icon_", traitName, ".dds"));

            Bitmap m_bmpTrait = DevIL.DevIL.LoadBitmap(traitPath);
            return m_bmpTrait;
        }


        #region
        private void pictureBox_trait1_MouseHover(object sender, EventArgs e)
        {
            if (traitList != null)
            {
                lbl_TraitText.Visible = true;
                lbl_TraitText.Text = traitList[0];
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                Point point = new Point(formPoint.X + 5, formPoint.Y - 5);
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
                Point point = new Point(formPoint.X + 5, formPoint.Y - 5);
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
                Point point = new Point(formPoint.X + 5, formPoint.Y - 5);
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
                Point point = new Point(formPoint.X + 5, formPoint.Y - 5);
                lbl_TraitText.Location = point;
            }
        }

        private void pictureBox_trait4_MouseLeave(object sender, EventArgs e)
        {
            lbl_TraitText.Visible = false;
        }
        #endregion


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.Close();
            this.change_Leader(ID);
        }

        /// <summary>
        /// 传入文件路径判断是否存在，如果不存在判断移除TFH文件夹名字
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string RetuenPath(string path)
        {
            string returnPath = path;
            if (!File.Exists(path))
            {
                if (!File.Exists(returnPath) && path.ToLower().IndexOf("tfh") > -1)
                {
                    returnPath = path.Remove(path.ToLower().IndexOf("tfh"), 4);
                }

            }
            return returnPath;
        }

        //待修改
        private string ReturnLeaderPicturePath(string pictureName)
        {
            string leaderPath = "";
            if (!string.IsNullOrEmpty(pictureName))
            {
                leaderPath = string.Concat(pathInfo.gfxPath, "pictures\\portraits\\", pictureName, ".tga");
                if (!File.Exists(leaderPath))
                {
                    if (leaderPath.ToLower().IndexOf("tfh") > -1)
                    {
                        leaderPath = leaderPath.Remove(leaderPath.ToLower().IndexOf("tfh"), 4);
                        if (!File.Exists(leaderPath))
                        {
                            leaderPath = string.Concat(pathInfo.gfxPath, "pictures\\portraits\\empty_position.tga");
                            if (leaderPath.ToLower().IndexOf("tfh") > -1)
                            {
                                leaderPath = leaderPath.Remove(leaderPath.ToLower().IndexOf("tfh"), 4);
                            }
                        }
                    }
                }
            }
            else
            {
                leaderPath = string.Concat(pathInfo.gfxPath, "pictures\\portraits\\empty_position.tga");
                if (!File.Exists(leaderPath))
                {
                    if (leaderPath.ToLower().IndexOf("tfh") > -1)
                    {
                        leaderPath = leaderPath.Remove(leaderPath.ToLower().IndexOf("tfh"), 4);
                    }
                }
            }
            return leaderPath;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_LeaderName.Text = "";
            BindLeaderMaxSkill();
            BindLeaderTrait();
            DataGridViewBind();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string leaderTraitCode = string.Empty;
            string leaderMaxSkill = string.Empty;
            if (cbb_LeaderTrait.SelectedItem != null)
            {
                if (!((string)cbb_LeaderTrait.SelectedItem).Equals("请选择"))
                {
                    leaderTraitCode = leaderTraitList.Find(lt => lt.traitName == (string)cbb_LeaderTrait.SelectedItem).traitCode;
                }
            }
            if (cbb_MaxSkill.SelectedItem != null)
            {
                if (!cbb_MaxSkill.SelectedItem.ToString().Equals("请选择"))
                {
                    leaderMaxSkill = cbb_MaxSkill.SelectedItem.ToString();
                }
            }
            DataGridViewBind(txt_LeaderName.Text, leaderMaxSkill, leaderTraitCode);
        }
    }
}
