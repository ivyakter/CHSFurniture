<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label runat="server" ID="lblloigin" Visible="false"></asp:Label>

    <!-- End Header -->
    
    <div id="content">
        <div class="container">
            <div class="content-top12">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                        <div class="wrap-cat-icon wrap-cat-icon12">
                            <h2 class="title14 title-cat-icon">Shopping Categories</h2>

                            <ul class="list-cat-icon">
                                <li class="has-cat-mega">
                                    <a href="#">
                                        <span>Popular </span>
                                        <i class='fa fa-star-o pull-right'></i>
                                    </a>
                                </li>
                            </ul>
                            <ul class="list-cat-icon">

                                <asp:Repeater ID="rptrMain" runat="server" OnItemDataBound="rptrMain_ItemDataBound">
                                    <ItemTemplate>
                                        <li class="has-cat-mega">
                                            <a href="<%= Page.ResolveUrl("~")%>Pages/CategoryPage.aspx?CatID=<%# Eval("Id")%> ">

                                                <%--    <i class='fa <%#Eval("MenuText") %>'></i><span><%#Eval("Icon") %></span> <i class="fa fa-angle-left pull-right"></i>--%>

                                                <span><%#Eval("MenuText") %> </span>
                                                <i class='fa <%#Eval("Icon") %> pull-right'></i>
                                            </a>
                                            <div class="cat-mega-menu cat-mega-style1">
                                                <h2 class="title-cat-mega-menu"><%#Eval("MenuText") %></h2>
                                                <asp:HiddenField ID="hfCateId" runat="server" Value='<%#Eval("Id") %>' />

                                                <asp:Repeater ID="rptrSubCate" runat="server">
                                                    <HeaderTemplate>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%--<li style="list-style-type: none; padding-bottom: 10px; padding-top: 10px; border-bottom: 1px solid #ddd"><a href='Pages/Home/ProductsByCategory.aspx?Subcatid=<%# Eval("Id")%>'><%#Eval("MenuText") %> </a></li>--%>
                                                        <li style="list-style-type: none; padding-bottom: 10px; padding-top: 10px; border-bottom: 1px solid #ddd"><a href='<%= Page.ResolveUrl("~")%>Pages/CategoryGridPage.aspx?Subcatid=<%# Eval("Id")%>&ParentId=<%# Eval("ParentId")%>'><%#Eval("MenuText") %> </a></li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>

                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12">
                        <div class="banner-slider banner-slider12">
                            <div class="wrap-item" data-pagination="false" data-autoplay="true" data-transition="fade" data-navigation="true" data-itemscustom="[[0,1]]">


                                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">

                                        <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
                                        <li data-target="#myCarousel" data-slide-to="2"></li>
                                        <li data-target="#myCarousel" data-slide-to="3"></li>
                                        <li data-target="#myCarousel" data-slide-to="4"></li>
                                        <li data-target="#myCarousel" data-slide-to="5"></li>

                                    </ol>
                                    <div class="carousel-inner">

                                        <div class="item active sliderimage">
                                            <div class="banner-thumb">
                                                <a href="#">

                                                    <img class="img-responsive sliderimage" src="SliderImage/1.jpg" alt="Chicago"/>
                                                </a>
                                            </div>

                                            <div class="banner-info white bg-color animated" data-animated="slideInUp">
                                                <h2 class="animated" data-animated="slideInLeft">
                                                    <asp:Label runat="server" ID="firstslidertitle"></asp:Label></h2>
                                                <p class="animated" data-animated="slideInRight">
                                                    <asp:Label runat="server" ID="firstsliderdetails"></asp:Label>
                                                </p>
                                            </div>

                                        </div>
                                        <div class="item sliderimage">

                                            <div class="banner-thumb">
                                                <a href="#">

                                                    <img class="img-responsive sliderimage" src="SliderImage/2.jpg" alt="New york"/>
                                                </a>
                                            </div>
                                            <div class="banner-info white bg-color animated" data-animated="slideInUp">
                                                <h2 class="animated" data-animated="slideInLeft">
                                                    <asp:Label runat="server" ID="secondslidertitle"></asp:Label></h2>
                                                <p class="animated" data-animated="slideInRight">
                                                    <asp:Label runat="server" ID="secondsliderdetails"></asp:Label>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="item sliderimage">
                                            <div class="banner-thumb">
                                                <a href="#">

                                                    <img class="img-responsive sliderimage" src="SliderImage/3.jpg" alt="Chicago"/>
                                                </a>
                                            </div>
                                            <div class="banner-info white bg-color animated" data-animated="slideInUp">
                                                <h2 class="animated" data-animated="slideInLeft">
                                                    <asp:Label runat="server" ID="thirdslidertitle"></asp:Label></h2>
                                                <p class="animated" data-animated="slideInRight"></p><asp:Label runat="server" ID="thirdsliderdetails"></asp:Label></p>
                                            </div>

                                        </div>
                                        <div class="item sliderimage">

                                            <div class="banner-thumb">
                                                <a href="#">

                                                    <img class="img-responsive sliderimage" src="SliderImage/4.jpg" alt="Chicago"/>
                                                </a>
                                            </div>
                                            <div class="banner-info white bg-color animated" data-animated="slideInUp">
                                                <h2 class="animated" data-animated="slideInLeft">
                                                    <asp:Label runat="server" ID="fourthslidertitle"></asp:Label></h2>
                                                <p class="animated" data-animated="slideInRight">
                                                    <asp:Label runat="server" ID="fourthsliderdetails"></asp:Label>
                                                </p>
                                            </div>

                                        </div>
                                        <div class="item sliderimage">
                                            <div class="banner-thumb">
                                                <a href="#">
                                                    <img class="img-responsive sliderimage" src="SliderImage/5.jpg" alt="New york"/>
                                                </a>
                                            </div>
                                            <div class="banner-info white bg-color animated" data-animated="slideInUp">
                                                <h2 class="animated" data-animated="slideInLeft">
                                                    <asp:Label runat="server" ID="fifthslidertitle"></asp:Label></h2>
                                                <p class="animated" data-animated="slideInRight">
                                                    <asp:Label runat="server" ID="fifthsliderdetails"></asp:Label>
                                                </p>
                                            </div>

                                        </div>

                                    </div>

                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="fa fa-angle-left" style="padding-top: 270px; font-size: 48px;"></span><span class="sr-only">Previous</span> </a>
                                    <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="fa fa-angle-right" style="padding-top: 270px; font-size: 48px;"></span><span class="sr-only">Next</span> </a>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
            <!-- End Content Top -->
            <div class="hot-product12">
                <%--   <h2 class="title-hot12 title24 text-center"><span>hot products</span></h2>--%>

                <div class="product-tab12">
                    <div class="title-tab12">
                        <ul class="list-none">
                            <li class="active"><a href="#fas2" data-toggle="tab">new arrivals</a></li>
                            <li><a href="#fas1" data-toggle="tab">Best sellers</a></li>
                            <li><a href="#fas3" data-toggle="tab">On Sale</a></li>
                        </ul>
                    </div>
                    <div class="tab-content">
                        <!-- End Tab -->
                        <div id="fas2" class="tab-pane active">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">

                                    <asp:Repeater ID="rptrHotnewarrivalProducts" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">

                                                    <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                   

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Price :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>


                                                    <br />
                                                    <div>
                                                        
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                  
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                 
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>
                            </div>
                        </div>


                        <div id="fas1" class="tab-pane">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">

                                    <asp:Repeater ID="rptrHotbestsellersProducts" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                                   <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                  

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Price :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>



                                                    <br />
                                                    <div class="">
                                                        <%-- <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1" runat="server" Text="Add Item" />--%>
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                                                                      <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>
                            </div>
                        </div>

                        <!-- End Tab -->
                        <div id="fas3" class="tab-pane">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">
                                    <asp:Repeater ID="rptrHotdealsProducts" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                                   <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                   

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Price :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>




                                                    <br />
                                                    <div class="">
                                                        <%--  <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1" runat="server" Text="Add Item" />--%>
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                    </div>
                </div>

            </div>
            <!-- End Hot Product -->
        </div>

        <div class="product-box12">
            <div class="container">
                <div class="header-box12">
                    <h2 class="title24">Chair</h2>
                    <div class="row">
                        <div class="col-lg-2 col-md-3 col-sm-12">
                            <ul class="list-cat-icon">
                                <li class="has-cat-mega">
                                    <asp:Repeater ID="rptrSubChair" runat="server">
                                        <HeaderTemplate>
                                            <ul>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li style="list-style-type: none; padding-bottom: 10px; padding-top: 10px; border-bottom: 1px solid #ddd"><a href='Pages/Home/ProductsByCategory.aspx?Subcatid=<%# Eval("Id")%>&catid=<%# Eval("ParentId")%>'><%#Eval("MenuText") %> </a></li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-7 col-md-9 col-sm-12">
                            <div class="banner-box banner-box12">
                                <a href="#" class="link-banner-box">
                                    <img src="images/photos/home12/fashion/ban1.jpg" alt="" />
                                </a>

                                <div class="banner-info">
                                    <h2 class="title24">trending styles</h2>
                                    <h3 class="title18 color">What new. what hot</h3>
                                    <a href="#" class="shopnow">Shop now</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-12 col-sm-12">
                            <div class="list-banner-zoom12">
                                <div class="row">
                                    <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6">
                                        <div class="banner-zoom banner-zoom12">
                                            <a href="#" class="thumb-zoom">
                                                <img src="images/photos/home12/fashion/side1.jpeg" alt="" /></a>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6">
                                        <div class="banner-zoom banner-zoom12">
                                            <a href="#" class="thumb-zoom">
                                                <img src="images/photos/home12/fashion/side2.jpeg" alt="" /></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Header Box -->
                <div class="product-tab12">
                    <div class="title-tab12">
                        <ul class="list-none">
                            <li class="active"><a href="#fas1" data-toggle="tab">new arrivals</a></li>
                            <li><a href="#fas2" data-toggle="tab">Best sellers</a></li>
                            <li><a href="#fas3" data-toggle="tab">On Sale</a></li>
                        </ul>
                    </div>
                    <div class="tab-content">
                        <div id="Div1" class="tab-pane active">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">

                                    <asp:Repeater ID="rptChairNewArrivals" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">

                                                <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                   

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>

                                              


                                                    <br />
                                                    <div class="">
                                                        <%-- <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1" runat="server" Text="Add Item" />--%>
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                                                                       <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                        <div id="Div2" class="tab-pane">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">
                                    <asp:Repeater ID="rptChairBestSellers" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                                <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                 

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price">
                                                        <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>

                                                   


                                                    <br />
                                                    <div class="">
                                                        <%-- <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1" runat="server" Text="Add Item" />--%>
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                                        <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                        <div id="Div3" class="tab-pane">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">
                                    <asp:Repeater ID="rptChairDeals" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                                <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                 
                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>

                                                    <br />
                                                    <div class="">
                                                        <%--   <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1" runat="server" Text="Add Item" />--%>
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                                                                       <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                    </div>
                </div>
                <!-- End Product Tab -->
            </div>
        </div>
        <!-- End Product Box -->



        <div class="product-box12 block-orange">
            <div class="container">
                <div class="header-box12">
                    <h2 class="title24">Table</h2>
                    <div class="row">
                        <div class="col-lg-2 col-md-3 col-sm-12">
                            <ul class="list-cat-icon">
                                <li class="has-cat-mega">
                                    <asp:Repeater ID="rptrforFresh" runat="server">
                                        <HeaderTemplate>
                                            <ul>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--  <li style="list-style-type: none; padding-bottom: 10px; padding-top: 10px; border-bottom: 1px solid #ddd"><a href='Pages/Home/ProductsByCategory.aspx?Subcatid=<%# Eval("Id")%>'><%#Eval("MenuText") %> </a></li>--%>
                                            <li style="list-style-type: none; padding-bottom: 10px; padding-top: 10px; border-bottom: 1px solid #ddd"><a href='Pages/Home/ProductsByCategory.aspx?Subcatid=<%# Eval("Id")%>&catid=<%# Eval("ParentId")%>'><%#Eval("MenuText") %> </a></li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-7 col-md-9 col-sm-12">
                            <div class="banner-box banner-box12">
                                <a href="#" class="link-banner-box">
                                     <img src="images/photos/home12/electronics/ban1.jpg" alt="" />

                                 <%--   <asp:Repeater ID="rptrfresgbannerimage" runat="server">
                                        <ItemTemplate>
                                            <img src="CategoryImage/<%#Eval("CatID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="580" height="300" alt="<%#Eval("Name")%>" />

                                        </ItemTemplate>
                                    </asp:Repeater>--%>


                                </a>
                                <div class="banner-info">
                                    <h2 class="title24">Consumer electronics</h2>
                                    <h3 class="title18 color">Hot-Selling this Season</h3>
                                    <a href="#" class="shopnow">Shop now</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-12 col-sm-12">
                            <div class="list-banner-zoom12">
                                <div class="row">
                                <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6">
										<div class="banner-zoom banner-zoom12">
											<a href="#" class="thumb-zoom"><img src="images/photos/home12/electronics/side1.jpg" alt="" /></a>
										</div>
									</div>
									<div class="col-lg-12 col-md-6 col-sm-6 col-xs-6">
										<div class="banner-zoom banner-zoom12">
											<a href="#" class="thumb-zoom"><img src="images/photos/home12/electronics/side2.jpg" alt="" /></a>
										</div>
									</div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Header Box -->
                <div class="product-tab12">
                    <div class="title-tab12">
                        <ul class="list-none">
                            <li class="active"><a href="#ele1" data-toggle="tab">new arrivals</a></li>
                            <li><a href="#ele2" data-toggle="tab">Best sellers </a></li>
                            <li><a href="#ele3" data-toggle="tab">On Sale</a></li>
                        </ul>
                    </div>

                    <div class="tab-content">
                        <div id="ele1" class="tab-pane active">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">

                                    <asp:Repeater ID="rptrFreshnewarrivalproduct" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                                <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                   

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>
                                            


                                                    <br />
                                                    <div class="">
                                                        
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                                                                     <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                        <div id="ele2" class="tab-pane">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">
                                    <asp:Repeater ID="rptrFreshbestsellersproduct" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                                 <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                   

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>
                                                


                                                    <br />
                                                    <div class="">
                                                        <%--  <asp:Button ID="btnaddtocart" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1" runat="server" Text="Add Item" />--%>
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                     <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                        <div id="ele3" class="tab-pane">
                            <div class="product-slider12">
                                <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">
                                    <asp:Repeater ID="rptrFreshdealsproduct" runat="server">
                                        <ItemTemplate>

                                            <div class="item-product">
                                               <div class="product-thumb">
                                                    <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" width="200" height="200" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                   

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("PName") %></a></h3>
                                                    <div class="product-price" style="text-align: left">
                                                        <span style="font-size: small">Col :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins>
                                                    </div>
                                                    


                                                    <br />
                                                    <div class="">
                                                        
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> Add Item</asp:LinkButton>
                                                    </div>

                                                    <%--<asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />--%>
                                                  
                                                   <%-- <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <!-- End Tab -->
                    </div>

                </div>
                <!-- End Product Tab -->
            </div>
        </div>

      


     
    </div>
    <!-- End Content -->

</asp:Content>

