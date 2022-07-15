﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAPI.Data;

#nullable disable

namespace MoviesAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("MovieMovieImage", b =>
                {
                    b.Property<int>("ImagesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ImagesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("MovieMovieImage");
                });

            modelBuilder.Entity("MoviesAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Availability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("RentalPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("SalePrice")
                        .HasColumnType("REAL");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesAPI.Models.MovieApproach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Approach")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApproachDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieApproaches");
                });

            modelBuilder.Entity("MoviesAPI.Models.MovieImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlImage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MovieImages");
                });

            modelBuilder.Entity("MoviesAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.Property<int>("LikedMoviesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LikedMoviesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("MovieUser");
                });

            modelBuilder.Entity("MovieMovieImage", b =>
                {
                    b.HasOne("MoviesAPI.Models.MovieImage", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesAPI.Models.MovieApproach", b =>
                {
                    b.HasOne("MoviesAPI.Models.Movie", "Movie")
                        .WithMany("Approaches")
                        .HasForeignKey("MovieId");

                    b.HasOne("MoviesAPI.Models.User", "User")
                        .WithMany("Approaches")
                        .HasForeignKey("UserId");

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.HasOne("MoviesAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("LikedMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesAPI.Models.Movie", b =>
                {
                    b.Navigation("Approaches");
                });

            modelBuilder.Entity("MoviesAPI.Models.User", b =>
                {
                    b.Navigation("Approaches");
                });
#pragma warning restore 612, 618
        }
    }
}