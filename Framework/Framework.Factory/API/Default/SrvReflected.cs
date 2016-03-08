// ============================================================================
// Project: Framework
// Name/Class: SrvReflected
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 08/Mar/2016
// Company: Cybermap Lta.
// Description: Reflected service implementation.
// ============================================================================

using System;
using Framework.Factory.API.Interface;
using Framework.Factory.Patterns;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Extensions;

namespace Framework.Factory.API.Default
{
    public class SrvReflected : ACommon, IReflected
    {
        public object Run(string srvName, string srvMethod, params object[] args)
        {
            //
            // Default output value.
            //

            object output = default(object);

            //
            // Get service implementation and its type.
            //

            ICommon srvImpl = Scope.Hub.GetByName<ICommon>(srvName);
            Type srvType = srvImpl.GetType();

            //
            // Find the method to run.
            //

            MethodInfo methodToRun = null;
            IEnumerable<MethodInfo> srvMethodList = srvType.GetMethods().Where(met => met.Name == srvMethod).ToList();

            srvMethodList.Apply(method =>
            {
                if (null == methodToRun)
                {
                    ParameterInfo[] parameters = method.GetParameters();

                    if (parameters.Length == args.Count())
                    {
                        int index = 0;
                        bool isTheSame = true;

                        args.Apply(arg =>
                        {
                            Type argType = arg.GetType();
                            Type methodParamType = parameters[index].ParameterType;

                            isTheSame = isTheSame && (argType.FullName == methodParamType.FullName);

                            index++;
                        });

                        methodToRun = isTheSame ? method : null;
                    }
                }
            });

            //
            // Run method if it was found!
            //

            if (methodToRun != null)
            {
                output = methodToRun.Invoke(srvImpl, args);
            }

            return output;
        }
    }
}
