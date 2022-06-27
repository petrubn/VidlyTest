using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Web.Services.Description;
using VidlyTest.Models;
using DbContext = System.Data.Entity.DbContext;

public class Context : DbContext
{
    
    public System.Data.Entity.DbSet<Movie> Movies { get; set; }
    public System.Data.Entity.DbSet<Customer> Customers { get; set; }
    public System.Data.Entity.DbSet<MembershipType> MembershipTypes { get; set; }
    public System.Data.Entity.DbSet<Genre> Genres { get; set; }
    
    
    /*
    public Context() : base("Server=DESKTOP-K0UC1SE\\MSSQLSERVER01;Database=Vidly;User Id=Petru;Password=test;MultipleActiveResultSets=True") 
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
    }
    */

    public Context() : base(@"Server=DESKTOP-K0UC1SE\MSSQLSERVER01;Database=Vidly;User Id=Petru;Password=test;")
    {
        Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
    }
    
}