<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="CustomerOrder.aspx.cs" Inherits="Pages_CustomerOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gv" runat="server" CssClass="table table-striped table-bordered table-hover"
                AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging"
                PageSize="10" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Orderid">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("orderid")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="&nbsp;&nbsp; CustomerName ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("CustomerName")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="&nbsp;&nbsp; CustomerPhone ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("CustomerPhone")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Date ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Date")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Pid ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Pid")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Pname ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Pname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Quantity ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Quantity")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Price ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Price")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Total ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Total")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="&nbsp;&nbsp; Status ">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <%# Eval("Status")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Action">
                        <ItemTemplate>
                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                            <asp:Button CssClass="btn-delete" ID="btnSeenComplete" runat="server" Text="Seen"
                                OnClientClick=" return confirm('Clicking ok will delete this record permanently.') "
                                OnClick="btnSeenComplete_Click" />
                        </ItemTemplate>
                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
