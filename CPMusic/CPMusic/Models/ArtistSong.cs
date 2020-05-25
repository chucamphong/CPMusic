using System;

namespace CPMusic.Models
{
    /// <summary>
    /// Lớp này thể hiện quan hệ n - n giữa bảng nghệ sĩ và thể loại
    /// </summary>
    public class ArtistSong
    {
        /// <summary>
        /// ID nghệ sĩ
        /// </summary>
        public Guid ArtistId { get; set; }

        // Nghệ sĩ
        public virtual Artist Artist { get; set; } = null!;

        // ID bài hát
        public Guid SongId { get; set; }

        // Bài hát
        public virtual Song Song { get; set; } = null!;
    }
}