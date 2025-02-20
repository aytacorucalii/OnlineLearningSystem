using Stripe.Checkout;
using Stripe;
using OnlineLearning.Core.Models;
using OnlineLearning.BL.Services.Abstractions;

public class StripeService: IStripeService
{
    private readonly string _secretKey = "your-stripe-secret-key";

    public StripeService()
    {
        StripeConfiguration.ApiKey = _secretKey;
    }

    public async Task<string> CreateCheckoutSessionAsync(Payment paymentSession)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = paymentSession.Currency,
                        UnitAmount = (long)(paymentSession.Amount * 100), // Stripe 100 bölünmüş formatı tələb edir
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Order Payment"
                        }
                    },
                    Quantity = 1
                }
            },
            Mode = "payment",
            SuccessUrl = paymentSession.SuccessUrl,
            CancelUrl = paymentSession.CancelUrl
        };

        var service = new SessionService();
        Session session = await service.CreateAsync(options);
        return session.Url;
    }
}
