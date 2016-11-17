using System;

namespace RapidMountain.Core.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string MadeBy { get; set; }

        public int Stars { get; set; }

        public DateTime Written { get; set; }

        public string Text { get; set; }

        public int ProductId { get; set; }

    }
}