using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/Project")]
public class ProjectController : CRUDController<Project> {
    public ProjectController(IRepository<Project> r) : base(r){}

    [HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(Project => 
            Project.Title.ToLower().IndexOf(term.ToLower()) != -1
            || Project.Text.ToLower().IndexOf(term.ToLower()) != -1
        )));
    }
}

[Route("/api/Projectlist")]
public class ProjectListController : CRUDController<ProjectList> {
    public ProjectListController(IRepository<ProjectList> r) : base(r){}
}

[Route("/api/Root")]
public class RootController : CRUDController<Root> {
    public RootController(IRepository<Root> r) : base(r){}
}
