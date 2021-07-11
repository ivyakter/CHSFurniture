<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ListModel.aspx.cs" Inherits="Pages_InformationSetup_ListModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="clearfix">
        <asp:Button ID="addbtn" runat="server" Text="Add New" PostBackUrl="AddModel.aspx"></asp:Button>
    </div>

    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True" PageSize="100" OnPageIndexChanging="gv_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" Width="100%" OnSelectedIndexChanged="gv_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="&nbsp;&nbsp;  Model Id">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ModelId")%>
                </ItemTemplate>
            </asp:TemplateField>
             
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Product Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("PName")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Model Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ModelName")%>
                </ItemTemplate>
            </asp:TemplateField>
           

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                <ItemTemplate>
                    <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="Edit" PostBackUrl='<%# String.Concat("AddModel.aspx?ID=", Eval("ModelId").ToString()) %>'
                        meta:resourcekey="btnEditResource1" />
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Delete">
                <ItemTemplate>
                    <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("ModelId") %>'></asp:Label>
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

