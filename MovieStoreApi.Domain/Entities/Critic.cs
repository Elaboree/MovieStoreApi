namespace MovieStoreApi.Domain
{
    public class Critic
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
