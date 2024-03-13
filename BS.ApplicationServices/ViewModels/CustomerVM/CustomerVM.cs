namespace BS.ApplicationServices.ViewModels.CustomerVM
{
    public class CustomerVM : BaseCustomerVM
    {
        public required Guid CustomerId { get; set; }        

        public DateTime RegistrationDate { get; set; }

        public bool HasOrders { get; set; }

        public int OrdersCount { get; set; }
    }
}
