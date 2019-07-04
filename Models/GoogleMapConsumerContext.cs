using Microsoft.EntityFrameworkCore;
namespace GoogleMapConsumer.Models
{
    public class GoogleMapConsumerContext:DbContext
    {
        public GoogleMapConsumerContext(DbContextOptions<GoogleMapConsumerContext> options):base(options){}
        public DbSet<TodoItem> TodoItems{get;set;}
    }
}