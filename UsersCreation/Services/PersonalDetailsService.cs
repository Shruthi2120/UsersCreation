using System.ComponentModel.DataAnnotations;
using UsersCreation.Interface;
using UsersCreation.Models;

namespace UsersCreation.Services
{
    public class PersonalDetailsService : IPersonalDetails
    {
        private static List<PersonalDetails> _personalDetails;
       public PersonalDetailsService()
        {
            _personalDetails = new List<PersonalDetails>
            {
                new PersonalDetails
                {
                    id = 1,
                    firstName = "Shruthi",
                    lastName = "Naligeshi",
                    email = "shruthi@gmail.com",
                    dateOfBirth = new DateTime(2000, 1, 2),
                    phoneNumber = "123-456-7890",
                    fullName = "Shruthi Naligeshi",
                    age = CalculateAge(new DateTime(2000, 1, 2)),
                    createdDate = DateTime.Now,
                    updateDate = DateTime.Now
                },
            };
        }
            public PersonalDetails AddPersonalDetails(PersonalDetailsDto personalDetailsDto)
        {
                foreach (var existDetails in _personalDetails) 
                {
                    if(existDetails.email == personalDetailsDto.email)
                    {
                        existDetails.firstName = personalDetailsDto.firstName;
                        existDetails.lastName = personalDetailsDto.lastName;
                        existDetails.email = personalDetailsDto.email;
                        existDetails.phoneNumber = personalDetailsDto.phoneNumber;
                        existDetails.dateOfBirth = personalDetailsDto.dateOfBirth;
                        existDetails.fullName = $"{existDetails.firstName} {existDetails.lastName}";
                        existDetails.age = CalculateAge(existDetails.dateOfBirth);
                        existDetails.createdDate = DateTime.Now;
                        existDetails.updateDate = DateTime.Now;
                        return existDetails;
                    }
                }
                var addedDetails = new PersonalDetails
                {
                    firstName = personalDetailsDto.firstName,
                    lastName = personalDetailsDto.lastName,
                    email = personalDetailsDto.email,
                    phoneNumber = personalDetailsDto.phoneNumber,
                    dateOfBirth = personalDetailsDto.dateOfBirth,
                    fullName = $"{personalDetailsDto.firstName} {personalDetailsDto.lastName}",
                    age = CalculateAge(personalDetailsDto.dateOfBirth),
                    createdDate = DateTime.Now,
                    updateDate = DateTime.Now,
                };
                _personalDetails.Add(addedDetails);
                return addedDetails;
        }

        public IEnumerable<PersonalDetails> GetAllPersonalDetails()
        {
            return _personalDetails.Select(details => new PersonalDetails
            {
                firstName = details.firstName,
                lastName = details.lastName,
                email = details.email,
                dateOfBirth = details.dateOfBirth,
                phoneNumber = details.phoneNumber,
                fullName = details.fullName,
                age = details.age,
            });
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateOfBirth.Year;

            if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age;
        }
    }
}
