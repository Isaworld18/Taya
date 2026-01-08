namespace Taya_Api.Response
{
    using Taya_Helper.DTOs;

    public class GetMovementResponse
    {
        public Guid Id { get; set; }

        public IEnumerable<MovementDto> Data { get; set; }

        public int TotalMovement { get; set; }

        public decimal TotalIncomes { get; set; }

        public decimal TotalExpenses { get; set; }
    }
}
