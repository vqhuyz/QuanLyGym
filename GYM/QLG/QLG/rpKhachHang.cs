using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using QLG.CLASS;

namespace QLG
{
    public partial class rpKhachHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rpKhachHang()
        {
            InitializeComponent();
            Ngay.Value = DateTime.Today;
        }
    }
}
