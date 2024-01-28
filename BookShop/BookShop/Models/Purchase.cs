using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookShop.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
    }

}
