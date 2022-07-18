using System;
using System.Collections.Generic;

public class Player
{
    private int _Id;
    private List<Cell> _selected;
    private bool _turn; 
    public Player(int Id)
    {
        _Id = Id;
        _selected = new List<Cell>();
        _turn = false;
    }     
    public int Id
    {
        get
        {
            return _Id;
        }
    }
    public List<Cell> selected
    {
        get
        {
            return _selected;
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
        _selected.Add(cell);
    }
    public bool visited(Cell cell)
    {
        return _selected.Contains(cell);
    }
}