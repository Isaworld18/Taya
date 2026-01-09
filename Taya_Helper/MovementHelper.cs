namespace Taya_Helper
{
    using System.Collections.Generic;
    using Taya_Helper.DTOs;

    public static class MovementHelper
    {
        public static KeyValuePair<decimal, decimal> GetTotalAmounts(IEnumerable<MovementDto> data)
        {
            decimal totalExpenses = 0;
            decimal totalIncomes = 0;

            foreach (MovementDto item in data)
            {
                if (item.Amount < 0)
                {
                    totalExpenses += item.Amount;
                }
                else
                {
                    totalIncomes += item.Amount;
                }
            }

           return new KeyValuePair<decimal, decimal>(totalExpenses, totalIncomes);
        }
    }
}
