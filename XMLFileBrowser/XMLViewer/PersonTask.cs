using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    public class PersonTasks
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<PersonSubTasks> SubTasks { get; }

        public PersonTasks(int id, string title, string description, IEnumerable<PersonSubTasks> subTasks)
        {
            Id = id;
            Title = title;
            Description = description;
            SubTasks = subTasks;
        }
    }
}
