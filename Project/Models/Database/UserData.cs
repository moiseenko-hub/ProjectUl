namespace Project.Models.Database
{
    public class UserData : BaseModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<ReviewData> Reviews { get; set; }
    }

}
