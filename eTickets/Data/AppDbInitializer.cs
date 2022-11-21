using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinema 
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT49yqjXhawzxqVSTmSE6MkCFhi-FExRdl6cQ&usqp=CAU",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbnPQiigCtJbBnf5QZ2OT62mrySiExAgF6ZA&usqp=CAU",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyab-v4RfVTu48oqKTgC7k2GrTa1Y4CyH8bg&usqp=CAU",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "data:image/png;base64,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",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                    //Actors
                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(new List<Actor>()
                        {
                            new Actor()
                            {
                                FullName="Actor 1",
                                Bio="This is the Bio of the first Actor",
                                ProfilePictureURL="https://wikibio.in/wp-content/uploads/2018/12/Salman-Khan-Image.jpg",
                            },
                            new Actor()
                            {
                                FullName="Actor 2",
                                Bio="This is the Bio of the second Actor",
                                ProfilePictureURL="https://www.yashrajfilms.com/images/default-source/talent/ayushmann-khhurana-profile.jpg?sfvrsn=ba7bf2cc_2"
                            },
                            new Actor()
                            {
                                FullName="Actor 3",
                                Bio="This is the Bio of the third Actor",
                                ProfilePictureURL=@"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Actors\actor-3.png"
                            },
                            new Actor()
                            {
                                FullName="Actor 4",
                                Bio="This is the Bio of the fourth Actor",
                                ProfilePictureURL=@"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Actors\actor-4.png"
                            },
                            new Actor()
                            {
                                FullName="Actor 5",
                                Bio="This is the Bio of the fifth Actor",
                                ProfilePictureURL=@"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Actors\actor-5.png"
                            },
                        });
                        context.SaveChanges();

                    }
                    //Producers
                    if (!context.Producers.Any())
                    {
                        context.Producers.AddRange(new List<Producer>()
                        {
                            new Producer()
                            {
                                FullName = "Producer 1",
                                Bio = "This is the Bio of the first actor",
                                ProfilePictureURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Producer\producer-1.png"

                            },
                            new Producer()
                            {
                                FullName = "Producer 2",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Producer\producer-2.png"
                            },
                            new Producer()
                            {
                                FullName = "Producer 3",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Producer\producer-3.png"
                            },
                            new Producer()
                            {
                                FullName = "Producer 4",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Producer\producer-4.png"
                            },
                            new Producer()
                            {
                                FullName = "Producer 5",
                                Bio = "This is the Bio of the second actor",
                                ProfilePictureURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Producer\producer-5.png"
                            }
                        });
                        context.SaveChanges();
                        //Movies
                        if (!context.Movies.Any())
                        {
                            context.Movies.AddRange(new List<Movie>()
                            {
                                new Movie()
                                {
                                    Name="Radhe",
                                    Description = "This is the Radhe movie description",
                                    Price = 219.99,
                                    ImageURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Movie\movie-1.png",
                                    StartDate = DateTime.Now.AddDays(-10),
                                    EndDate = DateTime.Now.AddDays(10),
                                    CinemaId = 3,
                                    ProducerId = 3,
                                    MovieCategory = MovieCategory.Action
                                },
                                 new Movie()
                                {
                                    Name="Chandigarh kare Aashiqui",
                                    Description = "This is the Chandigarh kare Aashiqui movie description",
                                    Price = 199.99,
                                    ImageURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Movie\movie-2.png",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(9),
                                    CinemaId = 1,
                                    ProducerId = 1,
                                    MovieCategory = MovieCategory.Drama
                                },
                                  new Movie()
                                {
                                    Name="Atrangi Re",
                                    Description = "This is the Atrangi Re movie description",
                                    Price = 149.99,
                                    ImageURL = "https://wikibio.in/wp-content/uploads/2018/12/Akshay-Kumar.jpg",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    CinemaId = 4,
                                    ProducerId = 4,
                                    MovieCategory = MovieCategory.Comedy
                                },
                                   new Movie()
                                {
                                    Name="Bhuj",
                                    Description = "This is the Bhuj movie description",
                                    Price = 149.99,
                                    ImageURL = "https://wikibio.in/wp-content/uploads/2018/07/Ajay-Devgn.jpg",
                                    StartDate = DateTime.Now.AddDays(-10),
                                    EndDate = DateTime.Now.AddDays(-5),
                                    CinemaId = 1,
                                    ProducerId = 2,
                                    MovieCategory = MovieCategory.Documentary
                                },
                                    new Movie()
                                {
                                    Name="Gangubai kathiawadi",
                                    Description = "This is the gangubai Kathiawadi movie description",
                                    Price = 229.99,
                                    ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8U8LnCN-1krsdc11C1cpmZUthdjKmpP1ooA&usqp=CAU",
                                    StartDate = DateTime.Now.AddDays(-10),
                                    EndDate = DateTime.Now.AddDays(-2),
                                    CinemaId = 1,
                                    ProducerId = 3,
                                    MovieCategory = MovieCategory.Drama
                                },
                                    new Movie()
                                {
                                    Name="India's Daughter",
                                    Description = "This is the India's Daughter movie description",
                                    Price = 249.99,
                                    ImageURL = @"C:\Weekly Practice\C# Training\ASP.Net Examples\eTickets\eTickets\Images\Movie\movie-6.png",
                                    StartDate = DateTime.Now.AddDays(3),
                                    EndDate = DateTime.Now.AddDays(20),
                                    CinemaId = 1,
                                    ProducerId = 5,
                                    MovieCategory = MovieCategory.Documentary
                                 }
                            });
                            context.SaveChanges();

                        }
                        //Actor_Movies
                        if (!context.Actors_Movies.Any())
                        {
                            context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                            context.SaveChanges();

                        }
                    }
                }
            }
        }
    }
}

