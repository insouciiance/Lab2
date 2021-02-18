using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    public class TeamsCollection : IEnumerable<Team>
    {
        private List<Team> _teams;

        public TeamsCollection()
        {
            _teams = new List<Team>();
        }

        public TeamsCollection(Team[] teams)
        {
            _teams = new List<Team>(teams);
        }

        public Team[] GetTeamsRating() => _teams.OrderBy(team => team.Rating).ToArray();

        public void Add(Team team) => _teams.Add(team);

        public IEnumerator<Team> GetEnumerator() => _teams.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
