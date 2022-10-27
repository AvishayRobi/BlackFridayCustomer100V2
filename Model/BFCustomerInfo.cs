namespace BlackFridayCustomer100.Model
{
  public class BFCustomerInfo
  {
    public string OrderID { get; set; }

    public bool IsEmailSent { get; set; }

    public bool IsSmsSent { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string CustomerName { get; set; }
  }
}
