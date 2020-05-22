using System;

namespace CPMusic.Models.Interfaces
{
    public interface IEntity : IEntity<Guid>
    {

    }

    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public string Name { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}