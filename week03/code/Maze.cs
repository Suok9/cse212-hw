public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        Move(0, -1, 0);
    }

    public void MoveRight()
    {
        Move(1, 1, 0);
    }

    public void MoveUp()
    {
        Move(2, 0, -1);
    }

    public void MoveDown()
    {
        Move(3, 0, 1);
    }

    private void Move(int directionIndex, int dx, int dy)
    {
        var key = (_currX, _currY);

        if (!_mazeMap.ContainsKey(key) || !_mazeMap[key][directionIndex])
            throw new InvalidOperationException("Can't go that way!");

        _currX += dx;
        _currY += dy;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
