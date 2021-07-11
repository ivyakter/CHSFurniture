<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ItemforProductionList.aspx.cs" Inherits="Pages_Production_ItemforProductionList" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="col-md-12 h3 text-center">
        <div class="row">
          Order To Factory
        </div>
    </div>
    
    <div class="col-md-12" style="padding-top: 20px;">
        <div class="row">
        
            <div class="col-md-2">
                Select Date
            </div>
            <div class="col-md-3">

                <asp:TextBox CssClass="form-control" ID="txtDateto" runat="server" Width="200" placeholder="dd/MM/yyyy"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtDateto"></cc1:CalendarExtender>
                <br />

            </div>

        </div>
    </div>

    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True" PageSize="8" OnRowCommand="gv_RowCommand" CssClass="table table-striped table-bordered table-hover" Width="100%" >
        <Columns>
            <asp:TemplateField HeaderText="&nbsp;&nbsp;  OrderID">
                <ItemTemplate>
                       <asp:Label ID="lblOrderID" Text=' <%# Eval("ID")%>'   runat="server" />
                   
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="&nbsp;&nbsp;ProductName">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ItemName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; ProductID">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Model")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="&nbsp;&nbsp; Quantity">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Quantity")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="&nbsp;&nbsp; Unit">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Unit")%>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="&nbsp;&nbsp; Date">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Date")%>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="&nbsp;&nbsp;Status">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Status")%>
                </ItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                <ItemTemplate>
                   <asp:Button ID="btnpay" runat="server" Text="Received" Width="70px" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Deliver" />
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Delete">
                <ItemTemplate>
                    <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    <asp:Button CssClass="btn-delete" ID="btnDelete" runat="server" Text="Delete"
                        OnClientClick=" return confirm('Clicking ok will delete this record permanently.') "
                        OnClick="btnDelete_Click" />
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

