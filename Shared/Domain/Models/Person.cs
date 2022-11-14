namespace repairnow_api.Domain.Models{
    public class Person
    {        // Properties of person
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public long CellphoneNumber { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; } 
    }
}