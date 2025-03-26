namespace WebApi.Models
{
    public class PersonItem
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string Description { get; set; }
    }
}
