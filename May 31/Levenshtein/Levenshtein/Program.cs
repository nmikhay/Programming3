using System;

class SpellingCorrectionApp
{
    static void Main()
    {
        Console.WriteLine("Enter the first word:");
        string word1 = Console.ReadLine();

        Console.WriteLine("Enter the second word:");
        string word2 = Console.ReadLine();

        int distance = ComputeLevenshteinDistance(word1, word2);
        Console.WriteLine($"The Levenshtein distance between '{word1}' and '{word2}' is: {distance}");

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static int ComputeLevenshteinDistance(string word1, string word2)
    {
        if (word1.Equals(word2))
            return 0;

        int len1 = word1.Length;
        int len2 = word2.Length;

        int[,] dp = new int[len1 + 1, len2 + 1];

        for (int i = 0; i <= len1; i++)
            dp[i, 0] = i;

        for (int j = 0; j <= len2; j++)
            dp[0, j] = j;

        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                int cost = (word1[i - 1] != word2[j - 1]) ? 1 : 0;

                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
            }
        }

        return dp[len1, len2];
    }
}
