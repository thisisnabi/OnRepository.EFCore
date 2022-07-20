namespace OnRepository.EFCore.WebAPI.Sample.Models
{
    public class CustomerKind : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
