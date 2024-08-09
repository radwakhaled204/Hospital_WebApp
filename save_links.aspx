<%@ Page Title="تحميل الروابط" Language="C#" MasterPageFile="~/empty.Master" AutoEventWireup="true" CodeBehind="save_links.aspx.cs" Inherits="Royal_Elshrouq.save_links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
<style>
    .table-container {
        display: flex;
        justify-content: space-between;
        width: 80%;
        margin: 0 auto;
        margin-top:25px;
    }

    table {
        border: 1px solid #ccc;
        border-radius: 5px;
        width: 48%; 
        margin-bottom: 10px;
          align-items: center;
          text-align:center;
    }

    .auto-style21 {
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        margin-top: 0px;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">

<div class="table-container">
    <table border="1">
     <tr>
       <th  colspan="2" style="color:red"> اضافه الصور والروابط الخاصه بالمستشفى</th>
     </tr>     
        
<tr>
    <th> الوصف</th>
  
    <th> ارفع الصور والروابط</th>

</tr>
<tr>
    <td> لوجو الجهة اليسرى</td>
 
    <td>  <asp:FileUpload ID="logo1" runat="server" />   </td>
    
 
</tr>
     <tr>
    <td> لوجو الجهه اليمنى</td>
 
    <td>  <asp:FileUpload ID="logo2" runat="server" />   </td>
    
 
</tr>
<tr>
    <td>صورة المستشفى</td>
   
    <td>     <asp:FileUpload ID="hos_img" runat="server" />        </td>
     

</tr>
     <tr>
    <td> رابط الفيس</td>
    
        <td> <asp:TextBox ID="lnk_f" runat="server"></asp:TextBox>  </td>
</tr>
                    <tr>
    <td> رابط لينكدان </td>
    
        <td> <asp:TextBox ID="lnk_linked" runat="server"></asp:TextBox>  </td>
</tr>
          <tr>
    <td> رابط تويتر </td>
    
        <td> <asp:TextBox ID="lnk_x" runat="server"></asp:TextBox>  </td>
</tr>
               <tr>
    <td> رابط انستجرام </td>
    
        <td> <asp:TextBox ID="lnk_inst" runat="server"></asp:TextBox>  </td>
</tr>
                                       <tr>
        <td> رابط يوتيوب </td>
        
            <td> <asp:TextBox ID="lnk_yt" runat="server"></asp:TextBox>  </td>
    </tr>
                               <tr>
        <td> رابط واتساب</td>
        
            <td> <asp:TextBox ID="lnk_whats" runat="server"></asp:TextBox>  </td>
    </tr>


   


      <tr>

    <th colspan="2" > 
        <asp:Label ID="hos_lbl" runat="server"  style="align-content: center" Font-Bold="True" ForeColor="red"></asp:Label>
                <br />
        <asp:Button ID="hos_up" runat="server"  OnClick="hos_update" Text="تخزين"  style="  width: 107px" /></th>
</tr>
        
    </table>
   
  <!---------------------------------------------------------------------------------------------------------------------->

        <table border="1" >
  <tr>
    <th colspan="2" style="color:red">اضافه الصور والروابط الخاصه بالشركة</th>
</tr>
  
    <tr>
        <th>الوصف</th>
      
        <th>   ارفع الصور والروابط </th>
    
    </tr>
    <tr>
        <td> لوجو الجهة اليسرى</td>
     
        <td>  <asp:FileUpload ID="ist_logo1" runat="server" />   </td>
        
     
    </tr>
         <tr>
        <td> لوجو الجهه اليمنى</td>
     
        <td>  <asp:FileUpload ID="ist_logo2" runat="server" />   </td>
        
     
    </tr>
    <tr>
        <td>صورة الشركه</td>
       
        <td>     <asp:FileUpload ID="ist_img" runat="server" />        </td>
         

    </tr>
         <tr>
        <td> رابط الفيس</td>
        
            <td> <asp:TextBox ID="ist_lnk_f" runat="server"></asp:TextBox>  </td>
    </tr>
                        <tr>
        <td> رابط لينكدان </td>
        
            <td> <asp:TextBox ID="ist_lnk_linked" runat="server"></asp:TextBox>  </td>
    </tr>
              <tr>
        <td> رابط تويتر </td>
        
            <td> <asp:TextBox ID="ist_lnk_x" runat="server"></asp:TextBox>  </td>
    </tr>
                   <tr>
        <td> رابط انستجرام </td>
        
            <td> <asp:TextBox ID="ist_lnk_inst" runat="server"></asp:TextBox>  </td>
    </tr>
                               <tr>
        <td> رابط يوتيوب </td>
        
            <td> <asp:TextBox ID="ist_lnk_yt" runat="server"></asp:TextBox>  </td>
    </tr>
                               <tr>
        <td> رابط واتساب</td>
        
            <td> <asp:TextBox ID="ist_lnk_whats" runat="server"></asp:TextBox>  </td>
    </tr>
       <tr>

    <th colspan="2" >
        <asp:Label ID="ist_lbl" runat="server"  style="align-content: center" Font-Bold="True" ForeColor="red"></asp:Label>
        <br />
        <asp:Button ID="ist_up" runat="server"  OnClick="ist_update" Text="تخزين"  style="  width: 107px" /></th>
</tr>
            
      

</table>
</div>
       
       
</form>
</asp:Content>
