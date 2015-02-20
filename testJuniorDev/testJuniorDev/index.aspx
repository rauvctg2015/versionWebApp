<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="testJuniorDev.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TestJunorDev</title>
</head>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.3/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
<script src="http://code.jquery.com/ui/1.11.3/jquery-ui.js"></script>

<script src="js/jquery.js" type="text/javascript"></script>
     <script type="text/javascript">
         function openDialog() {
             $("#divDialogForm").dialog({
                 modal: true,
                 width: "20%",
                 autoOpen: false,
                 buttons: {
                     "OK": function () {
                         $(this).dialog('close');
                     }
                 }
             });
             $("#divDialogForm").dialog('open');
             $('#divDialogForm').parent().appendTo($("form:first"));
         }
</script>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblTitle" runat="server" Text="Choose a File (txt) : "></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br /><br />
    
    &nbsp;<asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
            Text="Upload File" />
    
        <br />
        <br />
        FileName:
        <asp:Label ID="lblFileName" runat="server"></asp:Label><br /><br />
        <br /><br />
    
    <div id="divDialogForm" style="display:;">
    <asp:Label ID="lblTitleContent" runat="server" Text="File Content"></asp:Label><br /><br />
        <asp:TextBox TextMode="MultiLine" ID="txtContent"  ReadOnly="true"
            runat="server" Height="174px" Width="274px"></asp:TextBox>
    </div>
    </div>
    </form>
</body>
</html>
