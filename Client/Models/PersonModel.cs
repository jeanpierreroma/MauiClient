namespace Client.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public ValidationModel Validation { get; set; }
    }
}
