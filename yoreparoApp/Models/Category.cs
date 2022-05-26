using System;
namespace yoreparoApp.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public bool isActive { get; set; }
    }
}
