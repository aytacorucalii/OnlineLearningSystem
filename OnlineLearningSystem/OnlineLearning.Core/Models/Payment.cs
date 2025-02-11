using OnlineLearning.Core.Enums;
using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;
public class Payment
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public DateTime PaymentDate { get; set; }
	public PaymentStatus Status { get; set; }  // Ödənişin statusu
	public bool IsSuccessful { get; set; }     // Ödənişin nəticəsi
}

