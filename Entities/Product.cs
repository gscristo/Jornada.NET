using System;
using System.Collections.Generic;

namespace WebApiRest.Entities
{
    public class Product
    {
        public Product(string title, string description, decimal price)
        {   
            Title = title;
            Description = description;
            Price = price;
            RegistredAt = DateTime.Now;
            Reviews = new List<ProductReview>();
        }

        public int  Id { get;private set; }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public decimal Price { get;private set; }
        public DateTime RegistredAt  { get;private set; }

        public List<ProductReview> Reviews {get;private set;}

        // public void AddReview(ProductReview review)
        // { 
        //     Reviews.Add(review);
        // }
        public void Update(string decription, decimal price)
        {
            Description = decription;
            Price = price;
        }
    }
}