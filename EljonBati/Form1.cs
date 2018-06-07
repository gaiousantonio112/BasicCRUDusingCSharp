using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EljonBati
{
    
    public partial class Form1 : Form
    {
        string msc = "no", sprts = "no", mvs = "no", gms = "no", art = "no";
        int globalid = 0;
        int wanda;
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        public Form1()
        {
            InitializeComponent();
        }
        public void DBkonek()
        {
            string constr = "datasource=localhost;port=3306;username=root;pass=;database=eljon";
            try
            {
                conn = new MySqlConnection(constr);
                // conn.Open();
                //MessageBox.Show("Coonected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
            string msg = "Do you want to exit";
            string captn = "Profile Management System";
            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, msg, captn, btns);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                
            }
            
        }

        private void chckMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chckMusic.Checked == true)
            {
                listBox1.Items.Add(chckMusic.Text);
                msc = "yes";
            }
            else
            {
                listBox1.Items.Remove(chckMusic.Text);
                msc = "no";
            }
        }

        private void chckMovies_CheckedChanged(object sender, EventArgs e)
        {
            if (chckMovies.Checked == true)
            {
                listBox1.Items.Add(chckMovies.Text);
                mvs = "yes";
            }
            else
            {
                listBox1.Items.Remove(chckMovies.Text);
                mvs = "no";
            }
        }

        private void chckGames_CheckedChanged(object sender, EventArgs e)
        {
            if (chckGames.Checked == true)
            {
                listBox1.Items.Add(chckGames.Text);
                gms = "yes";
            }
            else
            {
                listBox1.Items.Remove(chckGames.Text);
                gms = "no";
            }
        }

        private void chckSports_CheckedChanged(object sender, EventArgs e)
        {
            if (chckSports.Checked == true)
            {
                listBox1.Items.Add(chckSports.Text);
                sprts = "yes";
            }
            else
            {
                listBox1.Items.Remove(chckSports.Text);
                sprts = "no";
            }
        }
        public string getItemLists()
        {
            
            List<string> vals = new List<string>();

            foreach (object o in listBox1.Items)
            {
                vals.Add(o.ToString());

            }
             string selec = String.Join(",",vals);
             return selec;
        }
        private void chckArts_CheckedChanged(object sender, EventArgs e)
        {
            if (chckArts.Checked == true)
            {
                listBox1.Items.Add(chckArts.Text);
                art = "yes";
            }
            else
            {
                listBox1.Items.Remove(chckArts.Text);
                art = "no";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            wanda = 0;
            btnSave.Visible = true;
            akteball();
            buralahat();
            if (btnUpdate.Visible == true)
            {
                btnUpdate.Visible = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (wanda == 0)
            {
                //add some new dataas
               // MessageBox.Show("Add Success!", "Profile Management System");
                AddProfile();
                desableall();
                buralahat();
                btnSave.Visible = false;
                btnDel.Visible = false;
            }
            else if(wanda ==1)
            {
                //update new datas
                UpdateProfile();
                desableall();
                btnUpdate.Visible = false;
                buralahat();
                btnAdd.Visible = true;
                btnSave.Visible = false;
                btnDel.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            wanda = 1;
            btnSave.Visible = true;
            akteball();
        }

        public void desableall()
        {
            txtage.Enabled = false;
            txtfname.Enabled = false;
            txtlname.Enabled = false;
            bdaypicker.Enabled = false;
            rbtnFemale.Enabled = false;
            rbtnMale.Enabled = false;
            cmbStatus.Enabled = false;
            txtadrs.Enabled = false;
            chckArts.Enabled = false;
            chckMovies.Enabled = false;
            chckMusic.Enabled = false;
            chckGames.Enabled = false;
            chckSports.Enabled = false;
        }
        public void akteball()
        {
            txtage.Enabled = true;
            txtfname.Enabled = true;
            txtlname.Enabled = true;
            bdaypicker.Enabled = true;
            rbtnFemale.Enabled = true;
            rbtnMale.Enabled = true;
            cmbStatus.Enabled = true;
            txtadrs.Enabled = true;
            chckArts.Enabled = true;
            chckMovies.Enabled = true;
            chckMusic.Enabled = true;
            chckGames.Enabled = true;
            chckSports.Enabled = true;
        }

        public void buralahat()
        {
            txtage.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            //bdaypicker.Text = "00-00-0000";
            //rbtnFemale.Enabled = true;
            //rbtnMale.Enabled = true;
            cmbStatus.Text = "";
            txtadrs.Text = "";
            chckArts.Checked = false;
            chckMovies.Checked = false;
            chckMusic.Checked = false;
            chckGames.Checked = false;
            chckSports.Checked = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Visible = true;
            btnDel.Visible = true;
            btnAdd.Visible = false;
            DBkonek();
            //conn.Open();
            //string qry = "SELECT * FROM profiletb WHERE pid=";
            int me = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            sendToField(me);
            //akteball();
        }
        public void sendToField(int a)
        {
            DBkonek();
            conn.Open();
            //MessageBox.Show(a.ToString());
            string qry = "SELECT * FROM profiletb WHERE pid="+a;
            cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) { 
            globalid = rdr.GetInt32("pid");
            txtfname.Text = rdr.GetString("fname");
            txtlname.Text = rdr.GetString("lname");
            txtage.Text = rdr.GetString("age");
            bdaypicker.Text = rdr.GetString("bdate");
            cmbStatus.Text = rdr.GetString("civstatus");
            txtadrs.Text = rdr.GetString("addrs");
                if (rdr.GetString("gender") == "Male")
                {
                    rbtnMale.Checked = true;
                }
                else if (rdr.GetString("gender") == "Female")
                {
                    rbtnFemale.Checked = true;
                }

                if (rdr.GetString("msc") == "yes")
                {
                    chckMusic.Checked = true;
                    //listBox1.Items.Add(rdr.GetString("msc"));
                }
                if (rdr.GetString("gms") == "yes")
                {
                    chckGames.Checked = true;
                   // listBox1.Items.Add(rdr.GetString("msc"));
                }
                if (rdr.GetString("mvs") == "yes")
                {
                    chckMovies.Checked = true;
                    //listBox1.Items.Add(rdr.GetString("msc"));
                }
                if (rdr.GetString("sprts") == "yes")
                {
                    chckSports.Checked = true;
                    //listBox1.Items.Add(rdr.GetString("msc"));
                }
                if (rdr.GetString("art") == "yes")
                {
                    chckArts.Checked = true;
                    //listBox1.Items.Add(rdr.GetString("msc"));
                }


            }
        }
        public void showData()
        {
            
            DBkonek();
            conn.Open();
            //data from database to datagridview
            string qry = "SELECT pid as 'ID',fname as 'First Name',lname as 'Last Name',gender as 'Gender' FROM profiletb";
            try
            {
                cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable datset = new DataTable();
                sda.Fill(datset);
                BindingSource bsrc = new BindingSource();

                bsrc.DataSource = datset;
                dataGridView1.DataSource = bsrc;
                sda.Update(datset);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
            desableall();
            DBkonek();
            btnUpdate.Visible = false;
        }
        public Boolean AddProfile()
        {
            
            string gndr="";
            DBkonek();
           string qry = "INSERT INTO profiletb(fname,lname,age,bdate,civstatus,addrs,gender,msc,mvs,sprts,gms,art) " + 
                        "values(@fnam,@lnam,@ages,@bday,@stats,@adrs,@gdnr,@msc,@mvs,@sprts,@gms,@art)";
           if (rbtnFemale.Checked == true)
           {
               gndr = "Female";
           }
           else if (rbtnMale.Checked == true)
           {
               gndr = "Male";
           }
            try
           {
               conn.Open();
               cmd = new MySqlCommand(qry,conn);
               cmd.Parameters.AddWithValue("@fnam",txtfname.Text);
               cmd.Parameters.AddWithValue("@lnam", txtlname.Text);
               cmd.Parameters.AddWithValue("@ages", txtage.Text);
               cmd.Parameters.AddWithValue("@bday", bdaypicker.Text);
               cmd.Parameters.AddWithValue("@stats", cmbStatus.Text);
               cmd.Parameters.AddWithValue("@adrs", txtadrs.Text);
               cmd.Parameters.AddWithValue("@gdnr", gndr);
               cmd.Parameters.AddWithValue("@msc", msc);
               cmd.Parameters.AddWithValue("@mvs", mvs);
               cmd.Parameters.AddWithValue("@sprts", sprts);
               cmd.Parameters.AddWithValue("@gms", gms);
               cmd.Parameters.AddWithValue("@art", art);

               cmd.ExecuteNonQuery();
               MessageBox.Show("Adding Profile Successfull!","Profile Management System");
               //conn.Close();
               showData();
               return true;
           }
           catch (Exception e)
           {
               MessageBox.Show(e.Message);
               return false;
               
           }
            
        }
        public Boolean UpdateProfile()
        {
            DBkonek();

            string gndr="";
            try
            {
                conn.Open();
                string qry = "UPDATE profiletb SET fname=@fnam,lname=@lnam,age=@age,bdate=@bday,civstatus=@stats,addrs=@adr,gender=@gen,msc=@mus,mvs=@mov,sprts=@sprts,gms=@gms,art=@art"
                                +" WHERE pid=@id";
                if (rbtnFemale.Checked == true)
                {
                    gndr = "Female";
                }
                else if (rbtnMale.Checked == true)
                {
                    gndr = "Male";
                }
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@fnam",txtfname.Text);
                cmd.Parameters.AddWithValue("@lnam", txtlname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@bday", bdaypicker.Text);
                cmd.Parameters.AddWithValue("@stats", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@adr", txtadrs.Text);
                cmd.Parameters.AddWithValue("@gen", gndr);
                cmd.Parameters.AddWithValue("@mus", msc);
                cmd.Parameters.AddWithValue("@mov", mvs);
                cmd.Parameters.AddWithValue("@sprts", sprts);
                cmd.Parameters.AddWithValue("@gms", gms);
                cmd.Parameters.AddWithValue("@art", art);
                cmd.Parameters.AddWithValue("@id",globalid);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updating Profile Successfull!", "Profile Management System");
                showData();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
        public Boolean DeleteProfile()
        {
            DBkonek();
           
            string qry = "DELETE FROM profiletb WHERE pid=@id";
            try
            {
                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@id", globalid);
                cmd.ExecuteNonQuery();
                
                buralahat();
                desableall();
                showData();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Profile Management System");
                return false;
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            string msg = "Do you want delete this data?";
            string captn = "Profile Management System";
            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, msg, captn, btns);
            if (result == DialogResult.Yes)
            {
                DeleteProfile();
                MessageBox.Show("Deleting Profile Successfull!", "Profile Management System");

            }
            else
            {
                buralahat();
                desableall();
                btnDel.Visible = true;

            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            buralahat();
            btnSave.Visible = false;
            btnAdd.Visible = true;
            if (btnUpdate.Visible == true)
            {
                btnUpdate.Visible = false;

            }
            
            desableall();
        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            
            if (txtSrch.Text == "")
            {
                showData();
            }
            else
            {
                srchData(txtSrch.Text);
            }
        }
        public void srchData(string me)
        {
            //searching data from database to datagridview
            DBkonek();
            conn.Open();
            //data from database to datagridview
            string qry = "SELECT pid as 'ID',fname as 'First Name',lname as 'Last Name',gender as 'Gender' FROM profiletb WHERE CONCAT(profiletb.fname,profiletb.lname,profiletb.gender) LIKE '%" + me + "%' ";
            try
            {
                cmd = new MySqlCommand(qry, conn);
                
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable datset = new DataTable();
                sda.Fill(datset);
                BindingSource bsrc = new BindingSource();

                bsrc.DataSource = datset;
                dataGridView1.DataSource = bsrc;
                sda.Update(datset);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
