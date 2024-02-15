using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_NET_ДЗ_Модуль_03_часть_01
{
    public partial class FormForUpdateData : Form
    {
        public FormForUpdateData()
        {
            InitializeComponent();
        }

        private async void btn_update_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "Npgsql")
                {
                    var sw = new Stopwatch();
                    NpgsqlConnection con = new NpgsqlConnection(Form1.GetMeProvider);
                    await con.OpenAsync();
                    string commandText = "UPDATE vegetables_and_fruits SET _name = @name, _type = @type, _color = @color, _calorific_value = @calorific_value" +
                    " WHERE _name = @name";
                    using (var cmd = new NpgsqlCommand(commandText, con))
                    {
                        cmd.Parameters.AddWithValue("name", textBox1.Text);
                        cmd.Parameters.AddWithValue("type", textBox2.Text);
                        cmd.Parameters.AddWithValue("color",textBox3.Text);
                        cmd.Parameters.AddWithValue("calorific_value", Convert.ToInt32(textBox4.Text));
                        sw.Start();
                        await cmd.ExecuteNonQueryAsync();
                        sw.Stop();
                    }
                    await con.CloseAsync();
                    MessageBox.Show($"Time span: {sw.ElapsedMilliseconds} milliseconds");
                    MessageBox.Show("Данные успешно обновлены!", "Success! ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else 
                {
                    MessageBox.Show("Данная СУБД не поддерживается!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void btn_update_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
