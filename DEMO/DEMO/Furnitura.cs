using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DEMO
{
    public partial class Furnitura : Form
    {
        SqlConnection ConnectionString = new SqlConnection("Data Source = (Local);Initial Catalog = Demo_ex;Integrated Security = True");

        public Furnitura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form klad = new Kladovshik();
            klad.Show();
            this.Close();
        }

        private void Furnitura_Load(object sender, EventArgs e)
        {
            String query = "Select * from Фурнитура";

            SqlDataAdapter sda = new SqlDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();

            sda.Fill(ds, "Фурнитура");

            dataGridView1.DataSource = ds.Tables["Фурнитура"];

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Картинки";

            dataGridView1.Columns.Add(img);


            for (int i=1; i<dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {

                    String basePath = "C:/Users/Alex/Desktop/Подготовка к демоэкзамену/picture/furnitura/";
                    string filename = dataGridView1.Rows[i].Cells[0].Value.ToString() + ".jpg";
                    string fulPath = basePath + filename;
                    Image image;

                    if (File.Exists(fulPath))
                    {
                        image = Image.FromFile(fulPath);
                    }
                    else
                    {
                        image = Image.FromFile(basePath + "good.jpg");
                    }
                    dataGridView1.Rows[i].Cells["img"].Value = image;
                }

            }
        }
    }
}
