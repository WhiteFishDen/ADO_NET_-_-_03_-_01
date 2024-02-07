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

namespace ADO_NET_ДЗ_Модуль_03_часть_01
{
    public partial class Form1 : Form
    {
        DbConnection conn = null;
        DbProviderFactory factory = null;
        string providerName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable tableFactory = DbProviderFactories.GetFactoryClasses();
            dataGridView1.DataSource = tableFactory;
            comboBox1.Items.Clear();
            foreach (DataRow dr in tableFactory.Rows)
            { comboBox1.Items.Add(dr["InvariantName"]); }
        }
        
        private void btn_show_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = textBox_provider.Text;
;
            DbDataAdapter da = factory.CreateDataAdapter();
            da.SelectCommand = conn.CreateCommand();
            da.SelectCommand.CommandText = "SELECT * FROM vegetables_and_fruits";
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            factory = DbProviderFactories.GetFactory(comboBox1.SelectedItem.ToString());
            conn = factory.CreateConnection();
            providerName = GetConnectionStringByProvider(comboBox1.SelectedItem.ToString());
            textBox_provider.Text = providerName;//typeof(Npgsql.NpgsqlFactory).AssemblyQualifiedName

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

    }
}
