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
    public partial class Form2 : Form
    {
        bool exist;
       
        public Form2()
        {
            InitializeComponent();
        }

        private void exitButton_form2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_form2_Click(object sender, EventArgs e)
        {
            string Group_Name = "";
            string Year_Group = "";

            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            string sql = "";
            SQLiteCommand command;
            SQLiteDataReader reader;

            if((textBox_group.Text.Length > 0)&&(textBox_year.Text.Length > 0))
            {
                Group_Name = textBox_group.Text;
                Year_Group = textBox_year.Text;

                if ((Group_Name.Length > 0)&&(Year_Group.Length > 0))
                {
                    
                    sql = "SELECT name FROM Groups WHERE name = ('" + Group_Name + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    
                    m_dbConnection.Open();
                    reader = command.ExecuteReader();
                    exist = false;

                    if (reader.Read())
                        exist = true;

                    reader.Close();
                    m_dbConnection.Close();


                    if (!exist)
                    {
                        
                        sql = "CREATE TABLE '" + Group_Name + "' (rowid INTEGER, name TEXT, balls REAL, lefts INTEGER)";
                        command = new SQLiteCommand(sql, m_dbConnection);

                        m_dbConnection.Open();
                        command.ExecuteNonQuery();
                        m_dbConnection.Close();

                        int row = Form1.id_growth("Groups") + 1;
                        sql = "INSERT INTO Groups (rowid, name, year) VALUES ('" + row + "','" + Group_Name + "', '" + Year_Group + "')";
                        command = new SQLiteCommand(sql, m_dbConnection);

                        m_dbConnection.Open();
                        command.ExecuteNonQuery();
                        m_dbConnection.Close();

                        
                        TabPage TabPage = new TabPage(Group_Name + " " + Year_Group);
                        Form1.tabControl1.TabPages.Add(TabPage);

                        DataGridView gridData = new DataGridView();
                        gridData.Dock = DockStyle.Fill;
                        gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                        TabPage.Controls.Add(gridData);

                        DataGridViewTextBoxColumn gridColumn_variant = new DataGridViewTextBoxColumn();
                        gridColumn_variant.HeaderText = "Вариант";
                        gridColumn_variant.Name = "variant";
                        gridColumn_variant.ReadOnly = false;
                        gridData.Columns.Add(gridColumn_variant);

                        DataGridViewTextBoxColumn gridColumn_fio = new DataGridViewTextBoxColumn();
                        gridColumn_fio.HeaderText = "Ф.И.О";
                        gridColumn_fio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        gridColumn_fio.Name = "fio";
                        gridColumn_fio.ReadOnly = false;
                        gridData.Columns.Add(gridColumn_fio);

                        DataGridViewTextBoxColumn gridColumn_balls = new DataGridViewTextBoxColumn();
                        gridColumn_balls.HeaderText = "Кол-во баллов";
                        gridColumn_balls.Name = "balls";
                        gridColumn_balls.ReadOnly = false;
                        gridData.Columns.Add(gridColumn_balls);
                        //gridData.CurrentCell.Value.ToString();

                        DataGridViewTextBoxColumn gridColumn_lefts = new DataGridViewTextBoxColumn();
                        gridColumn_lefts.HeaderText = "Лекций пропущено";
                        gridColumn_lefts.Name = "lefts";
                        gridColumn_lefts.ReadOnly = false;
                        gridData.Columns.Add(gridColumn_lefts);

                        DataGridViewTextBoxColumn gridColumn_pefts = new DataGridViewTextBoxColumn();
                        gridColumn_pefts.HeaderText = "Практик пропущено";
                        gridColumn_pefts.Name = "pefts";
                        gridColumn_pefts.ReadOnly = false;
                        gridData.Columns.Add(gridColumn_pefts);



                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Группа существует", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
            }else
            {
                MessageBox.Show("Введите название и год. \r\n Год в формате (год начала - год окончания) ", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
