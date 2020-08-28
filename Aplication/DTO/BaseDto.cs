namespace Aplication.DTO
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
