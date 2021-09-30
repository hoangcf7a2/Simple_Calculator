using System;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy giá trị của 2 ô số
                double so1, so2, kq = 0;
                if (txtSo1.ToString().Contains(",") || txtSo2.ToString().Contains(","))
                {
                    //throw new Exception("Kí tự không hợp lệ");
                    MessageBox.Show("Kí tự không hợp lệ", "Lỗi Đầu Vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                so1 = double.Parse(txtSo1.Text);
                so2 = double.Parse(txtSo2.Text);

                //Thực hiện phép tính dựa vào phép toán được chọn
                if (radCong.Checked) kq = so1 + so2;
                else if (radTru.Checked) kq = so1 - so2;
                else if (radNhan.Checked) kq = so1 * so2;
                else if (radChia.Checked)
                {
                    if (so2 == 0)
                    {
                        MessageBox.Show("Kí tự không hợp lệ", "Lỗi Đầu Vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    kq = so1 / so2;
                }
                //Hiển thị kết quả lên trên ô kết quả
                txtKq.Text = kq.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.SelectAll();
            txtSo1.Focus();
        }

        private void txtSo2_Click(object sender, EventArgs e)
        {
            txtSo2.SelectAll();
            txtSo2.Focus();
        }
    }
}
