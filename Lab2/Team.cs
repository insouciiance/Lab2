﻿using System;

namespace Lab2
{
    public class Team : IComparable<Team>, IEquatable<Team>
    {
        public string Name { get; private set; }
        public int Rating { get; set; }
    
        public int Scored { get; set; }
        public int Missed { get; set; }

        public Team(string name, int rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public Team(string name, int rating, int scored, int missed) : this(name, rating)
        {
            Scored = scored;
            Missed = missed;
        }

        public int CompareTo(Team other) => other?.Rating - this.Rating ?? -1;

        public bool Equals(Team another) => this.Name == another?.Name;

        public override string ToString()
        {
            return Name + " : " + Rating;
        }
    }
}