namespace AppEncuestas.Models
{
    public class Customer
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Address Address { get; } = new Address();
        public List<PaymentMethod> PaymentMethods { get; } = new List<PaymentMethod>();
    }

    public class Address
    {
        public string? Line1 { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
    }

    public class PaymentMethod
    {
        public enum Type { CreditCard, HonourSystem }

        public Type MethodType { get; set; }

        public string? CardNumber { get; set; }
    }
}
