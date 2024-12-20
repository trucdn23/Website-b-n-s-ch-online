﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Controls.Introduce_history
{
    public partial class checkOrder : System.Web.UI.UserControl
    {
        DataTable dtGridView = new DataTable();
        HttpCookie cookie = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] != null)
                cookie = Request.Cookies["login"];
            loadGridView();
        }
        #region hàm khởi tạo gridview
        void loadGridView()
        {
            dtGridView.Columns.Add("stt");
            dtGridView.Columns.Add("ma");
            dtGridView.Columns.Add("ngay");
            dtGridView.Columns.Add("thanhtien");
            dtGridView.Columns.Add("diachi");
            dtGridView.Columns.Add("email");
            dtGridView.Columns.Add("tinhtrang");
        }
        #endregion

        #region hàm kiểm tra quyền admin
        protected string ktraAdmin(string admin)
        {
            if (cookie != null && cookie["qtc"].ToString().Equals(admin))
                return "current";
            return "";
        }
        #endregion
        #region hàm load những đơn hàng mà tài khoản khách hàng này đã đặt
        protected string loadSach()
        {
            if (cookie != null && cookie["qtc"].ToString().Equals("admin"))
                return "";
            try
            {
                DateTime.Parse(txtSearch.Value.Trim());
            }
            catch (Exception ex)
            {
                return "";
            }
            if (cookie == null)
                return "";
            DataTable ds = donDatHang.timDonHangTheoEmailAndNgayTao(cookie["email"].ToString().Trim(), DateTime.Parse(txtSearch.Value.Trim()).ToShortDateString());
            if (ds.Rows.Count == 0)
                return "<span class='search_check'>Không tìm thấy đơn đặt hàng nào.</span>";
            int dem = 0;
            dtGridView.Clear();
            foreach (DataRow r in ds.Rows)
            {
                dem++;
                string tinhTrang = "Đã giao";
                if (r["tinhtrang"].ToString().Equals("0"))
                    tinhTrang = "Chưa giao";
                dtGridView.Rows.Add(dem, r["madonhang"].ToString().Trim(), DateTime.Parse(r["ngaytao"].ToString()).ToShortDateString(),
                    String.Format("{0:#,##}", Convert.ToInt32(r["thanhtien"].ToString().Substring(0, r["thanhtien"].ToString().Trim().IndexOf('.')))),
                    r["diachinhanhang"].ToString().Trim(), r["email"].ToString().Trim(), tinhTrang);
            }
            return "";
        }
        #endregion

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            loadSach();
            GridView1.DataSource = dtGridView;
            GridView1.DataBind();
        }
    }
}