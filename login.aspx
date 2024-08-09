<%@ Page Title="تسجيل دخول" Language="C#" MasterPageFile="~/master1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Royal_Elshrouq._interface1" %>

<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    <style>
        .contner {
            display: flex;
            flex-direction: column;
            align-items: center;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-top: 5px;
            margin-bottom: 0px;
            margin: 0 auto;
            width: 41%;
            height: 450px;
        }

        .column.middle {
            width:55%;
            text-align: center;
            margin-bottom: 0px; 
            height: 400px;
        }


        .auto-style18 {
            width: 100%;
        }

        .txtrow {
            display: flex;
            justify-content: space-between;
            align-items: center;          
            width: 100%;
        }

        .txtrow .label {
            font-size: 16px;
            color: black;
            text-align:center;
            display: flex;
            align-items: center;
            width: 100%;
        }

        .txtrow input[type="text"],
        .txtrow input[type="password"] {
            width: 100%;
          
            font-size: 18px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }



    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contner">
        <div class="column middle">
            <h4 class="text-center">تسجيل دخول</h4>
            <div class="form-check form-check-inline auto-style18">
                <asp:RadioButton ID="employee" runat="server" GroupName="patient" Text="" CssClass="form-check-input" />
                <label class="form-check-label">موظف</label>
                <asp:RadioButton ID="doctor" runat="server" GroupName="patient" Text="" CssClass="form-check-input" />
                <label class="form-check-label">طبيب</label>
                <asp:RadioButton ID="patient" runat="server" GroupName="patient" AutoPostBack="true" Checked="true" OnCheckedChanged="patient_checkedchange" Text="" CssClass="form-check-input" />
                <label class="form-check-label">مريض</label>
                <asp:RadioButton ID="user" runat="server" GroupName="patient" AutoPostBack="true" OnCheckedChanged="user_checkedchange" Text="" CssClass="form-check-input" />
                <label class="form-check-label">مستخدم</label>
            </div>
            <br />
             <br />
            <div class="form-group txtrow">
                <asp:Label ID="lblphone" runat="server" class="label">رقم الهاتف</asp:Label>
                <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
            </div>
            <div class="form-group txtrow">
                <asp:Label ID="lblcode" runat="server" class="label">كود المستخدم</asp:Label>
                <asp:TextBox ID="txtcode" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
            </div>
            <div class="form-group txtrow">
                <asp:Label ID="lblpass" runat="server" class="label">كلمة المرور</asp:Label>
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="form-control" Width="240px"></asp:TextBox>
            </div>
            <div class=" label ">
                <asp:Label ID="lbl_message" runat="server" class="text-center" Font-Bold="True" ForeColor="black"></asp:Label>
            </div>
            <div class="form-group txtrow text-center">
                <asp:Button ID="login" runat="server" Text="تسجيل دخول" OnClick="Sign_up_Click" CssClass="btn btn-primary"  Width="125px" style="background-color: #41AB88;"/>
                <asp:Button ID="signup" runat="server" Text="مستخدم جديد" OnClick="signup_Click" CssClass="btn btn-secondary"  Width="125px" style="background-color: #41AB88;"/>
            </div>

        </div>
    </div>
</asp:Content>






