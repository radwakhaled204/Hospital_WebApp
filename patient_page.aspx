<%@ Page Title="مستشفى الحكمة التخصصى" Language="C#" MasterPageFile="~/patient.Master" AutoEventWireup="true" CodeBehind="patient_page.aspx.cs" Inherits="Royal_Elshrouq.page_patient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>

            .label {
                color:black;
            }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
</asp:Content>
    <asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">   
    <div  runat="server" class="auto-style4" >
    <asp:Label ID="lbl2_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
</div>
</asp:Content>

