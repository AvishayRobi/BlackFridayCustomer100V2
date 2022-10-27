using System.Collections.Generic;
using System.Data;
using System.Linq;
using BlackFridayCustomer100.DAL;
using BlackFridayCustomer100.Model;
using WallaShops.Utils;

namespace BlackFridayCustomer100.BL
{
  public class BFOneHundredthCustomerDalManager
  {
    #region Data Members
    private BFOneHundredthCustomerDal dal { get; }
    #endregion

    #region Ctor
    public BFOneHundredthCustomerDalManager()
    {
      this.dal = new BFOneHundredthCustomerDal();
    }
    #endregion

    #region Public Methods    
    public IEnumerable<INotifiableCustomer> GetCustomers()
    {
      IEnumerable<BFCustomerInfo> customers = getCustomers();

      return getNotifiableCustomers(customers);
    }

    public void UpdateSmsSent(string orderID)
      =>
      this.dal
      .UpdateSentSms(orderID);

    public void UpdateEmailSent(string orderID)
      =>
      this.dal
      .UpdateSentEmail(orderID);
    #endregion

    #region Private Methods
    private IEnumerable<BFCustomerInfo> getCustomers()
    {
      DataTable dt = this.dal.GetRelevantCustomers();

      return from DataRow dr
             in dt.Rows
             select new BFCustomerInfo()
             {
               CustomerName = WSStringUtils.ToString(dr["customer_name"]),
               EmailAddress = WSStringUtils.ToString(dr["shopper_email"]),
               PhoneNumber = WSStringUtils.ToString(dr["shopper_phone"]),
               IsEmailSent = WSStringUtils.ToBoolean(dr["email_sent"]),
               IsSmsSent = WSStringUtils.ToBoolean(dr["sms_sent"]),
               OrderID = WSStringUtils.ToString(dr["order_id"])
             };
    }

    private IEnumerable<INotifiableCustomer> getNotifiableCustomers(IEnumerable<BFCustomerInfo> customers)
    {
      IEnumerable<INotifiableCustomer> emailNotifiableCustomers = customers
        .Where(isEmailNotSent)
        .Select(createEmailNotifiableCustomer);

      IEnumerable<INotifiableCustomer> smsNotifiableCustomers = customers
        .Where(isSmsNotSent)
        .Select(createSmsNotifiableCustomer);

      return emailNotifiableCustomers
        .Concat(smsNotifiableCustomers);
    }

    private bool isEmailNotSent(BFCustomerInfo customerInfo)
      =>
      !customerInfo.IsEmailSent;

    private bool isSmsNotSent(BFCustomerInfo customerInfo)
      =>
      !customerInfo.IsSmsSent;

    private INotifiableCustomer createEmailNotifiableCustomer(BFCustomerInfo customerInfo)
      =>
      new BFCustomerNotifiableByEmail(customerInfo);

    private INotifiableCustomer createSmsNotifiableCustomer(BFCustomerInfo customerInfo)
      =>
      new BFCustomerNotifiableBySms(customerInfo);
    #endregion
  }
}
