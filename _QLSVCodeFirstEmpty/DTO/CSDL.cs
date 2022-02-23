using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace _QLSVCodeFirstEmpty.DTO
{
    public class CSDL : DbContext
    {
        // Your context has been configured to use a 'CSDL' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_QLSVCodeFirstEmpty.DTO.CSDL' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CSDL' 
        // connection string in the application configuration file.
        public CSDL()
            : base("name=CSDL")
        {
            Database.SetInitializer<CSDL>(new CreateDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<LSH> LSHes { get; set; }
       
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}