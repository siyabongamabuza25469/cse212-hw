using System;
using System.Collections.Generic;

/// <summary>
/// Represents a maze whose locations are stored in a dictionary.
///
/// Each dictionary entry maps an (x, y) location to an array containing
/// four direction values in this order:
///
/// [0] left
/// [1] right
/// [2] up
/// [3] down
///
/// A value of true means movement in that direction is allowed.
/// A value of false means there is a wall.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int x, int y), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int x, int y), bool[]> mazeMap)
    {
        _mazeMap = mazeMap ?? throw new ArgumentNullException(nameof(mazeMap));
    }

    /// <summary>
    /// Moves left if the current location allows it.
    /// </summary>
    public void MoveLeft()
    {
        Move(0, -1, 0);
    }

    /// <summary>
    /// Moves right if the current location allows it.
    /// </summary>
    public void MoveRight()
    {
        Move(1, 1, 0);
    }

    /// <summary>
    /// Moves up if the current location allows it.
    /// </summary>
    public void MoveUp()
    {
        Move(2, 0, 1);
    }

    /// <summary>
    /// Moves down if the current location allows it.
    /// </summary>
    public void MoveDown()
    {
        Move(3, 0, -1);
    }

    /// <summary>
    /// Returns the current maze location.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }

    private void Move(int directionIndex, int xChange, int yChange)
    {
        bool[] directions = GetCurrentDirections();

        if (!directions[directionIndex])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX += xChange;
        _currY += yChange;
    }

    private bool[] GetCurrentDirections()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) ||
            directions == null ||
            directions.Length < 4)
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        return directions;
    }
}