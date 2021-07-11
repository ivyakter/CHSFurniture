<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="UserControl_AdminMenu" %>
<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
        <!-- Sidebar user panel -->
        <ul class="sidebar-menu">
            <asp:Repeater runat="server" ID="rptParent" OnItemDataBound="rptCategory_OnItemDataBound">
                <ItemTemplate>
                    <li class="treeview">
                        <a href='<%#Eval("URL") %>'>
                            <i class='fa <%#Eval("Icon") %>'></i><span><%#Eval("Text") %></span> <i class="fa fa-angle-left pull-right"></i>
                        </a
                        <asp:HiddenField runat="server" ID="hdnValue" Value='<%#Eval("Id")%>' />
                        <asp:Repeater runat="server" ID="rptChild">
                            <HeaderTemplate>
                                <ul class="treeview-menu">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href='<%#Eval("URL") %>'><i class='fa <%#Eval("Icon") %>'></i><%#Eval("Text") %></a></li>
                            </ItemTemplate>
                            <FooterTemplate></ul></FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </section>
    <!-- /.sidebar -->
</aside>