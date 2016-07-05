// ============================================================================
// Project: Framework
// Name/Class: Parsing
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Parsing utilities.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Globalization;
using Framework.Core.Extensions;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Engines
{
    public static class Parsing
    {
        public static dRect ParseRectD(string input, CultureInfo cult)
        {
            dRect shape = new dRect();
            string[] parcels = input.SplitNoEmpty(";");
            if (parcels.Length == 4)
            {
                foreach (string parcel in parcels)
                {
                    string[] prop = parcel.SplitNoEmpty(":");
                    if (prop.Length == 2)
                    {
                        string name = prop[0];
                        string value = prop[1];

                        // parse the property value.
                        double val = value.ParseRequiredValue_Double(cult);

                        switch (name.ToLower())
                        {
                            case "x": shape.X = val; break;
                            case "y": shape.Y = val; break;
                            case "w": shape.W = val; break;
                            case "h": shape.H = val; break;
                            default:
                                throw new Exception("invalid rectangle definition, invalid property '" + name + "'");
                        }
                    }
                    else
                    {
                        throw new Exception("invalid rectangle definition, invalid property '" + parcel + "'");
                    }
                }
            }
            else
            {
                throw new Exception("invalid rectangle definition! '" + input + "'");
            }

            return shape;
        }
    }
}
