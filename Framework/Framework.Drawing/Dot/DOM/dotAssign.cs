
namespace Framework.Drawing.Dot.DOM
{
    public class dotAttr
    {
        /// <summary>
        /// Name for attribute
        /// </summary>
        public string Name
        {
            get { return __Name; }
            set { __Name = value; }
        }

        /// <summary>
        /// Value of attribute
        /// </summary>
        public string Value
        {
            get { return __Value; }
            set { __Value = value; }
        }

        public dotAttr(string left, string right)
        {
            Name = left;
            Value = right;
        }

        // internal storage for public properties
        private string __Name = string.Empty;
        private string __Value = string.Empty;
    }
}
