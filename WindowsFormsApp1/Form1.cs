using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmStudentManager : Form
    {
        public frmStudentManager()
        {
            InitializeComponent();
        }

        List<CHocSinh> listHocSinh = null;
        CHocSinh hshientai = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            dtBirthday.Value = DateTime.Today;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (hshientai == null)
            {
                hshientai = new CHocSinh();
            }
            
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Mã số không được để trống!");
                txtID.Focus();
            }
            else if (txtFullName.Text == string.Empty)
            {
                MessageBox.Show("Họ tên không được để trống!");
                txtFullName.Focus();
            }
            else if (dtBirthday.Value == DateTime.Today)
            {
                MessageBox.Show("Bạn chưa chọn ngày sinh!");
                dtBirthday.Focus();
            }
            else if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                txtAddress.Focus();
            }
            else if (radMale.Checked == false && radFemale.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn phái!");
                radMale.Focus();
            }
            else
            {
                if (listHocSinh == null)
                {
                    listHocSinh = new List<CHocSinh>();
                }

                int iLengthGridView = listHocSinh.Count;
                bool bCheck = true;
                if (iLengthGridView > 0)
                {
                    for (int i = 0; i < iLengthGridView; i++)
                    {
                        if (listHocSinh[i].Mshs == txtID.Text)
                        {
                            MessageBox.Show("Mã bị trùng!");
                            bCheck = false;
                            txtID.Focus();
                            break;
                        }
                    }
                }

                if (bCheck == true)
                {
                    hshientai.Mshs = txtID.Text;
                    hshientai.Hoten = txtFullName.Text;
                    hshientai.Ngaysinh = dtBirthday.Value;
                    if (radMale.Checked == true) // Nam
                    {
                        hshientai.Phai = true;
                    }
                    if (radFemale.Checked == true) // Nu
                    {
                        hshientai.Phai = false;
                    }
                    hshientai.Diachi = txtAddress.Text;

                    listHocSinh.Add(hshientai);
                    dgvStudentList.DataSource = listHocSinh.ToList();

                    // Reset.
                    hshientai = null;
                    txtID.Text = string.Empty;
                    txtFullName.Text = string.Empty;
                    dtBirthday.Value = DateTime.Today;
                    txtAddress.Text = string.Empty;
                    radFemale.Checked = false;
                    radMale.Checked = false;
                }    
            }
        }
    }
}
