using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HospitalManagementSystem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.con.Open();
            OleDbCommand cmd = new OleDbCommand("insert into patient (pid,pname,pcity,pcountry) values (@pid,@pname,@pcity,@pcountry)", f2.con);
            cmd.Parameters.AddWithValue("pid",textBox1.Text);
            cmd.Parameters.AddWithValue("pname", textBox2.Text);
            cmd.Parameters.AddWithValue("pcity", textBox3.Text);
            cmd.Parameters.AddWithValue("pcountry", textBox4.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Has Been Updated", "Data Inserted", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            f2.con.Close();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
