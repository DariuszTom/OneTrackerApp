using System;
using System.Text;

namespace SharedLibrary.Misc
{
    public class InputValidator
    {
        #region Contructor

        public InputValidator()
        { }

        #endregion Contructor

        #region PublicMethods

        public string CheckInputStrings(params Tuple<string, string>[] list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.Item1)) sb.AppendLine($"Input for {item.Item2} is missing");
            }
            return sb.ToString().Trim();
        }

        #endregion PublicMethods
    }
}