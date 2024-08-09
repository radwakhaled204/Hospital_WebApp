<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="show_room_details.aspx.cs" Inherits="Royal_Elshrouq.show_room_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
     label {
         display: block;
         margin-bottom: 8px;
     }

     input, select, button {
       
         box-sizing: border-box;
     }

     .h_button {
         border-style: none;
         border-color: inherit; 
         border-width: medium;
         background: gray; 
         color: white;
         padding: 10px 15px;
         border-radius: 5px;
         Width:130px ;
         Height:42px;

     }
     button {
         background-color: #4caf50;
         color: #fff;
         border: none;
         border-radius: 5px;
         cursor: pointer;
     }
         .auto-style1 {
             width: 100%;
              text-align: center;
             
         }
         .form {
             width: 50%;
             border-radius: 5px;
             border: 1px solid #ccc;
             box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
             max-width: 1140px;
             min-width: 992px;
             margin-left: auto;
             margin-right: auto;
             margin-top: 10px;
             margin-bottom: 0px;
             padding: 20px;
             background-color: white;
             height: 500px;
         }
         
         .divfloor {
             height: 74px;
             margin-top: 20px;
             border-radius: 5px;
             border: 1px solid #ccc;
         }
         .auto-style3 {
             height: 74px;
             margin-top: 20px;
         }
         .auto-style4 {
             align-items:center;
         }

         .auto-style6 {
             float: right;
             height: 67px;
         }
         .auto-style7 {
            align-items:center;
             height: 86px;
            Width:304px;
            float: right;
         }
         .panel{

             float:left;
             border: 1px solid #ccc;
             border-radius: 5px;
         }
         .auto-style11 {
             height: 126px;
         }
         .auto-style12 {
             float: right;
             margin-top: 10px;
         }
         .auto-style13 {
             float: right;
             margin-left: 10px;
         }

         .auto-style14 {
             height: 86px;
         }

         .auto-style15 {
             float: right;
             height: 61px;
         }
         .dropdown_con{
             float: right;
         }





.square {
    width: 50px;
    height: 20px;
    border: 1px solid #000;
    margin: 2px;
    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
    color:black;
}


</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
