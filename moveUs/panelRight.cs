﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moveUs
{
    public partial class PanelRight : Form
    {
        public PanelRight()
        {
            InitializeComponent();
        }

        private void panelRight_Load(object sender, EventArgs e)
        {
            this.Width = 5;
            this.Height = 400;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
        }


        Point saniye5, saniye4, saniye3, saniye2, saniye1;

        private void panelRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = (e.Y + this.Top - mouseDownLocation.Y);
            }
            saniye1 = new Point(e.X, e.Y);
        }

        Point mouseDownLocation;

        private void panelRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
            if (this.Width == 5)
            {
                kepenkAc.Start();
                sleepModeActivate.Start();
            }
        }

        private void sleepModeActivate_Tick(object sender, EventArgs e)
        {
            saniye5 = saniye4;
            saniye4 = saniye3;
            saniye3 = saniye2;
            saniye2 = saniye1;
            if (saniye1 == saniye5)
            {
                if (this.Width == 150)
                {
                    kepenkKapat.Start();
                }
            }
            else
            {
                if (Cursor.Position.X < this.Left || Cursor.Position.X > (this.Left + this.Width) || Cursor.Position.Y < this.Top || Cursor.Position.Y > (this.Top + this.Height))
                {
                    if (this.Width == 150)
                    {
                        kepenkKapat.Start();
                    }
                }
            }
        }

        private void kepenkAc_Tick(object sender, EventArgs e)
        {
            this.Width += 5;
            this.Left -= 5;
            if (this.Width == 150)
            {
                kepenkAc.Stop();
            }
        }

        private void kepenkKapat_Tick(object sender, EventArgs e)
        {
            this.Width -= 5;
            this.Left += 5;
            if (this.Width == 5)
            {
                kepenkKapat.Stop();
            }
        }
    }
}
