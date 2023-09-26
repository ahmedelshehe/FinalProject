using System.Text;

namespace FinalProject.Utilities
{
    public static class StringUtils
    {
        public static string InsertSpaceBetweenCamelCaseWords(string text)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0 && char.IsUpper(text[i]))
                {
                    builder.Append(' ');
                }
                builder.Append(text[i]);
            }
            return builder.ToString();
        }
    }
}
