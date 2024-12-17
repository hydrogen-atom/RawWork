using Microsoft.EntityFrameworkCore;
using sqlTest.Server.Models;
using Microsoft.AspNetCore.Identity;


namespace sqlTest.Server.Data
{
    public class ArcasDbContext : DbContext
    {
        public ArcasDbContext(DbContextOptions<ArcasDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ExchangeDetails> ExchangeDetails { get; set; }
        public DbSet<ISBNCode> ISBNCodes { get; set; }
        public DbSet<BookID> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置实体关系

            //示例：配置 Comment 与 ISBNCode 的关系
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ISBNCode)
                .WithMany(ic => ic.Comments)
                .HasForeignKey(c => c.ISBN);

            // 配置 Comment 与 Book 的关系
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Book)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.bookID);

            // 配置 Comment 与 User 的关系（评论者）
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Commentator)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CommentatorID);

            // 配置 ExchangeDetails 与 User 的关系（用户A）
            modelBuilder.Entity<ExchangeDetails>()
                .HasOne(ed => ed.UserA)
                .WithMany(u => u.ExchangeDetailsAsA)
                .HasForeignKey(ed => ed.ID_A)
                .OnDelete(DeleteBehavior.Restrict);

            // 配置 ExchangeDetails 与 User 的关系（用户B）
            modelBuilder.Entity<ExchangeDetails>()
                .HasOne(ed => ed.UserB)
                .WithMany(u => u.ExchangeDetailsAsB)
                .HasForeignKey(ed => ed.ID_B)
                .OnDelete(DeleteBehavior.Restrict);

            //// 配置其他关系...
        }
    }
}
