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

        BindingList<CHocSinh> listHocSinh = null;
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
                hshientai.Mshs = txtID.Text;
                //Convert.ToInt32(txtID.Text);
                //int.Parse(txtID.Text);
                hshientai.Hoten = txtFullName.Text;
                hshientai.Ngaysinh = dtBirthday.Value;
                if (radMale.Checked == true)
                {
                    hshientai.Phai = radMale.Checked;
                }
                if (radFemale.Checked == true)
                {
                    hshientai.Phai = radFemale.Checked;
                }
                hshientai.Diachi = txtAddress.Text;

                string strGender = "";
                if (hshientai.Phai == true)
                {
                    strGender = "Nam";
                }
                else
                {
                    strGender = "Nữ";
                }

                //MessageBox.Show("Ma: " + hshientai.Mshs +
                //                "\nHo ten: " + hshientai.Hoten +
                //                "\nNgay sinh: " + hshientai.Ngaysinh.ToString() +
                //                "\nPhai: " + strGender +
                //                "\nDia chi: " + hshientai.Diachi
                //                );

                if (listHocSinh == null)
                {
                    listHocSinh = new BindingList<CHocSinh>();
                }

                //MessageBox.Show(listHocSinh.Count.ToString());
                listHocSinh.Add(hshientai);
                MessageBox.Show(listHocSinh.Count.ToString());

                //if (listHocSinh[0].Phai == true)
                //{
                //    strGender = "Nam";
                //}
                //else
                //{
                //    strGender = "Nữ";
                //}

                //MessageBox.Show("Ma: " + listHocSinh[0].Mshs +
                //                "\nHo ten: " + listHocSinh[0].Hoten +
                //                "\nNgay sinh: " + listHocSinh[0].Ngaysinh.ToString() +
                //                "\nPhai: " + strGender +
                //                "\nDia chi: " + listHocSinh[0].Diachi
                //                );

                dgvStudentList.DataSource = listHocSinh;

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
