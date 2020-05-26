using System;

namespace CPMusic.InputModels
{
    public class SongInputModel
    {
        public Guid Id { get; set; }
            
        public string Name { get; set; } = null!;
            
        public string? OtherName { get; set; }
            
        public string Thumbnail { get; set; } = null!;
            
        public string Url { get; set; } = null!;
            
        public uint Year { get; set; }
            
        public Guid CategoryId { get; set; }
    }
}
