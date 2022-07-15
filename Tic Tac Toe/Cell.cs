using System;

public class Cell
{
    private int _x;
    private int _y;
    private bool _used;
    public Cell(int x, int y)
    {
        _x = x;
        _y = y;
        _used = false;
    }
    public int x { get; }
    public int y { get; }
    public bool filled { get; set; }
}