using System.Collections.Generic;
using System.Linq;

namespace Entity.Constants
{
    public static class CurrencyEnum
    {
        public enum Currencies
        {
            TL = 1,
            USD = 2,
            EUR = 3
        }
        public static IList<ListItem> CurrencyList = new List<ListItem> {
            new ListItem {Text = CurrencyEnum.Currencies.TL.ToString(), Value=((int)CurrencyEnum.Currencies.TL).ToString() },
            new ListItem {Text = CurrencyEnum.Currencies.USD.ToString(), Value=((int)CurrencyEnum.Currencies.USD).ToString() },
            new ListItem {Text = CurrencyEnum.Currencies.EUR.ToString(), Value=((int)CurrencyEnum.Currencies.EUR).ToString() },
        };

        public static ListItem GetCurrencyByType(int type)
        {
            return CurrencyList.SingleOrDefault(m => m.Value == type.ToString());
        }
    }
}
