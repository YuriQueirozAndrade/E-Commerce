#nullable enable
using Back_End.Models.Interfaces;

namespace Back_End.Models.BaseModels
{
   public abstract partial class Base :  IDeletedEntity
   {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Deleted { get; set; }
        public DateTime? DeletedAt { get; set; }
   }
}