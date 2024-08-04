namespace E_Commerce_API.Core.Interfaces
{
    public interface IDeletedEntity
    {
        bool Deleted { get; set; }
        public DateTime? DeletedAt { get; set; } 
    }
}