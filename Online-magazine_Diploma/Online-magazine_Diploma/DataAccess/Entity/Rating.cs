namespace Online_magazine_Diploma.DataAccess.Entity
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
