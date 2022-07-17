using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MoviesAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {

            if (context.Users.Any()
                && context.Movies.Any()
                && context.MovieImages.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User
                {
                    Name = "Rodrigo",
                    UserName = "rod",
                    Role = UserRoleType.Admin
                },
                new User
                {
                    Name = "Alejandro",
                    UserName = "alj",
                    Role = UserRoleType.Client
                },
                new User
                {
                    Name = "Bryan",
                    UserName = "Bry",
                    Role = UserRoleType.Client,
                    LikedMovies = new List<Movie>
                    {
                        new Movie
                        {
                            Title = "3 Idiots",
                            Description = "Indie movie",
                            Stock = 0,
                            RentalPrice = 7.99,
                            SalePrice = 12,
                            Availability = false,
                            Images = new List<MovieImage>
                            {
                                new MovieImage
                                {
                                    UrlImage = "https://theobjectivestandard.com/wp-content/uploads/2022/03/3-Idiots-Written-and-Directed-by-Rajkumar-Hirani.jpg"
                                }
                            }
                        }
                    }
                }
            };

            var movies = new Movie[]
            {
                new Movie
                {
                    Title = "Star Wars: Phantom Menace",
                    Description = "Star Wars episode 1",
                    Stock = 10,
                    RentalPrice = 7.99,
                    SalePrice = 12,
                    Availability = true,
                    Images = new List<MovieImage>
                    {
                        new MovieImage
                        {
                            UrlImage = "https://static.wikia.nocookie.net/starwars/images/7/75/EPI_TPM_poster.png/revision/latest/scale-to-width-down/1000?cb=20130822171446"
                        }
                    }
                },
                new Movie
                {
                    Title = "Star Wars: Attack Of The Clones",
                    Description = "Star Wars episode 2",
                    Stock = 10,
                    RentalPrice = 7.99,
                    SalePrice = 12,
                    Availability = true,
                    Images = new List<MovieImage>
                    {
                        new MovieImage
                        {
                            UrlImage = "https://static.wikia.nocookie.net/starwars/images/d/dd/Attack-Clones-Poster.jpg/revision/latest?cb=20180318125654"
                        },
                        new MovieImage
                        {
                            UrlImage = "https://static.wikia.nocookie.net/starwars/images/b/bf/Episodeiidvd.jpg/revision/latest/scale-to-width-down/1000?cb=20220701220121"
                        }
                    }
                },
                new Movie
                {
                    Title = "Star Wars: Revenge Of The Sith",
                    Description = "Star Wars episode 3",
                    Stock = 10,
                    RentalPrice = 7.99,
                    SalePrice = 12,
                    Availability = true,
                    Images = new List<MovieImage>
                    {
                        new MovieImage
                        {
                            UrlImage = "https://static.wikia.nocookie.net/starwars/images/e/e7/EPIII_RotS_poster.png/revision/latest/scale-to-width-down/1000?cb=20130822174232"
                        }
                    }
                }
            };

            context.Users.AddRange(users);
            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}