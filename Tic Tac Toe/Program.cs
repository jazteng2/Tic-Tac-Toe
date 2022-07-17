using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Player p1 = new Player();
        Player p2 = new Player();
        Map map = new Map();
        TTT game = new TTT();        
        game.TTT_recursion(map, p1, p2);
    }
}
