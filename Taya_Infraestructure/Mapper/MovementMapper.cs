namespace Taya_Infraestructure.Mapper
{
    using Taya_Domain.Entities;
    using Taya_Helper.DTOs;

    public static class MovementMapper
    {
        public static Movement ToEntity(MovementDto dto)
        {
            Movement entity = new()
            {
                OperationDate = dto.OperationDate,
                ValueDate = dto.ValueDate,
                Id = dto.Id,
                Amount = dto.Amount,
                Description = dto.Description,
                Category = dto.Category
            };

            return entity;
        }

        public static MovementDto ToDto(Movement entity)
        {
            MovementDto dto = new()
            {
                OperationDate = entity.OperationDate,
                ValueDate = entity.ValueDate,
                Id = entity.Id,
                Amount = entity.Amount,
                Description = entity.Description,
                Category = entity.Category
            };

            return dto;
        }
    }
}
