<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseRegDefault.aspx.cs" MasterPageFile="~/School.Master" Inherits="CourseReg.CourseRegDefault" %>

   <asp:Content ID="HeadContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

 
    <div>
<asp:GridView ID="grwCourse" runat="server" AutoGenerateColumns="False" DataKeyNames="courseNo" OnRowDeleting="OnRowDeleting"
   OnRowCommand="grw_RowCommand" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged" OnRowEditing="OnRowEditing" Height="112px" Width="761px" style="margin-right: 76px; margin-bottom: 10px" >
<Columns>
    <asp:TemplateField HeaderText="Course Number" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="cNum" runat="server" Text='<%# Eval("courseNo") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtcNum" runat="server" Text='<%# Eval("courseNo") %>'></asp:TextBox>
        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Course Name" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="cname" runat="server" Text='<%# Eval("courseName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="cnamelabl" runat="server" Text='<%# Eval("courseName") %>'></asp:TextBox>
        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Created Date" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="cdate1" runat="server" Text='<%# Eval("createdDate") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="cdatelabl" runat="server" Text='<%# Eval("createdDate") %>'></asp:TextBox>
        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
    </asp:TemplateField>


    <asp:CommandField ButtonType="Link" ShowEditButton="True" ShowSelectButton="true" ShowDeleteButton="True" ItemStyle-Width="150">

<ItemStyle Width="150px"></ItemStyle>
    </asp:CommandField>
<asp:TemplateField HeaderText="Edit buttons"><ItemTemplate>
            <asp:Button ID="btnedit" Text="Edit This Row" runat="server" CommandName="editrow" CommandArgument="<%# Container.DataItemIndex %>"/>  
        
</ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
</asp:TemplateField>

</Columns>

                <FooterStyle BackColor="White" ForeColor="#333333" BorderStyle="Groove" />
                <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="10px" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
</asp:GridView>
<table border="1" style="border-collapse: collapse">
<tr>
    <td class="auto-style2">
        Course Number:<asp:RegularExpressionValidator ID="RegularExpression" runat="server" 
             ControlToValidate="cNumber" ErrorMessage="Not a Valid course Number" ForeColor="Red"
              ValidationExpression="\w+$">
         </asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="cNumber" runat="server" Width="125px" />

    </td>
    <td style="width: 150px">
        Course Name:<br />
        <asp:TextBox ID="cName" runat="server" Width="140" />
    </td>
    <td class="auto-style1">
        Created Date:<br />
        <asp:TextBox ID="cdate" runat="server" Width="140" TextMode="Date"  />
    </td>
    <td class="auto-style3">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="savedb" />
        <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="Update" Visible="false"/>
    </td>
</tr>
</table>
    </div>
</asp:Content>