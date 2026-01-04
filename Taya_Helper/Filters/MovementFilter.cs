namespace Taya_Helper.Filters
{
    using System;

    public class MovementFilter : BaseFilter
    {
        public DateTime? OperationDate { get; set; }

        public DateTime? ValueDate { get; set; }

        public decimal? Amount { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }
    }
}
