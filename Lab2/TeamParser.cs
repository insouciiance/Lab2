﻿using System;
using System.Collections.Generic;

namespace Lab2
{
    public class TeamParser
    {
        public static Team Parse(string[] line)
        {
            if (line == null)
            {
                throw new ArgumentNullException();
            }

            if (line.Length < 2)
            {
                throw new ArgumentException();
            }

            string name = line[0];
            int rating = 0;

            for (int i = 1; i < line.Length; i++)
            {
                string[] scores = line[i].Split(':');

                if (!int.TryParse(scores[0], out int teamScore) | !int.TryParse(scores[1], out int enemyScore))
                {
                    throw new ArgumentException();
                }

                rating += (teamScore - enemyScore) switch
                {
                    int diff when diff < 0 => (int) Rating.Lose,
                    int diff when diff > 0 => (int) Rating.Win,
                    _ => (int) Rating.Draw
                };
            }
            
            return new Team(name,rating);
        }

        public static Team[] Parse(string[][] lines, bool throwOnError = false)
        {
            List<Team> teams = new List<Team>();

            for (int i = 1; i < lines.Length; i++)
            {
                try
                {
                    teams.Add(Parse(lines[i]));
                }
                catch
                {
                    if (throwOnError)
                    {
                        throw;
                    }
                }
            }

            return teams.ToArray();
        }
    }
}