<%@ Page Title="" Language="C#" Inherits="Framework.Web.UI.Page" %>

<!DOCTYPE html>
<html data-ng-app="app01" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>angular v1</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <fw:Include runat="server" Type="STYLE" Folder="Packages\3party\angular\modules\loading-bar" Pattern="*.css" />
    <fw:Include runat="server" Type="STYLE" Folder="Packages\3party\angular\modules\local-storage" Pattern="*.css" />

    <fw:Include runat="server" Type="STYLE" Folder="Packages\framework\angular\v1\engine" Pattern="*.css" Recursive="true" />
    <fw:Include runat="server" Type="STYLE" Folder="Packages\framework\angular\v1\modules" Pattern="*.css" Recursive="true" />
</head>
<body>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.7/angular.min.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.7/angular-route.min.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.7/angular-resource.min.js"></script>

<fw:Include runat="server" Folder="Packages\3party\angular\modules\loading-bar" Pattern="*.js" />
<fw:Include runat="server" Folder="Packages\3party\angular\modules\local-storage" Pattern="*.js" />

<fw:Include runat="server" Folder="Packages\framework\angular\v1\engine" Pattern="*.js" Recursive="true" />
<fw:Include runat="server" Folder="Packages\framework\angular\v1\modules" Pattern="*.js" Recursive="true" />

<script type="text/javascript">


    var app = {

        name: 'app01',

        modules: [
            'angular-loading-bar',
            'fw',
            'fw.engine',
            'fw.auth'
        ],

        baseUrls: [],

        locales: [
            {
                key: 'pt',
                info: {
                    name: "PT"
                }
            },
            {
                key: 'en',
                info: {
                    name: 'EN'
                }
            }],

        resx: {},

        endpoints: [],

        templates: [],

        init: {
            'fw.auth.interceptor': 'processConfig',
            'fw.auth.login': 'processConfig',
            'fw.auth.login': 'fillAuthData'
        },

        pages: []
    };

    var ngApp = angular.injector(['fw.engine']).get('fw.engine.app').create(app);

</script>
</html>


