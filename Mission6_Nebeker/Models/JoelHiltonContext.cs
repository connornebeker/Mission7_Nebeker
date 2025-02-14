using Microsoft.EntityFrameworkCore;

namespace Mission6_Nebeker.Models;

public class JoelHiltonContext : DbContext
{
    public JoelHiltonContext(DbContextOptions<JoelHiltonContext> options) : base(options)
    {
        
    }
    
    public DbSet<Application> Applications { get; set; }
}