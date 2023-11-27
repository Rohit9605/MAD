namespace MyFirstMobileApp.Models.Entities
{
    public class Teletubbies
    {
        public string NameOfTeletubby { get; set; }

        public Teletubbies() 
        { 
            NameOfTeletubby = string.Empty;
        }

        public Teletubbies(string name)
        {
            //Constructor with parameter (Overloaded)
            NameOfTeletubby = name;
        }

        public static List<Teletubbies> GetTeletubbies()
        {
            return new List<Teletubbies>
            {
                new Teletubbies(" A New Hope "),
                new Teletubbies(" The Empire Strikes Back "),
                new Teletubbies(" Return of the Jedi "),
                new Teletubbies(" The Phantom Menace "),
                new Teletubbies(" Attack of the Clones "),
                new Teletubbies(" Revenge of the Sith ")
            };
        }
    }
}
