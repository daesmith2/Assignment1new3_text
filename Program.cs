using System;

// #6 I had to save this program seperately to run as its own class.
//    I believe this program calculates the value of each character, checks to see if they are the same. 
//    If the characters are not the same, the program tells you what letter (index) to add, delete, or replace to make it the same.
//    I found this frame for this solution on 'GeeksForGeeks.org'. 
public class Edit_Distance
{
    static int[,] dp;

    // Function to print the steps 
    static void printChanges(String s1, String s2)
    {
        int i = s1.Length;
        int j = s2.Length;

        // check till the end 
        while (i != 0 && j != 0)
        {

            // if characters are same 
            if (s1[i - 1] == s2[j - 1])
            {
                i--;
                j--;
            }

            // Replace 
            else if (dp[i, j] == dp[i - 1, j - 1] + 1)
            {
                Console.WriteLine("change " + s1[i - 1] + " to " + s2[j - 1]);
                i--;
                j--;
            }

            // Delete the character 
            else if (dp[i, j] == dp[i - 1, j] + 1)
            {
                Console.WriteLine("Delete " + s1[i - 1]);
                i--;
            }

            // Add the character 
            else if (dp[i, j] == dp[i, j - 1] + 1)
            {
                Console.WriteLine("Add " + s2[j - 1]);
                j--;
            }
        }
    }

    // Function to compute the DP matrix 
    static void editDP(String s1, String s2)
    {
        int l1 = s1.Length;
        int l2 = s2.Length;
        int[,] DP = new int[l1 + 1, l2 + 1];

        // initilize by the maximum edits possible 
        for (int i = 0; i <= l1; i++)
            DP[i, 0] = i;
        for (int j = 0; j <= l2; j++)
            DP[0, j] = j;

        // Compute the DP matrix 
        for (int i = 1; i <= l1; i++)
        {
            for (int j = 1; j <= l2; j++)
            {

                // if the characters are same 
                // no changes required 
                if (s1[i - 1] == s2[j - 1])
                    DP[i, j] = DP[i - 1, j - 1];
                else
                {

                    // minimu of three operations possible 
                    DP[i, j] = min(DP[i - 1, j - 1],
                                DP[i - 1, j], DP[i, j - 1])
                            + 1;
                }
            }
        }

        // initialize to global array 
        dp = DP;
    }

    // Function to find the minimum of three 
    static int min(int a, int b, int c)
    {
        int z = Math.Min(a, b);
        return Math.Min(z, c);
    }

    // Driver Code 
    public static void Main(String[] args)
    {
        String s1 = "goulls";
        String s2 = "gobulls";

        // calculate the DP matrix 
        editDP(s1, s2);

        // print the steps 
        printChanges(s1, s2);
    }
}