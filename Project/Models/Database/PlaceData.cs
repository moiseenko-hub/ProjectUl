namespace Project.Models.Database
{
    public class PlaceData : BaseModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<ReviewData> Reviews { get; set; }
        public virtual ICollection<TypeData> Types { get; set; } = new List<TypeData>();

    }


}
