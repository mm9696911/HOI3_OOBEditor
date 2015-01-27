namespace OOBEditor
{
    partial class AddMilitaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMilitaryForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_BasicType = new System.Windows.Forms.ComboBox();
            this.cb_Reserve = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_BasicLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BasicID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BasicName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_AddAttachment = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_BasicType);
            this.groupBox1.Controls.Add(this.cb_Reserve);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_BasicLocation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_BasicID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_BasicName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // cbb_BasicType
            // 
            this.cbb_BasicType.FormattingEnabled = true;
            this.cbb_BasicType.Location = new System.Drawing.Point(60, 41);
            this.cbb_BasicType.Name = "cbb_BasicType";
            this.cbb_BasicType.Size = new System.Drawing.Size(100, 21);
            this.cbb_BasicType.TabIndex = 11;
            // 
            // cb_Reserve
            // 
            this.cb_Reserve.AutoSize = true;
            this.cb_Reserve.Location = new System.Drawing.Point(228, 70);
            this.cb_Reserve.Name = "cb_Reserve";
            this.cb_Reserve.Size = new System.Drawing.Size(15, 14);
            this.cb_Reserve.TabIndex = 10;
            this.cb_Reserve.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "预备役";
            // 
            // txt_BasicLocation
            // 
            this.txt_BasicLocation.Location = new System.Drawing.Point(60, 67);
            this.txt_BasicLocation.Name = "txt_BasicLocation";
            this.txt_BasicLocation.Size = new System.Drawing.Size(100, 20);
            this.txt_BasicLocation.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "位置";
            // 
            // txt_BasicID
            // 
            this.txt_BasicID.Location = new System.Drawing.Point(204, 42);
            this.txt_BasicID.Name = "txt_BasicID";
            this.txt_BasicID.ReadOnly = true;
            this.txt_BasicID.Size = new System.Drawing.Size(76, 20);
            this.txt_BasicID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "类型";
            // 
            // txt_BasicName
            // 
            this.txt_BasicName.Location = new System.Drawing.Point(60, 16);
            this.txt_BasicName.Name = "txt_BasicName";
            this.txt_BasicName.Size = new System.Drawing.Size(223, 20);
            this.txt_BasicName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(202, 451);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(56, 451);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Location = new System.Drawing.Point(12, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(347, 284);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "附属部队";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 265);
            this.panel1.TabIndex = 0;
            // 
            // btn_AddAttachment
            // 
            this.btn_AddAttachment.Location = new System.Drawing.Point(223, 132);
            this.btn_AddAttachment.Name = "btn_AddAttachment";
            this.btn_AddAttachment.Size = new System.Drawing.Size(88, 23);
            this.btn_AddAttachment.TabIndex = 9;
            this.btn_AddAttachment.Text = "添加附属部队";
            this.btn_AddAttachment.UseVisualStyleBackColor = true;
            this.btn_AddAttachment.Click += new System.EventHandler(this.btn_AddAttachment_Click);
            // 
            // AddMilitaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 481);
            this.Controls.Add(this.btn_AddAttachment);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddMilitaryForm";
            this.Text = "AddMilitaryForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_Reserve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_BasicLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BasicID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BasicName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_AddAttachment;
        private System.Windows.Forms.ComboBox cbb_BasicType;

    }
}