namespace ExploringWebAPIDotNet9
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int Fees { get; set; }
    }
}
