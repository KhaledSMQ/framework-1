// ============================================================================
// Project: Framework
// Name/Class: RegexPattern
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Set of useful regular expressions.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public class RegexPattern
    {
        //
        // Alphabetic regular expression.
        //

        public const string Alpha = @"^[a-zA-Z]*$";

        //
        // Uppercase alphabetic regular expression.
        //

        public const string AlphaUpperCase = @"^[A-Z]*$";

        //
        // Lowercase Alphabetic regular expression.
        //

        public const string AlphaLowerCase = @"^[a-z]*$";

        //
        // Alphanumeric regular expression.
        //

        public const string AlphaNumeric = @"^[a-zA-Z0-9]*$";

        //
        // Alphanumeric and space regular expression.
        //

        public const string AlphaNumericSpace = @"^[a-zA-Z0-9 ]*$";

        //
        // Alphanumeric and space and dash regex.
        //

        public const string AlphaNumericSpaceDash = @"^[a-zA-Z0-9 \-]*$";

        //
        // Alphanumeric plus space, dash and underscore regex.
        //

        public const string AlphaNumericSpaceDashUnderscore = @"^[a-zA-Z0-9 \-_]*$";

        //
        // Alpha numeric plus space, dash, period and underscore regex.
        //

        public const string AlphaNumericSpaceDashUnderscorePeriod = @"^[a-zA-Z0-9\. \-_]*$";

        //
        // Latin alphabet.
        //

        public const string AlphaLatin = @"^[a-zA-Z\u00C0-\u00FF]*$";

        //
        // Number regular expression.
        //

        public const string Numeric = @"^\-?[0-9]*\.?[0-9]*$";

        //
        // Integer regular expression (with optional minus sign).
        //

        public const string Integer = @"^\-?[0-9]*$";

        // 
        // E-mail regular expression.
        //

        public const string Email = @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
        // public const string Email = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        //
        // Url regular expression.
        //

        public const string Url = @"^^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";

        //
        // Cascading style sheet class name regular expression.
        //

        public const string CssClassName = @"^([a-zA-Z0-9_]+)";

        //
        // Cascading style sheet width/heigh definition regular expression.
        //

        public const string CssWidthOrHeight = @"^auto$|^[+-]?[0-9]+\\.?([0-9]+)?(px|em|ex|%|in|cm|mm|pt|pc)?$";

        //
        // USA social security number regular expression.
        //

        public const string US_SocialSecurity = @"\d{3}[-]?\d{2}[-]?\d{4}";

        //
        // USA zip code.
        //

        public const string US_ZipCode = @"\d{5}";

        //
        // USA zip code regular expression with four digits.
        //

        public const string US_ZipCodeWithFour = @"\d{5}[-]\d{4}";

        // 
        // USA zip code regular expression with optional four digits.
        //

        public const string US_ZipCodeWithFourOptional = @"\d{5}([-]\d{4})?";

        //
        // USA phone number regular expression.
        //

        public const string US_Phone = @"\d{3}[-]?\d{3}[-]?\d{4}";
    }
}
