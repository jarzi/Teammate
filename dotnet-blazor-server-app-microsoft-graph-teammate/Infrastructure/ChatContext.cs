using Microsoft.EntityFrameworkCore;
using Teammate.Infrastructure.Entities;

namespace Teammate.Infrastructure
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }

        public DbSet<ChatMessageAnalysis> MessageAnalysis { get; set; }
    }
}