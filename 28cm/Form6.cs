using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace _28cm
{
    public partial class Form6 : Form
    {
        string sql = "";
        SQLiteCommand command;
        string group_name = "";
        string sql1 = "";
        SQLiteCommand command1;
        SQLiteDataReader reader1;

        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            int N = 0;
            
            sql = "SELECT COUNT(rowid) FROM Groups";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader;
            m_dbConnection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                N = Convert.ToInt32(reader["COUNT(rowid)"]);
            reader.Close();
            m_dbConnection.Close();


            for (int i = 1; i <= N; i++)
            {
                sql = "SELECT name FROM Groups WHERE rowid = ('" + i + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();


                if (reader.Read())
                {

                    group_name = Convert.ToString(reader["name"]);

                }

                reader.Close();
                m_dbConnection.Close();

                comboBox1.Items.Add(group_name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            bool exist;

            if ((comboBox1.Text.Length > 0) && (comboBox2.Text.Length > 0))
            {
                string les_column = Convert.ToString(DateTime.Now) + " " + comboBox2.Text;
                
                try { sql = "ALTER TABLE '" + comboBox1.Text + "' ADD COLUMN '" + les_column + "' TEXT";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                }
                catch {
                    MessageBox.Show("Занятие существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                 }

                    /*sql = "INSERT INTO days (date, les_type, group) VALUES ('" + DateTime.Today + "','" + comboBox2.Text + "', '" + comboBox1.Text + "' )";
                    command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                command.ExecuteNonQuery();
                m_dbConnection.Close();*/

                Close();
               
            }
            else
            {
                MessageBox.Show("Введите данные", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
