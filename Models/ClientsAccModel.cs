using System.ComponentModel.DataAnnotations;
namespace FinancialAccounting.Models
{
    public class ClientsAccModel
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? Balance { get; set; }
    }
}
