<%@ Page Title="التسكين" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="room_detail.aspx.cs" Inherits="Royal_Elshrouq.room_detail" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function divfloorisibility() {
        var div = document.getElementById('<%= divfloor.ClientID %>');
        div.style.display = (div.style.display === 'none' || div.style.display === '') ? 'block' : 'none';
    }
    function divroomisibility() {
        var div = document.getElementById('<%= divroom.ClientID %>');
            div.style.display = (div.style.display === 'none' || div.style.display === '') ? 'block' : 'none';
    }
    function divbedisibility() {
        var div = document.getElementById('<%= divbed.ClientID %>');
                div.style.display = (div.style.display === 'none' || div.style.display === '') ? 'block' : 'none';
    }
    function divdelete_fisibility() {
        var div = document.getElementById('<%= divdelete_f.ClientID %>');
            div.style.display = (div.style.display === 'none' || div.style.display === '') ? 'block' : 'none';
    }
    function divdelete_risibility() {
        var div = document.getElementById('<%= divdelete_r.ClientID %>');
                div.style.display = (div.style.display === 'none' || div.style.display === '') ? 'block' : 'none';
    }
    function lnkBedNo_Clicked(sender) {
        var bedNo = sender.getAttribute("data-bedno");
        alert("LinkButton with bedNo " + bedNo + " clicked!");
    }
   
        function toggleFormVisibility(frameClientId) {
            var formDiv = document.getElementById(frameClientId);

            if (formDiv.style.display === 'none') {
                formDiv.style.display = 'block';
            }

      
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            Sys.Application.add_init(function () {
                PageMethods = new WebForm_PageMethods();
            });
        });

    </script>
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
}
.auto-style1 {
             width: 100%;
              text-align: center;
             
}
     .divfrm{
             height: 120px;
             margin-top: 20px;
             border-radius: 5px;
             border: 1px solid #ccc;
     }
.divfloor {
             height: 74px;
             margin-top: 20px;
             border-radius: 5px;
             border: 1px solid #ccc;
}
.auto-style3 {
             height: 74px;
             margin-top: 20px;}
.auto-style4 {
             align-items:center;
}
.auto-style6 {
             float: right;
             height: 67px;
}
.panel{

             float:left;
             border: 1px solid #ccc;
             border-radius: 5px;
}
.auto-style12 {
             float: right;
             margin-top: 10px;
            text-align:right;
}
.auto-style13 {
             float: right;

             align-items: center;
             text-align:center;
}
.auto-style15 {
             float: right;
             height: 61px;
}
.dropdown_con{
             float: right;
             
}
.dropdowngrid{
            height: 74px;
            margin-top: 30px;

}
.square {
    width: 60px;
    height: 40px;
    border: 1px solid #000;
    margin: 2px;
    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
    color:white;
}

.form {
    display: flex;
    flex-direction: column;
    min-height: 60vh; 
    width: 50%;
    border-radius: 5px;
    border: 1px solid #ccc;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    max-width: 1140px;
    min-width: 992px;
    margin-left: auto;
    margin-right: auto;
    margin-top: 10px;
    margin-bottom: 0;
    padding: 20px;
    background-color: white;
}
.form22{
    display: flex;
    flex-direction: column;
    min-height: 50vh; 
    width: 50%;
    border-radius: 5px;
    border: 1px solid #ccc;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    max-width: 1140px;
    min-width: 850px;
    margin-left: auto;
    margin-right: auto;
    margin-top: 10px;
    margin-bottom: 0;
    padding: 20px;
    background-color: white;
}
    .bottom {
        margin-top: auto;
        text-align: center;
        padding-top: 15px;
        align-items: center;

    }
     .lbl{
         margin-top: auto;
           text-align: center;
           font-size:20px;
           color:black;
     }

     </style>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form" >
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

     
     
        <h2 class="auto-style1">نظام تسجيل الغرف</h2>
<div class="auto-style3">
    <div class="auto-style6">
        <div style="display: flex; justify-content: flex-end; color: gray; font-size: 18px; float: right;">
            <asp:Button ID="insert_floor" runat="server" Text="اضافة دور" class="h_button"   AutoPostBack="true"  OnClick="inser_floor"  OnClientClick="divfloorisibility(); return false;" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="delete_f" runat="server" Text=" حذف دور" class="h_button"   AutoPostBack="true"  OnClick="delete_floor"  OnClientClick="divdelete_fisibility(); return false;" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="insert_room" runat="server" Text="اضافة غرفة" class="h_button"  OnClick="inser_room"  OnClientClick="divroomisibility(); return false;"/>&nbsp;&nbsp;&nbsp;
             <asp:Button ID="delete_r" runat="server" Text=" حذف غرفة" class="h_button"  OnClick="delete_room"  OnClientClick="divdelete_risibility(); return false;"/>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="update_bed" runat="server" Text=" تعديل عدد الاسرة" class="h_button" Width="165px"  OnClick="update_bed_no"  OnClientClick="divbedisibility(); return false;"/>&nbsp;&nbsp;&nbsp;
        </div>
    </div>
</div>
        
<div id="divfloor" class="divfloor" runat="server" Visible="false">
  <div class="auto-style6">
    <div style="display: flex; justify-content: center; align-items: center;">
      <asp:Label ID="lbl_fname" runat="server" Width="93px" CssClass="float-right">اسم الدور</asp:Label>&nbsp;
     <asp:TextBox ID="floor_name" runat="server" Width="136px" CssClass="auto-style12" ></asp:TextBox>&nbsp;&nbsp;&nbsp;
     <asp:Button ID="s_floor" runat="server" Text="اضافه" style="align-items: center;"  Width="95px" OnClick="save_floor"/>&nbsp;&nbsp;&nbsp;     
        <asp:TextBox ID="code" runat="server" Width="136px"  Visible="false"></asp:TextBox>
     </div>
  </div>
</div>

<div id="divroom" class="divfloor" runat="server" Visible="false">
    <div class="auto-style6">
 <div style="display: flex; justify-content: center; align-items: center;">
    <div class="dropdown_con">
        <div style="color: gray; font-size: 18px;" class="auto-style15">
           &nbsp;&nbsp;&nbsp;الدور <asp:DropDownList ID="floor_r" runat="server" Style=" margin-top: 10px;text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true" >
            </asp:DropDownList>
        </div>
    </div>
     <asp:Label ID="lbl_rname" runat="server" Width="93px" CssClass="auto-style13"> اسم الغرفه</asp:Label>         
    <asp:TextBox ID="r_name" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
            <asp:Label ID="lbl_bed_r_no" runat="server" Width="93px" CssClass="auto-style13"> عدد الاسرة </asp:Label>  
             <asp:TextBox ID="bed_r_no" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>&nbsp;
          <asp:Button ID="s_room" runat="server" Text="اضافه" style="align-items: center;" Width="95px" OnClick="save_room"/>&nbsp;
     <asp:TextBox ID="code_r" runat="server" Width="136px"  Visible="false"></asp:TextBox>

</div>

    </div>
</div>


<div id="divbed" class="divfloor" runat="server" Visible="false">
    <div class="auto-style6">
        <div style="display: flex; justify-content: center; align-items: center;">
            <div class="dropdown_con">
                <div style="color: gray; font-size: 18px;" class="auto-style15">
                   &nbsp;&nbsp;&nbsp;الدور&nbsp;<asp:DropDownList ID="floor_b" runat="server" Style="margin-top: 10px;text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true" OnSelectedIndexChanged="floor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="dropdown_con">
                <div style="color: gray; font-size: 18px;" class="auto-style15">
                &nbsp;&nbsp;&nbsp;الغرفة&nbsp;<asp:DropDownList ID="rooms_fill" runat="server" Style="margin-top: 10px;text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>  
            <asp:Label ID="lbl_bno" runat="server" Width="93px" CssClass="auto-style13"> عدد الاسرة </asp:Label>&nbsp;
            <asp:TextBox ID="b_bed_no" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="up_b" runat="server" Text="تعديل" style="align-items: center;" Width="95px" OnClick="upbed" />&nbsp;&nbsp;&nbsp;


        </div>
    </div>
</div>


<div id="divdelete_f" class="divfloor" runat="server" Visible="false">
    <div class="auto-style6">
        <div style="display: flex; justify-content: center; align-items: center;">
            <div class="dropdown_con">&nbsp;&nbsp; &nbsp;
                <div style="color: gray; font-size: 18px;" class="auto-style15">
                   &nbsp;&nbsp;&nbsp;الدور&nbsp; <asp:DropDownList ID="floor_d_f" runat="server" Style="margin-top: 10px;text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true" OnSelectedIndexChanged="floor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>            
            <asp:Button ID="d_f" runat="server" Text="حذف" style="align-items: center;" Width="95px" OnClick="d_floor" />&nbsp;

        </div>
    </div>
</div>

<div id="divdelete_r" class="divfloor" runat="server" Visible="false">
    <div class="auto-style6">
        <div style="display: flex; justify-content: center; align-items: center;">
            <div class="dropdown_con">
                <div style="color: gray; font-size: 18px;" class="auto-style15">
                  &nbsp;&nbsp;&nbsp;الدور&nbsp;<asp:DropDownList ID="floor_d_r" runat="server" Style="margin-top: 10px;text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true" OnSelectedIndexChanged="floor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="dropdown_con">&nbsp;&nbsp; &nbsp;
                <div style="color: gray; font-size: 18px;" class="auto-style15">
                &nbsp;&nbsp;&nbsp;الغرفة&nbsp;<asp:DropDownList ID="rooms_delete" runat="server" Style="margin-top: 10px;text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Button ID="d_r" runat="server" Text="حذف" style="align-items: center;" Width="95px" OnClick="d_room" />&nbsp;


        </div>
    </div>
</div>

<div class="dropdowngrid">
    <div class="dropdown_con">
        <div style="color: gray; font-size: 18px;" class="auto-style15">
           &nbsp;&nbsp;&nbsp;الادوار&nbsp; <asp:DropDownList ID="floor" runat="server" Style="margin-top: 2px; margin-bottom: 4px; text-align: center; box-sizing: border-box;" Width="210px" Height="38px" AutoPostBack="true" OnSelectedIndexChanged="floor_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
</div>

<div>
    <div class="row txtrow" style="float: right">
        <div style="display: flex; justify-content: flex-end; font-size: 18px; float: right">
            <asp:GridView ID="rooms" runat="server" AutoGenerateColumns="False" Style="text-align: center" Visible="False" CssClass="auto-style4" Width="304px" OnRowDataBound="rooms_RowDataBound">
                <Columns>

                    <asp:BoundField DataField="name" HeaderText=" الغرفة" />

                    <asp:BoundField DataField="code" Visible="False" HeaderText=" الكود" />
                    <asp:BoundField DataField="flo" Visible="False" HeaderText="الدور" />
                    <asp:TemplateField HeaderText="عدد الاسرة">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("bed_no") %>' CommandArgument='<%# Eval("bed_no") %>'
                                CommandName="SelectBed" OnCommand="lnkBedNo_Command" CssClass="bedNoLinkButton"></asp:LinkButton>
                            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div> 
</div>

<asp:GridView ID="all" runat="server" AutoGenerateColumns="False" Style="text-align: center" Visible="False" CssClass="auto-style4" Width="304px">
    <Columns>
        <asp:BoundField DataField="bed_no" HeaderText="عدد الاسرة" />
        <asp:BoundField DataField="name" HeaderText="الغرفة" />
        <asp:BoundField DataField="flo" HeaderText="الدور" />
    </Columns>
</asp:GridView>
<div class="lbl" id="labelContainer" runat="server">
    <asp:Label ID="lbl_2" runat="server"></asp:Label>
</div>


<div class="bottom">
    <asp:Button ID="printall" runat="server" Text="طباعة الادوار" style="margin-top: 15px; align-items: center; Width: 125px" OnClick="allprint_Click" />&nbsp;&nbsp;&nbsp;   
    <asp:Button ID="print" runat="server" Text="طباعة الدور الحالى" style="margin-top: 15px; align-items: center; Width: 140px" OnClick="btnPrint_Click" Width="150px" />&nbsp;&nbsp;&nbsp;
</div>





 </div>
        <div class="form22"  id="frame" style="display: none;" runat="server"  >
    <div id="frm" class="divfloor" runat="server">
        <div class="auto-style6">
            <div style="display: flex; justify-content: center; align-items: center;">
            </div>
        </div>
    </div>
<div class="divfrm" style="display: flex; justify-content: center; align-items: center;">


    <div style="margin: 5px;">
                <asp:Label ID="lblmob" runat="server" Width="93px" CssClass="auto-style13">رقم الهاتف</asp:Label>
        <asp:TextBox ID="mob" runat="server" AutoPostBack="true" Width="200px" Height="40px" CssClass="auto-style12"></asp:TextBox>


                <asp:Label ID="Label6" runat="server" Width="93px" CssClass="auto-style13">رقم الاستمارة</asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" AutoPostBack="true" Width="200px" Height="40px" CssClass="auto-style12"></asp:TextBox>
    </div>

   
    <div style="margin: 5px;">

         <asp:Label ID="Label4" runat="server" Width="93px" CssClass="auto-style13">اسم المريض</asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="true" Width="200px" Height="40px" CssClass="auto-style12"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Width="93px" CssClass="auto-style13">الرقم القومى</asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" AutoPostBack="true" Width="200px" Height="40px" CssClass="auto-style12"></asp:TextBox>
    </div>
</div>

  <div class="bottom">
<asp:Button ID="save" runat="server" Text="تسجيل" style="margin-top: 15px; align-items: center; Width: 95px" OnClick="save_info" />
    </div>
    </div>


     
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
 
<script src="script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
