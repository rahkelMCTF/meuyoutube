namespace meuyoutube.Models
{
    public class VideoPlayList
    {
        public int IdPlayList { get; set; }
        public PlayList PlayList { get; set; }
        public int IdVideo { get; set; }
        public Video Video { get; set; }
    }
}