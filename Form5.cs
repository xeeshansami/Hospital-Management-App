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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.con.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from patient where pid =@pid",f2.con);
            cmd.Parameters.AddWithValue("pid",comboBox1.Text);
            cmd.Parameters.AddWithValue("pname", textBox1.Text);
            cmd.Parameters.AddWithValue("pcity", textBox2.Text);
            cmd.Parameters.AddWithValue("pcountry", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has beem Deleted", "Command Succesfull", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            f2.con.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.con.Open();
            OleDbCommand cmd = new OleDbCommand("select pid from patient", f2.con);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["pid"].ToString());
            }
            f2.con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from patient where pid = '" + comboBox1.Text + "'", f2.con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                this.textBox1.Text = dr["pname"].ToString();
                this.textBox2.Text = dr["pcity"].ToString();
                this.textBox3.Text = dr["pcountry"].ToString();
            }
            f2.con.Close();

        }
    }
}
