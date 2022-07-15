using System;
using System.Collections.Generic;

public class Map 
{
    private List<Cell> _cells;
    public Map()
    {
        _cells = new List<Cell>();
        mapping();
    }
    public void mapping()
    {
        for (int x = 0; x < 3; x++)
        {
            // string line = "";
            for (int y = 0; y < 3; y++)
            {
                _cells.Add(new Cell(x, y));
                // line += $"({x},{y}) ";
            }
            // Console.WriteLine(line + "\n");
        }
    }
    public bool empty()
    {
        foreach (Cell c in _cells)
        {
            if (!c.filled)
            {
                return true;
            }
        }
        return false;
    }
}