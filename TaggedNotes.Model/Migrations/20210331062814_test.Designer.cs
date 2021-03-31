﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaggedNotes.Model;

namespace TaggedNotes.Model.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20210331062814_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("TaggedNotes.Model.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TaggedNotes.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Selected")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TaggedNotes.Model.TagNoteLink", b =>
                {
                    b.Property<int>("IdTag")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdNote")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdTag", "IdNote");

                    b.HasIndex("IdNote");

                    b.ToTable("TagNoteLinks");
                });

            modelBuilder.Entity("TaggedNotes.Model.TagNoteLink", b =>
                {
                    b.HasOne("TaggedNotes.Model.Note", "Note")
                        .WithMany("TagNoteLinks")
                        .HasForeignKey("IdNote")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaggedNotes.Model.Tag", "Tag")
                        .WithMany("TagNoteLinks")
                        .HasForeignKey("IdTag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("TaggedNotes.Model.Note", b =>
                {
                    b.Navigation("TagNoteLinks");
                });

            modelBuilder.Entity("TaggedNotes.Model.Tag", b =>
                {
                    b.Navigation("TagNoteLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
