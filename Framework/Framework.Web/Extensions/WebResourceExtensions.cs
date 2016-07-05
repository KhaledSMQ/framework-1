// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Text;
using Framework.Core.Patterns;
using Framework.Types.Specialized;

namespace Framework.Web.Extensions
{
    public static class WebResourceExtensions
    {
        public static string GenerateHTML(this WebResource resx)
        {
            StringBuilder htmlString = new StringBuilder();

            switch (resx.Type)
            {
                case WebResource.TypeOfResource.SCRIPT:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.REMOTE:
                                {
                                    string frag = string.Empty;
                                    frag += "<script type=\"text/javascript\" src=\"" + resx.Value + "\">";
                                    frag += "<" + "/script>";
                                    htmlString.Append(frag);
                                }
                                break;
                            case WebResource.TypeOfSource.INLINE:
                                {
                                    string frag = string.Empty;
                                    frag += "<script language=\"javascript\">";
                                    frag += resx.Value;
                                    frag += "<" + "/script>";
                                    htmlString.Append(frag);
                                }
                                break;
                        }
                    }
                    break;
                case WebResource.TypeOfResource.STYLE:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.REMOTE:
                                {
                                    string frag = string.Empty;
                                    frag += "<link type='text/css' rel='stylesheet' href='" + resx.Value + "' />";
                                    htmlString.Append(frag);
                                }
                                break;
                            case WebResource.TypeOfSource.INLINE:
                                {
                                    string frag = string.Empty;
                                    frag += "<style type='text/css'>";
                                    frag += resx.Value;
                                    frag += "<" + "/style>";
                                    htmlString.Append(frag);
                                }
                                break;
                        }
                    }
                    break;
            }

            return htmlString.ToString();
        }

        public static WebResource ResolveUrl(this WebResource resx, IUrlResolverSet resolver)
        {
            string resolved = string.Empty;

            switch (resx.Type)
            {
                case WebResource.TypeOfResource.SCRIPT:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.INLINE:
                                resolved = resx.Value;
                                break;
                            case WebResource.TypeOfSource.REMOTE:
                                resolved = resolver.Resolve(resx.Value);
                                break;
                        }
                    }
                    break;
                case WebResource.TypeOfResource.STYLE:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.INLINE:                          
                                resolved = resx.Value;
                                break;
                            case WebResource.TypeOfSource.REMOTE:
                                resolved = resolver.Resolve(resx.Value);
                                break;
                        }
                    }
                    break;
            }

            resx.Value = resolved;
            return resx;
        }

        public static WebResource ResolveUrl(this WebResource resx, IUrlResolver resolver)
        {
            string resolved = string.Empty;

            switch (resx.Type)
            {
                case WebResource.TypeOfResource.SCRIPT:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.INLINE:
                                resolved = resx.Value;
                                break;
                            case WebResource.TypeOfSource.REMOTE:
                                resolved = resolver.Resolve(resx.Value);
                                break;
                        }
                    }
                    break;
                case WebResource.TypeOfResource.STYLE:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.INLINE:
                                resolved = resx.Value;
                                break;
                            case WebResource.TypeOfSource.REMOTE:
                                resolved = resolver.Resolve(resx.Value);
                                break;
                        }
                    }
                    break;
            }

            resx.Value = resolved;
            return resx;
        }
    }
}
