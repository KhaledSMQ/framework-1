// ============================================================================
// Project: Framework
// Name/Class: StringHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic string manipulation methods.
// ============================================================================                    

using Framework.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Core.Helpers
{
    public class StringHelper
    {
        //
        // Read all the lines in the string.
        // Return a list of lines from the input string.
        // @param text The input text.
        // @return The list of lines in the supplied text.
        //

        public static IList<string> ReadLines(string text)
        {
            //
            // Check for empty and return empty list.
            //

            if (string.IsNullOrEmpty(text))
            {
                return new List<string>();
            }

            StringReader reader = new StringReader(text);
            string currentLine = reader.ReadLine();
            IList<string> lines = new List<string>();

            // 
            // Read all lines and add them to the
            // return list.
            //

            while (currentLine.IsNotNull())
            {
                lines.Add(currentLine);
                currentLine = reader.ReadLine();
            }

            return lines;
        }

        //
        // Get delimited chars from a string.
        //

        public static string[] GetDelimitedChars(string rawText, string excludeText, char delimiter)
        {
            int indexOfDelimitedData = rawText.IndexOf(excludeText);
            string delimitedData = rawText.Substring(indexOfDelimitedData + excludeText.Length);
            string[] separatedChars = delimitedData.Split(delimiter);
            return separatedChars;
        }

        //
        // Truncates the string.
        //

        public static string Truncate(string txt, int maxChars)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return txt;
            }

            if (txt.Length <= maxChars)
            {
                return txt;
            }

            return txt.Substring(0, maxChars);
        }


        //
        // Truncate the text supplied by number of characters specified by 
        // the maxChars parameter and then appends the suffix.
        //

        public static string TruncateWithText(string txt, int maxChars, string suffix)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return txt;
            }

            if (txt.Length <= maxChars)
            {
                return txt;
            }

            // 
            // Now do the truncate and more.
            //

            string partial = txt.Substring(0, maxChars);

            return partial + suffix;
        }


        //
        // Join string enumeration items.
        // Return the joined list of items as a string.
        //

        public static string Join(IList<string> items, string delimeter)
        {
            string joined = "";
            int ndx;

            for (ndx = 0; ndx < items.Count - 2; ndx++)
            {
                joined += items[ndx] + delimeter;
            }

            joined += items[ndx];

            return joined;
        }

        //
        // If input string is null, return the empty string,
        // if not then returns the original string.
        //

        public static string GetOriginalOrEmptyString(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            return text;
        }

        //
        // Returns the defaultval if the val string is null or empty.
        // Returns the val string otherwise.
        //

        public static string GetDefaultStringIfEmpty(string val, string defaultVal)
        {
            if (string.IsNullOrEmpty(val)) return defaultVal;

            return val;
        }

        /// <summary>
        /// Convert the word(s) in the sentence to sentence case.
        /// UPPER = Upper
        /// lower = Lower
        /// MiXEd = Mixed
        /// </summary>
        /// <param name="s">Sentence.</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <returns>Original string as sentence case.</returns>
        public static string ConvertToSentanceCase(string s, char delimiter)
        {
            // Check null/empty
            if (string.IsNullOrEmpty(s))
                return s;

            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return s;

            // Only 1 token
            if (s.IndexOf(delimiter) < 0)
            {
                s = s.ToLower();
                s = s[0].ToString().ToUpper() + s.Substring(1);
                return s;
            }

            // More than 1 token.
            string[] tokens = s.Split(delimiter);
            StringBuilder buffer = new StringBuilder();

            foreach (string token in tokens)
            {
                string currentToken = token.ToLower();
                currentToken = currentToken[0].ToString().ToUpper() + currentToken.Substring(1);
                buffer.Append(currentToken + delimiter);
            }

            s = buffer.ToString();
            return s.TrimEnd(delimiter);
        }


        /// <summary>
        /// Get the index of a spacer ( space" " or newline )
        /// </summary>
        /// <param name="txt">Text to look into.</param>
        /// <param name="currentPosition">Starting position to start looking after.</param>
        /// <param name="isNewLine">True if a new line is found instead of a space.</param>
        /// <returns>Index of spacer.</returns>
        public static int GetIndexOfSpacer(string txt, int currentPosition, ref bool isNewLine)
        {
            // Take the first spacer that you find. it could be eithr
            // space or newline, if space is before the newline take space
            // otherwise newline.            
            int ndxSpace = txt.IndexOf(" ", currentPosition);
            int ndxNewLine = txt.IndexOf(Environment.NewLine, currentPosition);
            bool hasSpace = ndxSpace > -1;
            bool hasNewLine = ndxNewLine > -1;
            isNewLine = false;

            // Found both space and newline.
            if (hasSpace && hasNewLine)
            {
                if (ndxSpace < ndxNewLine) { return ndxSpace; }
                isNewLine = true;
                return ndxNewLine;
            }

            // Found space only.
            if (hasSpace && !hasNewLine) { return ndxSpace; }

            // Found newline only.
            if (!hasSpace && hasNewLine) { isNewLine = true; return ndxNewLine; }

            // no space or newline.
            return -1;
        }

        //
        // Convert boolean value to "Yes" or "No"
        //

        public static string ConvertBoolToYesNo(bool b)
        {
            return ConvertBoolToString(b, "Yes", "No");
        }

        //
        // Convert boolean value to a true string value or
        // false string value. Takes the boolean, checks it
        // and returns the appropriate string value.
        //

        public static string ConvertBoolToString(bool b, string trueValue, string falseValue)
        {
            if (b) { return trueValue; }

            return falseValue;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>Converted string.</returns>
        public static string ConvertToString(object[] args)
        {
            if (args == null || args.Length == 0)
                return string.Empty;

            StringBuilder buffer = new StringBuilder();
            foreach (object arg in args)
            {
                if (arg.IsNotNull())
                    buffer.Append(arg.ToString());
            }
            return buffer.ToString();
        }


        /// <summary>
        /// Convert to delimited text to a dictionary.
        /// </summary>
        /// <param name="delimitedText">"1,2,3,4,5"</param>
        /// <param name="delimeter">','</param>
        /// <returns>Dictionary with delimited text and tokens.</returns>
        public static IDictionary<string, string> ToMap(string delimitedText, char delimeter)
        {
            IDictionary<string, string> items = new Dictionary<string, string>();
            string[] tokens = delimitedText.Split(delimeter);

            // Check
            if (tokens == null) return new Dictionary<string, string>(items);

            foreach (string token in tokens)
            {
                items[token] = token;
            }
            return new Dictionary<string, string>(items);
        }


        /// <summary>
        /// Map a set of keyvalue pairs to a dictionary.
        /// </summary>
        /// <param name="delimitedText">e.g. "city=Queens, state=Ny, zipcode=12345, country=usa"</param>
        /// <param name="keyValuePairDelimiter">","</param>
        /// <param name="keyValueDelimeter">"="</param>
        /// <param name="makeKeysCaseSensitive">Flag to make the keys case insensitive, which
        /// converts the keys to lowercase if set to true.</param>
        /// <param name="trimValues">Flag to trim the values in the key-value pairs.</param>
        /// <returns>Dictionary with text and tokens.</returns>
        public static IDictionary<string, string> ToMap(string delimitedText, char keyValuePairDelimiter, char keyValueDelimeter, bool makeKeysCaseSensitive, bool trimValues)
        {
            IDictionary<string, string> map = new Dictionary<string, string>();
            string[] tokens = delimitedText.Split(keyValuePairDelimiter);

            // Check
            if (tokens == null) return map;

            // Each pair
            foreach (string token in tokens)
            {
                // Split city=Queens to "city", "queens"
                string[] pair = token.Split(keyValueDelimeter);

                string key = pair[0];
                string value = pair[1];

                if (makeKeysCaseSensitive)
                {
                    key = key.ToLower();
                }
                if (trimValues)
                {
                    key = key.Trim();
                    value = value.Trim();
                }
                map[key] = value;
            }
            return map;
        }


        /// <summary>
        /// Parses a delimited list of items into a string[].
        /// </summary>
        /// <param name="delimitedText">"1,2,3,4,5,6"</param>
        /// <param name="delimeter">','</param>
        /// <returns>String array with list of items in string.</returns>
        public static string[] ToStringArray(string delimitedText, char delimeter)
        {
            if (string.IsNullOrEmpty(delimitedText))
                return null;

            string[] tokens = delimitedText.Split(delimeter);
            return tokens;
        }


        //
        // Substitute the placeholders ${name} where name is the key in subsitutions dictionary
        // and replace it with the value associated with the key.
        // Returns a new string with the keys instatiated with the corresponding values.
        //

        public static string Substitute(IDictionary<string, string> subsitutions, string contentPlaceholders)
        {
            if (string.IsNullOrEmpty(contentPlaceholders))
            {
                return contentPlaceholders;
            }

            if (subsitutions == null || subsitutions.Count == 0)
            {
                return contentPlaceholders;
            }

            string replacedValues = contentPlaceholders;
            subsitutions.Apply<KeyValuePair<string, string>>(kv => replacedValues = replacedValues.Replace("${" + kv.Key + "}", kv.Value));

            return replacedValues;
        }


        //
        // Substitute parameters in an input text in the format ${name} with another value.
        // This value is obtained with a call to an external function. This external function
        // returns the value to substitute based on the input name from string.
        // Assumes the substitutor is a valid function reference.
        //

        public static string Substitute(string input, Func<string, string> substitutor, string pattern = @"(?<name>\$\{.+?\})")
        {
            //
            // If input string is null or empty, then 
            // there is nothing to substitute.
            //

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //
            // Initialize return buffer and matcher.
            //

            var buffer = new StringBuilder();
            var matches = Regex.Matches(input, pattern);

            //
            // Nothing to match? return the original string.
            //

            if (matches.Count == 0)
            {
                return input;
            }

            //
            // Perform the substitution. Traverse the string to 
            // find the matching placeholders.
            //

            int lastIndex = 0;

            Match match = null;

            for (int ndx = 0; ndx < matches.Count; ndx++)
            {
                match = matches[ndx];

                //
                // Extract the name/key to substitute.
                //

                var name = match.Value.Substring(2, match.Value.Length - 3);

                //
                // Call the function handle to substitute the value.
                //

                var replacement = substitutor(name);

                // 
                // Append to buffer remaining text not including the variable.
                //

                if (match.Index != 0)
                {
                    var length = match.Index - lastIndex;
                    var outside = input.Substring(lastIndex, length);
                    buffer.Append(outside);
                }

                //
                // Add the replacement text.
                //

                lastIndex = match.Index + match.Length;
                buffer.Append(replacement);
            }

            //
            // Add trailing text to result buffer.
            //

            if (match.Index + match.Length < input.Length)
            {
                var lastcontent = input.Substring(match.Index + match.Length);
                buffer.Append(lastcontent);
            }

            //
            // Return buffer as a string.
            //

            return buffer.ToString();
        }


        /// <summary>
        /// Finds the maximum length of a key and padd all the rest of the keys to be 
        /// the same fixed length, and calls the delegate supplied.
        /// </summary>
        /// <param name="keyValues">The key value pairs.</param>
        /// <param name="extraPadding">Additional number of chars to pad to the keys.</param>
        /// <param name="printer">The delegate to call to print to.</param>
        public static void DoFixedLengthPrinting(IDictionary keyValues, int extraPadding, Action<string, object> printer)
        {
            // Get the length of the longest named argument.
            int maxLength = 0;
            foreach (DictionaryEntry entry in keyValues)
            {
                int keyLen = ((string)entry.Key).Length;
                if (keyLen > maxLength)
                    maxLength = keyLen;
            }
            maxLength += extraPadding;

            // Iterate through all the keys and build a fixed length key.
            // e.g. if key is 4 chars and maxLength is 6, add 2 chars using space(' ').
            foreach (DictionaryEntry entry in keyValues)
            {
                string newKeyWithPadding = GetFixedLengthString((string)entry.Key, maxLength, " ");
                printer(newKeyWithPadding, entry.Value);
            }
        }


        /// <summary>
        /// Builds a fixed length string with the maxChars provided.
        /// </summary>
        /// <param name="text">Current string to start with.</param>
        /// <param name="maxChars">Maximum number of characters.</param>
        /// <param name="paddingChar">Padding character.</param>
        /// <returns>Final created string.</returns>
        public static string GetFixedLengthString(string text, int maxChars, string paddingChar)
        {
            int leftOver = maxChars - text.Length;
            string finalText = text;
            for (int ndx = 0; ndx < leftOver; ndx++)
                finalText += paddingChar;
            return finalText;
        }

        /// <summary>
        /// Build a string ou of another string, repeating the latter a number of
        /// times. If the supplied number of times is zero or less, this will return
        /// the empty string. If supplied string is null, then the empty string is 
        /// returned.
        /// </summary>
        /// <param name="strToRepeat">the string to repeat, must not be null</param>
        /// <param name="num">the number of times to represt the string</param>
        /// <returns>a new string, with the supplied string repeat the supplied number of times</returns>
        public static string Repeat(string strToRepeat, int num)
        {
            string str = string.Empty;
            if (num > 0)
            {
                if (!string.IsNullOrEmpty(strToRepeat))
                {
                    for (int i = 0; i < num; i++)
                    {
                        str += strToRepeat;
                    }
                }
            }
            return str;
        }

        #region LineSeparator Conversions
        /// <summary>
        /// A liberal list of line breaking characters used in unicode. Typically,
        /// LF and CR are the only characters supported in C#.
        /// </summary>
        public static readonly char[] LineBreakingCharacters = new char[]
        {
            '\x000a', // LF \n
            '\x000d', // CR \r
            '\x000c', // FF (form feed)
            '\x2028', // LS (unicode line separator)
            '\x2029', // paragraph separator
            '\x0085', // NEL (next line)
        };

        /// <summary>
        /// DOS/Windows style line breaks (CR+LF)
        /// </summary>
        public static readonly char[] DosLineSeparator = { '\x000d', '\x000a' };


        /// <summary>
        /// Unix style line breaks (LF)
        /// </summary>
        public static readonly char[] UnixLineSeparator = { '\x000a' };


        /// <summary>
        /// Commodore, TRS-80, Apple II, Apple MacOS9 style line breaks (CR)
        /// </summary>
        public static readonly char[] MacOs9Separator = { '\x000d' };


        /// <summary>
        /// Unicode line separator - not widely supported
        /// </summary>
        public static readonly char[] UnicodeSeparator = { '\x2028' };


        /// <summary>
        /// Converts from a liberal list of unicode line separators to the
        /// specified line separator.
        /// </summary>
        /// <param name="reader">TextReader to read from</param>
        /// <param name="writer">TextReader to write to</param>
        /// <param name="separator">Line break separator.</param>
        public static void ConvertLineSeparators(TextReader reader, TextWriter writer, char[] separator)
        {
            for (var c = reader.Read(); c != -1; c = reader.Read())
            {
                // One new line
                if (LineBreakingCharacters.Contains((char)c))
                {
                    // If a windows style new line, skip the next char
                    if (c == '\r' && reader.Peek() == '\n')
                    {
                        reader.Read();
                    }

                    writer.Write(separator);
                    continue;
                }
                writer.Write((char)c);
            }
        }

        /// <summary>
        /// Converts from a liberal list of unicode line separators to the
        /// specified line separator.
        /// </summary>
        /// <example>
        /// // Convert line breaks to current environment's default
        /// var text = "blah blah...";
        /// ConvertLineSeparators(text, Environment.NewLine.ToCharArray());
        /// </example>
        /// <param name="text">Source text</param>
        /// <param name="separator">Line break separator.</param>
        /// <returns>String with normalized line separators</returns>
        public static String ConvertLineSeparators(String text, char[] separator)
        {
            var reader = new StringReader(text);
            var writer = new StringWriter();
            ConvertLineSeparators(reader, writer, separator);
            return writer.ToString();
        }

        #endregion

        public static StringWriter CreateStringWriter(int capacity)
        {
            StringBuilder sb = new StringBuilder(capacity);
            StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture);

            return sw;
        }

        public static string ToCharAsUnicode(char c)
        {
            char h1 = MathHelper.IntToHex((c >> 12) & '\x000f');
            char h2 = MathHelper.IntToHex((c >> 8) & '\x000f');
            char h3 = MathHelper.IntToHex((c >> 4) & '\x000f');
            char h4 = MathHelper.IntToHex(c & '\x000f');

            return new string(new[] { '\\', 'u', h1, h2, h3, h4 });
        }

        public static int? GetLength(string value)
        {
            if (value == null)
                return null;
            else
                return value.Length;
        }

        /// <summary>
        /// Left of the first occurance of c
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="c">Return everything to the left of this character.</param>
        /// <returns>String to the left of c, or the entire string.</returns>
        public static string LeftOf(string src, char c)
        {
            string ret = src;

            int idx = src.IndexOf(c);

            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }

            return ret;
        }

        /// <summary>
        /// Left of the n'th occurance of c.
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="c">Return everything to the left n'th occurance of this character.</param>
        /// <param name="n">The occurance.</param>
        /// <returns>String to the left of c, or the entire string if not found or n is 0.</returns>
        public static string LeftOf(string src, char c, int n)
        {
            string ret = src;
            int idx = -1;

            while (n > 0)
            {
                idx = src.IndexOf(c, idx + 1);

                if (idx == -1)
                {
                    break;
                }

                --n;
            }

            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }

            return ret;
        }

        /// <summary>
        /// Right of the first occurance of c
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="c">The search char.</param>
        /// <returns>Returns everything to the right of c, or an empty string if c is not found.</returns>
        public static string RightOf(string src, char c)
        {
            string ret = String.Empty;
            int idx = src.IndexOf(c);

            if (idx != -1)
            {
                ret = src.Substring(idx + 1);
            }

            return ret;
        }

        /// <summary>
        /// Returns all the text to the right of the specified string.
        /// Returns an empty string if the substring is not found.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="substr"></param>
        /// <returns></returns>
        public static string RightOf(string src, string substr)
        {
            string ret = String.Empty;
            int idx = src.IndexOf(substr);

            if (idx != -1)
            {
                ret = src.Substring(idx + substr.Length);
            }

            return ret;
        }

        /// <summary>
        /// Returns the last character in the string.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static char LastChar(string src)
        {
            return src[src.Length - 1];
        }

        /// <summary>
        /// Returns all but the last character of the source.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string RemoveLastChar(string src)
        {
            return src.Substring(0, src.Length - 1);
        }

        /// <summary>
        /// Right of the n'th occurance of c
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="c">The search char.</param>
        /// <param name="n">The occurance.</param>
        /// <returns>Returns everything to the right of c, or an empty string if c is not found.</returns>
        public static string RightOf(string src, char c, int n)
        {
            string ret = String.Empty;
            int idx = -1;

            while (n > 0)
            {
                idx = src.IndexOf(c, idx + 1);

                if (idx == -1)
                {
                    break;
                }

                --n;
            }

            if (idx != -1)
            {
                ret = src.Substring(idx + 1);
            }

            return ret;
        }

        /// <summary>
        /// Returns everything to the left of the righmost char c.
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="c">The search char.</param>
        /// <returns>Everything to the left of the rightmost char c, or the entire string.</returns>
        public static string LeftOfRightmostOf(string src, char c)
        {
            string ret = src;
            int idx = src.LastIndexOf(c);

            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }

            return ret;
        }

        /// <summary>
        /// Returns everything to the right of the rightmost char c.
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="c">The seach char.</param>
        /// <returns>Returns everything to the right of the rightmost search char, or an empty string.</returns>
        public static string RightOfRightmostOf(string src, char c)
        {
            string ret = String.Empty;
            int idx = src.LastIndexOf(c);

            if (idx != -1)
            {
                ret = src.Substring(idx + 1);
            }

            return ret;
        }

        /// <summary>
        /// Returns everything between the start and end chars, exclusive.
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="start">The first char to find.</param>
        /// <param name="end">The end char to find.</param>
        /// <returns>The string between the start and stop chars, or an empty string if not found.</returns>
        public static string Between(string src, char start, char end)
        {
            string ret = String.Empty;
            int idxStart = src.IndexOf(start);

            if (idxStart != -1)
            {
                ++idxStart;
                int idxEnd = src.IndexOf(end, idxStart);

                if (idxEnd != -1)
                {
                    ret = src.Substring(idxStart, idxEnd - idxStart);
                }
            }

            return ret;
        }

        public static string Between(string src, string start, string end)
        {
            string ret = String.Empty;
            int idxStart = src.IndexOf(start);

            if (idxStart != -1)
            {
                idxStart += start.Length;
                int idxEnd = src.IndexOf(end, idxStart);

                if (idxEnd != -1)
                {
                    ret = src.Substring(idxStart, idxEnd - idxStart);
                }
            }

            return ret;
        }

        public static string BetweenEnds(string src, char start, char end)
        {
            string ret = String.Empty;
            int idxStart = src.IndexOf(start);

            if (idxStart != -1)
            {
                ++idxStart;
                int idxEnd = src.LastIndexOf(end);

                if (idxEnd != -1)
                {
                    ret = src.Substring(idxStart, idxEnd - idxStart);
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns the number of occurances of "find".
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <param name="find">The search char.</param>
        /// <returns>The # of times the char occurs in the search string.</returns>
        public static int Count(string src, char find)
        {
            int ret = 0;

            foreach (char s in src)
            {
                if (s == find)
                {
                    ++ret;
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns the rightmost char in src.
        /// </summary>
        /// <param name="src">The source string.</param>
        /// <returns>The rightmost char, or '\0' if the source has zero length.</returns>
        public static char Rightmost(string src)
        {
            char c = '\0';

            if (src.Length > 0)
            {
                c = src[src.Length - 1];
            }

            return c;
        }

        public static bool BeginsWith(string src, char c)
        {
            bool ret = false;

            if (src.Length > 0)
            {
                ret = src[0] == c;
            }

            return ret;
        }

        public static bool EndsWith(string src, char c)
        {
            bool ret = false;

            if (src.Length > 0)
            {
                ret = src[src.Length - 1] == c;
            }

            return ret;
        }

        public static string EmptyStringAsNull(string src)
        {
            string ret = src;

            if (ret == String.Empty)
            {
                ret = null;
            }

            return ret;
        }

        public static string NullAsEmptyString(string src)
        {
            string ret = src;

            if (ret == null)
            {
                ret = String.Empty;
            }

            return ret;
        }

        public static bool IsNullOrEmpty(string src)
        {
            return ((src == null) || (src == String.Empty));
        }

        // Read about MD5 here: http://en.wikipedia.org/wiki/MD5
        public static string Hash(string src)
        {
            HashAlgorithm hashProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(src);
            byte[] encoded = hashProvider.ComputeHash(bytes);
            return Convert.ToBase64String(encoded);
        }

        /// <summary>
        /// Returns a camelcase string, where the first character is lowercase.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string CamelCase(string src)
        {
            return src[0].ToString().ToLower() + src.Substring(1).ToLower();
        }

        /// <summary>
        /// Returns a Pascalcase string, where the first character is uppercase.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string PascalCase(string src)
        {
            string ret = String.Empty;

            if (!String.IsNullOrEmpty(src))
            {
                ret = src[0].ToString().ToUpper() + src.Substring(1).ToLower();
            }

            return ret;
        }

        /// <summary>
        /// Returns a Pascal-cased string, given a string with words separated by spaces.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string PascalCaseWords(string src)
        {
            StringBuilder sb = new StringBuilder();
            string[] s = src.Split(' ');
            string more = String.Empty;

            foreach (string s1 in s)
            {
                sb.Append(more);
                sb.Append(PascalCase(s1));
                more = " ";
            }

            return sb.ToString();
        }

        public static string SeparateCamelCase(string src)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Char.ToUpper(src[0]));

            for (int i = 1; i < src.Length; i++)
            {
                char c = src[i];

                if (Char.IsUpper(c))
                {
                    sb.Append(' ');
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        public static string[] Split(string source, char delimeter, char quoteChar)
        {
            List<string> retArray = new List<string>();
            int start = 0, end = 0;
            bool insideField = false;

            for (end = 0; end < source.Length; end++)
            {
                if (source[end] == quoteChar)
                {
                    insideField = !insideField;
                }
                else if (!insideField && source[end] == delimeter)
                {
                    retArray.Add(source.Substring(start, end - start));
                    start = end + 1;
                }
            }

            retArray.Add(source.Substring(start));

            return retArray.ToArray();
        }
    }
}
