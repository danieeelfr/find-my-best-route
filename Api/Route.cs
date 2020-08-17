using System;

namespace Api
{
    public class Route
    {
        public string From { get; set; }

        public string To { get; set; }

        public string getFrom()
        {
            return this.From;
        }

        public void setFrom(string From)
        {
            this.From = From;
        }

        public string getTo()
        {
            return this.To;
        }

        public void setTo(string To)
        {
            this.To = To;
        }

    }
}
