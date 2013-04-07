namespace FeedRepository.Projections
{
    public class FeedProjection
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Uri { get; set; }

        public string CategoryName { get; set; }

        public int FeedSetId { get; set; }

        public string FeedSetName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
