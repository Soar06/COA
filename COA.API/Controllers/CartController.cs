using CustomerOrderService.Application.DTOs;
using CustomerOrderService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomerOrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(Guid userId)
        {
            var carts = await _cartService.GetCartAsync(userId);
            return Ok(carts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartDto cartDto)
        {
            await _cartService.AddToCartAsync(cartDto);
            return Ok();
        }
    }
}