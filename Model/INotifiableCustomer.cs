namespace BlackFridayCustomer100.Model
{
  public interface INotifiableCustomer
  {
    eNotifyType NotifyType { get; }

    string NotifyTarget { get; }

    string OrderID { get; }

    string Name { get; }

    bool Notify();
  }
}
