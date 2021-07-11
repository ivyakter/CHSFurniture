<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="OfficerInfo.aspx.cs" Inherits="Pages_HumanResource_OfficerInfo" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Initial
        {
            display: block;
            padding: 4px 4px 4px 18px;
            float: left;
            background: url("../../Images/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }
        .Initial:hover
        {
            color: White;
            background: url("../../Images/SelectedButton.png") no-repeat right top;
        }
        .Clicked
        {
            float: left;
            display: block;
            background: url("../../Images/SelectedButton.png") no-repeat right top;
            padding: 4px 4px 4px 18px;
            color: Black;
            font-weight: bold;
            color: White;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="container">
    <div class="row">
        <form role="form">
           <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                        <label for="exampleInputEmail1">Employee Type</label>                      
                          <asp:DropDownList ID="ddlOfficer" runat="server" class="form-control" AutoPostBack="true">
                                    </asp:DropDownList>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                    <label for="exampleInputEmail1">Guranter Name</label>             
                         <asp:TextBox ID="txtGN" runat="server"  class="form-control" placeholder="Guranter Name"></asp:TextBox>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                    <label for="exampleInputEmail1">Employee Name</label>                       
                          <asp:TextBox ID="txtOffName" runat="server" class="form-control" placeholder="Employee Name"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                     <label for="exampleInputEmail1">Guranter Mobile</label>     
                       <asp:TextBox ID="txtGMob" runat="server" class="form-control" placeholder="Guranter Mobile"></asp:TextBox>
                    </div>
                    
                     <div class="clearfix"></div>             
                      <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">        
                        <label for="exampleInputPassword1">Id No:</label>
                        <asp:TextBox ID="txtOfficerId" runat="server" class="form-control" placeholder="Id No" ></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                    <label for="exampleInputEmail1">Guranter Address</label> 
                      <asp:TextBox ID="txtGAdd" runat="server" class="form-control" placeholder="Guranter Address"></asp:TextBox>
                    </div>
                    
                     <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                        <label for="exampleInputPassword1">Address</label>                      
                         <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                     <label for="exampleInputPassword1">Security Check</label>               
                        <asp:TextBox ID="txtCheck" runat="server" class="form-control" placeholder="Security Check"></asp:TextBox>
                    </div>
                   
                     <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                        <label for="exampleInputPassword1">Mobile No:</label>                      
                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile No"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                     <label for="exampleInputPassword1">No of Chield</label>   
                        <asp:TextBox ID="txtChil" runat="server" class="form-control" placeholder="No of Chield"></asp:TextBox>
                    </div>
                     <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">  
                    <label for="exampleInputPassword1">Joining Date:</label>                            
                        <asp:TextBox ID="txtDofMar" runat="server" placeholder="yyyy-MM-dd"  class="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                            TargetControlID="txtDofMar">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                     <label for="exampleInputPassword1">Privious Company:</label>  
                       <asp:TextBox ID="txtCompany" runat="server" class="form-control" placeholder="Privious Company"></asp:TextBox>
                    </div>
                     <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                        <label for="exampleInputPassword1">Date of Birth</label>                      
                        <asp:TextBox ID="txtDofBirth" runat="server" placeholder="yyyy-MM-dd" class="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                            TargetControlID="txtDofBirth">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                    <label for="exampleInputPassword1">Relation</label>  
                          <asp:TextBox ID="txtRelation" runat="server" class="form-control" placeholder="Privious Company"></asp:TextBox>

                    </div>
                     
                     <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                        <label for="exampleInputPassword1">Basic Salary:</label>                      
                       <asp:TextBox ID="txtBasicSalary" runat="server" class="form-control" placeholder="Basic Salary"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                      <label for="exampleInputPassword1">NID No:</label> 
                       <asp:TextBox ID="txtNid" runat="server"  Width="150px"></asp:TextBox>
                    </div>

                     <div class="clearfix"></div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                         <asp:Button ID="btnSave" runat="server" Text="Save" Height="25px" Width="100px" ValidationGroup="sv"
                                        OnClick="btn_Submit_Click" />
                    </div>
                    <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                       
                    </div>

                    
          </form>
      </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>
