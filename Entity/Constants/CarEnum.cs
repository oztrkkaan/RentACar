using System.Collections.Generic;
using System.Linq;

namespace Entity.Constants
{
    public static class CarEnum
    {
        public enum Types
        {
            Sedan = 1,
            Jeep = 2,
            Suv = 3
        }
        public static IList<ListItem> TypeList = new List<ListItem> {
            new ListItem {Text = "Sedan", Value=((int)CarEnum.Types.Sedan).ToString() },
            new ListItem {Text = "Jip", Value=((int)CarEnum.Types.Jeep).ToString() },
            new ListItem {Text = "SUV", Value=((int)CarEnum.Types.Suv).ToString() },
        };
        public static ListItem GetByType(int type)
        {
            return TypeList.SingleOrDefault(m => m.Value == type.ToString());
        }


    }
}
