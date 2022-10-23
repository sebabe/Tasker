using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext dataContext){

            if (dataContext.Todos.Any()) return;

            var toDos = new List<ToDo>{
                new ToDo{
                    Title = "Title 1",
                    Description = "Description 1"
                },
                new ToDo{
                    Title = "Title 2",
                    Description = "Description 2"
                },
                new ToDo{
                    Title = "Title 3",
                    Description = "Description 3"
                }
            };

            await dataContext.Todos.AddRangeAsync(toDos);
            await dataContext.SaveChangesAsync(); 
        } 
    }
}