<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ListSubCategory.aspx.cs" Inherits="Pages_Set_ListSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <div class="col-md-12">
        <span>
            <h2>List Of Sub Category</h2>
        </span>
    </div>
    <div class="row">
        <div class="col-md-5">
            <asp:Button ID="addbtn" runat="server" Text="Add New" PostBackUrl="~/Pages/AddSubCategory.aspx"></asp:Button>
        </div>

    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gv" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false"
                AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging" PageSize="10" Width="70%">
                <Columns>
                    <asp:TemplateField HeaderText="&nbsp;&nbsp;  ID">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                    <%# Eval("Id")%>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="&nbsp;&nbsp; MenuText ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                    <%# Eval("MenuText")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="&nbsp;&nbsp; MenuLevel ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                    <%# Eval("MenuLevel")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="&nbsp;&nbsp; ParentId ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                    <%# Eval("ParentId")%>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                        <ItemTemplate>
                            <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="Edit" PostBackUrl='<%# String.Concat("AddSubCategory.aspx?Id=", Eval("Id").ToString()) %>'
                                meta:resourcekey="btnEditResource1" />
                        </ItemTemplate>
                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Delete">
                        <ItemTemplate>
                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            <asp:Button CssClass="btn-delete" ID="btnDelete" runat="server" Text="Delete" OnClientClick=" return confirm('Clicking ok will delete this record permanently.') "
                                OnClick="btnDelete_Click" />
                        </ItemTemplate>
                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </div>
    </div>
    </center>
</asp:Content>

