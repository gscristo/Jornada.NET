using System;
using System.Collections.Generic;

namespace WebApiRest.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, string title, string description, decimal price, DateTime registredAt, List<ProductReviewViewModel> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            RegistredAt = registredAt;
            Reviews = reviews;
        }

        public int  Id { get;private set; }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public decimal Price { get;private set; }
        public DateTime RegistredAt  { get;private set; }
        public List<ProductReviewViewModel> Reviews {get; private set;}
    }

    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string author, int rating, string comments, DateTime registredAt)
        {
            Id = id;
            Author = author;
            Rating = rating;
            Comments = comments;
            RegistredAt = registredAt;
        }

        public int  Id { get;private set; }
        public string Author { get;private set; }
        public int Rating { get;private set; }
        public string Comments { get; private set; }
        public DateTime RegistredAt { get;private set; }

    }
}