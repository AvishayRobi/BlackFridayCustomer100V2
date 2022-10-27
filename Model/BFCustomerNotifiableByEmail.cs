using BlackFridayCustomer100.Notifiers;

namespace BlackFridayCustomer100.Model
{
  public class BFCustomerNotifiableByEmail : INotifiableCustomer
  {
    #region Properties
    public bool IsAlreadyNotified => this.isAlreadyNotified;
    public eNotifyType NotifyType => this.notifyType;
    public string NotifyTarget => this.notifyTarget;
    public string OrderID => this.orderID;
    public string Name => this.name;
    #endregion

    #region Data Members
    private bool isAlreadyNotified { get; }
    private eNotifyType notifyType { get; }
    private string notifyTarget { get; }
    private INotifier notifier { get; }
    private string orderID { get; }
    private string name { get; }
    #endregion

    #region Ctors
    public BFCustomerNotifiableByEmail(BFCustomerInfo customerInfo)
    {
      this.isAlreadyNotified = customerInfo.IsEmailSent;
      this.notifyType = eNotifyType.Email;
      this.notifyTarget = customerInfo.EmailAddress;
      this.notifier = new EmailNotifier();
      this.orderID = customerInfo.OrderID;
      this.name = customerInfo.CustomerName;
    }
    #endregion

    public bool Notify()
      =>
      this.notifier
      .Notify(this);
  }
}
