using System;

namespace Lab2
{
    public class Team : IComparable<Team>
    {
        public string Name { get; private set; }
        public int Rating { get; private set; }

        public Team(string name, int rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public int CompareTo(Team other) => other?.Rating - this.Rating ?? -1;

        public override string ToString()
        {
            return Name + " : " + Rating;
        }
    }
}