namespace OOBEditor
{
    partial class SelectLeaderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLeaderForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_TraitText = new System.Windows.Forms.Label();
            this.pictureBox_trait4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_trait3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_trait2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_trait1 = new System.Windows.Forms.PictureBox();
            this.lbl_MaxSkill = new System.Windows.Forms.Label();
            this.lbl_Skill = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picture_Leader = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_LeaderName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_LeaderTrait = new System.Windows.Forms.ComboBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.cbb_MaxSkill = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Leader)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 283);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "将领信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(754, 264);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_TraitText);
            this.groupBox3.Controls.Add(this.pictureBox_trait4);
            this.groupBox3.Controls.Add(this.pictureBox_trait3);
            this.groupBox3.Controls.Add(this.pictureBox_trait2);
            this.groupBox3.Controls.Add(this.pictureBox_trait1);
            this.groupBox3.Controls.Add(this.lbl_MaxSkill);
            this.groupBox3.Controls.Add(this.lbl_Skill);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lbl_Name);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.picture_Leader);
            this.groupBox3.Location = new System.Drawing.Point(12, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(757, 78);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "当前将领";
            // 
            // lbl_TraitText
            // 
            this.lbl_TraitText.AutoSize = true;
            this.lbl_TraitText.Location = new System.Drawing.Point(662, 45);
            this.lbl_TraitText.Name = "lbl_TraitText";
            this.lbl_TraitText.Size = new System.Drawing.Size(35, 13);
            this.lbl_TraitText.TabIndex = 12;
            this.lbl_TraitText.Text = "label5";
            this.lbl_TraitText.Visible = false;
            // 
            // pictureBox_trait4
            // 
            this.pictureBox_trait4.Location = new System.Drawing.Point(577, 45);
            this.pictureBox_trait4.Name = "pictureBox_trait4";
            this.pictureBox_trait4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait4.TabIndex = 11;
            this.pictureBox_trait4.TabStop = false;
            this.pictureBox_trait4.MouseLeave += new System.EventHandler(this.pictureBox_trait4_MouseLeave);
            this.pictureBox_trait4.MouseHover += new System.EventHandler(this.pictureBox_trait4_MouseHover);
            // 
            // pictureBox_trait3
            // 
            this.pictureBox_trait3.Location = new System.Drawing.Point(536, 45);
            this.pictureBox_trait3.Name = "pictureBox_trait3";
            this.pictureBox_trait3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait3.TabIndex = 10;
            this.pictureBox_trait3.TabStop = false;
            this.pictureBox_trait3.MouseLeave += new System.EventHandler(this.pictureBox_trait3_MouseLeave);
            this.pictureBox_trait3.MouseHover += new System.EventHandler(this.pictureBox_trait3_MouseHover);
            // 
            // pictureBox_trait2
            // 
            this.pictureBox_trait2.Location = new System.Drawing.Point(492, 45);
            this.pictureBox_trait2.Name = "pictureBox_trait2";
            this.pictureBox_trait2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait2.TabIndex = 9;
            this.pictureBox_trait2.TabStop = false;
            this.pictureBox_trait2.MouseLeave += new System.EventHandler(this.pictureBox_trait2_MouseLeave);
            this.pictureBox_trait2.MouseHover += new System.EventHandler(this.pictureBox_trait2_MouseHover);
            // 
            // pictureBox_trait1
            // 
            this.pictureBox_trait1.Location = new System.Drawing.Point(451, 45);
            this.pictureBox_trait1.Name = "pictureBox_trait1";
            this.pictureBox_trait1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_trait1.TabIndex = 8;
            this.pictureBox_trait1.TabStop = false;
            this.pictureBox_trait1.MouseLeave += new System.EventHandler(this.pictureBox_trait1_MouseLeave);
            this.pictureBox_trait1.MouseHover += new System.EventHandler(this.pictureBox_trait1_MouseHover);
            // 
            // lbl_MaxSkill
            // 
            this.lbl_MaxSkill.AutoSize = true;
            this.lbl_MaxSkill.Location = new System.Drawing.Point(317, 54);
            this.lbl_MaxSkill.Name = "lbl_MaxSkill";
            this.lbl_MaxSkill.Size = new System.Drawing.Size(0, 13);
            this.lbl_MaxSkill.TabIndex = 7;
            // 
            // lbl_Skill
            // 
            this.lbl_Skill.AutoSize = true;
            this.lbl_Skill.Location = new System.Drawing.Point(202, 54);
            this.lbl_Skill.Name = "lbl_Skill";
            this.lbl_Skill.Size = new System.Drawing.Size(0, 13);
            this.lbl_Skill.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "技能";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "最大技能";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前技能";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(81, 54);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名";
            // 
            // picture_Leader
            // 
            this.picture_Leader.Location = new System.Drawing.Point(6, 18);
            this.picture_Leader.Name = "picture_Leader";
            this.picture_Leader.Size = new System.Drawing.Size(38, 52);
            this.picture_Leader.TabIndex = 0;
            this.picture_Leader.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_MaxSkill);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.btn_Clear);
            this.groupBox1.Controls.Add(this.cbb_LeaderTrait);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_LeaderName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 40);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "姓名";
            // 
            // txt_LeaderName
            // 
            this.txt_LeaderName.Location = new System.Drawing.Point(50, 13);
            this.txt_LeaderName.Name = "txt_LeaderName";
            this.txt_LeaderName.Size = new System.Drawing.Size(133, 20);
            this.txt_LeaderName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "技能";
            // 
            // cbb_LeaderTrait
            // 
            this.cbb_LeaderTrait.FormattingEnabled = true;
            this.cbb_LeaderTrait.Location = new System.Drawing.Point(451, 13);
            this.cbb_LeaderTrait.Name = "cbb_LeaderTrait";
            this.cbb_LeaderTrait.Size = new System.Drawing.Size(121, 21);
            this.cbb_LeaderTrait.TabIndex = 7;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(587, 11);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 8;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(676, 11);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "搜索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // cbb_MaxSkill
            // 
            this.cbb_MaxSkill.FormattingEnabled = true;
            this.cbb_MaxSkill.Location = new System.Drawing.Point(263, 13);
            this.cbb_MaxSkill.Name = "cbb_MaxSkill";
            this.cbb_MaxSkill.Size = new System.Drawing.Size(121, 21);
            this.cbb_MaxSkill.TabIndex = 10;
            // 
            // SelectLeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectLeaderForm";
            this.Text = "选择将领";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trait1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Leader)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picture_Leader;
        private System.Windows.Forms.Label lbl_MaxSkill;
        private System.Windows.Forms.Label lbl_Skill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_trait4;
        private System.Windows.Forms.PictureBox pictureBox_trait3;
        private System.Windows.Forms.PictureBox pictureBox_trait2;
        private System.Windows.Forms.PictureBox pictureBox_trait1;
        private System.Windows.Forms.Label lbl_TraitText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_LeaderTrait;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_LeaderName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.ComboBox cbb_MaxSkill;
    }
}