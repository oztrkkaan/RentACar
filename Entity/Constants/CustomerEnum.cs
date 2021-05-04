using System.Collections.Generic;
using System.Linq;

namespace Entity.Constants
{
    public static class CustomerEnum
    {
        public enum Gender
        {
            Male = 1,
            Female = 0
        }

        public static IList<ListItem> GenderList = new List<ListItem> {
            new ListItem { Text = "Erkek", Value = ((int)Gender.Male).ToString() },
            new ListItem { Text = "Kadın", Value = ((int)Gender.Female).ToString() }
        };

        public static ListItem GetGender(int value)
        {
            return GenderList.SingleOrDefault(m => m.Value == value.ToString());
        }
    }
}
