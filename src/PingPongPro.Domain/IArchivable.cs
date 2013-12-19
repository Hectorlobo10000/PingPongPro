namespace PingPongPro.Domain
{
    public interface IArchivable
    {
        void Archive();
        bool Archived { get;  }
    }
}