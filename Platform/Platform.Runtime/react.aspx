<%@ Page Title="" Language="C#" Inherits="Framework.Web.Controls.Page" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>react</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    <fw:Include runat="server" Folder="Packages\framework\react" Pattern="*.css" Recursive="true" />
</head>
<body>
</body>
    <fw:Include runat="server" Folder="Packages\framework\react" Pattern="*.js" Recursive="true" />
    <script src="https://fb.me/react-with-addons-15.1.0.min.js"></script>
    <script src="https://fb.me/react-dom-15.1.0.min.js"></script>

    <script>

        "use strict";

        var MarkdownEditor = React.createClass({
            displayName: "MarkdownEditor",

            getInitialState: function getInitialState() {
                return { value: 'Type some *markdown* here!' };
            },
            handleChange: function handleChange() {
                this.setState({ value: this.refs.textarea.value });
            },
            rawMarkup: function rawMarkup() {
                var md = new Remarkable();
                return { __html: md.render(this.state.value) };
            },
            render: function render() {
                return React.createElement(
                  "div",
                  { className: "MarkdownEditor" },
                  React.createElement(
                    "h3",
                    null,
                    "Input"
                  ),
                  React.createElement("textarea", {
                      onChange: this.handleChange,
                      ref: "textarea",
                      defaultValue: this.state.value
                  }),
                  React.createElement(
                    "h3",
                    null,
                    "Output"
                  ),
                  React.createElement("div", {
                      className: "content",
                      dangerouslySetInnerHTML: this.rawMarkup()
                  })
                );
            }
        });

        ReactDOM.render(React.createElement(MarkdownEditor, null), mountNode);

    </script>
</html>


