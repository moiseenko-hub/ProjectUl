namespace Project.Models.Database
{
    public class TypeData : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<PlaceData> Places { get; set; }
    }


}
