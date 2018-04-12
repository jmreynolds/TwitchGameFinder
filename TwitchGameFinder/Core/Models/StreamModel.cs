namespace Core.Models
{
    public class StreamModel
    {
        public long Id { get; protected set; }
        public string Game { get; protected set; }
        public bool IsPlaylist { get; protected set; }
        public string StreamType { get; protected set; }
        public int Viewers { get; protected set; }
    }
}