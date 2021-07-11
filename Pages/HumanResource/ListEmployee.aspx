<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ListEmployee.aspx.cs" Inherits="Pages_HumanResource_ListEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="clearfix">
        <asp:Button ID="addbtn" runat="server" Text="Add New" PostBackUrl="AddEmployee.aspx"></asp:Button>
    </div>

    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" CssClass="table table-striped table-bordered table-hover" Width="100%">
        <Columns>
        
            <asp:TemplateField HeaderText="&nbsp;&nbsp;Officer Type">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Officer_Type")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp;  Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Address">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Address")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp;Mobile">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Mobile")%>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="&nbsp;&nbsp;BasicSalary">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("BasicSalary")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                <ItemTemplate>
                    <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="Edit" PostBackUrl='<%# String.Concat("AddEmployee.aspx?ID=", Eval("id").ToString()) %>'
                        meta:resourcekey="btnEditResource1" />
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
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
        </Columns>
    </asp:GridView>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

