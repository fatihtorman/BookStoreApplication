using Entity;
using Entity.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiGatewayController : ControllerBase
    {


        private const string BookStoreUrl = "https://localhost:5004/api/bookstore";

        private readonly ILogger<ApiGatewayController> _logger;
        private HttpClient _client = new HttpClient();


        public ApiGatewayController(ILogger<ApiGatewayController> logger)
        {
            _logger = logger;
        }

        //private string GetTokenUrl(string user, string pass)
        //{
        //    return AuthUrl + "/?name=" + user + "&pwd=" + pass;/*+ "?"
        //           + "access_key=" + "ApiKey"
        //           + "&query=" + parameter;*/
        //}

        private string GetBookStoreUrl(string parameter)
        {
            return BookStoreUrl + "/" + parameter;
        }

        private string ValidateBookStoreUrl(string parameter)
        {
            return BookStoreUrl + "/validate/" + parameter;
        }

        private string CreateBookStoreUrl()
        {
            return BookStoreUrl;
        }

        // GET: api/GetToken
        //[HttpGet("GetToken")]
        //public async Task<IActionResult> GetToken(string name, string pwd)
        //{
        //    try
        //    {
        //        _client = new HttpClient();
        //        var responseStream = await _client.GetStringAsync(GetTokenUrl(name, pwd));
        //        var accessToken = (string)responseStream;

        //        return Ok(accessToken);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, $"Something went wrong!" + e.Message);
        //        return null;
        //    }
        //}

        /*Methods*/

        [HttpGet("CheckStock")]
        public async Task<IActionResult> CheckStocks(int isbnNo)//Return book details including quantity for the ISBN
        {
            try
            {
                Book books = new Book();
                var response = await _client.GetAsync(GetBookStoreUrl(isbnNo.ToString()));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                books = JsonConvert.DeserializeObject<Book>(responseBody);

                return Ok(books);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;
            }
        }

        //to do
        [HttpGet("CheckStock")]
        public async Task<IActionResult> CheckStocks(List<Book>isbnNo)//Return book details including quantity for the ISBN
        {
            try
            {
                Book books = new Book();
                var response = await _client.GetAsync(GetBookStoreUrl(isbnNo.ToString()));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                books = JsonConvert.DeserializeObject<Book>(responseBody);

                return Ok(books);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;
            }
        }

        [HttpGet("GetAuthor")]
        public async Task<IActionResult> GetAuthors(int id)//Return list of authors
        {
            try
            {
                Author authors = new Author();
                var response = await _client.GetAsync(GetBookStoreUrl(id.ToString()));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                authors = JsonConvert.DeserializeObject<Author>(responseBody);

                return Ok(authors);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;
            }
        }

        [HttpGet("GetPublisher")]
        public async Task<IActionResult> GetPublishers(int id)//Return list of publishers
        {
            try
            {
                Publisher publishers = new Publisher();
                var response = await _client.GetAsync(GetBookStoreUrl(id.ToString()));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                publishers = JsonConvert.DeserializeObject<Publisher>(responseBody);

                return Ok(publishers);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;
            }
        }

        [HttpGet("GetAuthorBook")]
        public async Task<IActionResult> GetAuthorBooks(int id)//Return list of books & details for the given author
        {
            try
            {
                Author authors = new Author();
                var response = await _client.GetAsync(GetBookStoreUrl(id.ToString()));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                authors = JsonConvert.DeserializeObject<Author>(responseBody);

                return Ok(authors);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;
            }
        }

        [HttpGet("GetPublisherBook")]
        public async Task<IActionResult> GetPublisherBooks(int id)//Return list of books & details for the given publisher
        {
            try
            {
                Publisher publishers = new Publisher();
                var response = await _client.GetAsync(GetBookStoreUrl(id.ToString()));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                publishers = JsonConvert.DeserializeObject<Publisher>(responseBody);

                return Ok(publishers);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;
            }
        }



        [HttpPost("AddBookToStock")]
        public async Task<IActionResult> AddBookToStock(Book book)//Add given book details into stock.
        {
            try
            {
                var myContent = JsonConvert.SerializeObject(book);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //_client.DefaultRequestHeaders.Add("access-token", _token);
                using var responseStream = await _client.PostAsync(CreateBookStoreUrl(), byteContent);
                if (responseStream != null)
                {
                    var jsonString = await responseStream.Content.ReadAsStringAsync();

                    // var result = JsonConvert.DeserializeObject<Customer>(jsonString);
                    return Ok(jsonString);
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                return null;

            }
        }

        [HttpGet("IsValidISBN")]
        public async Task<IActionResult> IsValidISBN(int isbnNo)
        {
            try
            {
                using var responseStream = await _client.GetAsync(ValidateBookStoreUrl(isbnNo.ToString()));
                if (responseStream != null)
                {
                    if (responseStream.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Ok();
                    }
                }
                return NotFound();

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong!" + e.Message);
                throw new Exception(e.Message);
            }
        }




    }
}
