using System;
using System.Windows.Forms;
using IsteBahane.Data;
using IsteBahane.Data.DB;

namespace IsteBahane.Admin
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
        }

        public int ExcuseId { get; set; }

        readonly IRepository<Excuse> _repository = new Repository<Excuse>();
        private void Detail_Load(object sender, EventArgs e)
        {
            var excuse = _repository.Get(ExcuseId);
            if (excuse == null)
            {
                this.Close();
                return;
            }
            txtExcuse.Text = excuse.Description;
            txtDislike.Text = excuse.DislikeCount.ToString();
            txtLike.Text = excuse.LikeCount.ToString();
            txtNick.Text = excuse.Author;
            checkBox1.Checked = excuse.Status == 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var entity = _repository.Get(ExcuseId);
            entity.Description = txtExcuse.Text;
            entity.DislikeCount = ConvertToInt(txtDislike.Text);
            entity.LikeCount = ConvertToInt(txtLike.Text);
            entity.Author = txtNick.Text;
            entity.Status = checkBox1.Checked ? (byte)1 : (byte)0;
            if (entity.Status == 1)
                entity.ApproveDate = DateTime.Now;
            _repository.Update(entity, ExcuseId);
            MessageBox.Show("Tamamlandı.");
        }

        public int ConvertToInt(string input)
        {
            var result = 0;
            int.TryParse(input, out result);
            return result;
        }
    }
}
