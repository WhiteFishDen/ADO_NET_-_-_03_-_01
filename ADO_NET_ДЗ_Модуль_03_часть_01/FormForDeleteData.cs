using System;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ADO_NET_ДЗ_Модуль_03_часть_01
{
    public partial class FormForDeleteData : Form
    {
        public FormForDeleteData()
        {
            InitializeComponent();
        }
        
        private async void button_OK_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "Npgsql")
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    NpgsqlConnection con = new NpgsqlConnection(Form1.GetMeProvider);
                    await con.OpenAsync();
                    string query = $"delete from vegetables_and_fruits where _name = @name";
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("name", textBox_for_delete.Text);
                        await cmd.ExecuteNonQueryAsync();
                    }
                    con.Close();
                    sw.Stop();
                    MessageBox.Show($"Time span: {sw.ElapsedMilliseconds} milliseconds");

                }
                else if (textBox1.Text == "System.Data.SqlClient")
                {
                    var sw = new Stopwatch();
                    sw.Start();

                    string query = $"delete from vegetables_and_fruits where name = {textBox_for_delete}";
                    using (var conn = new SqlConnection(Form1.GetMeProvider))
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        await cmd.ExecuteNonQueryAsync();
                    }
                    sw.Stop();
                    MessageBox.Show($"Time span: {sw.ElapsedMilliseconds} milliseconds");
                }
                Close();
                MessageBox.Show("Данные успешно удалены!","Success! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
