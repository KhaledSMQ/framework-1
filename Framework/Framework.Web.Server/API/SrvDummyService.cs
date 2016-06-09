// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
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
                    new Code.Model.Property() { Type = new Code.Model.Type() { Name = "int" }, Name = "ID" },
                    new Code.Model.Property() { Type = new Code.Model.Type() { Name = "string" }, Name = "Name" }
                }
            };

            srvCompiler.GenerateSourceCode(CodeProvider.CSHARP, "C:\\Users\\joaoc\\Desktop\\example.cs", srvClassGen.GenerateSimpleClass(simpleClass));
        }
    }
}
