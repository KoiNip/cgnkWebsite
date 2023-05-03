using cgnkWebsite.Models;
using cgnkWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cgnkWebsite.Pages
{
    public class IndexModel : PageModel
    {
        //Logger is used to log things to console, file etc.
        private readonly ILogger<IndexModel> _logger;
        //Create an instance of our service to use
        public JsonFileProjectService _projectService;

        //A list of projects (As IEnumerable) that we can display to website
        public IEnumerable<Project> Projects { get; private set; }

        //If we want to use a service on this page, we must add it to the constructor arguments
        public IndexModel(ILogger<IndexModel> logger, JsonFileProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        //When this page is "get" using HTTP GET
        public void OnGet()
        {
            Projects = _projectService.GetProjects();   //Get our projects using our service, our webpage now has the list of projects
        }
    }
}