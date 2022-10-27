namespace BlackFridayCustomer100.Model
{
  public interface INotifier
  {
    bool Notify(INotifiableCustomer notifiableCustomer);
  }
}
