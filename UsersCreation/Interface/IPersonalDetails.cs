using Microsoft.AspNetCore.Mvc;
using UsersCreation.Models;

namespace UsersCreation.Interface
{
    public interface IPersonalDetails
    {
        PersonalDetails AddPersonalDetails(PersonalDetailsDto personalDetailsDto);
        IEnumerable<PersonalDetails> GetAllPersonalDetails();
    }
}
