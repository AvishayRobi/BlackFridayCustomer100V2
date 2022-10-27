using BlackFridayCustomer100.Clients;
using BlackFridayCustomer100.Model;

namespace BlackFridayCustomer100.Notifiers
{
  public class EmailNotifier : INotifier
  {
    #region Data Members    
    private EmailClient emailClient { get; }
    #endregion

    #region Ctor    
    public EmailNotifier()
    {
      this.emailClient = new EmailClient();
    }
    #endregion

    #region Public Methods
    public bool Notify(INotifiableCustomer notifiableCustomer)
      =>
      this.emailClient
      .SendEmail(
        emailAddress: notifiableCustomer.NotifyTarget,
        customerName: notifiableCustomer.Name,
        orderID: notifiableCustomer.OrderID);
    #endregion
  }
}
