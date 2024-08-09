<%@ Page Title="معلومات عن الدكتور" Language="C#" MasterPageFile="~/empty.Master" AutoEventWireup="true" CodeBehind="show_video.aspx.cs" Inherits="Royal_Elshrouq.show_video" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <style type="text/css">
 .doc-corner{
    display: flex;
    width: 700px;
    height: 300px;
    background-color: #f2f2f2;
    border-radius: 5px;
    overflow: hidden;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    margin: 20px auto;
    align-items: center;
    align-content: center;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 2px 2px 5px #ccc;
 }


        .doc-corner img {
            width: 85%; 
            height: 100%;
            object-fit: cover;
            float:right;
        }

        .doc-corner-content {
            display: flex;
            flex-direction: column;
            justify-content: center;
            padding: 15px;
            width: 60%; 
        }

        .doc-corner-content h2 {
            margin: 0;
            font-size: 24px;
            color: #333; 
            text-align: center;
        }

        .doc-corner-content p {
            margin: 10px 0 0 0;
            font-size: 16px;
            color: #555; 
            text-align: center;
        }
.doc-corner-text{

        align-items: center;
    align-content: center;
}
        .doc-corner-content table-container {
            margin: 0;
            font-size: 24px;
            color: #333; 
            text-align: center;
                    align-items: center;
    align-content: center;
        }
  .crd {
    width: 90%;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 2px 2px 5px #ccc;
    margin: 0 auto;
    margin-top: 20px;
     margin-bottom: 20px;
    height:450px;
      display: flex;
    background-color: #f2f2f2;



  

 
    overflow: hidden;

    margin: 20px auto;
    align-items: center;
    align-content: center;
  }



        .crd-content {
            display: flex;
            flex-direction: column;
            justify-content: center;
            padding: 15px;
            width: 60%; 
        }

        .crd-content h2 {
            margin: 0;
            font-size: 24px;
            color: #333; 
            text-align: center;
        }

        .crd-content p {
            margin: 10px 0 0 0;
            font-size: 16px;
            color: #555; 
            text-align: center;
        }
.crd-text{
    float:left;
}

.box {
    position: relative;
    height: 400px;
    width: 50%;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 2px 2px 5px #ccc;
    margin: 20px auto;
    display: flex;
    justify-content: center;
    align-items: center;
}

.box video {
   
    width: 100%;
    height: 100%; 
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}
 .table-container {
        display: flex;
        justify-content: space-between;
        margin-bottom: 5px; 
    }

    table {
        border-collapse: collapse;
        width: 48%; 
    }

    th, td {
        border: none; 
        padding: 1px;
      
        text-align: center; 
    }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     <div class="doc-corner">
        <img id="img" runat="server" src="your_image_source" style="height:300px; width:400px;" class="img-fluid" />
      <div class="doc-corner-content">
        <div class="doc-corner-text">   
<h2><asp:Label ID="lbl_pic" runat="server" Text="اسم الدكتور" CssClass="mt-2"></asp:Label></h2>
<h2><asp:Label ID="lbl_dates" runat="server" Text=" مواعيد الدكتور"  Style="font-size:20px"  ></asp:Label></h2>
<div class="table-container">
<table border="1">  
     <tr>
    <td><asp:Label ID="n_day1" runat="server" CssClass="textbox-label" Text=""></asp:Label> </td>
    <td><asp:Label ID="day_1" runat="server" CssClass="form-control"></asp:Label> </td>
    </tr> 
     <tr>
    <td><asp:Label ID="n_day2" runat="server" CssClass="textbox-label" Text=""></asp:Label> </td>
    <td><asp:Label ID="day_2" runat="server" CssClass="form-control"></asp:Label></td>
    </tr>
     <tr>
    <td><asp:Label ID="n_day3" runat="server" CssClass="textbox-label" Text=""></asp:Label></td>
    <td><asp:Label ID="day_3" runat="server" CssClass="form-control"></asp:Label></td>
    </tr>
     <tr>
    <td><asp:Label ID="n_day4" runat="server" CssClass="textbox-label" Text=""></asp:Label></td>
    <td><asp:Label ID="day_4" runat="server" CssClass="form-control"></asp:Label></td>
    </tr>
     
</table>
<table border="1">
      <tr>
    <td><asp:Label ID="n_day5" runat="server" CssClass="textbox-label" Text=" "></asp:Label></td>
    <td><asp:Label ID="day_5" runat="server" CssClass="form-control"></asp:Label></td>
    </tr>
     <tr>
    <td><asp:Label ID="n_day6" runat="server" CssClass="textbox-label" Text=""></asp:Label></td>
    <td><asp:Label ID="day_6" runat="server" CssClass="form-control"></asp:Label></td>
    </tr>
     <tr>
    <td><asp:Label ID="n_day7" runat="server" CssClass="textbox-label" Text=""></asp:Label> </td>
    <td><asp:Label ID="day_7" runat="server" CssClass="form-control"></asp:Label></td>
    </tr>   
 </table>
</div>
 </div>
  </div>

    </div>

    <div class="crd">
         <div class="box">
             <video id="vid" runat="server" controls style=" float:right;" class="img-fluid"></video>
                </div> 
             <div class="crd-content">
        <div class="crd-text">
          <h2><asp:Label ID="lbl_vid" runat="server" Text="اسم الدكتور" CssClass="mt-2"></asp:Label></h2>
          <p><asp:Label ID="lbl_doc_info" runat="server" Text="" CssClass="mt-2"></asp:Label></p>
                </div>
                </div>
    </div>
    </form>
</asp:Content>



