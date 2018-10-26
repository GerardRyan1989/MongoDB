using MongoDBCA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1320, 1050);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(25, 25);

            LoadPanels();
            panelUpdate.Visible = false;
            panelAdd.Visible = false;
            panelRemove.Visible = false;
            panelSearch2.Visible = false;
            HomePanel.Visible = true;

        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = false;
            panelUpdate.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = true;

            panelUpdate.Visible = false;
            panelRemove.Visible = false;
            panelSearch2.Visible = false;
            HomePanel.Visible = false;

        }



        private void LoadPanels()
        {
          
            panelAdd.Location = new Point(296, 70);
            panelUpdate.Location = new Point(296, 70);
            HomePanel.Location = new Point(296, 70);
            panelRemove.Location = new Point(296, 70);
            panelSearch2.Location = new Point(296, 70);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            panelRemove.Visible = true;

            panelUpdate.Visible = false;
            panelAdd.Visible = false;
            panelSearch2.Visible = false;
            HomePanel.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelSearch2.Visible = true;

            panelUpdate.Visible = false;
            panelRemove.Visible = false;
            panelAdd.Visible = false;
            HomePanel.Visible = false;
        }
    }
}
