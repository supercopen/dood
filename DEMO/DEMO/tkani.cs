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
    public partial class tkani : Form
    {
        SqlConnection ConnectionString = new SqlConnection("Data Source = (Local);Initial Catalog = Demo_ex;Integrated Security = True");

        public tkani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form klsd = new Kladovshik();
            klsd.Show();
            this.Close();
        }

        private void tkani_Load(object sender, EventArgs e)
        {
            String query = "Select * from Ткань";

            SqlDataAdapter sda = new SqlDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();

            sda.Fill(ds, "Ткань");

            dataGridView1.DataSource = ds.Tables["Ткань"];

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Картинки";

            dataGridView1.Columns.Add(img);

            for (int i = 1; i < dataGridView1.RowCount; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {

                    String basePath = "C:/Users/Alex/Desktop/Подготовка к демоэкзамену/DEMO/DemoOne/DEMO/picture/tkani/";
                    string filename = dataGridView1.Rows[i].Cells[0].Value.ToString() + ".jpg";
                    string fulPath = basePath + filename;
                    Image image;

                    if (File.Exists(fulPath))
                    {
                        image = Image.FromFile(fulPath);
                    }
                    else
                    {
                        image = Image.FromFile(basePath+"good.JPG");
                    }
                    dataGridView1.Rows[i].Cells["img"].Value = image;
                }

            }
        }
    }
}
