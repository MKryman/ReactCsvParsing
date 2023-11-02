namespace Homework_06_12.Data
{
    public class PersonRepository
    {
        private readonly string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPeople(List<Person> people)
        {
            var context = new FakerDataContext(_connectionString);
            context.AddRange(people);
            context.SaveChanges();
        }


        public List<Person> GetAllPeople()
        {
            var context = new FakerDataContext(_connectionString);
            return context.People.ToList();
        }

        public void DeleteAll()
        {
            var context = new FakerDataContext(_connectionString);
            context.People.RemoveRange(GetAllPeople());
            context.SaveChanges();
        }
    }
}