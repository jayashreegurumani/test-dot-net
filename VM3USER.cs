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
    public partial class VM3USER : Form
    {
        SqlConnection con = new SqlConnection("Data Source=JAYA-PC\\SQLEXPRESS;Initial Catalog=coresident;Integrated Security=True");
        public VM3USER()
        {
            InitializeComponent();
        }

        private void VM3USER_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select UserName,Filename from VM3USER", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
