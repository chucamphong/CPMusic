namespace CPMusic.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string OtherName { get; set; }
        
        public string Thumbnail { get; set; }
        
        public string Url { get; set; }
        
        public ushort Year { get; set; }
        
        public ulong Views { get; set; }
    }
}