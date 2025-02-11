
using OnlineLearning.Core.Enums;

namespace OnlineLearning.BL.DTOs;

public class PaymentDTO
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public string CardNumber { get; set; }  // Bu sətiri əlavə edin
	public PaymentStatus Status { get; set; }
	public PaymentMethod Method { get; set; }
	public DateTime PaymentDate { get; set; }
}
