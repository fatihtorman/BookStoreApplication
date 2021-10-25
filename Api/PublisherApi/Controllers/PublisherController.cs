using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        private IPublisherRepository _publisherRepository;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(IPublisherRepository publisherRepository, ILogger<PublisherController> logger)
        {
            _publisherRepository = publisherRepository;
            _logger = logger;
        }

        // GET: api/Publisher
        [HttpGet]
        public IEnumerable<Publisher> GetPublisher()
        {
            return _publisherRepository.GetAll();
        }

        // GET: api/Publisher/5
        [HttpGet("{id}")]
        public IActionResult GetPublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = _publisherRepository.GetById(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        //// PUT: api/Publisher/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] Publisher order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //         _orderRepository.Update(order);
        //         _orderRepository.Commit();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // PUT: api/Orders/5
        //[HttpPut("change/{id}")]
        //public async Task<IActionResult> ChangeStatusOrder([FromRoute] int id, [FromBody] string status)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //if (id != orders.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    var order =  _orderRepository.GetById(id);
        //    order.Status = status;

        //    try
        //    {
        //         _orderRepository.Update(order);
        //        _orderRepository.Commit();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Orders
        //[HttpPost]
        //public async Task<IActionResult> CreateOrder([FromBody] Publisher orders)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        _orderRepository.Add(orders);
        //        _orderRepository.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    var order = _orderRepository.GetById(orders.Id);
        //    return Ok(order.Id);
        //    //return CreatedAtAction("GetOrder", new { id = orders.Id }, orders);
        //}

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order =  _orderRepository.GetById(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //         _orderRepository.Remove(order);
        //        _orderRepository.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok(order);
        //}

        //private bool OrderExists(int id)
        //{
        //    return _orderRepository.Find(e => e.Id == id).Any();
        //}
    }
}
