namespace Project_Foodle.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public string Username { get; set; }
        public int SelectedQuantity { get; set; }
    }
}