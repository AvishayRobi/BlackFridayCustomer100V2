using BlackFridayCustomer100.Notifiers;

namespace BlackFridayCustomer100.Model
{
  public class BFCustomerNotifiableBySms : INotifiableCustomer
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

    #region Ctor
    public BFCustomerNotifiableBySms(BFCustomerInfo customerInfo)
    {
      this.isAlreadyNotified = customerInfo.IsSmsSent;
      this.notifyType = eNotifyType.Sms;
      this.notifyTarget = customerInfo.PhoneNumber;
      this.notifier = new SmsNotifier();
      this.orderID = customerInfo.OrderID;
      this.name = customerInfo.CustomerName;
    }
    #endregion

    public bool Notify()
      =>
      this.notifier
      .SendNotification(this);
  }
}
