using System.Collections.Generic;
using BlackFridayCustomer100.Model;
using WallaShops.Utils;

namespace BlackFridayCustomer100.BL
{
  public class BFOneHundredthCustomerHandler
  {
    #region Data Members
    private BFOneHundredthCustomerDalManager dalManager { get; }
    #endregion

    #region Ctor
    public BFOneHundredthCustomerHandler()
    {
      this.dalManager = new BFOneHundredthCustomerDalManager();
    }
    #endregion

    #region Public Methods    
    public void Exec()
    {
      IEnumerable<INotifiableCustomer> customers = getCustomers();

      customers
        .ApplyEach(notifyCustomer);
    }
    #endregion

    #region Private Methods
    private void notifyCustomer(INotifiableCustomer customer)
    {
      bool isSuccessfullyNotified = customer.Notify();

      if (isSuccessfullyNotified)
      {
        updateSuccessfullyNotified(customer.OrderID, customer.NotifyType);
      }
    }

    private void updateSuccessfullyNotified(string orderID, eNotifyType notificationType)
    {
      switch (notificationType)
      {
        case eNotifyType.Email:
          updateEmailSuccessfullySent(orderID);
          break;
        case eNotifyType.Sms:
          updateSmsSuccessfullySent(orderID);
          break;
      }
    }

    private IEnumerable<INotifiableCustomer> getCustomers()
      =>
      this.dalManager
      .GetCustomers();

    private void updateEmailSuccessfullySent(string orderID)
      =>
      this.dalManager
      .UpdateEmailSent(orderID);

    private void updateSmsSuccessfullySent(string orderID)
      =>
      this.dalManager
      .UpdateSmsSent(orderID);
    #endregion
  }
}
