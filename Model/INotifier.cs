namespace BlackFridayCustomer100.Model
{
  public interface INotifier
  {
    bool SendNotification(INotifiableCustomer notifiableCustomer);
  }
}
