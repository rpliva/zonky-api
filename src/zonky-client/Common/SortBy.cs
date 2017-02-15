using System;

namespace Rpliva.Zonky.Client.Common
{
    public class SortBy
    {
        public SortBy(LoanField field, OrderBy orderBy = OrderBy.Asc)
        {
            Field = field;
            OrderBy = orderBy;
        }

        public LoanField Field { get; private set; }
        public OrderBy OrderBy { get; private set; }

        public string ToHeader()
        {
            return (OrderBy == OrderBy.Desc ? "-" : string.Empty) + ToFieldName(Field);
        }

        private string ToFieldName(LoanField field)
        {
            switch (field)
            {
                case LoanField.DatePublished:
                    return "datePublished";
                case LoanField.InterestRate:
                    return "interestRate";
                case LoanField.Covered:
                    return "covered";
                case LoanField.TermInMonths:
                    return "termInMonths";
                case LoanField.Purpose:
                    return "purpose";
                case LoanField.Rating:
                    return "rating";
                case LoanField.Incomes:
                    return "incomes";
                case LoanField.Topped:
                    return "topped";
                case LoanField.RemainingInvestment:
                    return "remainingInvestment";
                default:
                    throw new ArgumentOutOfRangeException(nameof(field), field, null);
            }
        }
    }
}