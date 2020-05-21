using System;

namespace CPMusic.Models.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}