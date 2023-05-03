using System.Text.Json;
using cgnkWebsite.Models;

namespace cgnkWebsite.Services
{
    //This is a service for providing data from our json file to the website
    //Services are a division of work, the service takes care of presenting data to the website for use
    //This service has ONE JOB: Return a list of Project Objects holding all the information in the projects json
    public class JsonFileProjectService
    {
        //Used to easily get the path of the JSON file we want to use
        public IWebHostEnvironment WebHostEnvironment { get; }

        //Constructor
        public JsonFileProjectService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        //Holds the path of the project.json file so we can access it.
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json"); }
        }

        //Returns a list of Project objects containing all of the info from the projects.json
        //Make it case insensitive so we don't worry about that
        //IEnumerable is any object that can be enumerated over, arrays lists etc.
        public IEnumerable<Project> GetProjects()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Project[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
    }
}

/*jsonFileReader.ReadToEnd(),
new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
}
*/