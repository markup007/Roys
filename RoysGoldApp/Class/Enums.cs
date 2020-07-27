using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoysGold
{
    class Enums
    {
        public enum VoucherType
        {
            SmithIssue = 1,
            SmithReciept = 2,
            RawPurchase = 3,
            Sales = 4,
            Journel = 5,
            PettyCash = 6,
            Opening = 7,
            SalesReceipt = 8,
            SalesReturn = 9,
            DirectPurchaseReturn = 10,
            RecieptReturn=11,
            SmithReturn = 12,
            WeightPurchaseReturn=13
          

        }
        public enum SaleMode
        {
            WeightToCash = 1,
            WeightToWeight = 2,
            Contract=3


        }

    }
}
