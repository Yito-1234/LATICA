<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REPORTE_COMPRA.aspx.cs" Inherits="LATICA.REPORTE_COMPRA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
 
    
    <form id="form1" runat="server">
        <div style="width: 616px; margin-left: 349px" >

              <center>
<section >

<div ><h1>Minisuper La Tica</h1></div>


    <br />

    <div ><h2>Detalle de Compra</h2></div>
</section>
</center>
    <br />
            <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="605px" style="margin-left: 0px">
         
                <AlternatingRowStyle BackColor="White" />

            <Columns>
                 <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                   
                   
                     <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                 
                </Columns>

                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>
              

            <br />
            <br />
              

        </div>
        <br />
        <br />
        <asp:Button ID="ExportPDF" runat="server" Text="Imprimir" OnClick="ExportPDF_Click" BackColor="#009933" BorderStyle="Outset" ForeColor="White" Height="41px" style="margin-left: 569px; margin-top: 0px" Width="185px" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BASEDATOS %>" SelectCommand="SELECT B.nom_producto as Producto, CONVERT(varchar,A.fecha,1) as Fecha,A.cantidad as Cantidad FROM DETALLE_COMPRA A, PRODUCTOS B
WHERE A.id_producto = B.id;"></asp:SqlDataSource>
    </form>
</body>
</html>
