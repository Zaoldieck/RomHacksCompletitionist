using Rom_Hacks_Completitionist.Properties;
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

namespace Rom_Hacks_Completitionist
{
    public partial class AddStar : Form
    {
        Star star = new Star();
        public AddStar()
        {
            InitializeComponent();
        }

        private void button_Upload_Click(object sender, EventArgs e)
        {
            // browse image.
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select a photo(*.jpg;*.png;*.gif|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK )
            {
                pictureBox_Picture.Image=Image.FromFile(opf.FileName);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            // add new star
            /*
            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = starName;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@rh", MySqlDbType.VarChar).Value = romHack;
            command.Parameters.Add("@t", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@d", MySqlDbType.Date).Value = obtainedDate;
            command.Parameters.Add("@o", MySqlDbType.VarChar).Value = obtained;
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = listed;
            command.Parameters.Add("@r", MySqlDbType.Double).Value = rating;
            command.Parameters.Add("@n", MySqlDbType.Text).Value = note;
            command.Parameters.Add("@img", MySqlDbType.LongBlob).Value = img;
            */
            string starName = textBox_StarName.Text;
            string courseName = textBox_CourseName.Text;
            DateTime obtainedDate = DateTime_ObtainedDate.Value;
            string romHack = comboBox_RomHack.Text;
            string type = comboBox_Type.Text;
            string obtained = comboBox_Obtained.Text;
            string listed = comboBox_Listed.Text;
            double rating = Convert.ToDouble(textBox_Rating.Text);
            string note = textBox_Notes.Text;
            //for the picture box
            MemoryStream ms = new MemoryStream();
            pictureBox_Picture.Image.Save(ms, pictureBox_Picture.Image.RawFormat);
            byte[] img = ms.ToArray();

            if (verify())
            {
                try
                {
                    if (star.insertStar(starName, courseName, romHack, type, obtainedDate, obtained, listed, note, rating, img))
                    {
                        MessageBox.Show("Star has been added","Add Star", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Star", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        // create a function to verify
        bool verify()
        {
            if ((textBox_StarName.Text=="") || (textBox_CourseName.Text=="") || 
                (comboBox_Type.Text=="") || (comboBox_Obtained.Text=="") || 
                (comboBox_Listed.Text=="") || (comboBox_RomHack.Text=="") || 
                (textBox_Rating.Text=="") || (pictureBox_Picture.Image==null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_StarName.Clear();
            textBox_CourseName.Clear();
            comboBox_Obtained.Text = "YES";
            comboBox_Listed.Text="NO";
            textBox_Rating.Text="0.0";
            textBox_Notes.Clear();
            pictureBox_Picture.Image=Resources.Star112x112;
        }

        private void AddStar_Load(object sender, EventArgs e)
        {
            showTable();
        }

        // to show star list in datagridview
        public void showTable()
        {
            DataGridView_star.DataSource = star.getStarList();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_star.Columns[10];//index 0 so 11 -1
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            

            DataGridView_star.Columns[0].Width = 41;        // IDs
            DataGridView_star.Columns[1].Width = 120;       // Star Name
            DataGridView_star.Columns[2].Width = 120;       // Course Name
            DataGridView_star.Columns[3].Width = 120;       // Rom Hack
            DataGridView_star.Columns[4].Width = 50;       // Type
            DataGridView_star.Columns[5].Width = 42;        // Obtained
            DataGridView_star.Columns[6].Width = 64;        // Date Obtained
            DataGridView_star.Columns[7].Width = 29;        // Listed
            DataGridView_star.Columns[8].Width = 40;        // Rating
            DataGridView_star.Columns[9].Width = 40;        // Note
            DataGridView_star.Columns[10].Width = 40;       // Picture

        }
    }
}
