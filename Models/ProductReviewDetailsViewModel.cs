using System;

namespace WebApiRest.Models
{
    public class ProductReviewDetailsViewModel
    {
        public int  Id { get;private set; }
        public string Author { get;private set; }
        public int Rating { get;private set; }
        public string Comments { get;private set; }
        public DateTime RegistredAt  { get;private set; }
    }
}