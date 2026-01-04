namespace Taya_Helper.DTOs
{
    using System;

    public class MovementDto
    {
        public Guid Id { get; set; }

        public DateTime OperationDate { get; set; }

        public DateTime ValueDate { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
