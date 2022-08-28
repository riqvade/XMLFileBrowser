using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    public class PersonSubTasks
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PersonSubTasks(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}