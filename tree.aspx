<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="tree.aspx.cs" Inherits="Royal_Elshrouq.tree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
    .auto-style3 {
        margin-right: 0px;
    }
    .auto-style4 {
        height: 301px;
        width: 275px;
    }
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table   style="width:100%; direction:rtl">
<tr>



  <td class="auto-style4">
    <label for="txtName">المستوى الاول</label> 
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <br />
    <br />
      <form1 id="form1" runat="server" style="width: 100%; height: 200px; ">
       
          <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="7" CssClass="auto-style3" Height="222px" Width="293px">
              <Columns>
                  <asp:BoundField DataField="GroupsID" HeaderText="id" />
                  <asp:BoundField DataField="GroupsName" HeaderText="name" />
              </Columns>
              <PagerStyle BackColor="#CCCCCC" />
          </asp:GridView>
          
         <br />
          <asp:Button ID="show1" runat="server" OnClick="show1_Click" Text="عرض" />

      <asp:Button ID="insert1" runat="server" OnClick="insert1_Click" Text="جديد" Width="57px" />
          <br />
         
          <br />
      </form1>
</td> 


  <td class="auto-style4">
    <label for="txtName">المستوى الثانى<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
      </label>  
    &nbsp;<br />
    <br />
         <div id="Divtoprint" runat="server">
 <form2 id="form2" runat="server" style="width: 100%; height: 200px; ">

  
       <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="GridView2_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" PageSize="7" CssClass="auto-style3" Height="222px" Width="293px">
           <Columns>
               <asp:BoundField DataField="GroupsID" HeaderText="id" />
               <asp:BoundField DataField="GroupsName" HeaderText="name" />
           </Columns>
           <PagerStyle BackColor="#CCCCCC" />
       </asp:GridView>
 
        <br />
       <asp:Button ID="show2" runat="server" OnClick="show2_Click" Text="عرض" />
       <asp:Button ID="print1" runat="server" OnClick="print1_Click" Text="طباعة"/>
       <br />
       <br />
   
    </form2>
                 </div>
    
</td> 



  <td class="auto-style4">
    <label for="txtName">المستوى الثالث</label> 
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
      <br />
    <br />
     <form3 style="width:100%; height:200px; background-color:antiquewhite">
       <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="GridView3_PageIndexChanging" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" PageSize="7" CssClass="auto-style3" Height="222px" Width="293px">
           <Columns>
               <asp:BoundField DataField="GroupsID" HeaderText="id" />
               <asp:BoundField DataField="GroupsName" HeaderText="name" />
           </Columns>
           <PagerStyle BackColor="#CCCCCC" />
       </asp:GridView>
         <br />
       <asp:Button ID="show3" runat="server" OnClick="show3_Click" Text="عرض" />
       <br />
       <br />
    </form3>
</td>


  <td class="auto-style4">
    <label for="txtName">المستوى الرابع</label> 
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
      <form4 style="width:100%; height:200px; background-color:antiquewhite">
       <br />
      <br />
      <br />
       <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="GridView4_PageIndexChanging" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" PageSize="7" CssClass="auto-style3" Height="222px" Width="293px">
           <Columns>
               <asp:BoundField DataField="GroupsID" HeaderText="id" />
               <asp:BoundField DataField="GroupsName" HeaderText="name" />
           </Columns>
           <PagerStyle BackColor="#CCCCCC" />
       </asp:GridView>
          <br />
       <asp:Button ID="show4" runat="server" OnClick="show4_Click" Text="عرض" />
       <br />
       <br />
    </form4>
</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>






 

