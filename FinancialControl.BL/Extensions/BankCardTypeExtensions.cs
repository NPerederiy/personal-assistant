using FinancialControl.BL.Enums;
using System;

namespace FinancialControl.BL.Extensions
{
    public static class BankCardTypeExtensions
    {
        public static string GetName(this BankCardType type)
        {
            return Enum.GetName(typeof(BankCardType), type);
        }

        public static BankCardType ToBankCardTypeEnum(this string type)
        {
            switch (type.ToUpper())
            {
                case "MASTERCARD": return BankCardType.MasterCard;
                case "VISA": return BankCardType.Visa;
                default: return BankCardType.NotProvided;
            }
        }
    }
}
