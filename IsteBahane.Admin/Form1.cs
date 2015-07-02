using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IsteBahane.Data;
using IsteBahane.Data.DB;

namespace IsteBahane.Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IRepository<Excuse> _repository = new Repository<Excuse>();
        private void Form1_Load(object sender, EventArgs e)
        {
           FillData();
           checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            
        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            _repository = new Repository<Excuse>();
            if (!checkBox1.Checked)
                dataGridView1.DataSource = _repository.GetAll(q=> q.Status != 2).OrderByDescending(q=> q.CreateDate).ToList();
            else
                dataGridView1.DataSource = _repository.GetAll(q => q.Status == 0);

            var rows = dataGridView1.Rows;
            foreach (DataGridViewRow row in rows)
            {
                var data = row.DataBoundItem as Excuse;
                if (data != null && data.Status == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("İşlemi gerçekleştirebilmek için Eleman seçmelisiniz.");
                return;
            }
            
            var data = dataGridView1.SelectedRows[0].DataBoundItem as Excuse;
           

            Detail detail = new Detail();
            detail.ExcuseId = data.Id;
            detail.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://api.hocaokudumu.com/Home/RemoveCache");
               
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                MessageBox.Show("işlem gerçekleştirildi.");
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("İşlemi gerçekleştirebilmek için Eleman seçmelisiniz.");
                return;
            }

            var data = dataGridView1.SelectedRows[0].DataBoundItem as Excuse;

            var entity = _repository.Get(data.Id);
            entity.Status = 2;
            _repository.Update(entity, data.Id);
            MessageBox.Show("Veri silindi.");
            FillData();
        }
    }
}
