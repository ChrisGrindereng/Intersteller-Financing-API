// using Microsoft.AspNetCore.Mvc;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Session;
// using Microsoft.AspNetCore.Http;
// using System;
// using System.Threading.Tasks;
// using System.Collections.Generic;
// using System.Collections.Immutable;
// using System.Collections.Concurrent;
// using System.Collections.ObjectModel;
// using System.Collections.Specialized;
// using System.IO;
// using Microsoft.Extensions.Options;
// using Microsoft.Net.Http.Headers;


// [Route("/")]
// public class HomeController : Controller
// {
//     private IRepository<Applicant> Applicants;
//     private IRepository<LoanLeaseOption> lists;
//     private IRepository<Project> Projects;
//     public HomeController(IRepository<Applicant> Applicants, IRepository<LoanLeaseOption> LoanOptions, IRepository<Project> Projects)
//     {
//         this.Applicants = Applicants;
//         this.lists = lists;
//         this.Projects = Projects;
//     }


//     [HttpGet("/{username?}")]
//     [HttpGet("home/index/{username?}")]
//     public IActionResult Root(string username = "you")
//     {
//         // Console.WriteLine(HttpContext);
//         ViewData["Message"] = "Some extra info can be sent to the view";
//         ViewData["Username"] = username;
//         return View("Index"); // View(new Student) method takes an optional object as a "model", typically called a ViewModel
//     }


//     // [HttpGet("sql/Applicants")] // ?sql=....
//     // public IActionResult SqlApplicants([FromQuery]string sql) => Ok(Applicants.FromSql(sql));


//     // [HttpGet("sql/lists")] // ?sql=....
//     // public IActionResult SqlLists([FromQuery]string sql) => Ok(lists.FromSql(sql));


//     // [HttpGet("sql/Projects")] // ?sql=....
//     // public IActionResult SqlProjects([FromQuery]string sql) => Ok(Projects.FromSql(sql));


//     // Handle file uploads?
//     // <form method="post" enctype="multipart/form-data">
//     //     <input type="file" name="files" id="files" multiple />
//     //     <input type="submit" value="submit" />
//     // </form>
//     [HttpPost]
//     public async Task<IActionResult> Index(IList<IFormFile> files)
//     {
//         foreach (var file in files)
//         {
//             var fileName = ContentDispositionHeaderValue
//                 .Parse(file.ContentDisposition)
//                 .FileName
//                 .Trim('"');// FileName returns "fileName.ext"(with double quotes) in beta 3

//             if (fileName.EndsWith(".txt"))// Important for security if saving in webroot
//             {
//                 // take file and store as Postgres Blob
//             }
//         }
//         return RedirectToAction("Index");
//     }
// }