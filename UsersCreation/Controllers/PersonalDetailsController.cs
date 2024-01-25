using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersCreation.Interface;
using UsersCreation.Models;
using UsersCreation.Services;

namespace UsersCreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetails _personalDetails;
        public PersonalDetailsController(IPersonalDetails personalDetails)
        {
            _personalDetails = personalDetails;      
        }

        [HttpPost]
        public ActionResult<PersonalDetails> AddPersonalDetails([FromBody] PersonalDetailsDto personalDetailsDto)
        {
            if (string.IsNullOrWhiteSpace(personalDetailsDto.email))
            {
                return BadRequest("Email cannot be null or empty.");
            }

            var result = _personalDetails.AddPersonalDetails(personalDetailsDto);

            if (result == null)
                return BadRequest("Email not found");

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonalDetailsDto>> GetPersonalDetails()
        {
            var allPersonalDetails = _personalDetails.GetAllPersonalDetails();
            return Ok(allPersonalDetails);
        }
    }
}
