﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listBook.ascx.cs" Inherits="WebApplication1.Controls.Admin.Manager.listBook" %>
<%=loaddsSach() %>

<script language="javascript" type="text/javascript">

    //hàm xoá 1 cuốn sách theo mã sách
    function xoaSach(mas) {
        if (confirm("Bạn chắc muốn xoá sách này?")) {
            $.post("Controls/Admin/Manager/Ajax/xuLy.aspx",
                {
                    "thaotac": "xoaSach",
                    "masach": mas,
                },
                function (data, status) {
                    if (data == 1 || data.substring(0, data.indexOf('<')) == 1) {
                        alert("Xoá thành công");
                        $("#madong_" + mas).slideUp();
                    }
                    else
                        alert("Không xoá được");
                });
        }
    }
</script>