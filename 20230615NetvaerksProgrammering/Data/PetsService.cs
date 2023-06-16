using System.Data.SqlClient;

namespace _20230615NetvaerksProgrammering.Data;

public class PetsService
{
    //Connection string shouldnt be public accessable
    private string conString = "Data Source=192.168.1.2;Initial Catalog=Pets;User ID=sa;Password=Passw0rd;";

    public Pets ReadPets()
    {
        //int id, string? name, string? brand, int rAM, string? gPU, string? cPU, float price)

        return new Pets(1, "John", "Cat", "Sphinx", "Pink", 15, 6000);
    }

    public List<Pets> ReadPets(string query)
    {
        List<Pets> list = new();
        using (SqlConnection con = new(conString))
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pets pets = new();
                pets.Id = (int)reader[0];
                pets.Name = (string)reader[1];
                pets.Species = (string)reader[2];
                pets.Breed = (string)reader[3];
                pets.Colour = (string)reader[4];
                pets.Speed = (int)reader[5];
                pets.Price = (double)reader[6];
                list.Add(pets);
            }
            con.Close();
        }
        return list;
    }

    public void CreatePet(Pets pet)
    {
        using (SqlConnection con = new(conString))
        {
            string query = $"INSERT INTO Pets ([Name], Species, Breed, Colour, Speed, Price) VALUES (@Name, @Species, @Breed, @Colour, @Speed, @Price)";
            SqlCommand cmd = new SqlCommand(query, con);
            if (pet.Name == null) pet.Name = "Name Not Set";
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = pet.Name;
            if (pet.Species == null) pet.Species = "Species Not Set";
            cmd.Parameters.Add("@Species", System.Data.SqlDbType.NVarChar).Value = pet.Species;
            if (pet.Breed == null) pet.Breed = "Breed Not Set";
            cmd.Parameters.Add("@Breed", System.Data.SqlDbType.NVarChar).Value = pet.Breed;
            if (pet.Colour == null) pet.Colour = "Colour Not Set";
            cmd.Parameters.Add("@Colour", System.Data.SqlDbType.NVarChar).Value = pet.Colour;
            cmd.Parameters.Add("@Speed", System.Data.SqlDbType.Int).Value = pet.Speed;
            cmd.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = pet.Price;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void DeletePet(int id)
    {
        using (SqlConnection con = new(conString))
        {
            string query = $"DELETE FROM Pets WHERE Id = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void UpdatePet(Pets pet)
    {
        using (SqlConnection con = new(conString))
        {
            //ToDo Set Set values in query
            string query = $"UPDATE Pets SET [Name] = @Name, Species=@Species, Breed=@Breed, Colour=@Colour, Speed=@Speed, Price=@Price WHERE id = {pet.Id}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = pet.Id;
            if (pet.Name == null) pet.Name = "Name Not Set";
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = pet.Name;
            if (pet.Species == null) pet.Species = "Species Not Set";
            cmd.Parameters.Add("@Species", System.Data.SqlDbType.NVarChar).Value = pet.Species;
            if (pet.Breed == null) pet.Breed = "Breed Not Set";
            cmd.Parameters.Add("@Breed", System.Data.SqlDbType.NVarChar).Value = pet.Breed;
            if (pet.Colour == null) pet.Colour = "Colour Not Set";
            cmd.Parameters.Add("@Colour", System.Data.SqlDbType.NVarChar).Value = pet.Colour;
            cmd.Parameters.Add("@Speed", System.Data.SqlDbType.Int).Value = pet.Speed;
            cmd.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = pet.Price;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
