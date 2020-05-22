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
        public Artist Artist { get; set; } = null!;

        // ID bài hát
        public Guid SongId { get; set; }

        // Bài hát
        public Song Song { get; set; } = null!;
    }
}