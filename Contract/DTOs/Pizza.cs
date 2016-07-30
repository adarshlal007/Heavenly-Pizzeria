namespace Contract.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class Pizza
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}