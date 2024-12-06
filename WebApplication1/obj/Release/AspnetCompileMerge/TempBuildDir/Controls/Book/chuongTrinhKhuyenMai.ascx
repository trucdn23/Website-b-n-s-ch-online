<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chuongTrinhKhuyenMai.ascx.cs" Inherits="WebApplication1.Controls.Book.chuongTrinhKhuyenMai" %>
<div class="introduce">
    <h1 class="introduce__title">CHƯƠNG TRÌNH KHUYẾN MÃI
    </h1>
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <p>Tên chương trình:<b><%# Eval("tenkm") %></b></p>
            <p>Giảm giá: <b><%# Eval("giamgia") %>%</b></p>
        </ItemTemplate>
    </asp:DataList>
    <%=loadCTKM() %>
</div>