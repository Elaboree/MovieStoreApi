namespace MovieStoreApi.MessageProducer.Sender
{
    public interface IMovieSender
    {
        void SendMovie(string json);
    }
}
