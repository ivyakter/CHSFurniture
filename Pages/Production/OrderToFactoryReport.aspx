<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="OrderToFactoryReport.aspx.cs" Inherits="Pages_Inventory_OrderToFactoryReport" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    function PrintDetailsView() {
        var detailsview = document.getElementById('<%= Pnlprint.ClientID %>');
        var printWindow = window.open('', '', 'width=1000,height=600,toolbar=0,scrollbars=1,status=0,resizable=1');
        printWindow.document.write(detailsview.outerHTML);
        printWindow.document.close();
        printWindow.focus();
        printWindow.print();
        printWindow.close();
    }  
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12 h3 text-center">
        <div class="row">
            Order To Factory
        </div>
    </div>


    <div class="col-md-12" style="padding-top: 20px;">
        <div class="row">
             <div class="col-md-2">
                Invoice No
            </div>
            <div class="col-md-2">
                <asp:TextBox CssClass="form-control" ID="txtinvoiceno" runat="server" Width="50"></asp:TextBox>  
            </div>

            <div class="col-md-2">
                Select Date
            </div>
            <div class="col-md-2">
                <asp:TextBox CssClass="form-control" ID="txtDateto" runat="server" Width="100" placeholder="dd/MM/yyyy"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtDateto"></cc1:CalendarExtender>              
            </div>
              <div class="col-md-2">
              Search by Order No:
            </div>
            <div class="col-md-2">
                <asp:TextBox CssClass="form-control" ID="txtOrderNo" runat="server" Width="150"  AutoPostBack="true"
                    ontextchanged="txtOrderNo_TextChanged"></asp:TextBox>
                 <br />
            </div>

        </div>
    </div>

    
    <div class="row">
        <div class="col-md-12">
        <asp:Panel ID="Pnlprint" runat="server" Style="background-color: #FFFFFF" Width="100%">
             <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True" PageSize="50" OnRowCommand="gv_RowCommand" CssClass="table table-striped table-bordered table-hover" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="&nbsp;&nbsp;  OrderID">
                <ItemTemplate>
                    <asp:Label ID="lblOrderID" Text=' <%# Eval("OrderID")%>' runat="server" />
                     <asp:Label ID="lblProductID" Text=' <%# Eval("ProductID")%>' Visible="false" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp;ProductName">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ProductName")%>
                      <asp:Label ID="lblProductName" Text=' <%# Eval("ProductName")%>' Visible="false" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="&nbsp;&nbsp;Model">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Model")%>
                      <asp:Label ID="lblModelID" Text=' <%# Eval("Model")%>' Visible="false" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
         
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Quantity">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Quantity")%>
                    <asp:Label ID="lblQuantity" Text=' <%# Eval("Quantity")%>' Visible="false" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Unit">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Unit")%>
                    <asp:Label ID="lblUnit" Text=' <%# Eval("Unit")%>' Visible="false" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Date">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Date", "{0:dd/MM/yyyy}")%>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="&nbsp;&nbsp; Delivery Date">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("DeliverDate", "{0:dd/MM/yyyy}")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <img width="80" height="80" src="../../ProductImage/<%#Eval("PID") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt="<%#Eval("Name") %>" onerror="this.src='images/noimage.jpg'">
                    <%-- <ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Center">--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="lblPIMGID" runat="server" Visible="false" Text='<%# Eval("PIMGID") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp;Remarks">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Comments")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Delete">
                <ItemTemplate>
                    <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    <asp:Button CssClass="btn-delete" ID="btnDelete" runat="server" Text="Delete"
                        OnClientClick=" return confirm('Clicking ok will delete this record permanently.') "
                        OnClick="btnDelete_Click" />
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Select Action">
                <ItemTemplate>
                    <asp:CheckBox ID="chkinsertforyearly" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Panel>
        </div>
    </div>

       <div class="row">
        <div class="col-md-12">

            <div class="col-md-6">
               
            </div>
              <div class="col-md-4">
         <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="PrintDetailsView();"/>
        </div>
        <div class="col-md-2">
         <asp:button runat="server" ID="btnSave" Text="Delivery" CssClass="btn-success" OnClick="btnSave_Click" ></asp:button>
        </div>
        </div>        
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

