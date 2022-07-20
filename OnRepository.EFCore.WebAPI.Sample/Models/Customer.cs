namespace OnRepository.EFCore.WebAPI.Sample.Models
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int KindId { get; set; }

        public CustomerKind Kind { get; set; }
    }
}
