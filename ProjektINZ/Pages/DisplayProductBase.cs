using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;

namespace ProjektINZ.Pages
{
    public class DisplayProductBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
