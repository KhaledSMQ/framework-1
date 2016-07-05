// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Code.API;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Web.Server.API
{
    public class SrvDummyService : ACommon, IDummyService
    {
        public void Run()
        {
            IClassGenerator srvClassGen = Scope.Hub.Get<IClassGenerator>();
            ICompiler srvCompiler = Scope.Hub.Get<ICompiler>();

            Code.Model.SimpleClass simpleClass = new Code.Model.SimpleClass()
            {
                Namespace = "Gen",
                Name = "Example",
                Properties = new List<Code.Model.Property>() {
                    new Code.Model.Property() {
                        Accessibility = Code.Model.Accessibility.PUBLIC,
                        Type = typeof(int),
                        Name = "ID"
                    },
                    new Code.Model.Property() {
                        Accessibility = Code.Model.Accessibility.PUBLIC,
                        Type = typeof(string),
                        Name = "Name"
                    }
                }
            };

            srvCompiler.GenerateSourceCode(CodeProvider.CSHARP, "C:\\Users\\joaoc\\Desktop\\example.cs", srvClassGen.GenerateSimpleClass(simpleClass));
        }
    }
}
