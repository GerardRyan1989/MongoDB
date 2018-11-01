using MongoDBCA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class MongoUI : Form
    {

        public string update_id { get; set; }
        public string delete_id { get; set; }




        public MongoUI()
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

            panelUpdate.Visible = true;

            panelSearch2.Visible = false;       
            panelRemove.Visible = false;
            panelAdd.Visible = false;
            HomePanel.Visible = false;
            panelMapReduce.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = true;

            panelUpdate.Visible = false;
            panelRemove.Visible = false;
            panelSearch2.Visible = false;
            HomePanel.Visible = false;
            panelMapReduce.Visible = false;

        }

        private void LoadPanels()
        {
          
            panelAdd.Location = new Point(296, 70);
            panelUpdate.Location = new Point(296, 70);
            HomePanel.Location = new Point(296, 70);
            panelRemove.Location = new Point(296, 70);
            panelSearch2.Location = new Point(296, 70);
            panelMapReduce.Location = new Point(296, 76);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            panelRemove.Visible = true;

            panelUpdate.Visible = false;
            panelAdd.Visible = false;
            panelSearch2.Visible = false;
            HomePanel.Visible = false;
            panelMapReduce.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelSearch2.Visible = true;

            panelUpdate.Visible = false;
            panelRemove.Visible = false;
            panelAdd.Visible = false;
            HomePanel.Visible = false;
            panelMapReduce.Visible = false;
        }

        private void BtnAddFigther_Click(object sender, EventArgs e)
        {

            MongoAdd add = new MongoAdd();

            try
            {
                FighterProfile fighter = new FighterProfile()
                {
                    Name = txtName.Text.ToString(),
                    Age = Convert.ToInt32(txtAge.Text.ToString()),
                    WinLossRecord = new FightRecord()
                    {
                        Wins = Convert.ToInt32(txtWins.Text.ToString()),
                        Losses = Convert.ToInt32(txtLosses.Text.ToString()),
                        Draws =  Convert.ToInt32(txtDraws.Text.ToString()),
                    },
                    Nickname = txtNickName.Text,
                    Height = Convert.ToDouble(txtHeight.Text.ToString()),
                    Weight = Convert.ToDouble(txtWeight.Text.ToString()),
                    FightStyle = new FightStyle()
                    {
                        Style = txtFightStye.Text.ToString()
                    },
                    WeightClass = txtWeightClass.Text
                };


               add.AddFighter(fighter);

            }catch(Exception ex)
            {
                MessageBox.Show("Please ensure all fields are filled in!");
            }
            
        }

        private async void btnSearchFighter_Click(object sender, EventArgs e)
        {
            MongoRead read = new MongoRead();


         
            var fighter = await read.getFighter(txtSearchFirstName.Text, txtSearchLastName.Text);
           
  
            if (fighter != null)
            {
                txtSearchName.Text = fighter.Name.ToString();
                txtSearchNickName.Text = fighter.Nickname.ToString();
                txtSearchHeight.Text = fighter.Height.ToString();
                txtSearchFightStyle.Text = fighter.FightStyle.Style.ToString();
                txtUpdateWeightClass.Text = fighter.WeightClass.ToString();
                txtSearchAge.Text = fighter.Age.ToString();
                txtSearchDraws.Text = fighter.WinLossRecord.Draws.ToString();
                txtSearchWins.Text = fighter.WinLossRecord.Wins.ToString();
                txtSearchlosses.Text = fighter.WinLossRecord.Losses.ToString();
                txtSearchWeightClass.Text = fighter.WeightClass.ToString();
                txtSearchWeight.Text = fighter.Weight.ToString();
            }
           



        }

        private async void btnUpdateSearch_Click(object sender, EventArgs e)
        {
            MongoRead read = new MongoRead();

            FighterProfile fighter = null;

            try {
                fighter = await read.getFighter(txtUpdateFirstName.Text, txtUpdateLastName.Text);
                update_id = fighter._id;
            }
            catch (Exception ex)
            {
                //No Error Message Needed 
            }

   


            if (update_id != null)
            {
                txtUpdateName.Text = fighter.Name.ToString();
                txtUpdateNickName.Text = fighter.Nickname.ToString();
                txtUpdateHeight.Text = fighter.Height.ToString();
                txtUpdateFightStyle.Text = fighter.FightStyle.Style.ToString();
                txtUpdateWeightClass.Text = fighter.WeightClass.ToString();
                txtUpdateAge.Text = fighter.Age.ToString();
                txtUpdateDraws.Text = fighter.WinLossRecord.Draws.ToString();
                txtUpdateWins.Text = fighter.WinLossRecord.Wins.ToString();
                txtUpdateLosses.Text = fighter.WinLossRecord.Losses.ToString();
                txtUpdateWeightClass.Text = fighter.WeightClass.ToString();
                txtUpdateWeight.Text = fighter.Weight.ToString();
            }
               
         
        }



        private void btnUpdateFighter_Click(object sender, EventArgs e)
        {
            MongoUpdate update = new MongoUpdate();


            try
            {
                FighterProfile fighter = new FighterProfile()
                {
                    _id = update_id,
                    Name = txtUpdateName.Text.ToString(),
                    Age = Convert.ToInt32(txtUpdateAge.Text.ToString()),
                    WinLossRecord = new FightRecord()
                    {
                        Wins = Convert.ToInt32(txtUpdateWins.Text.ToString()),
                        Losses = Convert.ToInt32(txtUpdateLosses.Text.ToString()),
                        Draws = Convert.ToInt32(txtUpdateDraws.Text.ToString()),
                    },
                    Nickname = txtUpdateNickName.Text,
                    Height = Convert.ToDouble(txtUpdateHeight.Text.ToString()),
                    Weight = Convert.ToDouble(txtUpdateWeight.Text.ToString()),
                    FightStyle = new FightStyle()
                    {
                        Style = txtUpdateFightStyle.Text.ToString()
                    },
                    WeightClass = txtUpdateWeightClass.Text
                };


                update.updateFighter(fighter);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please ensure all fields are filled in!");
            }
        }

        private async void txtRemoveSearch_Click(object sender, EventArgs e)
        {
            MongoRead read = new MongoRead();
            FighterProfile fighter = null;

            try
            {
                fighter = await read.getFighter(txtremoveFirstName.Text, txtremoveLastName.Text);
                delete_id = fighter._id;
            }
            catch (Exception ex)
            {
                //No Error Message Needed 
            }


            if (delete_id != null)
            {
                    txtRemoveName.Text = fighter.Name.ToString();
                    txtRemoveNickName.Text = fighter.Nickname.ToString();
                    txtRemoveheight.Text = fighter.Height.ToString();
                    txtRemoveFightStyle.Text = fighter.FightStyle.Style.ToString();
                    txtRemoveWeightClass.Text = fighter.WeightClass.ToString();
                    txtRemoveAge.Text = fighter.Age.ToString();
                    txtRemoveDraws.Text = fighter.WinLossRecord.Draws.ToString();
                    txtRemoveWins.Text = fighter.WinLossRecord.Wins.ToString();
                    txtRemoveLosses.Text = fighter.WinLossRecord.Losses.ToString();
                    txtRemoveWeightClass.Text = fighter.WeightClass.ToString();
                    txtUpdateWeight.Text = fighter.Weight.ToString();

            }

        }
        
        

        private void btnDeleteFighter_Click(object sender, EventArgs e)
        {
            MongoRemove delete = new MongoRemove();
            try
            {
                delete.RemoveFighter(delete_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please ensure you have searched for Fighter /nbefore hitting the remove button!");
            }
            
        }



        //allow moveable ui]

        int mouseX= 0;
        int mouseY = 0;
        bool mouseDown;

        private void MongoUI_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void MongoUI_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void MongoUI_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelAdd_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelAdd_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panelAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panelUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panelUpdate_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panelUpdate_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelSearch2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panelSearch2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panelSearch2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelRemove_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panelRemove_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panelRemove_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void HomePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void HomePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void HomePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void btnMapReduce_Click(object sender, EventArgs e)
        {

            panelMapReduce.Visible = true;

            panelUpdate.Visible = true;
            panelSearch2.Visible = false;
            panelRemove.Visible = false;
            panelAdd.Visible = false;
            HomePanel.Visible = false;
           
        }

        private async void btnMapReducePerform_Click(object sender, EventArgs e)
        {
            MongoMapReduce map = new MongoMapReduce();
            var results = await map.getMapReduce();
            List<dynamic> mapping = new List<dynamic>();


          

            foreach(var result in results)
            {

                var resultDisplayed = new ResultDisplayed
                {
                    WeightClass = result.WeightClass.ToString(),
                    TotalFighters = result.value.TotalFighter.ToString(),
                    AverageHeightInCentimetres = result.value.AverageHeight.ToString()

                };

                mapping.Add(resultDisplayed);
            }


            dataGrid.DataSource = mapping;
            dataGrid.AutoResizeColumns();
        }
    }
}
