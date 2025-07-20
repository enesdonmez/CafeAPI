using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Domain.Entities;
using System.Text;

namespace CafeAPI.Application.Helpers
{
    public class HtmlConverter
    {
        public static string ConvertToHtml(List<ResultMenuItemDto> items)
        {
            var sb = new StringBuilder();
            sb.Append(@"
    <html>
    <head>
        <title>Cafe Menü</title>
        <meta name='viewport' content='width=device-width, initial-scale=1'>
        <style>
            body { font-family: sans-serif; margin: 20px; }
            .menu { max-width: 600px; margin: auto; }
            .item { display: flex; justify-content: space-between; padding: 10px; border-bottom: 1px solid #ccc; }
            .item-name { font-size: 18px; }
            .item-price { font-weight: bold; }
            h1 { text-align: center; }
        </style>
    </head>
    <body>
        <div class='menu'>
            <h1>Menü</h1>");

            foreach (var item in items)
            {
                sb.Append($@"
            <div class='item'>
                <div class='item-name'>{item.Name}</div>
                <div class='item-price'>{item.Price} TL</div>
            </div>");
            }

            sb.Append(@"
        </div>
    </body>
    </html>");

            return sb.ToString();
        }
    }
}
