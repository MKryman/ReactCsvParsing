using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Homework_06_12.Data;
using Faker;


namespace Homework_06_12.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString;

        public PeopleController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getall")]
        public List<Person> GetAllPeople()
        {
            var repo = new PersonRepository(_connectionString);
            return repo.GetAllPeople();
        }

        [HttpGet]
        [Route("generate")]
        public IActionResult GenerateCSV(int amount)
        {
            var people = GenerateFakePeople(amount);
            var csv = BuildCsv(people);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "fakePeople.csv");
        }


        [HttpPost]
        [Route("deleteall")]
        public void DeleteInfo()
        {
            var repo = new PersonRepository(_connectionString);
            repo.DeleteAll();
        }


        [HttpPost]
        [Route("uploadfile")]
        public void Upload(UploadViewModel vm)
        {
            string base64 = vm.Base64.Substring(vm.Base64.IndexOf(",") + 1);
            byte[] csvBytes = Convert.FromBase64String(base64);
            var repo = new PersonRepository(_connectionString);
            var ppl = GetFromCsvBytes(csvBytes);
            repo.AddPeople(ppl);
        }

        private static List<Person> GenerateFakePeople(int amount)
        {
            List<Person> ppl = new();
            for (int i = 1; i <= amount; i++)
            {
                ppl.Add(new Person
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Age = Faker.RandomNumber.Next(20, 85),
                    Address = Faker.Address.StreetAddress(),
                    Email = Faker.Internet.Email()
                });
            }
            return ppl;
        }

        private static string BuildCsv(List<Person> people)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);
            var csv = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csv.WriteRecords(people);
            return builder.ToString();
        }

        private List<Person> GetFromCsvBytes(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);
            var streamReader = new StreamReader(memoryStream);
            using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return reader.GetRecords<Person>().ToList();
        }
    }
}
