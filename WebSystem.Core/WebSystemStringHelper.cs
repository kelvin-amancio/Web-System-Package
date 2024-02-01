using System.Text;

namespace WebSystem.Core
{
    public static class WebSystemStringHelper
    {
        public static string? ClearCharacters(string value, params char[] characters)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder vb = new StringBuilder();

            foreach (var val in value)
            {
                bool clear = true;

                for (var i = 0; i < characters.Length; i++)
                {
                    if (characters[i] == val)
                    {
                        clear = false;
                        break;
                    }
                }

                if (clear)
                    vb.Append(val);
            }
            return vb.ToString().Trim();
        }
    }
}
