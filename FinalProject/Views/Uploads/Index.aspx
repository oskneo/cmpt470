<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Imgs{
            display:block;
            max-width:100%;
            height:auto;
        }
    </style>
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" integrity="sha384-fLW2N01lMqjakBkx3l/M9EahuwpSfeNvV63J5ezn3uZzapT0u7EYsXMjQV+0En5r" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <h1>Uploading files with ASP.NET’s asp:fileupload control in c#</h1>
        <br />
        <div class="row">
            <h2>upload your image files here.</h2>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <div class="col-sm-8">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
            </div>
            <div class="col-sm-4">
                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn btn-primary btn-block" Text="Upload" />
            </div>
        </div>
        <hr />
        <div class="row">
            <asp:Repeater ID="rptImgs" runat="server">
    <ItemTemplate>
        <div class="col-sm-3">
        <asp:Image ID="img1" ImageUrl='<%#"imageUploads/" + Eval("Name") %>' CssClass="img-responsive" runat="server"/>
            </div>
    </ItemTemplate>
</asp:Repeater>

        </div>
    </div>
    </form>
    <!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>

</body>
</html>
