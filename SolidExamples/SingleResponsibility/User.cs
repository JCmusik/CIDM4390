namespace Solid
{
    public class User
    {
        public User(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"{ this.FirstName } { this.LastName }";
    }
}