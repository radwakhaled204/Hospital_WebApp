<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="show_date_doc.aspx.cs" Inherits="Royal_Elshrouq.show_date_doc" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>

    <asp:Content ID="Content6" ContentPlaceHolderID="head" runat="server">

        <style type="text/css">
      .auto-style6 {
          margin-top: 8px;
      }
      .auto-style12 {
          width: 100%;
         
      }
      .auto-style14 {
          margin-left: 300px;
          margin-top:28px;
      }
      .auto-style15 {
          width: 914px;
          height: 87px;
      }
      .auto-style17 {
          width: 900px;
          margin-left: 100px;
      }
      .auto-style18 {
       
        margin-right:2px;
    }
      </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    


  <div class="auto-style17">
<div class="auto-style6"  >

            <div class="row txtrow">
                <div style="display: flex; justify-content: flex-end; align-items: center; color: gray; font-size: 18px;" class="auto-style12">
                    <asp:DropDownList ID="doc" runat="server" Style="margin-right: 2px; margin-top: 2px; margin-bottom: 4px;" Width="223px" Height="38px" AutoPostBack="true"  >
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;الدكتور&nbsp;&nbsp;&nbsp
                    <asp:DropDownList ID="clinic" runat="server" style="margin-right: 2px; margin-top: 2px; margin-bottom: 4px;" Width="223px" Height="38px" AutoPostBack="true" OnSelectedIndexChanged="clinic_SelectedIndexChanged">
                 </asp:DropDownList> &nbsp;&nbsp;&nbsp;العياده&nbsp;&nbsp;&nbsp;
                </div>
            </div>

            <div class="row txtrow">
                <div style="display: flex; justify-content: flex-end; align-items: center; color: gray; font-size: 18px;" class="auto-style12">
                    <asp:TextBox ID="searchBox" runat="server" CssClass="auto-style18" Width="283px" placeholder="ابحث باسم الدكتور" ></asp:TextBox>
                                
                </div>
            </div>


<div class="row txtrow">
    <div style="display: flex; justify-content: flex-end; align-items: center; color: gray; font-size: 18px;" class="auto-style12">

        <div>
            <asp:Label ID="label7" runat="server" CssClass="textbox-label" Text="الجمعة" Style="text-align:center" ></asp:Label>
            <asp:TextBox ID="day7" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="label6" runat="server" CssClass="textbox-label" Text="الخميس" Style="text-align:center"></asp:Label>
            <asp:TextBox ID="day6" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="label5" runat="server" CssClass="textbox-label" Text="الاربعاء" Style="text-align:center"></asp:Label>
            <asp:TextBox ID="day5" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="label4" runat="server" CssClass="textbox-label" Text="الثلاثاء" Style="text-align:center"></asp:Label>
            <asp:TextBox ID="day4" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="label3" runat="server" CssClass="textbox-label" Text="الاثنين" Style="text-align:center"></asp:Label>
            <asp:TextBox ID="day3" runat="server"></asp:TextBox>
        </div>
        
        <div>
            <asp:Label ID="label2" runat="server"  Text="الاحد" Style="text-align:center; justify-content:center"></asp:Label>
            <asp:TextBox ID="day2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="label1" runat="server" CssClass="textbox-label" Text="السبت" Style="text-align:center"></asp:Label>
            <asp:TextBox ID="day1" runat="server"></asp:TextBox>
        </div>
        <asp:Label runat="server" ID="dates" CssClass="result-label">المواعيد</asp:Label>
    </div>
</div>
 





    <div class="row txtrow">
    <div style="display: flex; justify-content: flex-end; align-items: center; color: gray; font-size: 18px;" class="auto-style12">
              <img id="img" runat="server" src="your_image_source" style="height:200px; width:300px;" visible="False"/>
        <asp:Label ID="lbl_pic" runat="server" Text="Label">الصورة</asp:Label>

    </div>
</div>
<div class="row txtrow">
    <div style="display: flex; justify-content: flex-end; align-items: center; color: gray; font-size: 18px;" class="auto-style12">
         <iframe id="vid" runat="server" src="your_video_source" style="height:400px; width:600px;" visible="False"></iframe>
        <asp:Label ID="lbl_vid" runat="server" Text="Label">الفيديو</asp:Label>
       
    </div>
</div>




   
            <asp:Label ID="lbl_message" runat="server" Style="margin-left: 485px" Font-Bold="True" Font-Size="20px" ForeColor="darkred " margin-top="30px"></asp:Label>
     <asp:Label ID="lbl2_message" runat="server" Style="margin-left: 485px" Font-Bold="True" Font-Size="20px" ForeColor="darkred " margin-top="30px"></asp:Label>
            <div class="row txtrow">
                <div class="auto-style15">
               
                    <asp:Button ID="save" runat="server" Text="ابحث" Style="border-style: none; border-color: inherit; border-width: medium; background: gray; color: white; padding: 10px 15px; border-radius: 5px;" Width="195px" CssClass="auto-style14" Height="42px"  OnClick="SearchButton_Click" />

                </div>                     
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
