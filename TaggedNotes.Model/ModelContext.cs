using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TaggedNotes.Interfaces;

namespace TaggedNotes.Model
{

    /// <summary>
    /// Database context for Entity Framework
    /// </summary>
	public class ModelContext : DbContext
	{
        /// <summary>
        /// Table with notes
        /// </summary>
		public DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Table with tags
        /// </summary>
		public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Table with many-to-many relations of tags and notes linked between each other
        /// </summary>
		public DbSet<TagNoteLink> TagNoteLinks { get; set; }

        /// <summary>
        /// Setting connection string for a SQLite databse
        /// </summary>
        /// <param name="options">Settings</param>
        /// <remarks>
        /// TODO: change for app.config initialization
        /// </remarks>
		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=test.db");

        /// <summary>
        /// Many-to-many mapping for linking tags and notes
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagNoteLink>()
                .HasKey(tnl => new { tnl.IdTag, tnl.IdNote });

            modelBuilder.Entity<TagNoteLink>()
                .HasOne(tnl => tnl.Tag)
                .WithMany(tag => tag.TagNoteLinks)
                .HasForeignKey(tnl => tnl.IdTag);

            modelBuilder.Entity<TagNoteLink>()
               .HasOne(tnl => tnl.Note)
               .WithMany(note => note.TagNoteLinks)
               .HasForeignKey(tnl => tnl.IdNote);
        }
    }
}