using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesApi.Data;
using QuotesApi.Models;
using Microsoft.AspNetCore.Http;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    { 
        private QuotesDbContext _quotesDbContext;

        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }
    


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_quotesDbContext.Quotes);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quote =_quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("No record found");
            }
            else 
            {
                return Ok(quote);
            }
            

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
           var entity = _quotesDbContext.Quotes.Find(id);
            if(entity==null)
            {
                return NotFound("No rcord found for this id");
            } else
            {
                entity.Title = quote.Title;
                entity.Author = quote.Author;
                entity.Description = quote.Description;
                _quotesDbContext.SaveChanges();
                return Ok("Record updated successfully");
            }
            

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            if(quote==null)
            {
                return NotFound("No record found for this id");
            } else
            {
                _quotesDbContext.Remove(quote);
                _quotesDbContext.SaveChanges();
                return Ok("Quote Deleted");
            }
           
        }
    }
}
