using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Controls.Account
{
    public partial class loginRegisterControl : System.Web.UI.UserControl
    {
        static string modul;
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList1.SelectedIndex = 0;
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];
            switch (modul)
            {
                case "dn":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                case "dk":
                    MultiView1.ActiveViewIndex = 1;
                    break;
            }
        }

        #region hàm chuyển qua view đăng kí
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        #endregion
        #region hàm bấm vào nút đăng kí
        protected void btnRegister1_Click(object sender, EventArgs e)
        {
            int i = khacHang.dangKy(txtEmailRegister.Text.Trim(), maHoaMD5.MaHoaMD5(txtPWRegister.Text.Trim()), txtAddress.Text.Trim(), txtPhone.Text.Trim(), txtTenHienThi.Text.Trim(), RadioButtonList1.SelectedItem.ToString().Trim());
            if (i != -1)
            {
                MultiView1.ActiveViewIndex = 0;
                DatabaseSql.con.Close();
                Response.Write("<script>alert('Đăng ký thành công!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Tài khoản tồn tại!!')</script>");
                MultiView1.ActiveViewIndex = 1;
            }
        }
        #endregion
        #region hàm chuyển qua view đăng nhập
        protected void btnLoginRegister_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        #endregion
        #region hàm bấm vào nút login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //đăng nhập theo tư cách quản trị
            bool check = false;
            #region đăng nhập theo quyền quản trị hoặc quyền khách hàng
            if (RadioButtonList2.SelectedIndex == 1)
            {
                DataTable ds = quanTri.dangNhap(txtEmailLogin.Text.Trim(), maHoaMD5.MaHoaMD5(txtPWLogin.Text.Trim()));
                if (ds.Rows.Count > 0)
                {

                    if (Session["Captcha"].ToString().Equals(txtCaptcha.Value))
                    {
                        HttpCookie cookie = new HttpCookie("login");
                        cookie["checkDN"] = "1";
                        cookie["email"] = ds.Rows[0]["email"].ToString().Trim();
                        Session["tenhienthi"] = ds.Rows[0]["tenhienthi"].ToString().Trim();
                        cookie["qtc"] = "admin";
                        cookie.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(cookie);
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        check = true;
                        lbNotifyLogin.Text = "Mã bảo vệ không đúng";
                    }
                }

            }
            else
            {
                DataTable dsKH = khacHang.dangNhap(txtEmailLogin.Text.Trim(), maHoaMD5.MaHoaMD5(txtPWLogin.Text.Trim()));
                if (dsKH.Rows.Count > 0)
                {

                    if (Session["Captcha"].ToString().Equals(txtCaptcha.Value))
                    {
                        HttpCookie cookie = new HttpCookie("login");
                        cookie["email"] = dsKH.Rows[0]["email"].ToString().Trim();
                        Session["tenhienthi"] = dsKH.Rows[0]["tenkh"].ToString().Trim();
                        cookie["checkDN"] = "1";
                        cookie["qtc"] = "kh";
                        cookie.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(cookie);
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        check = true;
                        lbNotifyLogin.Text = "Mã bảo vệ không đúng";
                    }
                }
            }
            #endregion
            if (!check)
                lbNotifyLogin.Text = "Sai tên tài khoản hoặc mật khẩu";
            txtCaptcha.Value = "";
            MultiView1.ActiveViewIndex = 0;
        }
        #endregion
    }
}