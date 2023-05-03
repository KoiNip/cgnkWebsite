using System.Text.Json;

namespace cgnkWebsite.Models
{
    //This class is a representation of our json objects in data, we created everything in this models folder
    public class Project
    {
        //One property for each json property
        public string Name { get; set; }
        public string Type { get; set; }
        public string Tech { get; set; }
        public string Link { get; set; }
        public string Git { get; set; }

        //This function converts our Project item to a string, the => works as a shorthand for return as f/x has one line of code
        public override string ToString() => JsonSerializer.Serialize<Project>(this);
    }
}
