using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    public class Person
    {
        public int Id { get; }

        public string Name { get; }

        public int Age { get; }

        public IEnumerable<PersonTasks> Tasks { get; }

        public Person(int id, string name, int age, IEnumerable<PersonTasks> tasks)
        {
            Id = id;
            Name = name;
            Age = age;
            Tasks = tasks;
        }
    }
}
