<%@ Page Title="" Language="C#" Inherits="Framework.Web.UI.Page" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>fw</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
</head>
<body>
</body>
<fw:Include runat="server" Folder="Packages\3party\jquery\112" Pattern="*.js" />
<fw:Include runat="server" Folder="Packages\framework\fw" Pattern="*.js" NoCache="true" />
<fw:Include runat="server" Folder="Packages\framework\fw" Pattern="__*.js" Recursive="true" NoCache="true" />
<fw:Include runat="server" Folder="Packages\framework\fw\modules" Pattern="*.js" Recursive="true" NoCache="true" />
<script>

    fw.debug(true);


    var f = {

        model: {},

        view: {
            id: 'left',
            type: 'mvc.framework.bootstrap.col1',
            content: {
                'ph0': [
                    {
                        id: 'id0',
                        type: 'mvc.framework.bootstrap.col3',
                    }
                ]
            }

        }
    };

    var fJSON = '{"model": {}, "view": {"id": "left", "type": "mvc.framework.bootstrap.col1"}}';

    var r = fw.get('mvc.engine.fragment');

</script>
</html>


