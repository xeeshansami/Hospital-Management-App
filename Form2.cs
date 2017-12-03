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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select pid from patient", con);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["pid"].ToString());
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * patient where pid='"+comboBox1.Text+"'", con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                this.textBox1.Text = dr["pname"].ToString();
                this.textBox2.Text = dr["pcity"].ToString();
                this.textBox3.Text = dr["pcountry"].ToString();
            }
            con.Close();
        }
    }
}
