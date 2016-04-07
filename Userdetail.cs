using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Userdetail : Form
    {
        SqlConnection con = new SqlConnection("Data Source=JAYA-PC\\SQLEXPRESS;Initial Catalog=coresident;Integrated Security=True");
        public Userdetail()
        {
            InitializeComponent();
        }


        private void UserList_Load(object sender, EventArgs e)
        
{




            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Register ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;



            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                

         }


        

        private void button1_Click(object sender, EventArgs e)
        {

           // DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn();
            //if (c.Selected==true )
            {
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update Register set Status='Active'", con);
                cmd1.ExecuteNonQuery();
                
               
            }

        }

        private void vM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM1USER vm1 = new VM1USER();
            this.Hide();
            vm1.Show();
        }

        private void userdatailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Userdetail ud = new Userdetail();
           
            ud.Show();
        }

        private void userlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userlist ul = new userlist();
            //this.Hide();
            ul.Show();

        }

        private void vM2USERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM2USER vm2 = new VM2USER();
            //this.Hide();
            vm2.Show();
        }

        private void vM3USERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM3USER vm3 = new VM3USER();
            //this.Hide();
            vm3.Show();

        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            //this.Hide();
            fm.Show();
        }


    }
}

    
      
     
        
    


