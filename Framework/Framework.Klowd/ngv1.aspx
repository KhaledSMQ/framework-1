<%@ Page Title="" Language="C#" Inherits="Framework.Web.View.Page" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>angular v1</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    <framework:Include runat="server" Folder="Packages\framework\angular\v1\engine" Pattern="*.css" Recursive="true" />
    <framework:Include runat="server" Folder="Packages\framework\angular\v1\modules" Pattern="*.css" Recursive="true"/>
</head>
<body>
</body>
    <framework:Include runat="server" Folder="Packages\framework\angular\v1\engine" Pattern="*.js" Recursive="true" />
    <framework:Include runat="server" Folder="Packages\framework\angular\v1\modules" Pattern="*.js" Recursive="true"/>
</html>


