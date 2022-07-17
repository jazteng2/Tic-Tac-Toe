using System;
using System.Collections.Generic;

public class Player
{
    private List<Cell> _selected;
    public bool _turn; 
    public Player()
    {
        _visited = new List<Cell>();
        _turn = false;
    }     
    public List<Cell> selected
    {
        get
        {
            return _visited;
        }
    }    
    public bool turn 
    {
        get
        {
            return _turn;
        }
        set
        {
            _turn = value;
        }
    }
    public void visit(Cell cell)
    {
        visited.Add(cell);
    }    
    public bool visited(Cell cell)
    {
        return _selected.Contains(cell);
    }
}