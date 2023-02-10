using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compet2
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        public void getData()
        {
            DataSet ds = new DataSet();
            string sql_select = "select * from tb_member where m_user = '" + member_info.username + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(sql_select, db.conn);
            sda.Fill(ds, "dtMember");
            foreach (DataRow dr in ds.Tables["dtMember"].Rows)
            {
                textBox_user.Text = dr["m_user"].ToString();
                textBox_name.Text = dr["m_name"].ToString();
                textBox_pass.Text = dr["m_pass"].ToString();
                if (dr["m_phone"].ToString() != "")
                {
                    textBox_phone.Text = "0" + dr["m_phone"].ToString();
                } else
                {
                    textBox_phone.Text = dr["m_phone"].ToString();

                }
            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string user = textBox_user.Text;
            string pass = textBox_pass.Text;
            string name = textBox_name.Text;
            string phone = textBox_phone.Text;
            // checked user
            if (user.Length == 0 || pass.Length == 0 || name.Length == 0)
            {
                MessageBox.Show("ไม่สามารถแกไขข้อมูลได้");
                getData();
            }
            else
            {
                string sql_insert = "";
                if (phone.Length == 0)
                {
                    sql_insert = "UPDATE `tb_member` SET `m_pass`='" + pass + "',`m_name`='" + name + "'," +
                    "`m_phone`='NULL' WHERE m_user = '" + user + "'";
                } else
                {
                    sql_insert = "UPDATE `tb_member` SET `m_pass`='" + pass + "',`m_name`='" + name + "'," +
                    "`m_phone`='" + phone + "' WHERE m_user = '" + user + "'";
                }
                
                MySqlDataAdapter da1 = new MySqlDataAdapter(sql_insert, db.conn);
                da1.Fill(ds, "dtUpdate");
                if (ds.Tables["dtUpdate"] == null)
                {
                    MessageBox.Show("ทำรายการสำเร็จ");
                }
            }
        }
    }
}
