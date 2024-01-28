// We are importing some libraries needed for our code to work
using System;
using System.Collections.Generic;
using System.IO;

// A class to represent a team in our program.
public class Team
{
    // Each team has a name.
    public string Name { get; set; }

    // Each team belongs to a league.
    public string League { get; set; }

    // Each team has a count of players.
    public int PlayerCount { get; set; }
}

// A class to represent a generic league.
public abstract class League
{
    // Each league has a name.
    public string Name { get; set; }

    // Each league has a list of teams.
    public List<Team> Teams { get; set; } = new List<Team>();

    // This is a method to calculate some kind of statistic for a team.
    // For now, it returns a random number between 1 and 100.
    public virtual int CalculateTeamStats()
    {
        Random rand = new Random();
        return rand.Next(1, 101);
    }
}

// This is a subclass of League specifically for football leagues.
public class FootballLeague : League
{
    // Here we override the method for calculating team stats.
    // For a football league, we want a random number between 1 and 150.
    public override int CalculateTeamStats()
    {
        Random rand = new Random();
        return rand.Next(1, 151);
    }
}

// This is a subclass of League specifically for basketball leagues.
public class BasketballLeague : League
{
    // Here we override the method for calculating team stats.
    // For a basketball league, we want a random number between 1 and 200.
    public override int CalculateTeamStats()
    {
        Random rand = new Random();
        return rand.Next(1, 201);
    }
}

// This is the main class for our program.
public class Program
{
    // This is the main method where our program starts.
    public static void Main()
    {
        // Here we read in a list of teams from a file.
        var teams = ReadTeamsFromFile("teams.txt");

        // Then we create some leagues and calculate stats for each team.
        CreateLeaguesAndCalculateStats(teams, "league_stats.txt");
    }

    // This method reads teams from a file and returns a list of them.
    public static List<Team> ReadTeamsFromFile(string filePath)
    {
        // We start with an empty list of teams.
        var teams = new List<Team>();

        try
        {
            // Here we open the file for reading.
            using (var reader = new StreamReader(filePath))
            {
                string line;

                // We read each line of the file.
                while ((line = reader.ReadLine()) != null)
                {
                    // We split the line into parts by commas.
                    var parts = line.Split(',');

                    // Then we create a new team with the data from the line.
                    var team = new Team
                    {
                        Name = parts[0],
                        League = parts[1],
                        PlayerCount = Int32.Parse(parts[2])
                    };

                    // And we add the team to our list.
                    teams.Add(team);
                }
            }
        }
        catch (Exception ex)
        {
            // If something goes wrong, we print an error message.
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        // Finally, we return our list of teams.
        return teams;
    }

    // This method creates leagues and calculates stats for each team.
    public static void CreateLeaguesAndCalculateStats(List<Team> teams, string outputFilePath)
    {
        // We start with an empty list of leagues.
        var leagues = new List<League>();

        // We go through each team.
        foreach (var team in teams)
        {
            // We look for a league with the same name as the team's league.
            var league = leagues.Find(l => l.Name == team.League);

            // If we don't find such a league, we create a new one.
            if (league == null)
            {
                // If the team has 22 or fewer players, it's a football team.
                // Otherwise, it's a basketball team.
                if (team.PlayerCount <= 22)
                    league = new FootballLeague { Name = team.League };
                else
                    league = new BasketballLeague { Name = team.League };

                // We add the new league to our list.
                leagues.Add(league);
            }

            // We add the team to the league's list of teams.
            league.Teams.Add(team);
        }

        try
        {
            // We open a file for writing.
            using (var writer = new StreamWriter(outputFilePath))
            {
                // We go through each league.
                foreach (var league in leagues)
                {
                    // And each team in the league.
                    foreach (var team in league.Teams)
                    {
                        // We calculate stats for the team.
                        var stats = league.CalculateTeamStats();

                        // And we write the league name, team name, and stats to the file.
                        writer.WriteLine($"{league.Name},{team.Name},{stats}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // If something goes wrong, we print an error message.
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
}





