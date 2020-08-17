using System;
using System.ComponentModel.DataAnnotations;

namespace Api
{
    public class Route
    {
        [Required]
        [StringLength(3)]
        private string From { get; set; }

        [Required]
        [StringLength(3)]
        private string To { get; set; }

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
