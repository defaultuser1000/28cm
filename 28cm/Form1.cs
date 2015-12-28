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
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {
            InitializeComponent();
        }

        
//Добавление группы
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form3 = new Form3();
            Form3.Show();
        }

        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form7 = new Form7();
            Form7.Show();
        }

        private void редактироватьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form4 = new Form4();
            Form4.Show();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void добавитьЗанятиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            string sql = "INSERT INTO '" + comboBox1.Text + "' (rowid,name,balls,lefts,pefts) VALUES ('" + row + "','" + Student_Name + "', '" + 0 + "' , '" + 0 + "' , '" + 0 + "')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            Initialize();*/
            Form Form6 = new Form6();
            Form6.Show();
        }

        /*public static void Poseshenie(DataGridView gridData)
        {
            DateTimePicker date = new DateTimePicker();

            DataGridViewCheckBoxColumn gridColumn_poseshenie = new DataGridViewCheckBoxColumn();
            gridColumn_poseshenie.HeaderText = (date.Value).ToString();
            gridColumn_poseshenie.Name = "poseshenie";
            gridColumn_poseshenie.ReadOnly = false;
            gridData.Columns.Add(gridColumn_poseshenie);
        }*/

        
        public static void Initialize()
        {
            int N = 42;
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            string Name_of_tab = "";
            string name1 = "";
            int i;
            string sql = "";
            SQLiteCommand command;
            SQLiteDataReader reader;
            int N1 = 42;
            string student_name = "";
            double balls = 42.0;
            int lefts = 42;
            int pefts = 42;


            sql = "SELECT COUNT(rowid) FROM Groups";
            command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                N = Convert.ToInt32(reader["COUNT(rowid)"]);
            reader.Close();
            m_dbConnection.Close();

            
            for (i = 1; i <= N; i++)
            {
                sql = "SELECT name, year FROM Groups WHERE rowid = ('" + i + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();


                if (reader.Read())
                {
                    name1 = Convert.ToString(reader["name"]);
                    Name_of_tab = Convert.ToString(reader["name"]) + " " + Convert.ToString(reader["year"]);
                }

                reader.Close();
                m_dbConnection.Close();

                TabPage TabPage = new TabPage(Name_of_tab);
                tabControl1.TabPages.Add(TabPage);

                DataGridView gridData = new DataGridView();
                gridData.Dock = DockStyle.Fill;
                gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                gridData.ReadOnly = true;
                TabPage.Controls.Add(gridData);

                //tab_create(Name_of_tab);
                
                DataGridViewTextBoxColumn gridColumn_variant = new DataGridViewTextBoxColumn();
                gridColumn_variant.HeaderText = "Вариант";
                gridColumn_variant.Name = "variant";
                gridData.Columns.Add(gridColumn_variant);

                DataGridViewTextBoxColumn gridColumn_fio = new DataGridViewTextBoxColumn();
                gridColumn_fio.HeaderText = "Ф.И.О";
                gridColumn_fio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gridColumn_fio.Name = "fio";
                gridData.Columns.Add(gridColumn_fio);

                /*DataGridViewButtonColumn gridColumn_plus = new DataGridViewButtonColumn();
                gridColumn_plus.HeaderText = "Плюс балл";
                gridColumn_plus.Name = "plus";
                gridColumn_plus.ReadOnly = false;
                gridData.Columns.Add(gridColumn_plus);*/

                DataGridViewTextBoxColumn gridColumn_balls = new DataGridViewTextBoxColumn();
                gridColumn_balls.HeaderText = "Кол-во баллов";
                gridColumn_balls.Name = "balls";
                gridData.Columns.Add(gridColumn_balls);
                //gridData.CurrentCell.Value.ToString();

                /*DataGridViewButtonColumn gridColumn_minus = new DataGridViewButtonColumn();
                gridColumn_minus.HeaderText = "Минус балл";
                gridColumn_minus.Name = "minus";
                gridColumn_minus.ReadOnly = false;
                gridData.Columns.Add(gridColumn_minus);*/

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

                //Poseshenie(gridData);
                //Заполнение из БД
                sql = "SELECT COUNT(rowid) FROM ('" + name1 + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                    N1 = Convert.ToInt32(reader["COUNT(rowid)"]);
                reader.Close();
                m_dbConnection.Close();

                int j;
                for (j = 1; j <= N1; j++)
                {
                    DataGridViewRow rows = (DataGridViewRow)gridData.Rows[0].Clone();
                    rows.Cells[0].Value = j;

                    sql = "SELECT name FROM ('" + name1 + "') WHERE rowid = ('" + j + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                        student_name = Convert.ToString(reader["name"]);
                    reader.Close();
                    m_dbConnection.Close();
                    
                    rows.Cells[1].Value = student_name;

                    //----------------------------------------------------------------------
                    sql = "SELECT balls FROM ('" + name1 + "') WHERE rowid = ('" + j + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                        balls = Convert.ToDouble(reader["balls"]);
                    reader.Close();
                    m_dbConnection.Close();

                    rows.Cells[2].Value = balls;

                    //----------------------------------------------------------------------
                    sql = "SELECT lefts FROM ('" + name1 + "') WHERE rowid = ('" + j + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                        lefts = Convert.ToInt32(reader["lefts"]);
                    reader.Close();
                    m_dbConnection.Close();

                    rows.Cells[3].Value = lefts;

                    //----------------------------------------------------------------------
                    sql = "SELECT pefts FROM ('" + name1 + "') WHERE rowid = ('" + j + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                        pefts = Convert.ToInt32(reader["pefts"]);
                    reader.Close();
                    m_dbConnection.Close();

                    rows.Cells[4].Value = pefts;

                    gridData.Rows.Add(rows);
                }

            }
        }

        public static int id_growth(string table)
        {
            string sql;
            SQLiteCommand command;
            SQLiteDataReader reader;

            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            
            sql = "SELECT COUNT(rowid) FROM '" + table + "'";
            command = new SQLiteCommand(sql, m_dbConnection);

            int key = 0;
            m_dbConnection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                key = Convert.ToInt32(reader["COUNT(rowid)"]);
            
            reader.Close();
            m_dbConnection.Close();

            if (key > 0)
            {
                sql = "SELECT MAX(rowid) FROM '" + table + "'";
                command = new SQLiteCommand(sql, m_dbConnection);


                int max = 0;
                m_dbConnection.Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                    max = Convert.ToInt32(reader["MAX(rowid)"]);

                reader.Close();
                m_dbConnection.Close();
                return max;
            }
            else { return 0; }
                
        }

        private void отметитьПосещениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form8 = new Form8();
            Form8.Show();
        }

        /*public static void tab_create(string Name_of_tab)
        {
            TabPage TabPage = new TabPage(Name_of_tab);
            tabControl1.TabPages.Add(TabPage);

            DataGridView gridData = new DataGridView();
            gridData.Dock = DockStyle.Fill;
            TabPage.Controls.Add(gridData);

            DataGridViewTextBoxColumn gridColumn_variant = new DataGridViewTextBoxColumn();
            gridColumn_variant.HeaderText = "Вариант";
            gridColumn_variant.Name = "variant";
            gridColumn_variant.ReadOnly = false;
            gridData.Columns.Add(gridColumn_variant);

            DataGridViewTextBoxColumn gridColumn_fio = new DataGridViewTextBoxColumn();
            gridColumn_fio.HeaderText = "Ф.И.О";
            gridColumn_fio.Name = "fio";
            gridColumn_fio.ReadOnly = false;
            gridData.Columns.Add(gridColumn_fio);

            /*DataGridViewButtonColumn gridColumn_plus = new DataGridViewButtonColumn();
            gridColumn_plus.HeaderText = "Плюс балл";
            gridColumn_plus.Name = "plus";
            gridColumn_plus.ReadOnly = false;
            gridData.Columns.Add(gridColumn_plus);*/
        /*
        DataGridViewTextBoxColumn gridColumn_balls = new DataGridViewTextBoxColumn();
        gridColumn_balls.HeaderText = "Кол-во баллов";
        gridColumn_balls.Name = "balls";
        gridColumn_balls.ReadOnly = false;
        gridData.Columns.Add(gridColumn_balls);
        //gridData.CurrentCell.Value.ToString();

        /*DataGridViewButtonColumn gridColumn_minus = new DataGridViewButtonColumn();
        gridColumn_minus.HeaderText = "Минус балл";
        gridColumn_minus.Name = "minus";
        gridColumn_minus.ReadOnly = false;
        gridData.Columns.Add(gridColumn_minus);*/

        /* DataGridViewTextBoxColumn gridColumn_lefts = new DataGridViewTextBoxColumn();
         gridColumn_lefts.HeaderText = "Лекций пропущено";
         gridColumn_lefts.Name = "lefts";
         gridColumn_lefts.ReadOnly = false;
         gridData.Columns.Add(gridColumn_lefts);

         DataGridViewTextBoxColumn gridColumn_pefts = new DataGridViewTextBoxColumn();
         gridColumn_pefts.HeaderText = "Практик пропущено";
         gridColumn_pefts.Name = "pefts";
         gridColumn_pefts.ReadOnly = false;
         gridData.Columns.Add(gridColumn_pefts);
     }*/

    }
}
