using System;

namespace WebApiRest.Entities
{
    public class ProductReview
    {
        public ProductReview(string author, int rating, string comments,int productId)
        {
            Author = author;
            Rating = rating;
            Comments = comments;
            ProductId = productId;
            RegistredAt = DateTime.Now;

        }

        public int  Id { get;private set; }
        public string Author { get;private set; }
        public int Rating { get;private set; }
        public string Comments { get;private set; }
        public DateTime RegistredAt  { get; set; }
        public int ProductId { get;private set; }
        public Product Product { get; private set; }
        
    }
}