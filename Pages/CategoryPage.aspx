<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.master" AutoEventWireup="true" CodeFile="CategoryPage.aspx.cs" Inherits="Pages_CategoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server" ID="lblloigin" Visible="false"></asp:Label>
    <div id="content">
        <div class="banner-shop full-width">
         <%--   <div class="banner-shop-thumb">
                <asp:Repeater ID="LoadBigImageinCategory" runat="server">
                    <ItemTemplate>
                        <a href="#">
                            <img src="../CategoryImage/<%#Eval("CatID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" alt="<%#Eval("Name")%>" />
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
         
            </div>--%>
            <div class="banner-shop-info text-center">
                <h3>big sale</h3>
                <h2>up to 30% off</h2>
            </div>
            <div class="bread-crumb">
                <div class="container">
                    <a href="#">Home</a> <span>Fashion</span>
                </div>
            </div>
            <!-- End Bread Crumb -->
        </div>
        <!-- End Banner -->
        <div class="content-page">
            <div class="container">
                <div class="row">
                 
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="content-grid-boxed">
                            <div class="sort-pagi-bar clearfix">
                                <div class="view-type pull-left">
                                    <%--<a href="CategoryGridPage.aspx" class="grid-view"></a>--%>

                                    <a class="grid-view" href="CategoryGridPage.aspx?catid=<%=lblcatid.Text%>&Subcatid=<%=lblSubcatid.Text%> &Parentid=<%=lblParentid.Text%>">
                                        <asp:Label ID="lblcatid" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lblSubcatid" Visible="false" runat="server"></asp:Label>
                                    <asp:Label ID="lblParentid" Visible="false" runat="server"></asp:Label>
                                    </a>
                                    
                                    <a href="CategoryPage.aspx" class="list-view active"></a>
                                </div>
                                <div class="sort-paginav pull-right">
                                    <div class="sort-bar select-box">
                                        <label>Sort By:</label>
                                        <select>
                                            <option value="">position</option>
                                            <option value="">price</option>
                                        </select>
                                    </div>
                                    <div class="show-bar select-box">
                                        <label>Show:</label>
                                        <select>
                                            <option value="">20</option>
                                            <option value="">12</option>
                                            <option value="">24</option>
                                        </select>
                                    </div>
                                    <div class="pagi-bar">
                                        <a href="#" class="current-page">1</a>
                                        <a href="#">2</a>
                                        <a href="#" class="next-page"><i class="fa fa-caret-right" aria-hidden="true"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- End Sort PagiBar -->
                            <div class="list-pro-color">
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <asp:Label runat="server" ID="lblproduct" Visible="false" ForeColor="Red" Font-Size="XX-Large" Text="There Is No Product Fro This Category"></asp:Label>
                                    </div>
                                </div>

                                <asp:Repeater ID="rptrFoodcupboardnewarrivals" runat="server">
                                    <ItemTemplate>
                                        <div class="item-product-list">

                                            <div class="row">
                                                <div class="col-md-3 col-sm-4 col-xs-12">
                                                    <div class="item-pro-color">
                                                        <div class="product-thumb">
                                                            <a href='<%# String.Concat("../Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>'>
                                                                <img src="../ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                            </a>
                                                           
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-9 col-sm-8 col-xs-12">
                                                    <div class="product-info">
                                                        <h3 class="product-title"><a href='<%# String.Concat("../Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>'><%# Eval("ProductName") %></a></h3>
                                                        <div class="product-price">
                                                            <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                           <%-- <br />
                                                            <span style="font-size: small">Del :</span> £ <del><span><%# Eval("PPrice") %></span></del>
                                                            <ins><span><%# Eval("PSelPrice") %></span></ins>--%>
                                                        </div>
                                                        <p class="desc">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla paria tur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                                        <div class="product-rate">
                                                            <div class="product-rating" style="width: 90%"></div>
                                                        </div>
                                                        <div class="product-extra-link2">
                                                            <%-- <a href="#" class="addcart-link">Add to Cart</a>--%>
                                                            <asp:LinkButton class="addcart-link" runat="server" ID="addtocart" OnClick="addtocart_Click" CausesValidation="false">Add to Cart</asp:LinkButton>
                                                            <a href="#" class="wishlist-link"><i class="fa fa-heart" aria-hidden="true"></i></a>
                                                            <a href="#" class="compare-link"><i class="fa fa-refresh" aria-hidden="true"></i></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                         <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
<%--                                        <asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />
                                     
                                        <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />
                                        <asp:HiddenField ID="hfPId" Value='<%# Eval("PID") %>' runat="server" />
                                        <asp:HiddenField ID="hfname" Value='<%# Eval("PName") %>' runat="server" />
                                        <asp:HiddenField ID="hfprice" Value='<%# Eval("PSelPrice") %>' runat="server" />
                                        <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />
                                        <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                        <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />--%>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <!-- End Item -->
                                <div class="pagi-bar bottom">
                                    <a class="current-page" href="#">1</a>
                                    <a href="#">2</a>
                                    <a class="next-page" href="#"><i aria-hidden="true" class="fa fa-caret-right"></i></a>
                                </div>
                            </div>
                            <!-- End List Pro color -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

