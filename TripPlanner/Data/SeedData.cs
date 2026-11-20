using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Models;

namespace TripPlanner.Data
{
    public class SeedData
    {
        private const string ToDo = "To Do";
        private const string InProgress = "In Progress";
        private const string Done = "Done";
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var db = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            if (await db.Trips.AnyAsync()) return;
            var daniel = await CreateUserAsync(userManager, "dan@test.com");
            var bogdan = await CreateUserAsync(userManager, "bogdan@test.com");
            var andrei = await CreateUserAsync(userManager, "andrei@test.com");
            var maria = await CreateUserAsync(userManager, "maria@test.com");
            var diana = await CreateUserAsync(userManager, "diana@test.com");


            //Trips
            
            var rome= new Trip
            {
                Title = "City Break in Rome",
                Destination = "Rome, Italy",
                Description = "Four days to explore Rome and eat plenty of pizza, pasta and gelato.",
                StartDate = new DateTime(2027,5,4),
                EndDate = new DateTime(2027,5,7),
                OrganizerId = daniel.Id
            };

            rome.Participants.Add(bogdan);
            rome.Participants.Add(andrei);
            rome.Participants.Add(maria);
            rome.Participants.Add(diana);
            rome.Participants.Add(daniel);



            var sibiu = new Trip
            {
                Title = "Weekend in Sibiu",
                Destination = "Sibiu, Romania",
                Description = "A weekend exploring the old town and the museums in the city center.",
                StartDate = new DateTime(2026, 12, 04),
                EndDate = new DateTime(2026, 12, 06),
                OrganizerId = andrei.Id
            };
            sibiu.Participants.Add(daniel);
            sibiu.Participants.Add(bogdan);
            sibiu.Participants.Add(andrei);


            var paris = new Trip
            {
                Title= "Trip to Paris",
                Destination = "Paris, France",
                Description = "Five days in Paris: the Eiffel Tower, the Louvre, Opera Garnier.",
                StartDate = new DateTime(2027, 02, 27),
                EndDate = new DateTime(2027, 03, 03),
                OrganizerId = bogdan.Id
            };
            paris.Participants.Add(daniel);
            paris.Participants.Add(diana);
            paris.Participants.Add(maria);
            paris.Participants.Add(bogdan);

            //Activities sibiu
            var museum = new Activity
            {
                Title = "Visit the ASTRA Village Museum",
                Description = "An open-air museum with traditional houses",
                Status = ToDo,
                StartTime = new DateTime(2026, 12, 5, 11, 0, 0),
                EndTime = new DateTime(2026, 12, 5, 16, 0, 0),
                MediaType = "Image",
                AssignedUserId = andrei.Id
            };
            museum.Comments.Add(new Comment
            {
                Text = "Worth seeing, the old houses are amazing.",
                PostedAt = DateTime.Now.AddHours(-6),
                UserId = bogdan.Id
            });
            var dinner = new Activity
            {
                Title = "Dinner",
                Description = "Evening meal at a restaurant on the square.",
                Status = ToDo,
                StartTime = new DateTime(2026, 12, 5, 19, 0, 0),
                EndTime = new DateTime(2026, 12, 5, 21, 0, 0),
                MediaType = "Image",
                AssignedUserId = daniel.Id
            };
            sibiu.Activities.Add(museum);
            sibiu.Activities.Add(dinner);

            //activities paris
            var flights = new Activity
            {
                Title = "Book the flights to Paris",
                Description = "Direct round-trip flights, with one checked bag for each traveler.",
                Status = Done,
                StartTime = new DateTime(2026, 11, 01, 9, 0, 0),
                EndTime = new DateTime(2026, 11, 19, 18, 0, 0),
                MediaType = "Image",
                AssignedUserId = daniel.Id
            };

            flights.Comments.Add(new Comment
            {
                Text = "Which airport should we fly into, Charles de Gaulle or Orly?",
                PostedAt = DateTime.Now.AddHours(-4),
                UserId = maria.Id
            });
            flights.Comments.Add(new Comment
            {
                Text = "Orly is closer to the city center by metro, but I'll check which one has the cheaper direct flight from Bucharest.",
                PostedAt = DateTime.Now.AddHours(-2),
                UserId = daniel.Id
            });


            var louvreTickets = new Activity
            {
                Title = "Buy the Louvre tickets",
                Description = "Skip-the-line tickets for the second day.",
                Status = InProgress,
                StartTime = new DateTime(2026, 11, 16, 9, 0, 0),
                EndTime = new DateTime(2027, 01, 10, 18, 0, 0),
                MediaType = "Image",
                AssignedUserId = diana.Id
            };

            louvreTickets.Comments.Add(new Comment
            {
                Text = "Let's go in the morning, it's less crowded.",
                PostedAt = DateTime.Now.AddHours(-8),
                UserId = maria.Id
            });

            var operaGarnier = new Activity
            {
                Title = "Book the Opera Garnier visit",
                Description = "Tour of the Opera Garnier, if possible on the third day.",
                Status = ToDo,
                StartTime = new DateTime(2027, 01, 03, 9, 0, 0),
                EndTime = new DateTime(2027, 01, 20, 18, 0, 0),
                MediaType = "Image"
                
            };
            var eiffelTickets = new Activity
            {
                Title = "Buy the Eiffel Tower tickets",
                Description = "Evening tickets with access to the top.",
                Status = ToDo,
                StartTime = new DateTime(2026, 12, 14, 9, 0, 0),
                EndTime = new DateTime(2026, 12, 21, 18, 0, 0),
                MediaType = "Image",
                AssignedUserId = daniel.Id
            };
            paris.Activities.Add(flights);
            paris.Activities.Add(louvreTickets);
            paris.Activities.Add(operaGarnier);
            paris.Activities.Add(eiffelTickets);

            //acitivities - rome
            var romeFlights = new Activity
            {
                Title = "Book the flights to Rome",
                Description = "Direct round-trip flights, with one checked bag for each traveler.",
                Status = InProgress,
                StartTime = new DateTime(2026, 10, 01, 10, 0, 0),
                EndTime = new DateTime(2026, 12, 21, 20, 0, 0),
                MediaType = "Image",
                AssignedUserId = andrei.Id
            };
            var accommodation = new Activity
            {
                Title = "Book accommodation",
                Description = "A budget friendly apartment, with free cancellation.",
                Status = ToDo,
                StartTime = new DateTime(2026, 12, 14, 9, 0, 0),
                EndTime = new DateTime(2027, 02, 14, 18, 0, 0),
                MediaType = "Image",
                AssignedUserId = bogdan.Id
            };
            var restaurants = new Activity
            {
                Title = "Find the best places to eat",
                Description = "Research traditional trattorias and local favorites.",
                Status = Done,
                StartTime = new DateTime(2026, 11, 10, 9, 0, 0),
                EndTime = new DateTime(2026, 11, 19, 18, 0, 0),
                MediaType = "Image",
                AssignedUserId = maria.Id
            };
            var colosseum = new Activity
            {
                Title = "Visit the Colosseum",
                Description = "Guided tour on the first morning.",
                Status = ToDo,
                StartTime = new DateTime(2027, 5, 5, 9, 0, 0),
                EndTime = new DateTime(2027, 5, 5, 13, 0, 0),
                MediaType = "Image"
            };
            rome.Activities.Add(romeFlights);
            rome.Activities.Add(accommodation);
            rome.Activities.Add(restaurants);
            rome.Activities.Add(colosseum);

            db.Trips.AddRange(sibiu, paris, rome);
            await db.SaveChangesAsync();
        }


      

        private static async Task<IdentityUser> CreateUserAsync(UserManager<IdentityUser> userManager, string email)
        {
            var exist = await userManager.FindByEmailAsync(email);
            if (exist!=null) return exist;

            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed=true

            };
            var result = await userManager.CreateAsync(user, "Testare123.!");
            if (!result.Succeeded)
                throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

            return user;
        }


    }
}
