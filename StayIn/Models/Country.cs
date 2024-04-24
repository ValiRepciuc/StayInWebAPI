namespace StayInAPI.Models
{
    public class Country
    {
        public int CountryId {  get; set; }
        public string Name { get; set; }
        public ICollection<Adress> Adress { get; set; }
    }
}
