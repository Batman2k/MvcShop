using System.Collections.Generic;
using RapidMountain.Core.Dtos;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.ViewModels
{
    public class CartViewModel
    {
        public string Title { get; set; }

        public IEnumerable<CartDto> CartViews { get; set; }
    }
}