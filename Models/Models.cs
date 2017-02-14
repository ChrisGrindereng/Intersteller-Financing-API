using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


//Loan Lease Option Model
//one possible loan option
public class LoanLeaseOption : HasId
{
    [Required]
    public int Id { get; set; }
    [Required]
    public double percentDown { get; set; }
    [Required]
    
    public double MonthlyPayment { get; set; }

    public int LoanTerm { get; set; }

    public int ProjectId {get;set;}
}


//Applicant Model
//Includes all stored fields for under the applicant 
public class Applicant : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string Address1 {get; set;}
    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string Address2 { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string City { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string state { get; set; }

    public int Zip { get; set; }

    public string Country { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string Email { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 1)]
    public int Phone { get; set; }

    public int ProjectId {get;set;}
}

//Porject Model 
//This will be the Root object of the JSON data
public class Project : HasId {
    [Required]
    public int Id { get; set; }
    
    public int projectNum { get; set; }

    public int revisionNum { get; set; }
    [Required]
    public LoanLeaseOption LoanOption { get; set; }
    [Required]
    public int FinancialOption { get; set; }
    [Required]
    public int installerXREF { get; set; }
    [Required]
    public Applicant applicant { get; set; }
    [Required]
    public Applicant coapplicant { get; set; }
    [Required]
    public int applicantSSN { get; set; }
    [Required]
    public int applicantDriversLicenceNum { get; set; }
    [Required]
    public string StateOnApplicantLicence { get; set; }
    [Required]
    public double houseHoldIncom { get; set; }

    public int AuthorizationNum { get; set; }
    
    public int Returncode { get; set; }
    
    public string Message{ get; set; }

}

// declare the DbSet<T>'s of our DB context, thus creating the tables
public partial class DB : IdentityDbContext<IdentityUser> {
    public DbSet<LoanLeaseOption> LendLeaseOptions { get; set; }
    public DbSet <Applicant> Applicants { get; set; }
    public DbSet<Project> Projects { get; set; }
}

// create a Repo<T> services
public partial class Handler {
    public void RegisterRepos(IServiceCollection services){
        Repo<LoanLeaseOption>.Register(services, "LoanLeaseOptions");
        Repo <Applicant>.Register(services,  "Applicants");
        Repo<Project>.Register(services, "Projects");
            //includes not workining but may be needed down the line
            // d => d.Include(b => b.Applicants).Include(l => l.LendLeaseOptions));
    }
}