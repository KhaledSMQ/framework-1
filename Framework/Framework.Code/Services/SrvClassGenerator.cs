// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Code.Model;
using Framework.Core.Patterns;
using System.CodeDom;
using Framework.Core.Extensions;
using Framework.Code.Api;

namespace Framework.Code.Services
{
    public class SrvClassGenerator : ACommon, IClassGenerator
    {
        public CodeCompileUnit GenerateSimpleClass(SimpleClass classSpec)
        {
            //
            // Compilation unit.
            //

            CodeCompileUnit unit = new CodeCompileUnit();

            //
            // Namespace
            //

            CodeNamespace nameSpace = new CodeNamespace(classSpec.Namespace);
            unit.Namespaces.Add(nameSpace);

            //
            // Usings
            //

            nameSpace.Imports.Add(new CodeNamespaceImport("System"));

            //
            // Class declaration.
            //

            CodeTypeDeclaration classDecl = new CodeTypeDeclaration(classSpec.Name);
            nameSpace.Types.Add(classDecl);

            //
            // Properties
            //

            classSpec.Properties.Apply(property => 
            {                
                CodeMemberProperty propDecl = new CodeMemberProperty();
                propDecl.Type = new CodeTypeReference(property.Type);
                propDecl.Name = property.Name;
                propDecl.HasGet = true;
                propDecl.HasSet = true;

                classDecl.Members.Add(propDecl);
            });

            return unit;
        }
    }
}
