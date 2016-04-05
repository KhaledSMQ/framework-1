<%@ Page Title="" Language="C#" Inherits="Framework.Web.View.Page" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>[APP]</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
</head>
<body>
</body>
    <framework:Include runat="server" Folder="Client" Pattern="*.js" />
    <framework:Include runat="server" Folder="Client\fw" Pattern="*.js" />
    <framework:Include runat="server" Folder="Client\fw" Pattern="__*.js" Recursive="true" />
    <framework:Include runat="server" Folder="Client\fw\modules" Pattern="*.js" Recursive="true" />
</html>


