using System;
using System.Collections.Generic;

public class TTT
{
    public TTT() {}
    public string TTT_recursion(Map m, Player p1, Player p2)
    {
        string result = "";
        check_turn(p1, p2);     
        // Console.WriteLine("Player 1: " + p1.turn);
        // Console.WriteLine("Player 2: " + p2.turn);

        if (m.empty())
        {
            if (check_winner(p1))
            {
                result = "Player 1 wins";
            }
            if (check_winner(p2))
            {
                result = "Player 2 wins";
            }
            Console.WriteLine("Finish");
        }
        else if (p1.turn)
        {
            Console.WriteLine($"Player 1 turn, select cell: ");
            action(p1, m);
            result = TTT_recursion(m, p1, p2);
        }
        else if (p2.turn)
        {
            Console.WriteLine($"Player 2 turn, select cell: ");
            action(p2, m);
            result = TTT_recursion(m, p1, p2);
        }
        return result;
    }
    public void action(Player p, Map m)
    {
        
        string move = Console.ReadLine();
        Cell[,] cells = m.cells;
        int x = Convert.ToInt32(move[0]);
        int y = Convert.ToInt32(move[2]);
        cells[x,y].filled = true;
        p.visit(cells[x,y]);
    }
    private void check_turn(Player p1, Player p2)
    {
        // assign a turn
        if (!p1.turn && !p2.turn)
        {
            p1.turn = true;               
        }
        else if (p1.turn && !p2.turn)
        {
            p1.turn = false;
            p2.turn = true;
        }
        else if (!p1.turn && p2.turn)
        {
            p1.turn = true;
            p2.turn = false;
        }
    }

    private bool check_winner(Player p)
    {
        // check if horizontal, veritcal or diagonal
        if (p.)

        return false;
    }
}