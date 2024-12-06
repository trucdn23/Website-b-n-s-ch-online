using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class empty : System.Web.UI.Page
    {
        protected string checkDisplay = "none";
        protected HttpCookie cookie = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] != null)
            {
                cookie = Request.Cookies["login"];
                if (cookie["qtc"].ToString().Equals("admin"))
                    Session["tenhienthi"] = quanTri.timTenTheoEmail(cookie["email"].ToString().Trim());
                else
                        if (cookie["qtc"].ToString().Equals("kh"))
                    Session["tenhienthi"] = khacHang.timTenTheoEmail(cookie["email"].ToString().Trim());
            }
        }
        #region check đăng nhập hay chưa và đăng xuất khỏi trang web

        public string load()
        {
            string value = "";
            string checkdn = "0";
            string quyen = "kh";
            if (cookie != null)
            {
                quyen = cookie["qtc"].ToString();
                checkdn = cookie["checkDN"].ToString();
            }
            if (Request.QueryString["modul"] != null && Request.QueryString["modul"].Equals("dx"))
            {
                Response.Cookies["login"]["qtc"] = Response.Cookies["login"]["email"] = Response.Cookies["login"]["checkDN"] = null;
                Session["tenhienthi"] = "";
            }
            else
            if (checkdn.Equals("1"))
            {
                string vl = @"<a class='btnDangXuat header__first-menu-link'>Tài khoản</a>
                    <ul class='header__first-menu-sub'>
                        <li class='header__first-menu-sub-item'>
                       
                          <a  href='javascript:thongTinCaNhan()' ><i class='fas fa-info-circle'></i>Thông tin cá nhân</a>
                        </li>
                        <li class='header__first-menu-sub-item'>
                        
                        <a  href='javascript:doiMatKhau()' ><i class='fas fa-key'></i>Đổi mật khẩu</a>
                        </li>
                        <li class='header__first-menu-sub-item'>
        
                         <a  href='Home.aspx?modul=dx' ><i class='fas fa-sign-out-alt'></i>Đăng xuất</a>
                        </li>
                    </ul>";
                if (cookie != null && cookie["qtc"].ToString().Equals("admin"))
                    vl = "<a style='cursor:pointer;' class='btnDangXuat header__first-menu-link' href='Home.aspx?modul=dx' >Đăng xuất</a>";

                value = @"
        <ul class='header__first-menu'>
              <li class='header__first-menu-item'>
                  <a Class='header__first-menu-link' runat='server' >Xin chào " + Session["tenhienthi"] + @"</a>
              </li>
              <li class='header__first-menu-item'>
                       " + vl + @"
              </li>
         </ul>";

            }
            else
            {
                value = @"
        <ul class='header__first-menu'>
              <li class='header__first-menu-item'>
                  <a class='header__first-menu-link' runat='server' href='empty.aspx?modul=dn'>Đăng nhập</a>
              </li>
              <li class='header__first-menu-item'>
                   <a class='header__first-menu-link' runat='server' href='empty.aspx?modul=dk'>Đăng ký</a>
              </li>
         </ul>";
            }
            return value;
        }
        #endregion
    }
}