﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bill.ascx.cs" Inherits="WebApplication1.Controls.Admin.Manager.bill" %>
<%=loadDSHD() %>

<script language="javascript" type="text/javascript">
    //hàm xoá 1 hoá đơn theo mã
    function xoaHD(mas) {
        if (confirm("Bạn chắc muốn xoá hoá đơn này?")) {
            $.post("Controls/Admin/Manager/Ajax/xuLy.aspx",
                {
                    "thaotac": "xoaHD",
                    "mahd": mas,
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