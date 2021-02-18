namespace Lab2
{
    public class Team
    {
        public string Name { get; private set; }
        public int Rating { get; private set; }

        public Team(string name, int rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public override string ToString()
        {
            return Name + " : " + Rating;
        }
    }
}