namespace Back_End.Models.Interfaces
{
    public interface IDeletedEntity
    {
        bool Deleted { get; set; }
        public DateTime? DeletedAt { get; set; } 
    }
}