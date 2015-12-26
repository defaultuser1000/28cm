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
    public partial class Form5 : Form
    {
        
        public Form5(string student, string group)
        {
            InitializeComponent();
            groupBox1.Text = student;
            label6.Text = group;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            string sql = "";
            SQLiteCommand command;
            SQLiteDataReader reader;
            
            double balls = 42.0;
            int lefts = 42;
            int pefts = 42;

            sql = "SELECT balls, lefts, pefts FROM '" + label6.Text + "' WHERE name = ('" + groupBox1.Text + "')";
            command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            reader = command.ExecuteReader();


            if (reader.Read())
            {
                balls = Convert.ToDouble(reader["balls"]);
                lefts = Convert.ToInt32(reader["lefts"]);
                pefts = Convert.ToInt32(reader["pefts"]);
            }

            reader.Close();
            m_dbConnection.Close();

            textBox1.Text = balls.ToString();
            textBox2.Text = pefts.ToString();
            textBox3.Text = lefts.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            string sql = "";
            SQLiteCommand command;
            

            sql = "UPDATE '" + label6.Text + "' SET balls = ('" + textBox1.Text + "'), lefts = ('" + textBox3.Text + "') WHERE name = ('" + groupBox1.Text + "')";
            command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            Close();
        }
    }
}
