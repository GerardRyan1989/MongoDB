﻿using MongoDBCA;
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
        }

        private async void button1_Click(object sender, EventArgs e)
        {



            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //MongoRead read = new MongoRead();

            //await read.get();

            //MongoUpdate update = new MongoUpdate();

            //update.update();

            MongoAdd add = new MongoAdd();

            add.Add();
        }
    }
}
