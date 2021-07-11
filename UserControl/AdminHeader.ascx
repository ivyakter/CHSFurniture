<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminHeader.ascx.cs" Inherits="UserControl_AdminHeader" %>
<header class="main-header">   
    <a href="<%= Page.ResolveUrl("~")%>Pages/Admin/Dashboard.aspx" class="logo">
        <span class="logo-lg"><img src="<%= Page.ResolveUrl("~")%>img/hospital-clinic-logo.png" width="80px" height="50px" /></span>         
    </a>

    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top" style="width: auto;" role="navigation">
        <!-- Sidebar toggle button-->
        <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
            <span class="sr-only">Toggle navigation</span>
        </a>
        <!-- Navbar Right Menu -->
        <div class="navbar-custom-menu">
            <ul class="nav navbar-nav">
               
                     <!-- User Account: style can be found in dropdown.less -->
                <li class="dropdown user user-menu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <img src="../../Images/Common/avatar5.png" class="img-circle" height="15" width="15" />
                        <span class="hidden-xs">
                            <asp:Label ID="lblUser" runat="server"></asp:Label></span>
                    </a>
                    <ul class="dropdown-menu">
                        <!-- User image -->
                        <li class="user-header">
                            <img src="../../Images/Common/avatar5.png" class="img-circle" />
                            <div>
                                <h3> <asp:Label ID="Label1" runat="server"></asp:Label></span></h3>

                            </div>
                        </li>
                        <!-- Menu Body -->
                        <li class="user-body">
                            <div class="row">
                                <div class="col-sm-12 text-center" style="color:white;">
                                    <asp:Button ID="changepass" runat="server" Text="Change Password" 
                                        CssClass="btn btn-block btn-default btn-flat" style="margin: 0;" onclick="changepass_Click" />

                                </div>
                            </div>
                        </li>
                        <!-- Menu Footer-->
                        <li class="user-footer">
                            <div class="pull-left" style="padding-top: 15px; padding-left: 15px;">
                                <a href="#" class="btn btn-info btn-flat">Profile</a>
                            </div>
                            <div class="pull-right">
                                <asp:Button ID="LoginStatus1" runat="server" Text="Logout" OnClick="LoginStatus1_Click" CssClass="btn btn-danger btn-flat"
                                    ForeColor="Black" />
                            </div>
                        </li>
                    </ul>
                </li>
                <!-- Control Sidebar Toggle Button -->
                <%-- <li>
                    <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                </li>--%>
            </ul>
        </div>

    </nav>
</header>
