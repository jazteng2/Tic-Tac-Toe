using System;

public class Cell
{
    public int x { get; }
    public int y { get; }
    public bool filled { get; set; }
    public Cell(int xpos, int ypos)
    {
        x = xpos;
        y = ypos;
        filled = false;
    }    
}