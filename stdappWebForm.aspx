<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stdappWebForm.aspx.cs" Inherits="Studentapp.stdappWebForm" MasterPageFile="~/School.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   <div>
       <h1>Students Detail</h1>
           <asp:Button ID="search" runat="server" Text="Search" OnClick="Search_Click" />
                    <asp:TextBox ID="Searchbox" runat="server" ></asp:TextBox>
             <br> </br>
            <asp:GridView ID="GridViewstudentlist" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
             AutoGenerateColumns="false" DataKeyNames="studId" OnSelectedIndexChanged="GridViewstudentlist_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
            <Columns>
                <asp:CommandField ShowSelectButton="true"  SelectText="Select" HeaderText="Select" />
                <asp:BoundField DataField="studID"  HeaderText="studID" />
                <asp:BoundField DataField="firstname"  HeaderText="firstname" />
                <asp:BoundField DataField="fathername"  HeaderText="fathername"  />
                <asp:BoundField DataField="grandfathername"  HeaderText="grandfathername" />
                <asp:BoundField DataField="dateofBirth"  HeaderText="dateofBirth" />
                <asp:BoundField DataField="createdDate"  HeaderText="createdDate" />
                <asp:BoundField DataField="gender"  HeaderText="gender" />          
            </Columns>
        </asp:GridView>
        <table border="1"  style="border-collapse: collapse">
        <tr>
            <td valign ="top">
                studID:<br />
                <asp:TextBox ID="txtstudID" runat="server" ReadOnly ="True" />
            </td>
            <td valign ="top">
                firstname:<br />
                <asp:TextBox ID="txtfirstname" runat="server"  />
            </td>
            <td valign ="top">
                fathername:<br />
                <asp:TextBox ID="txtfathername" runat="server"  />
            </td>
            <td valign ="top">
                grandfathername:<br />
                <asp:TextBox ID="txtgrandfathername" runat="server"  />
            </td>
            <td valign ="top" height =" ">
                dateofBirth:<br />
                <asp:TextBox ID="txtdateofBirth" runat="server"  />
                <asp:ImageButton ID="ImageButtondateofBirth" runat="server" Height="26px" ImageUrl="~/images/calendar-icon.png" OnClick="ImageButtondateofBirth_Click" Width="29px" />
                <asp:Calendar ID="dateofBirthCalendar" runat="server" OnSelectionChanged="dateofBirthCalendar_SelectionChanged"></asp:Calendar> 
            </td>
            <td valign ="top" >
                createdDate:<br />
                <asp:TextBox ID="txtcreatedDate" runat="server"  />
                <asp:ImageButton ID="ImageButtoncreatedDate" runat="server" Height="25px" ImageUrl="~/images/calendar-icon.png" OnClick="ImageButtoncreatedDate_Click" Width="31px" />
                <asp:Calendar ID="createdDateCalendar" runat="server" OnSelectionChanged="createdDateCalendar_SelectionChanged"></asp:Calendar>
             </td>

            <td valign ="top">
                gender:<br />
                <asp:TextBox ID="txtgender" runat="server"  />
            </td>
            <td valign ="top">
                 <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />

            </td>
            <td valign ="top">
                <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
            </td>
       </tr>
      </table>
    </div>
</asp:Content>
  
