using System;
using System.Collections.Generic;

public class Map 
{
    public Cell[,] _cells;
    public Map()
    {
        _cells = new Cell[3,3];
        mapping();
        draw();
    }
    public Cell[,] cells
    {
        get 
        {
            return _cells;
        }
    }    
    public bool empty()
    {
        foreach (Cell c in cells)
        {
            if (!c.filled)
            {
                return true;
            }
        }
        return false;
    }
    private void mapping()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                _cells[x,y] = new Cell(x, y);
            }
        }
    }
    public void draw()
    {
        for (int y = 0; y < 3; y++)
        {
            string row = "";
            for (int x = 0; x < 3; x++)
            {
                row += cells[x,y].value + " ";
            }
            Console.WriteLine(row);
        }

        /*for (int y = 0; y < 3; y++)
        {
            string row = "";
            for (int x = 0; x < 3; x++)
            {
                row += x + "," + y + " ";
            }
            Console.WriteLine(row);
        */
    }
}