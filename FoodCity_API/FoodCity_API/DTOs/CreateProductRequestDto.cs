namespace FoodCityProductApi.DTOs
{
    public class CreateProductRequestDto
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
