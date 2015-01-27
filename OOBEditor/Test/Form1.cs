using OOBEditor.Model;
using OOBEditor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOBEditor.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PathInfo pathInfo = new PathInfo();
            //pathInfo.leaderPath = "E:\\game\\HOI3-WW1\\tfh\\history\\localisation\\";
            //LoadDataServices load = new LoadDataServices(pathInfo,"AFG");
            //load.LoadLeaderInfo();
            pathInfo.localisationPath = "E:\\game\\HOI3-WW1\\tfh\\localisation\\";
            LoadDataServices load = new LoadDataServices(pathInfo);
            load.LoadCountry();
        }
    }
}
