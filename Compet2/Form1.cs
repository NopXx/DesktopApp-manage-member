using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compet2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public void getData()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM tb_member";
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
            sda.Fill(ds, "dtMember");
            dataGridView1.DataSource = ds.Tables["dtMember"];
            dataGridView1.Columns["m_phone"].Visible = false;
            var i = 0;
            foreach (DataRow dr in ds.Tables["dtMember"].Rows)
            {
                dataGridView1.Rows[i].Cells["number"].Value = i + 1;
                if (dr["m_phone"].ToString() != "")
                {

                    dataGridView1.Rows[i].Cells["m_phone_1"].Value = "0" + dr["m_phone"];
                }
                else
                {
                    dataGridView1.Rows[i].Cells["m_phone_1"].Value = dr["m_phone"];

                }
                i++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormAdd().Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "แก้ไข" && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    member_info.username = row.Cells["m_user"].Value.ToString();
                    this.Hide();
                    new FormEdit().Show();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "ลบ" && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    member_info.username = row.Cells["m_user"].Value.ToString();
                    this.Hide();
                    new FormDelete().Show();
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ชื่อผู้ใช้ / ชื่อ - นามสกุล")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ชื่อผู้ใช้ / ชื่อ - นามสกุล";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = "";
            if (textBox1.Text == "ชื่อผู้ใช้ / ชื่อ - นามสกุล")
            {
                getData();
            }
            else
            {
                search = textBox1.Text;
                DataSet ds = new DataSet();
                string sql_search = "select * from tb_member where m_user like '%" + search + "%' or m_name like '%" + search + "%'";
                MySqlDataAdapter sda = new MySqlDataAdapter(sql_search, db.conn);
                sda.Fill(ds, "dtMember");
                dataGridView1.DataSource = ds.Tables["dtMember"];
                dataGridView1.Columns["m_phone"].Visible = false;
                var i = 0;
                foreach (DataRow dr in ds.Tables["dtMember"].Rows)
                {
                    dataGridView1.Rows[i].Cells["number"].Value = i + 1;
                    if (dr["m_phone"].ToString() != "")
                    {

                        dataGridView1.Rows[i].Cells["m_phone_1"].Value = "0" + dr["m_phone"];
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["m_phone_1"].Value = dr["m_phone"];

                    }
                    i++;
                }
            }
        }
    }
}
