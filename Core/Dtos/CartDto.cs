namespace RapidMountain.Core.Dtos
{
    public class CartDto
    {
        public int ProductId { get; set; }
        
        public int Amount { get; set; }
        
        public string Name { get; set; }
        
        public int PictureId { get; set; }

        public decimal Price { get; set; }
    }
}