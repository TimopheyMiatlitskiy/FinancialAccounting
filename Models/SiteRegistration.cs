using System.ComponentModel.DataAnnotations;

namespace FinancialAccounting.Models
{
    public class SiteRegistration
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
