using System;
using System.Collections.Generic;

public class TTT
{
    public TTT() {}
    public string TTT_recursion(Map m, Player p1, Player p2)
    {
        bool result = false;        
        string winner = "";
        check_turn(p1, p2);     
        // Console.WriteLine("Player 1: " + p1.turn);
        // Console.WriteLine("Player 2: " + p2.turn);
        
        if (p1.turn)
        {
            Console.WriteLine($"Player 1 turn, select cell: ");
            result = action(p1, m);
            if (result == true) // terminate recursion
            {
                return "Player 1";
            }
            else if (!m.empty()) // no more moves
            {
                return "Draw";
            }
            
            winner = TTT_recursion(m, p1, p2);
        }
        else if (p2.turn)
        {
            Console.WriteLine($"Player 2 turn, select cell: ");
            result = action(p2, m);
            if (result == true) // terminate recursion
            {
                return "Player 1";
            }
            else if (!m.empty()) // no more moves
            {
                return "Draw";
            }

            winner = TTT_recursion(m, p1, p2);
        }        
        return winner;
    }
    public bool action(Player p, Map m)
    {
        
        string move = Console.ReadLine();
        bool valid_move = validate(move, m);
        Cell[,] cells = m.cells;
        int x = (int)char.GetNumericValue(move[0]);
        int y = (int)char.GetNumericValue(move[2]);
        cells[x,y].filled = true;        
        p.visit(cells[x, y]);

        // refresh map
        if (p.Id == 1) { cells[x, y].value = "X"; }
        if (p.Id == 2) { cells[x, y].value = "O"; }
        m.draw();

        // check only when player have used three moves
        if (p.selected.Count < 3)
        {
            return false;
        }
        return check_winner(p, m);
    }
    bool validate(string move, Map m)
    {
        if (move == "")
        {
            Console.WriteLine("Invalid Move try again");
            return false;
        }
        if (!char.IsNumber(move[0]) || !char.IsNumber(move[2]))
        {
            Console.WriteLine("Position x and y must be numeric");
            return false;
        }
        var x = (int)char.GetNumericValue(move[0]);
        var y = (int)char.GetNumericValue(move[2]);
        Cell selected = m.cells[x,y];
        if (selected.filled)
        {
            Console.WriteLine("Selected Cell is already used");
            return false;
        }
        return true;
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

    private bool check_winner(Player p, Map m)
    {
        // the sum of x and y positions 
        // to check if row, column or diagonal
        // with further checking for final result        
        int sum_x = 0;
        int sum_y = 0;
        Cell[,] cells = m.cells;
        foreach (Cell c in p.selected)
        {
            sum_x += c.x;
            sum_y += c.y;
        }
        Console.WriteLine("Sum selected: x=" + sum_x + " y=" + sum_y);

        // top row & left column
        if (sum_x == 0) { return true; }
        if (sum_y == 0) { return true; }

        // bot row & right column
        if (sum_x == 3 && sum_y == 6) { return true; }
        if (sum_x == 6 && sum_y == 3) { return true;}

        // mid row, column or diagonals
        if (sum_x == 3 && sum_y == 3)
        {
            bool mid_row = true;
            bool mid_column = true;
            bool diagonal = true;

            
            List<Cell> row = new List<Cell>();
            List<Cell> column = new List<Cell>();
            List<Cell> diagonal1 = new List<Cell>();
            List<Cell> diagonal2 = new List<Cell>();
            row.Add(cells[0, 1]);
            row.Add(cells[1, 1]);
            row.Add(cells[2, 1]);
            column.Add(cells[1, 0]);
            column.Add(cells[1, 1]);
            column.Add(cells[1, 2]);
            diagonal1.Add(cells[0, 0]);
            diagonal1.Add(cells[1, 1]);
            diagonal1.Add(cells[2, 2]);
            diagonal2.Add(cells[2,0]);
            diagonal2.Add(cells[1,1]);
            diagonal2.Add(cells[0,2]);
            foreach (Cell c in row) // check mid row
            {
                if (!p.visited(c))
                {
                    mid_row = false;
                }
            }
            if (mid_row == false)
            {
                foreach (Cell c in column) // check mid column
                {
                    if (!p.visited(c))
                    {
                        mid_column = false;
                    }
                }

                if (mid_column == false)
                {
                    foreach (Cell c in diagonal1) // check diagonal
                    {
                        if (!p.visited(c))
                        {
                            diagonal = false;
                        }
                    }
                    if (diagonal == false)
                    {
                        foreach (Cell c in diagonal2) // check diagonal
                        {
                            if (!p.visited(c))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    return true;
                }
                return true;
            }
            return true;
        }
        return false;
    }
}