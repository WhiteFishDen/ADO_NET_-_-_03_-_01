using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace ADO_NET_ДЗ_Модуль_03_часть_01
{
    public partial class Form1 : Form
    {
        DbConnection conn = null;
        DbProviderFactory factory = null;
        DbDataAdapter da = null;
        static string providerName = "";
        public Form1()
        {
            InitializeComponent();
        }
        static public string GetMeProvider { get { return providerName; } }
        private void Form1_Load(object sender, EventArgs e)
        {
            btn_show.Enabled = false;
            btn_delete.Enabled = false;
            btn_insert.Enabled = false;
            btn_update.Enabled = false;    
            DataTable tableFactory = DbProviderFactories.GetFactoryClasses();
            dataGridView1.DataSource = tableFactory;
            foreach (DataRow dr in tableFactory.Rows)
            { comboBox1.Items.Add(dr["InvariantName"]); }
        }
        private async void btn_show_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ShowDb());
        }
        void ShowDb()
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();
                conn.ConnectionString = textBox_provider.Text;
                da = factory.CreateDataAdapter();
                da.SelectCommand = conn.CreateCommand();
                da.SelectCommand.CommandText = "SELECT * FROM vegetables_and_fruits";
                DataTable dt = new DataTable();
                da.Fill(dt);
                Invoke(new Action(() => { dataGridView1.DataSource = null; dataGridView1.DataSource = dt; }));
                sw.Stop();
                MessageBox.Show($"Time span: {sw.ElapsedMilliseconds} milliseconds");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            factory = DbProviderFactories.GetFactory(comboBox1.SelectedItem.ToString());
            conn = factory.CreateConnection();
            providerName = GetConnectionStringByProvider(comboBox1.SelectedItem.ToString());
            textBox_provider.Text = providerName;
            btn_show.Enabled = true;
            btn_delete.Enabled = true;
            btn_insert.Enabled = true;
            btn_update.Enabled = true;
        }

        static string GetConnectionStringByProvider(string InvariantNameProvider)
        {
            string returnValue = null;
            var settings = ConfigurationManager.ConnectionStrings;
            if(settings != null)
            {
                foreach (ConnectionStringSettings item in settings)
                {
                    if(item.ProviderName == InvariantNameProvider)
                    {
                        returnValue = item.ConnectionString;
                        break;
                    }
                }
            }
            return returnValue;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            FormForDeleteData formDelete = new FormForDeleteData();
            formDelete.textBox1.Text = this.comboBox1.SelectedItem.ToString();
            formDelete.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            FormForUpdateData formUpdate = new FormForUpdateData();
            formUpdate.textBox5.Text = this.comboBox1.SelectedItem.ToString();
            formUpdate.ShowDialog();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            FormForInsertData formInsert = new FormForInsertData();
            formInsert.textBox5.Text = this.comboBox1.SelectedItem.ToString(); 
            formInsert.ShowDialog();
        }
    }
}
