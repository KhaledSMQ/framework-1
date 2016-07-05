// ============================================================================
// Project: Framework
// Name/Class: Transform
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Configuration.Model;
using Framework.Core.Extensions;
using System.Collections.Generic;

namespace Framework.Configuration.Config
{
    public static class Transforms
    {
        //
        // META
        //

        public static Meta ToMeta(this MetaElement elm)
        {
            Meta meta = new Meta();
            meta.Name = elm.Name;
            meta.Description = elm.Description;
            meta.Version = elm.Version;
            meta.Icon = elm.Icon;
            meta.Authors = elm.Authors.SplitNoEmpty(";").Map(new List<string>(), v => { return v.Trim(); });
            return meta;
        }

        //
        // STARTUP-SEQUENCE
        //

        public static IEnumerable<MethodCall> ToSequence(this MethodCallElementCollection lst)
        {
            List<MethodCall> output = new List<MethodCall>();
            foreach (MethodCallElement elm in lst) { output.Add(elm.ToSequence()); }
            return output;
        }

        public static MethodCall ToSequence(this MethodCallElement elm)
        {
            MethodCall output = new MethodCall();
            output.Service = elm.Service;
            output.Method = elm.Method;
            return output;
        }
    }
}
