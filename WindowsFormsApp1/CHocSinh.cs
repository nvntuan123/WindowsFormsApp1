using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CHocSinh
    {
        private string m_mshs;
        private string m_hoten;
        private DateTime m_ngaysinh;
        private bool m_phai;
        private string m_diachi;

        public string Mshs { get => m_mshs; set => m_mshs = value; }
        public string Hoten { get => m_hoten; set => m_hoten = value; }
        public DateTime Ngaysinh { get => m_ngaysinh; set => m_ngaysinh = value; }
        public bool Phai { get => m_phai; set => m_phai = value; }
        public string Diachi { get => m_diachi; set => m_diachi = value; }

        public CHocSinh()
        {
            //m_mshs = "";
            m_mshs = string.Empty;
            m_hoten = "";
            m_ngaysinh = DateTime.MinValue;
            m_phai = true;
            m_diachi = string.Empty;
        }

        public CHocSinh(string ma, string ht, DateTime ns, bool p, string dc)
        {
            m_mshs = ma;
            m_hoten = ht;
            m_ngaysinh = ns;
            m_phai = p;
            m_diachi = dc;
        }
    }
}
