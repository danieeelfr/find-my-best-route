using System;

namespace Core.Models
{
    public class Route
    {
        public String From { get; set; }
        public String To { get; set; }
        public Double Price { get; set; }

        public String getFrom()
        {
            return this.From;
        }

        public void setFrom(String From)
        {
            this.From = From;
        }

        public String getTo()
        {
            return this.To;
        }

        public void setTo(String To)
        {
            this.To = To;
        }

        public Double getPrice()
        {
            return this.Price;
        }

        public void setPrice(Double Price)
        {
            this.Price = Price;
        }

    }
}