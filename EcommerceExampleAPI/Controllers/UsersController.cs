using EcommerceExampleAPI.Models;
using EcommerceExampleAPI.Models.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EcommerceExampleAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/users")]
    public class UsersController : ControllerBase
    {
        private static readonly List<UserDto> _userDtos = new List<UserDto>()
        {
        new UserDto(){ Id = 1, Name = "Mustafa", Surname = "Kocatepe", Email = "mustafakocatepe@gmail.com", Telephone = "05465553684" ,CreatedDate = DateTime.Now.AddDays(-15), IsActive = true,
                                                                                                                        Orders = { new OrderDto() { Id = 1, OrderDate = DateTime.Now.AddDays(-2), UserId = 1, OrderNumber = "35698", OrderStatus = OrderStatus.Approved,   PaymentType = PaymentType.Online },
                                                                                                                                   new OrderDto() { Id = 2, OrderDate = DateTime.Now.AddDays(-1), UserId = 1, OrderNumber = "35478", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.Online }}  },
        new UserDto(){ Id = 2, Name = "Necati", Surname = "Atım", Email = "necatiatım@gmail.com" , Telephone = "05465552784", CreatedDate = DateTime.Now.AddDays(-2), IsActive = false, Orders = { new OrderDto() { Id = 3, OrderDate = DateTime.Now, UserId = 1, OrderNumber = "45698", OrderStatus = OrderStatus.Shipment,   PaymentType = PaymentType.Online },
                                                                                                                     new OrderDto() { Id = 4, OrderDate = DateTime.Now.AddDays(-10), UserId = 1, OrderNumber = "35478", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.CashOnDelivery }}},
        new UserDto(){ Id = 3, Name = "Ahmet", Surname = "Atım", Email = "ahmetatim@gmail.com" ,Telephone = "05498553684", CreatedDate = DateTime.Now.AddDays(-5), IsActive = false,  Orders = { new OrderDto() { Id = 5, OrderDate = DateTime.Now, UserId = 1, OrderNumber = "55698", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.CashOnDelivery },
                                                                                                                     new OrderDto() { Id = 6, OrderDate = DateTime.Now.AddDays(-3), UserId = 1, OrderNumber = "35478", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.CashOnDelivery }}},
        new UserDto(){ Id = 4, Name = "Mustafa", Surname = "Onay", Email = "mustafaonay@gmail.com",Telephone = "05463553684", CreatedDate = DateTime.Now.AddDays(-4) , IsActive = true,  Orders = { new OrderDto() { Id = 7, OrderDate = DateTime.Now, UserId = 1, OrderNumber = "15698", OrderStatus = OrderStatus.Approved,   PaymentType = PaymentType.CashOnDelivery },
                                                                                                                     new OrderDto() { Id = 8, OrderDate = DateTime.Now.AddDays(-6), UserId = 1, OrderNumber = "35478", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.Online }}},
        new UserDto(){ Id = 5, Name = "Feray", Surname = "Olcay", Email = "ferayolcay@gmail.com",Telephone = "05465546684", CreatedDate = DateTime.Now.AddDays(-6), IsActive = true, Orders = { new OrderDto() { Id = 9, OrderDate = DateTime.Now, UserId = 1, OrderNumber = "35498", OrderStatus = OrderStatus.Shipment,   PaymentType = PaymentType.Online },
                                                                                                                     new OrderDto { Id = 10, OrderDate = DateTime.Now.AddDays(-2), UserId = 1, OrderNumber = "35478", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.CashOnDelivery }}},
        new UserDto(){ Id = 6, Name = "Nejat", Surname = "Boy", Email = "nejatboy@gmail.com",Telephone = "05463553684", IsActive = true, CreatedDate = DateTime.Now.AddDays(-16), Orders = { new OrderDto() { Id = 11, OrderDate = DateTime.Now, UserId = 1, OrderNumber = "95618", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.Online },
                                                                                                                     new OrderDto() { Id = 12, OrderDate = DateTime.Now.AddDays(-4), UserId = 1, OrderNumber = "35478", OrderStatus = OrderStatus.Delivered,   PaymentType = PaymentType.Online }}},
        };

        private static int _orderIdCount = 12;

        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            if (_userDtos == null)
            {
                return NotFound();
            }

            return Ok(_userDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get([FromRoute] int id)
        {
            var user = _userDtos.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] CreateUserDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            UserDto user = new UserDto()
            {
                Id = _userDtos.Count() + 1,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Telephone = model.Telephone,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _userDtos.Add(user);

            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            var user = _userDtos.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _userDtos.Remove(user);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateEmail(int id, [FromBody] EmailDto emailDto)
        {
            var user = _userDtos.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Email = emailDto.Email;
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateFullName(int id, [FromBody] FullNameDto fullNameDto)
        {
            var user = _userDtos.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return BadRequest();
            }

            user.Name = fullNameDto.Name;
            user.Surname = fullNameDto.Surname;

            return NoContent();
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult List([FromQuery] string name, [FromQuery] string surname, [FromQuery] string email, [FromQuery] string telephone, [FromQuery] bool isActive)
        {
            List<UserDto> response = _userDtos;

            if (!string.IsNullOrEmpty(name))
                response = _userDtos.Where(x => x.Name == name).ToList();

            if (!string.IsNullOrEmpty(surname))
                response = response.Where(x => x.Surname == surname).ToList();

            if (!string.IsNullOrEmpty(email))
                response = response.Where(x => x.Email == email).ToList();

            if (!string.IsNullOrEmpty(telephone))
                response = response.Where(x => x.Email == telephone).ToList();

            if (HttpContext.Request.Query.ContainsKey("isActive"))
                response = response.Where(x => x.IsActive == isActive).ToList();

            if (response.Count == 0)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("group")]
        [ProducesResponseType(typeof(List<List<UserDto>>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Group([FromQuery] string groupParameter)
        {
            var result = new List<List<UserDto>>();

            switch (groupParameter.ToLower())
            {
                case "name":
                    result = _userDtos.GroupBy(x => x.Name).Select(x => x.ToList()).ToList();
                    break;
                case "surname":
                    result = _userDtos.GroupBy(x => x.Surname).Select(x => x.ToList()).ToList();
                    break;
                case "email":
                    result = _userDtos.GroupBy(x => x.Email).Select(x => x.ToList()).ToList();
                    break;
                case "telephone":
                    result = _userDtos.GroupBy(x => x.Telephone).Select(x => x.ToList()).ToList();
                    break;
                case "createdDate":
                    result = _userDtos.GroupBy(x => x.CreatedDate).Select(x => x.ToList()).ToList();
                    break;
                case "isactive":
                    result = _userDtos.GroupBy(x => x.IsActive).Select(x => x.ToList()).ToList();
                    break;
            }

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("sort")]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Sort([FromQuery] string sortParameter)
        {
            var result = new List<UserDto>();

            switch (sortParameter.ToLower())
            {
                case "name":
                    result = _userDtos.OrderBy(x => x.Name).ToList();
                    break;
                case "surname":
                    result = _userDtos.OrderBy(x => x.Surname).ToList();
                    break;
                case "email":
                    result = _userDtos.OrderBy(x => x.Email).ToList();
                    break;
                case "telephone":
                    result = _userDtos.OrderBy(x => x.Telephone).ToList();
                    break;
                case "createdDate":
                    result = _userDtos.OrderBy(x => x.CreatedDate).ToList();
                    break;
                case "isactive":
                    result = _userDtos.OrderBy(x => x.IsActive).ToList();
                    break;
            }

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("{id:int}/orders")]
        [ProducesResponseType(typeof(OrderDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateOrder(int id, [FromBody] CreateOrderDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            _orderIdCount += 1; 
            OrderDto orderDto = new OrderDto()
            {
                Id = _orderIdCount,
                UserId = model.UserId,
                OrderNumber = model.OrderNumber,
                OrderDate = DateTime.Now,
                OrderStatus = model.OrderStatus,
                PaymentType = model.PaymentType
            };

            

            _userDtos.FirstOrDefault(x => x.Id == id).Orders.Add(orderDto);
            return Created("", orderDto);
        }

        [HttpDelete("{id:int}/orders")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteOrder(int id)
        {
            var user = _userDtos.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Orders.RemoveAll(x => x.UserId == id);
            return NoContent();
        }

        [HttpGet("{id:int}/orders")]
        [ProducesResponseType(typeof(List<OrderDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UserOrders(int id)
        {
            var user = _userDtos.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Orders);
        }
    }
}
