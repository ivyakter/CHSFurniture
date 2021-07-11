<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ListClient.aspx.cs" Inherits="Pages_InformationSetup_ListClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="clearfix">
        <asp:Button ID="addbtn" runat="server" Text="Add New" PostBackUrl="AddClientName.aspx"></asp:Button>
    </div>

    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True" PageSize="50" CssClass="table table-striped table-bordered table-hover"  OnPageIndexChanging="gv_PageIndexChanging" Width="100%" >
        <Columns>
            <asp:TemplateField HeaderText="&nbsp;&nbsp;   Id">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ID")%>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="&nbsp;&nbsp;  Client Id">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ClientID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Client Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ClientName")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="&nbsp;&nbsp; Conact No">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ContactNo")%>
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
                    <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="Edit" PostBackUrl='<%# String.Concat("AddClientName.aspx?ID=", Eval("ID").ToString()) %>'
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

