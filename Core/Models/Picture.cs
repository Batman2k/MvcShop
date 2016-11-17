namespace RapidMountain.Core.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public byte[] Img { get; set; }

        public int ProductId { get; set; }
    }
}