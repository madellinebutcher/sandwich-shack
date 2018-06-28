using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using sandwich_shack.Models;

namespace sandwich_shack.Repositories
{
  public class SandwichRepository
  {
    //Fake DB
    // public static List<Sandwich> Sandwiches = new List<Sandwich>()
        // {
        //     new Sandwich(6.99m, "Breakfast Sandwich", "Breakfast put nicely together.",new List<string>(){
        //             "Eggs",
        //             "Bacon",
        //             "Wheat Bread"
        //         }),
        //     new Sandwich(9.99m, "Meat Me", "Great sandwich for meat lovers to meat.", new List<string>(){
        //             "Bacon",
        //             "Beef",
        //             "Sausage",
        //             "Jalapeno Bread"

        //         }),
        //     new Sandwich(7.99m, "Honey Bacon Club", "Made simple.", new List<string>(){
        //             "Bacon",
        //             "Honey Ham",
        //             "White Bread",
                    
        //         })
        // };
    private readonly IDbConnection _db;

    public SandwichRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Sandwich> GetAll()
    {
      return _db.Query<Sandwich>("SELECT * FROM sandwiches");
    }


    public Sandwich GetById(int id)
    {
        return _db.Query<Sandwich>("SELECT * FROM Sandwiches WHERE id=@id", new{id}).FirstOrDefault();
    }

    public Sandwich AddSandwich(Sandwich newSandwich)
    {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO sandwiches (name, price, description) 
        VALUES(@Name, @Price, @Description); 
        SELECT LAST_INSERT_ID()", newSandwich);
        newSandwich.Id = id;
        return newSandwich;
    }

    //edit

    //delete
  }
}