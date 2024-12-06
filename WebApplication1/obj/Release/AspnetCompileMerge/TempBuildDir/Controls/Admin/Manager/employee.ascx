<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="employee.ascx.cs" Inherits="WebApplication1.Controls.Admin.Manager.employee" %>
<%=loadDSNV() %>

<script language="javascript" type="text/javascript">
    //hàm xoá 1 nhân viên
    function xoaNV(mas) {
        if (confirm("Bạn muốn xoá nhân viên này?")) {
            $.post("Controls/Admin/Manager/Ajax/xuLy.aspx",
                {
                    "thaotac": "xoaNV",
                    "manv": mas,
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