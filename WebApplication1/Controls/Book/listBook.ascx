﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listBook.ascx.cs" Inherits="WebApplication1.Controls.Book.listBook" %>
<%=loaddsSach() %>
<script language="javascript" type="text/javascript">
      
    //hàm thêm sách vào giỏ hàng
        function themGioHang(mas) {
           
                //Viết code xóa danh mục tại đây                 
                $.post("Controls/Book/Ajax/xuLy.aspx",
                    {
                        "thaotac": "themGioHang",
                        "masach":mas,
                        "soluong":1
                    },
                    function (data, status) {
                        if (data == 1 || data.substring(0, data.indexOf('<')) == 1)
                        alert("Thêm thành công");
                    });
        }
    //hàm thêm sách vào giỏ hàng và hiển thị giỏ hàng
        function muaNgay(mas) {

            //Viết code xóa danh mục tại đây                 
            $.post("Controls/Book/Ajax/xuLy.aspx",
                {
                    "thaotac": "muaNgay",
                    "masach": mas,
                    "soluong": 1
                },
                function (data, status) {
                    if (data == 1 || data.substring(0, data.indexOf('<')) == 1)
                        location.reload();
                });
        }

</script>