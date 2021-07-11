<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Pages_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label runat="server" ID="lblloigin" Visible="false"></asp:Label>
      <div id="content">
                <div class="content-page">
                    <div class="container">

                        <!-- End Bread Crumb -->
                        <div class="row">
                            <div class="col-md-9 col-sm-8 col-col-xs-12">
                                <div class="product-detail accordion-detail border radius">
                                    <div class="row">
                                        <div class="col-md-5 col-sm-12 col-xs-12">
                                            <div class="detail-gallery">

                                                <asp:Repeater runat="server" ID="rptrsingleimage">
                                                    <ItemTemplate>
                                                        <div class="mid">
                                                            <img src="../ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="328" height="328" alt="<%#Eval("Name")%>" />
                                                        </div>
                                                        <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                        <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:Repeater>


                                                <div class="gallery-control" style="height: 70px">
                                                    <a href="#" class="prev"><i class="fa fa-angle-left"></i></a>
                                                    <div class="carousel">

                                                        <ul>
                                                            <asp:Repeater runat="server" ID="rptrthreeimage">
                                                                <ItemTemplate>
                                                                    <li style="height: 58px"><a href="#">
                                                                        <img src="../ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="68" height="68" alt="<%#Eval("Name")%>" /></a>
                                                                    </li>

                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>

                                                    </div>
                                                    <a href="#" class="next"><i class="fa fa-angle-right"></i></a>
                                                </div>
                                            </div>
                                            <!-- End Gallery -->
                                            <div class="detail-social">
                                                <ul class="list-social-detail list-inline-block">
                                                    <li><a href="#" class="soci-fa soc-tumblr"><i class="fa fa-tumblr" aria-hidden="true"></i></a></li>
                                                    <li><a href="#" class="soci-fa soc-facebook"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                                    <li><a href="#" class="soci-fa soc-twitter"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                                    <li><a href="#" class="soci-fa soc-print"><i class="fa fa-print" aria-hidden="true"></i></a></li>
                                                    <li>
                                                        <div class="more-social">
                                                            <a class="soci-fa add-link soc-add" href="#"><i aria-hidden="true" class="fa fa-plus"></i><span>7</span></a>
                                                            <ul class="list-social-share list-none">
                                                                <li><a href="#"><i class="fa fa-youtube" aria-hidden="true"></i><span>Youtute</span></a></li>
                                                                <li><a href="#"><i class="fa fa-linkedin"></i><span>linkedin</span></a></li>
                                                                <li><a href="#"><i class="fa fa-pinterest"></i><span>pinterest</span></a></li>
                                                                <li><a href="#"><i class="fa fa-google"></i><span>google</span></a></li>
                                                                <li><a href="#"><i class="fa fa-instagram"></i><span>instagram</span></a></li>
                                                                <li><a href="#"><i class="fa fa-flickr"></i><span>flickr</span></a></li>
                                                                <li><a href="#"><i class="fa fa-reddit"></i><span>reddit</span></a></li>
                                                            </ul>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-md-7 col-sm-12 col-xs-12">

                                            <div class="detail-info">

                                                <!-- Nav tabs -->
                                                <div class="card">
                                                    <ul class="nav nav-tabs" role="tablist">
                                                        <li role="presentation" class="active"><a href="#Description" aria-controls="home" role="tab" data-toggle="tab">Description</a></li>
                                                       <%-- <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Profile</a></li>--%>
                                                        <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Price</a></li>
                                                       <%-- <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Settings</a></li>--%>
                                                    </ul>

                                                    <!-- Tab panes -->
                                                    <div class="tab-content">
                                                        <asp:Repeater runat="server" ID="rptrproductinfo">
                                                            <ItemTemplate>

                                                                <div role="tabpanel" class="tab-pane active" id="Description">
                                                                    <h2 class="title-detail">New Favorite</h2>
                                                                    <div class="product-rate">
                                                                        <div class="product-rating" style="width: 90%"></div>
                                                                    </div>
                                                                    <p class="desc"><%# Server.HtmlDecode(Eval("PDescription").ToString()) %></p>

                                                                </div>

                                                               
                                                                <div role="tabpanel" class="tab-pane" id="messages">
                                                                  <asp:Label runat="server" ID="lblcostingprice" Font-Size="Larger" Text='<%#Eval("CostingPrice") %>'></asp:Label>  
                                                                </div>
                                                            


                                                      <asp:HiddenField ID="hfPId" Value='<%# Eval("PID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />


                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </div>
                                                </div>


                                                <div class="available">
                                                    <strong>Availability: </strong>
                                                    <span class="in-stock">In Stock</span>
                                                </div>

                                                <div class="detail-extralink">

                                                    <div class="product-extra-link2">
                                                        <asp:Label runat="server" ID="lbllog" Visible="false"></asp:Label>
                                                        <%--<a class="addcart-link" href="#">Add to Cart</a>--%>
                                                        <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click" runat="server" Text="Add Item" />

                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Detail Info -->
                                        </div>
                                    </div>
                                
                                </div>
                                <!-- End Main Detail -->
                                <div class="product-related border radius">
                                    <h2 class="title18">ALSO PURCHASED</h2>
                                    <div class="product-related-slider">
                                        <div class="wrap-item" data-itemscustom="[[0,1],[480,2],[1024,3],[1200,4]]" data-pagination="false" data-navigation="true">
                                            <div class="item-pro-color">
                                                <div class="product-thumb">
                                                    <a href="detail.html" class="product-thumb-link">
                                                        <img data-color="black" class="active" src="../images/photos/fashion/2.jpg" alt="">
                                                        <img data-color="purple" src="../images/photos/fashion/1.jpg" alt="">
                                                        <img data-color="blue" src="../images/photos/fashion/3.jpg" alt="">
                                                        <img data-color="cyan" src="../images/photos/fashion/4.jpg" alt="">
                                                    </a>
                                                    <a href="quick-view.html" class="quickview-link plus fancybox.iframe"><span>quick view</span></a>
                                                </div>
                                                <div class="product-info">
                                                    <div class="list-color">
                                                        <a href="#" data-color="black" style="background: #404040"></a>
                                                        <a href="#" data-color="purple" style="background: #ff8ff8"></a>
                                                        <a href="#" data-color="blue" style="background: #868fff"></a>
                                                        <a href="#" data-color="cyan" style="background: #80e6ff"></a>
                                                    </div>
                                                    <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                    <div class="product-price">
                                                        <ins><span>$360.00</span></ins>
                                                        <del><span>$400.00</span></del>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="item-pro-color">
                                                <div class="product-thumb">
                                                    <div class="product-label">
                                                        <span class="new-label">new</span>
                                                        <span class="sale-label">sale</span>
                                                    </div>
                                                    <a href="detail.html" class="product-thumb-link">
                                                        <img data-color="yellow" class="active" src="../images/photos/fashion/9.jpg" alt="">
                                                        <img data-color="red" src="../images/photos/fashion/10.jpg" alt="">
                                                    </a>
                                                    <a href="quick-view.html" class="quickview-link plus fancybox.iframe"><span>quick view</span></a>
                                                </div>
                                                <div class="product-info">
                                                    <div class="list-color">
                                                        <a href="#" data-color="yellow" style="background: #ffdb33"></a>
                                                        <a href="#" data-color="red" style="background: #ff596d"></a>
                                                    </div>
                                                    <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                    <div class="product-price">
                                                        <ins><span>$360.00</span></ins>
                                                        <del><span>$400.00</span></del>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="item-pro-color">
                                                <div class="product-thumb">
                                                    <a href="detail.html" class="product-thumb-link">
                                                        <img data-color="purple" class="active" src="../images/photos/fashion/8.jpg" alt="">
                                                        <img data-color="blue" src="../images/photos/fashion/7.jpg" alt="">
                                                    </a>
                                                    <a href="quick-view.html" class="quickview-link plus fancybox.iframe"><span>quick view</span></a>
                                                </div>
                                                <div class="product-info">
                                                    <div class="list-color">
                                                        <a href="#" data-color="purple" style="background: #ff8ff8"></a>
                                                        <a href="#" data-color="blue" style="background: #868fff"></a>
                                                    </div>
                                                    <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                    <div class="product-price">
                                                        <ins><span>$360.00</span></ins>
                                                        <del><span>$400.00</span></del>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="item-pro-color">
                                                <div class="product-thumb">
                                                    <a href="detail.html" class="product-thumb-link">
                                                        <img data-color="black" class="active" src="../images/photos/fashion/10.jpg" alt="">
                                                        <img data-color="green" src="../images/photos/fashion/9.jpg" alt="">
                                                        <img data-color="blue" src="../images/photos/fashion/8.jpg" alt="">
                                                    </a>
                                                    <a href="quick-view.html" class="quickview-link plus fancybox.iframe"><span>quick view</span></a>
                                                </div>
                                                <div class="product-info">
                                                    <div class="list-color">
                                                        <a href="#" data-color="black" style="background: #404040"></a>
                                                        <a href="#" data-color="green" style="background: #c3f1c7"></a>
                                                        <a href="#" data-color="blue" style="background: #868fff"></a>
                                                    </div>
                                                    <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                    <div class="product-price">
                                                        <ins><span>$360.00</span></ins>
                                                        <del><span>$400.00</span></del>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="item-pro-color">
                                                <div class="product-thumb">
                                                    <a href="detail.html" class="product-thumb-link">
                                                        <img data-color="purple" class="active" src="../images/photos/fashion/12.jpg" alt="">
                                                        <img data-color="blue" src="../images/photos/fashion/7.jpg" alt="">
                                                    </a>
                                                    <a href="quick-view.html" class="quickview-link plus fancybox.iframe"><span>quick view</span></a>
                                                </div>
                                                <div class="product-info">
                                                    <div class="list-color">
                                                        <a href="#" data-color="purple" style="background: #ff8ff8"></a>
                                                        <a href="#" data-color="blue" style="background: #868fff"></a>
                                                    </div>
                                                    <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                    <div class="product-price">
                                                        <ins><span>$360.00</span></ins>
                                                        <del><span>$400.00</span></del>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="item-pro-color">
                                                <div class="product-thumb">
                                                    <a href="detail.html" class="product-thumb-link">
                                                        <img data-color="black" class="active" src="../images/photos/fashion/13.jpg" alt="">
                                                        <img data-color="green" src="../images/photos/fashion/9.jpg" alt="">
                                                        <img data-color="blue" src="../images/photos/fashion/8.jpg" alt="">
                                                    </a>
                                                    <a href="quick-view.html" class="quickview-link plus fancybox.iframe"><span>quick view</span></a>
                                                </div>
                                                <div class="product-info">
                                                    <div class="list-color">
                                                        <a href="#" data-color="black" style="background: #404040"></a>
                                                        <a href="#" data-color="green" style="background: #c3f1c7"></a>
                                                        <a href="#" data-color="blue" style="background: #868fff"></a>
                                                    </div>
                                                    <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                    <div class="product-price">
                                                        <ins><span>$360.00</span></ins>
                                                        <del><span>$400.00</span></del>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Product Related -->
                            </div>
                            <div class="col-md-3 col-sm-4 col-col-xs-12">
                                <div class="sidebar sidebar-right">
                            <%--        <div class="list-detail-adv">

                                        <asp:Repeater runat="server" ID="rptrsidebar">
                                            <ItemTemplate>

                                                <div class="detail-adv">
                                                    <a href="#">
                                                        <img src="../ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" height="120" alt="<%#Eval("Name")%>" /></a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                             
                                    </div>--%>
                                    <div class="widget widget-seller">
                                        <h2 class="widget-title title14">best sellers</h2>
                                        <div class="widget-content">
                                            <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1]]">
                                                <div class="list-pro-seller">
                                                    <div class="item-pro-seller">
                                                        <div class="product-thumb">
                                                            <a href="#" class="product-thumb-link">
                                                                <img src="../images/photos/homeware/8.jpg" alt="" /></a>
                                                        </div>
                                                        <div class="product-info">
                                                            <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                            <div class="product-price">
                                                                <ins><span>$360.00</span></ins>
                                                                <del><span>$400.00</span></del>
                                                            </div>
                                                            <div class="product-rate">
                                                                <div style="width: 90%" class="product-rating"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="item-pro-seller">
                                                        <div class="product-thumb">
                                                            <a href="#" class="product-thumb-link">
                                                                <img src="../images/photos/homeware/2.jpg" alt="" /></a>
                                                        </div>
                                                        <div class="product-info">
                                                            <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                            <div class="product-price">
                                                                <ins><span>$360.00</span></ins>
                                                                <del><span>$400.00</span></del>
                                                            </div>
                                                            <div class="product-rate">
                                                                <div style="width: 90%" class="product-rating"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="item-pro-seller">
                                                        <div class="product-thumb">
                                                            <a href="#" class="product-thumb-link">
                                                                <img src="../images/photos/homeware/9.jpg" alt="" /></a>
                                                        </div>
                                                        <div class="product-info">
                                                            <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                            <div class="product-price">
                                                                <ins><span>$360.00</span></ins>
                                                                <del><span>$400.00</span></del>
                                                            </div>
                                                            <div class="product-rate">
                                                                <div style="width: 90%" class="product-rating"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="list-pro-seller">
                                                    <div class="item-pro-seller">
                                                        <div class="product-thumb">
                                                            <a href="#" class="product-thumb-link">
                                                                <img src="../images/photos/homeware/3.jpg" alt="" /></a>
                                                        </div>
                                                        <div class="product-info">
                                                            <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                            <div class="product-price">
                                                                <ins><span>$360.00</span></ins>
                                                                <del><span>$400.00</span></del>
                                                            </div>
                                                            <div class="product-rate">
                                                                <div style="width: 90%" class="product-rating"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="item-pro-seller">
                                                        <div class="product-thumb">
                                                            <a href="#" class="product-thumb-link">
                                                                <img src="../images/photos/homeware/4.jpg" alt="" /></a>
                                                        </div>
                                                        <div class="product-info">
                                                            <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                            <div class="product-price">
                                                                <ins><span>$360.00</span></ins>
                                                                <del><span>$400.00</span></del>
                                                            </div>
                                                            <div class="product-rate">
                                                                <div style="width: 90%" class="product-rating"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="item-pro-seller">
                                                        <div class="product-thumb">
                                                            <a href="#" class="product-thumb-link">
                                                                <img src="../images/photos/homeware/10.jpg" alt="" /></a>
                                                        </div>
                                                        <div class="product-info">
                                                            <h3 class="product-title"><a href="detail.html">new favorite</a></h3>
                                                            <div class="product-price">
                                                                <ins><span>$360.00</span></ins>
                                                                <del><span>$400.00</span></del>
                                                            </div>
                                                            <div class="product-rate">
                                                                <div style="width: 90%" class="product-rating"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End widget -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



</asp:Content>

