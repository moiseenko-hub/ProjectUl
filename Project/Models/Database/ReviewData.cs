namespace Project.Models.Database
{
    public class ReviewData : BaseModel
    {
        public string Text { get; set; }
        public int PlaceId { get; set; }
        public int UserId { get; set; }

        public virtual PlaceData Place { get; set; }
        public virtual UserData User { get; set; }
    }


}
