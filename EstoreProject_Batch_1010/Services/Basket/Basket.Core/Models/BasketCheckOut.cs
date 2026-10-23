namespace Basket.Core.Models
{
    public class BasketCheckOut
    {

        public string UserName { get; init; } = string.Empty;

        public List<CartInformation> CartItems { get; set; } 
            = new List<CartInformation>();

        public BasketCheckOut(string userName)
        {
            this.UserName = userName;
        }
    }
}
