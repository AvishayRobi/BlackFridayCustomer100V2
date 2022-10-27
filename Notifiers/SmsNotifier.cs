using BlackFridayCustomer100.Clients;
using BlackFridayCustomer100.Model;

namespace BlackFridayCustomer100.Notifiers
{
  public class SmsNotifier : INotifier
  {
    #region Data Members
    private SmsClient smsClient { get; }
    #endregion

    #region Ctor
    public SmsNotifier()
    {
      this.smsClient = new SmsClient();
    }
    #endregion

    #region Public Methods
    public bool Notify(INotifiableCustomer notifiableCustomer)
      =>
      this.smsClient
      .SendSMS(
        phoneNumber: notifiableCustomer.NotifyTarget,
        customerName: notifiableCustomer.Name,
        orderID: notifiableCustomer.OrderID);
    #endregion
  }
}
