﻿// <auto-generated />
using System;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Conversation.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ConversationDbContext))]
    [Migration("20230912191052_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Conversation.Api.Domain.Models.EmailConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("NewEmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldEmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("emailconfirmation", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("entry", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreateById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("EntryId");

                    b.ToTable("entrycomment", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryCommentFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryCommentId");

                    b.ToTable("entrycommentfavorite", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryCommentVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VoteType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryCommentId");

                    b.ToTable("entrycommentvote", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryId");

                    b.ToTable("entryfavorite", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VoteType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("entryvote", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("user", "dbo");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.Entry", b =>
                {
                    b.HasOne("Conversation.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("Entries")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryComment", b =>
                {
                    b.HasOne("Conversation.Api.Domain.Models.User", "CreateBy")
                        .WithMany("EntriesComments")
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Conversation.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryComments")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreateBy");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryCommentFavorite", b =>
                {
                    b.HasOne("Conversation.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Conversation.Api.Domain.Models.EntryComment", "EntryComment")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("EntryComment");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryCommentVote", b =>
                {
                    b.HasOne("Conversation.Api.Domain.Models.EntryComment", "EntryComment")
                        .WithMany("EntryCommentVotes")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryComment");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryFavorite", b =>
                {
                    b.HasOne("Conversation.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Conversation.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryVote", b =>
                {
                    b.HasOne("Conversation.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryVotes")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.Entry", b =>
                {
                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.EntryComment", b =>
                {
                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryCommentVotes");
                });

            modelBuilder.Entity("Conversation.Api.Domain.Models.User", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("EntriesComments");

                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
