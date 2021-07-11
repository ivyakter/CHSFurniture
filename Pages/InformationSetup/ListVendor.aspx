<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ListVendor.aspx.cs" Inherits="Pages_InformationSetup_ListVendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="clearfix">
        <asp:Button ID="addbtn" runat="server" Text="Add New" PostBackUrl="AddVendorName.aspx"></asp:Button>
    </div>

    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True"  PageSize="100" OnPageIndexChanging="gv_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" Width="100%" OnSelectedIndexChanged="gv_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="&nbsp;&nbsp;  Product Id">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ID")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Vendor Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("VendorID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Product Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("VendorName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Product Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Contact")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Email">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Email")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="&nbsp;&nbsp; Address">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Address")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                <ItemTemplate>
                    <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="Edit" PostBackUrl='<%# String.Concat("AddVendorName.aspx?ID=", Eval("ID").ToString()) %>'
                        meta:resourcekey="btnEditResource1" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

