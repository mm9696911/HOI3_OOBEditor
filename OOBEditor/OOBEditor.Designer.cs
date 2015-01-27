namespace OOBEditor
{
    partial class OOBEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OOBEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.加载文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ccb_SelectCountry = new System.Windows.Forms.ComboBox();
            this.lbl_SelectCountry = new System.Windows.Forms.Label();
            this.ccb_SelectScenarios = new System.Windows.Forms.ComboBox();
            this.lbl_SelectScenarios = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tv_Military = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Reserve = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_BasicLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BasicID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_BasicType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BasicName = new System.Windows.Forms.TextBox();
            this.pb_CountryFlag = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_TraitText = new System.Windows.Forms.Label();
            this.pictureBox_trait4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_trait3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_trait2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_trait1 = new System.Windows.Forms.PictureBox();
            this.txt_LeaderRank = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_LeaderMaxSkill = new System.Windows.Forms.TextBox();
            this.txt_LeaderID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_LeaderSkill = new System.Windows.Forms.TextBox();
            this.txt_LeaderName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pb_Leader = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加新部队ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除当前部队ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加将领ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.变更将领ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除当前将领ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_AddAttBriage = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CountryFlag)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Leader)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载文件ToolStripMenuItem,
            this.设置路径ToolStripMenuItem,
            this.保存文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 加载文件ToolStripMenuItem
            // 
            this.加载文件ToolStripMenuItem.Name = "加载文件ToolStripMenuItem";
            this.加载文件ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.加载文件ToolStripMenuItem.Text = "加载文件";
            this.加载文件ToolStripMenuItem.Click += new System.EventHandler(this.加载文件ToolStripMenuItem_Click);
            // 
            // 设置路径ToolStripMenuItem
            // 
            this.设置路径ToolStripMenuItem.Name = "设置路径ToolStripMenuItem";
            this.设置路径ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.设置路径ToolStripMenuItem.Text = "设置路径";
            this.设置路径ToolStripMenuItem.Click += new System.EventHandler(this.设置路径ToolStripMenuItem_Click);
            // 
            // 保存文件ToolStripMenuItem
            // 
            this.保存文件ToolStripMenuItem.Name = "保存文件ToolStripMenuItem";
            this.保存文件ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.保存文件ToolStripMenuItem.Text = "保存文件";
            this.保存文件ToolStripMenuItem.Click += new System.EventHandler(this.保存文件ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ccb_SelectCountry);
            this.groupBox2.Controls.Add(this.lbl_SelectCountry);
            this.groupBox2.Controls.Add(this.ccb_SelectScenarios);
            this.groupBox2.Controls.Add(this.lbl_SelectScenarios);
            this.groupBox2.Location = new System.Drawing.Point(13, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // ccb_SelectCountry
            // 
            this.ccb_SelectCountry.FormattingEnabled = true;
            this.ccb_SelectCountry.Location = new System.Drawing.Point(290, 17);
            this.ccb_SelectCountry.Name = "ccb_SelectCountry";
            this.ccb_SelectCountry.Size = new System.Drawing.Size(121, 21);
            this.ccb_SelectCountry.TabIndex = 3;
            // 
            // lbl_SelectCountry
            // 
            this.lbl_SelectCountry.AutoSize = true;
            this.lbl_SelectCountry.Location = new System.Drawing.Point(220, 20);
            this.lbl_SelectCountry.Name = "lbl_SelectCountry";
            this.lbl_SelectCountry.Size = new System.Drawing.Size(58, 13);
            this.lbl_SelectCountry.TabIndex = 2;
            this.lbl_SelectCountry.Text = "选择国家:";
            // 
            // ccb_SelectScenarios
            // 
            this.ccb_SelectScenarios.FormattingEnabled = true;
            this.ccb_SelectScenarios.Location = new System.Drawing.Point(80, 17);
            this.ccb_SelectScenarios.Name = "ccb_SelectScenarios";
            this.ccb_SelectScenarios.Size = new System.Drawing.Size(121, 21);
            this.ccb_SelectScenarios.TabIndex = 1;
            // 
            // lbl_SelectScenarios
            // 
            this.lbl_SelectScenarios.AutoSize = true;
            this.lbl_SelectScenarios.Location = new System.Drawing.Point(10, 20);
            this.lbl_SelectScenarios.Name = "lbl_SelectScenarios";
            this.lbl_SelectScenarios.Size = new System.Drawing.Size(67, 13);
            this.lbl_SelectScenarios.TabIndex = 0;
            this.lbl_SelectScenarios.Text = "选择剧本：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tv_Military);
            this.groupBox3.Location = new System.Drawing.Point(13, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 594);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "军队";
            // 
            // tv_Military
            // 
            this.tv_Military.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Military.Location = new System.Drawing.Point(3, 16);
            this.tv_Military.Name = "tv_Military";
            this.tv_Military.Size = new System.Drawing.Size(302, 575);
            this.tv_Military.TabIndex = 0;
            this.tv_Military.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Military_AfterSelect);
            this.tv_Military.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Military_NodeMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Reserve);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_BasicLocation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_BasicID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_BasicType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_BasicName);
            this.groupBox1.Controls.Add(this.pb_CountryFlag);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(327, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 103);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // cb_Reserve
            // 
            this.cb_Reserve.AutoSize = true;
            this.cb_Reserve.Location = new System.Drawing.Point(339, 70);
            this.cb_Reserve.Name = "cb_Reserve";
            this.cb_Reserve.Size = new System.Drawing.Size(15, 14);
            this.cb_Reserve.TabIndex = 10;
            this.cb_Reserve.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "预备役";
            // 
            // txt_BasicLocation
            // 
            this.txt_BasicLocation.Location = new System.Drawing.Point(160, 67);
            this.txt_BasicLocation.Name = "txt_BasicLocation";
            this.txt_BasicLocation.Size = new System.Drawing.Size(100, 20);
            this.txt_BasicLocation.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "位置";
            // 
            // txt_BasicID
            // 
            this.txt_BasicID.Location = new System.Drawing.Point(307, 42);
            this.txt_BasicID.Name = "txt_BasicID";
            this.txt_BasicID.ReadOnly = true;
            this.txt_BasicID.Size = new System.Drawing.Size(76, 20);
            this.txt_BasicID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID";
            // 
            // txt_BasicType
            // 
            this.txt_BasicType.Location = new System.Drawing.Point(160, 42);
            this.txt_BasicType.Name = "txt_BasicType";
            this.txt_BasicType.ReadOnly = true;
            this.txt_BasicType.Size = new System.Drawing.Size(100, 20);
            this.txt_BasicType.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "类型";
            // 
            // txt_BasicName
            // 
            this.txt_BasicName.Location = new System.Drawing.Point(160, 16);
            this.txt_BasicName.Name = "txt_BasicName";
            this.txt_BasicName.Size = new System.Drawing.Size(223, 20);
            this.txt_BasicName.TabIndex = 2;
            // 
            // pb_CountryFlag
            // 
            this.pb_CountryFlag.Location = new System.Drawing.Point(7, 20);
            this.pb_CountryFlag.Name = "pb_CountryFlag";
            this.pb_CountryFlag.Size = new System.Drawing.Size(92, 65);
            this.pb_CountryFlag.TabIndex = 1;
            this.pb_CountryFlag.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_TraitText);
            this.groupBox4.Controls.Add(this.pictureBox_trait4);
            this.groupBox4.Controls.Add(this.pictureBox_trait3);
            this.groupBox4.Controls.Add(this.pictureBox_trait2);
            this.groupBox4.Controls.Add(this.pictureBox_trait1);
            this.groupBox4.Controls.Add(this.txt_LeaderRank);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txt_LeaderMaxSkill);
            this.groupBox4.Controls.Add(this.txt_LeaderID);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txt_LeaderSkill);
            this.groupBox4.Controls.Add(this.txt_LeaderName);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.pb_Leader);
            this.groupBox4.Location = new System.Drawing.Point(328, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(428, 106);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "将领信息";
            // 
            // lbl_TraitText
            // 
            this.lbl_TraitText.AutoSize = true;
            this.lbl_TraitText.Location = new System.Drawing.Point(283, 76);
            this.lbl_TraitText.Name = "lbl_TraitText";
            this.lbl_TraitText.Size = new System.Drawing.Size(35, 13);
            this.lbl_TraitText.TabIndex = 17;
            this.lbl_TraitText.Text = "label5";
            this.lbl_TraitText.Visible = false;
            // 
            // pictureBox_trait4
            // 
            this.pictureBox_trait4.Location = new System.Drawing.Point(198, 76);
            this.pictureBox_trait4.Name = "pictureBox_trait4";
            this.pictureBox_trait4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait4.TabIndex = 16;
            this.pictureBox_trait4.TabStop = false;
            this.pictureBox_trait4.MouseLeave += new System.EventHandler(this.pictureBox_trait4_MouseLeave);
            this.pictureBox_trait4.MouseHover += new System.EventHandler(this.pictureBox_trait4_MouseHover);
            // 
            // pictureBox_trait3
            // 
            this.pictureBox_trait3.Location = new System.Drawing.Point(157, 76);
            this.pictureBox_trait3.Name = "pictureBox_trait3";
            this.pictureBox_trait3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait3.TabIndex = 15;
            this.pictureBox_trait3.TabStop = false;
            this.pictureBox_trait3.MouseLeave += new System.EventHandler(this.pictureBox_trait3_MouseLeave);
            this.pictureBox_trait3.MouseHover += new System.EventHandler(this.pictureBox_trait3_MouseHover);
            // 
            // pictureBox_trait2
            // 
            this.pictureBox_trait2.Location = new System.Drawing.Point(113, 76);
            this.pictureBox_trait2.Name = "pictureBox_trait2";
            this.pictureBox_trait2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait2.TabIndex = 14;
            this.pictureBox_trait2.TabStop = false;
            this.pictureBox_trait2.MouseLeave += new System.EventHandler(this.pictureBox_trait2_MouseLeave);
            this.pictureBox_trait2.MouseHover += new System.EventHandler(this.pictureBox_trait2_MouseHover);
            // 
            // pictureBox_trait1
            // 
            this.pictureBox_trait1.Location = new System.Drawing.Point(72, 76);
            this.pictureBox_trait1.Name = "pictureBox_trait1";
            this.pictureBox_trait1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait1.TabIndex = 13;
            this.pictureBox_trait1.TabStop = false;
            this.pictureBox_trait1.MouseLeave += new System.EventHandler(this.pictureBox_trait1_MouseLeave);
            this.pictureBox_trait1.MouseHover += new System.EventHandler(this.pictureBox_trait1_MouseHover);
            // 
            // txt_LeaderRank
            // 
            this.txt_LeaderRank.Location = new System.Drawing.Point(325, 50);
            this.txt_LeaderRank.Name = "txt_LeaderRank";
            this.txt_LeaderRank.ReadOnly = true;
            this.txt_LeaderRank.Size = new System.Drawing.Size(57, 20);
            this.txt_LeaderRank.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "等级";
            // 
            // txt_LeaderMaxSkill
            // 
            this.txt_LeaderMaxSkill.Location = new System.Drawing.Point(239, 50);
            this.txt_LeaderMaxSkill.Name = "txt_LeaderMaxSkill";
            this.txt_LeaderMaxSkill.ReadOnly = true;
            this.txt_LeaderMaxSkill.Size = new System.Drawing.Size(38, 20);
            this.txt_LeaderMaxSkill.TabIndex = 8;
            // 
            // txt_LeaderID
            // 
            this.txt_LeaderID.Location = new System.Drawing.Point(260, 16);
            this.txt_LeaderID.Name = "txt_LeaderID";
            this.txt_LeaderID.ReadOnly = true;
            this.txt_LeaderID.Size = new System.Drawing.Size(122, 20);
            this.txt_LeaderID.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "最大技能";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "ID";
            // 
            // txt_LeaderSkill
            // 
            this.txt_LeaderSkill.Location = new System.Drawing.Point(118, 50);
            this.txt_LeaderSkill.Name = "txt_LeaderSkill";
            this.txt_LeaderSkill.ReadOnly = true;
            this.txt_LeaderSkill.Size = new System.Drawing.Size(38, 20);
            this.txt_LeaderSkill.TabIndex = 4;
            // 
            // txt_LeaderName
            // 
            this.txt_LeaderName.Location = new System.Drawing.Point(118, 16);
            this.txt_LeaderName.Name = "txt_LeaderName";
            this.txt_LeaderName.ReadOnly = true;
            this.txt_LeaderName.Size = new System.Drawing.Size(100, 20);
            this.txt_LeaderName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "技能点";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "姓名";
            // 
            // pb_Leader
            // 
            this.pb_Leader.Location = new System.Drawing.Point(14, 31);
            this.pb_Leader.Name = "pb_Leader";
            this.pb_Leader.Size = new System.Drawing.Size(38, 52);
            this.pb_Leader.TabIndex = 0;
            this.pb_Leader.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加新部队ToolStripMenuItem,
            this.删除当前部队ToolStripMenuItem,
            this.添加将领ToolStripMenuItem,
            this.变更将领ToolStripMenuItem,
            this.删除当前将领ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 114);
            // 
            // 添加新部队ToolStripMenuItem
            // 
            this.添加新部队ToolStripMenuItem.Name = "添加新部队ToolStripMenuItem";
            this.添加新部队ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.添加新部队ToolStripMenuItem.Text = "添加新部队";
            this.添加新部队ToolStripMenuItem.Click += new System.EventHandler(this.添加新部队ToolStripMenuItem_Click);
            // 
            // 删除当前部队ToolStripMenuItem
            // 
            this.删除当前部队ToolStripMenuItem.Name = "删除当前部队ToolStripMenuItem";
            this.删除当前部队ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.删除当前部队ToolStripMenuItem.Text = "删除当前部队";
            this.删除当前部队ToolStripMenuItem.Click += new System.EventHandler(this.删除当前部队ToolStripMenuItem_Click);
            // 
            // 添加将领ToolStripMenuItem
            // 
            this.添加将领ToolStripMenuItem.Name = "添加将领ToolStripMenuItem";
            this.添加将领ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.添加将领ToolStripMenuItem.Text = "添加将领";
            this.添加将领ToolStripMenuItem.Click += new System.EventHandler(this.添加将领ToolStripMenuItem_Click);
            // 
            // 变更将领ToolStripMenuItem
            // 
            this.变更将领ToolStripMenuItem.Name = "变更将领ToolStripMenuItem";
            this.变更将领ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.变更将领ToolStripMenuItem.Text = "变更将领";
            this.变更将领ToolStripMenuItem.Click += new System.EventHandler(this.变更将领ToolStripMenuItem_Click);
            // 
            // 删除当前将领ToolStripMenuItem
            // 
            this.删除当前将领ToolStripMenuItem.Name = "删除当前将领ToolStripMenuItem";
            this.删除当前将领ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.删除当前将领ToolStripMenuItem.Text = "删除当前将领";
            this.删除当前将领ToolStripMenuItem.Click += new System.EventHandler(this.删除当前将领ToolStripMenuItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Location = new System.Drawing.Point(334, 344);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(429, 298);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "附属部队";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 279);
            this.panel1.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(653, 648);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Save);
            // 
            // btn_AddAttBriage
            // 
            this.btn_AddAttBriage.Location = new System.Drawing.Point(643, 315);
            this.btn_AddAttBriage.Name = "btn_AddAttBriage";
            this.btn_AddAttBriage.Size = new System.Drawing.Size(94, 23);
            this.btn_AddAttBriage.TabIndex = 8;
            this.btn_AddAttBriage.Text = "添加附属部队";
            this.btn_AddAttBriage.UseVisualStyleBackColor = true;
            this.btn_AddAttBriage.Click += new System.EventHandler(this.btn_AddAttBriage_Click);
            // 
            // OOBEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 686);
            this.Controls.Add(this.btn_AddAttBriage);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "OOBEditor";
            this.Text = "OOBEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CountryFlag)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Leader)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加载文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ccb_SelectCountry;
        private System.Windows.Forms.Label lbl_SelectCountry;
        private System.Windows.Forms.ComboBox ccb_SelectScenarios;
        private System.Windows.Forms.Label lbl_SelectScenarios;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tv_Military;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_BasicLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BasicID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_BasicType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BasicName;
        private System.Windows.Forms.PictureBox pb_CountryFlag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_Reserve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pb_Leader;
        private System.Windows.Forms.TextBox txt_LeaderMaxSkill;
        private System.Windows.Forms.TextBox txt_LeaderID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_LeaderSkill;
        private System.Windows.Forms.TextBox txt_LeaderName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加新部队ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除当前部队ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加将领ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 变更将领ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除当前将领ToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_LeaderRank;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_AddAttBriage;
        private System.Windows.Forms.Label lbl_TraitText;
        private System.Windows.Forms.PictureBox pictureBox_trait4;
        private System.Windows.Forms.PictureBox pictureBox_trait3;
        private System.Windows.Forms.PictureBox pictureBox_trait2;
        private System.Windows.Forms.PictureBox pictureBox_trait1;
    }
}