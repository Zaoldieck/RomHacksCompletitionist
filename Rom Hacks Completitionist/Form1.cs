using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rom_Hacks_Completitionist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            //close subpanels at start
            panel_starsubmenu.Visible = false;
            panel_romhacksubmenu.Visible = false;
            panel_scoresubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_starsubmenu.Visible == true)
            {
                panel_starsubmenu.Visible = false;
            }
            if (panel_romhacksubmenu.Visible == true)
            {
                panel_romhacksubmenu.Visible = false;
            }
            if (panel_scoresubmenu.Visible == true)
            {
                panel_scoresubmenu.Visible = false;
            }
        }
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_star_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_starsubmenu);
        }
        #region Star SubMenu
        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new AddStar());
            //...
            //..code
            //
            hideSubmenu();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //...
            //..code
            //
            hideSubmenu();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //...
            //..code
            //
            hideSubmenu();
        }
        #endregion Star SubMenu
        private void button_roms_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_romhacksubmenu);
        }
        #region RomHack SubMenu
        private void button_addRomhack_Click(object sender, EventArgs e)
        {
            //...
            //..code
            //
            hideSubmenu();
        }
        private void button_manageRomHacks_Click(object sender, EventArgs e)
        {
            //...
            //..code
            //
            hideSubmenu();
        }
        private void button_romhackStatus_Click(object sender, EventArgs e)
        {
            //...
            //..code
            //
            hideSubmenu();
        }
        #endregion RomHack SubMenu
        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoresubmenu);
        }
        #region Score SubMenu
        #endregion Score SubMenu

        // to show AddStar form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void button_dashboard_Click(object sender, EventArgs e)
        {
            // WORKING ON THIS
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
        }
    }
}
