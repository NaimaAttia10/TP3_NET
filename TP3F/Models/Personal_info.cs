using System.Data.SQLite;
namespace TP3F.Models
{
    public class Personal_info

    {
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\NaimaAttia\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                  //    DateTime date_birth = Convert.ToDateTime(reader["date_birth"].ToString());
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        list.Add(new Person(id, first_name, last_name, email, image, country/*date_birth*/));
                    }
                }
            }

            return list;
        }
        public Person GetPerson(int id)
        {
            List<Person> list = GetAllPerson();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == id)
                {
                    return list[i];
                }
            }
            return null;

        }
    }
}

