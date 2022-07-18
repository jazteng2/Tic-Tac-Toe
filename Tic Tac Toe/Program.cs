using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Player p1 = new Player(1);
        Player p2 = new Player(2);
        Map map = new Map();
        TTT game = new TTT();
        string result = game.TTT_recursion(map, p1, p2);
        if (result == "Draw")
        {
            Console.WriteLine(result);
        } else {
            Console.WriteLine("Winner is " + result);
        }
    }
}
