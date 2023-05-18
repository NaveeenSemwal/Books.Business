namespace Books.Business.Model
{
    public class MemberDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string PhotoUrl { get; set; }

        public string KnownAs { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Gender { get; set; }

        public string Introducation { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<PhotoDto> Photos { get; set; } = new();
        public List<string> Roles { get; set; } = new();
    }
}
