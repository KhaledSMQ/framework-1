// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Framework.Code.API
{
    public class SrvCompiler : ACommon, ICompiler
    {
        public void GenerateSourceCode(CodeProvider provider, string filePath, CodeCompileUnit unit)
        {
            CodeDomProvider codeDomProvider = __GetCodeDomProvider(provider);

            IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(filePath, false), "    ");

            codeDomProvider.GenerateCodeFromCompileUnit(unit, tw, new CodeGeneratorOptions());

            tw.Flush();

            tw.Close();
        }

        //
        //
        //

        private CodeDomProvider __GetCodeDomProvider(CodeProvider provider)
        {
            CodeDomProvider codeDomProvider = null;

            switch (provider)
            {
                case CodeProvider.VISUAL_BASIC:
                    codeDomProvider = CodeDomProvider.CreateProvider("VisualBasic");
                    break;
                case CodeProvider.JSCRIPT:
                    codeDomProvider = CodeDomProvider.CreateProvider("VisualBasic");
                    break;
                default:
                    codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
                    break;
            }

            return codeDomProvider;
        }
    }
}
