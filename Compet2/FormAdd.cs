using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compet2
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBox_user.Text = "";
            textBox_pass.Text = "";
            textBox_name.Text = "";
            textBox_phone.Text = "";
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
            string sql_check = "select * from tb_member where m_user = '" + user + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql_check, db.conn);
            da.Fill(ds, "dtMember");
            if (ds.Tables["dtMember"].Rows.Count > 0)
            {
                MessageBox.Show("ไม่สามารถเพิ่มข้อมูบได้ เนื่องจากมีชื่อผู้ใช้แล้ว");
            } else
            {
                string sql_insert = "INSERT INTO tb_member (m_user, m_pass, m_name, m_phone) " +
                    "VALUES ('" + user + "', '" + pass + "', '" + name + "', '" + phone + "')";
                MySqlDataAdapter da1 = new MySqlDataAdapter(sql_insert, db.conn);
                da1.Fill(ds, "dtInsert");
                if (ds.Tables["dtInsert"] == null)
                {
                    MessageBox.Show("ทำรายการสำเร็จ");
                    textBox_user.Text = "";
                    textBox_pass.Text = "";
                    textBox_name.Text = "";
                    textBox_phone.Text = "";
                }
            }

        }
    }
}
