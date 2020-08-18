using System.ComponentModel.DataAnnotations;

namespace Api
{
    public class RouteDTO
    {
        [Required]
        [StringLength(3)]
        public string From { get; set; }

        [Required]
        [StringLength(3)]
        public string To { get; set; }

        [Required]
        public double Price { get; set; }

        public double getPrice()
        {
            return this.Price;
        }

        public void setPrice(double Price)
        {
            this.Price = Price;
        }

        public string getFrom()
        {
            return this.From.ToUpper();
        }

        public void setFrom(string From)
        {
            this.From = From.ToUpper();
        }

        public string getTo()
        {
            return this.To.ToUpper();
        }

        public void setTo(string To)
        {
            this.To = To.ToUpper();
        }

    }
}
