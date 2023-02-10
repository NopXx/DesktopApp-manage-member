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
    public partial class FormDelete : Form
    {
        public FormDelete()
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
                }
                else
                {
                    textBox_phone.Text = dr["m_phone"].ToString();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันการลบข้อมูลสมาชิก ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                string user = textBox_user.Text;
                string sql_delete = "DELETE FROM `tb_member` WHERE m_user = '" + user + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(sql_delete, db.conn);
                sda.Fill(ds, "dtDelete");
                if (ds.Tables["dtDelete"] == null)
                {
                    MessageBox.Show("ลบข้อมูลสำเร็จ");
                    this.Hide();
                    new Form1().Show();
                }
            } else
            {
                MessageBox.Show("ยกเลิก");
            }
        }

        private void FormDelete_Load(object sender, EventArgs e)
        {
            getData();
        }
    }
}
