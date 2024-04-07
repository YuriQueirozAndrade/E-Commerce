#nullable enable
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Core.Entities
{
   public abstract partial class Base :  IDeletedEntity
   {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Deleted { get; set; }
        public DateTime? DeletedAt { get; set; }
   }
}