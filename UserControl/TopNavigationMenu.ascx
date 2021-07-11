<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopNavigationMenu.ascx.cs"
    Inherits="UserControl_NavigationMenu" %>
<div class="" id="main-menu-container">
    <div class="">
        <div class="">
            <div class="col-md-4">
            </div>
            <div class="col-md-6">
                <div class="navbar navbar-default sitenavbar-default">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"
                            aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                                class="icon-bar"></span><span class="icon-bar"></span>
                        </button>
                    </div>
                    <div class="col-sm-12 col -md-12 menulist">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                                    <ul class="nav navbar-nav topnavright">
                                        <li class="actives">
                                            <asp:HyperLink ID="BIOHyperLink" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="ScheduleHyperLink" runat="server" NavigateUrl="~/">Portal</asp:HyperLink></li>
                                        <li class="dropdown-1">
                                            <asp:HyperLink ID="NewsHyperLink" runat="server" NavigateUrl="~/">System Tools</asp:HyperLink>
                                        </li>
                                        <li class="dropdown-1">
                                            <asp:HyperLink ID="GalleryHyperLink" runat="server" NavigateUrl="~/">Help</asp:HyperLink>
                                        </li>
                                        <li class="dropdown-1">
                                            <asp:HyperLink ID="VideosHyperLink" runat="server" NavigateUrl="~/Login.aspx"><asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label></asp:HyperLink>
                                        </li>
                                       
                                        <li>
                                            <asp:HyperLink ID="SocialHyperLink" runat="server" NavigateUrl="~/">User(<asp:Label ID="lbluser" runat="server" Text=""></asp:Label>)</asp:HyperLink></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
