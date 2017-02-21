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

public class Project : HasId
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [StringLength(250, MinimumLength = 10)]
    public string Text { get; set; }

    public int ProjectListId {get;set;}
}

public class ProjectList : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Summary { get; set; }
    [Required]
    public List<Project> Projects { get; set; }

    public int RootId {get;set;}
}

public class Root : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public List<ProjectList> Lists { get; set; }
}

// declare the DbSet<T>'s of our DB context, thus creating the tables
public partial class DB : IdentityDbContext<IdentityUser> {
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectList> ProjectLists { get; set; }
    public DbSet<Root> Roots { get; set; }
}

// create a Repo<T> services
public partial class Handler {
    public void RegisterRepos(IServiceCollection services){
        Repo<Project>.Register(services, "Projects");
        Repo<ProjectList>.Register(services, "ProjectLists",
            d => d.Include(l => l.Projects));
        Repo<Root>.Register(services, "Roots",
            d => d.Include(b => b.Lists).ThenInclude(l => l.Projects));
    }
}