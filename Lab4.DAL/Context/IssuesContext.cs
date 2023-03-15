using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class IssuesContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();

    public IssuesContext(DbContextOptions<IssuesContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":20,"Title":"in","Description":"Harum hic impedit dolore voluptate placeat.","Severity":1},{"Id":1,"Title":"id","Description":"Rerum totam est quo possimus sunt sunt ad.","Severity":0},{"Id":2,"Title":"dicta","Description":"Id cumque explicabo beatae.","Severity":1},{"Id":3,"Title":"eius","Description":"Consectetur beatae dolorem voluptates occaecati.","Severity":0},{"Id":4,"Title":"assumenda","Description":"Nulla est doloribus ut non aspernatur vero dolores.","Severity":2},{"Id":5,"Title":"ex","Description":"Et praesentium est ipsum eligendi rerum itaque voluptate quia.","Severity":1},{"Id":6,"Title":"velit","Description":"Optio non debitis ut molestiae dolorem ad.","Severity":2},{"Id":7,"Title":"voluptas","Description":"Dolor quae iure quas error est.","Severity":2},{"Id":8,"Title":"recusandae","Description":"Iste molestiae aut inventore necessitatibus necessitatibus perspiciatis sit.","Severity":2},{"Id":9,"Title":"qui","Description":"Voluptas expedita placeat ad sint consequuntur.","Severity":0},{"Id":10,"Title":"autem","Description":"Voluptates qui sed aliquid laudantium in.","Severity":0},{"Id":11,"Title":"totam","Description":"Placeat non repellat qui libero.","Severity":1},{"Id":12,"Title":"enim","Description":"Debitis vero laborum asperiores deserunt nihil tempora quia.","Severity":2},{"Id":13,"Title":"natus","Description":"Voluptatibus a et natus ipsa at quis rem dolores.","Severity":0},{"Id":14,"Title":"et","Description":"Dolorem qui animi sint ad facere ut ullam voluptatem repellendus.","Severity":1},{"Id":15,"Title":"aut","Description":"Sint suscipit delectus accusamus distinctio earum aliquam.","Severity":2},{"Id":16,"Title":"et","Description":"Et vel tempora.","Severity":0},{"Id":17,"Title":"iusto","Description":"Aut atque officiis numquam mollitia voluptas dolore.","Severity":1},{"Id":18,"Title":"facere","Description":"Ipsum mollitia sit officiis sapiente natus.","Severity":2},{"Id":19,"Title":"recusandae","Description":"Inventore aut reprehenderit vitae ratione dolorum harum.","Severity":2}]""") ?? new();

        modelBuilder.Entity<Ticket>().HasData(tickets);

    }
}
