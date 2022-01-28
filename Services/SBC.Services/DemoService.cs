namespace SBC.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    using SBC.Common;

    public class DemoService
    {
        private readonly List<Person> demoData = new()
        {
            new Person { FirsName = "Pesho", LastName = "Ivanov", Age = 22, Gender = "Male" },
            new Person { FirsName = "Gosho", LastName = "Georgiev", Age = 30, Gender = "Male" },
            new Person { FirsName = "Tosho", LastName = "Petrov", Age = 33, Gender = "Male" },
            new Person { FirsName = "Ivan", LastName = "Mihov", Age = 20, Gender = "Male" },
        };

        public Result GetAll()
        {
            return new ResultModel(this.demoData);
        }

        public Result GetById(int id)
        {
            return new ResultModel(this.demoData[id]);
        }

        public Result Add(Person person)
        {
            if (this.demoData.Contains(person))
            {
            }
                return new Tuple<HttpStatusCode, string>(HttpStatusCode.BadRequest, "Entity already exist");

        //    this.demoData.Add(person);
         //   return this.demoData.Contains(person);
        }

        public class Person
        {
            public string FirsName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string Gender { get; set; }

        }
    }
}
