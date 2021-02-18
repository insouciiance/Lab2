namespace Lab2
{
    public class TeamParser
    {
        
        
        public static Team Parse(string[] line)
        {
            string name = line[0];
            int rating = 0;

            for (int i = 1; i < line.Length; i++)
            {
                string[] scores = line[i].Split(':');
                int teamScore = int.Parse(scores[0]);
                int enemyScore = int.Parse(scores[1]);

                if (teamScore < enemyScore)
                {
                    rating += (int) Rating.Lose;
                }
                else if (teamScore == enemyScore)
                {
                    rating += (int) Rating.Draw;
                }
                else if (teamScore > enemyScore)
                {
                    rating += (int) Rating.Win;
                }
                
            }
            
            return new Team(name,rating);
        }
    }
}