using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/LoanLeaseOption")]
public class LoanLeaseOptionController : CRUDController<LoanLeaseOption> {
    public LoanLeaseOptionController(IRepository<LoanLeaseOption> r) : base(r){}

    // [HttpGet("search")]
    // public IActionResult Search([FromQuery]string term, int listId = -1){
    //     return Ok(r.Read(dbset => dbset.Where(LoanLeaseOption => 
    //         LoanLeaseOption.Title.ToLower().IndexOf(term.ToLower()) != -1
    //         || LoanLeaseOption.Text.ToLower().IndexOf(term.ToLower()) != -1
    //     )));
    // }
}


//Applicant API for Debuging purposes
[Route("/api/Applicant")]
public class ApplicantController : CRUDController<Applicant> {
    public ApplicantController(IRepository<Applicant> r) : base(r){}
}

[Route("/api/Projects")]
public class ProjectController : CRUDController<Project> {
    public ProjectController(IRepository<Project> r) : base(r){}

    [HttpPost("Approval")]
    public IActionResult Post([FromBody] Project item){
        if(!ModelState.IsValid)
            return BadRequest(ModelState.ToErrorObject());
        r.Create(item);
        return Ok(r.Read());
    }
    
}
