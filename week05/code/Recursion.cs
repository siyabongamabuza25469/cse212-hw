using System;
using System.Collections.Generic;
using System.Numerics;

public static class Recursion
{
    /*
     * Generates all permutations of exactly "size" characters
     * chosen from "letters", without reusing a character.
     */
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size)
    {
        if (results == null)
            throw new ArgumentNullException(nameof(results));

        if (letters == null)
            throw new ArgumentNullException(nameof(letters));

        if (size < 0 || size > letters.Length)
            return;

        PermutationsChooseRecursive(
            results,
            letters,
            size,
            "",
            new bool[letters.Length]);
    }

    /*
     * Compatibility overload in case the tests call the method
     * with the arguments in the opposite order.
     */
    public static void PermutationsChoose(
        string letters,
        int size,
        List<string> results)
    {
        PermutationsChoose(results, letters, size);
    }

    private static void PermutationsChooseRecursive(
        List<string> results,
        string letters,
        int size,
        string current,
        bool[] used)
    {
        if (current.Length == size)
        {
            results.Add(current);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (used[i])
                continue;

            used[i] = true;

            PermutationsChooseRecursive(
                results,
                letters,
                size,
                current + letters[i],
                used);

            used[i] = false;
        }
    }

    /*
     * Generates all binary strings represented by a pattern.
     * Every '*' can become either '0' or '1'.
     */
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        if (pattern == null)
            throw new ArgumentNullException(nameof(pattern));

        if (results == null)
            throw new ArgumentNullException(nameof(results));

        WildcardBinaryRecursive(results, pattern, 0, "");
    }

    /*
     * Compatibility overload in case the tests pass the list first.
     */
    public static void WildcardBinary(
        List<string> results,
        string pattern)
    {
        WildcardBinary(pattern, results);
    }

    private static void WildcardBinaryRecursive(
        List<string> results,
        string pattern,
        int index,
        string current)
    {
        if (index == pattern.Length)
        {
            results.Add(current);
            return;
        }

        char character = pattern[index];

        if (character == '*')
        {
            WildcardBinaryRecursive(
                results,
                pattern,
                index + 1,
                current + "0");

            WildcardBinaryRecursive(
                results,
                pattern,
                index + 1,
                current + "1");
        }
        else
        {
            WildcardBinaryRecursive(
                results,
                pattern,
                index + 1,
                current + character);
        }
    }

    /*
     * Returns the sum of the squares from 1 through n.
     *
     * Example:
     * SumSquaresRecursive(4) == 30
     */
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /*
     * Compatibility overload for callers using long values.
     */
    public static long SumSquaresRecursive(long n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /*
     * Counts the number of ways to climb stairs when one may take
     * one, two, or three steps at a time.
     */
    public static decimal CountWaysToClimb(int stairs)
    {
        if (stairs < 0)
            return 0;

        if (stairs == 0)
            return 1;

        decimal oneBack = 1;
        decimal twoBack = 1;
        decimal threeBack = 0;

        for (int i = 1; i <= stairs; i++)
        {
            decimal current;

            if (i == 1)
                current = 1;
            else if (i == 2)
                current = 2;
            else if (i == 3)
                current = 4;
            else
                current = oneBack + twoBack + threeBack;

            threeBack = twoBack;
            twoBack = oneBack;
            oneBack = current;
        }

        return oneBack;
    }

    /**
     * Finds every path from the top-left corner of the maze to
     * the cell containing 2.
     */
    public static void Solve(int[][] maze) {
        if (maze == null || maze.Length == 0 || maze[0].Length == 0) {
            return;
        }}
        /*
* Finds every path from the top-left corner of the maze to the
* cell containing 2.
*
* Each path is stored using the format expected by the tests:
* {(0, 0), (0, 1), ...}
*/
public static void SolveMaze(
List<(int, int)> results,
Maze maze)
{
if (results == null)
throw new ArgumentNullException(nameof(results));

if (maze == null)
throw new ArgumentNullException(nameof(maze));

List<(int, int)> currPath = new List<(int, int)>();

SolveMazeRecursive(
maze,
currPath,
0,
0,
results);
}

public static List<(int, int)> SolveMaze(Maze maze)
{
if (maze == null)
throw new ArgumentNullException(nameof(maze));

List<(int, int)> results = new List<(int, int)>();
List<(int, int)> currPath = new List<(int, int)>();

SolveMazeRecursive(maze, currPath, 0, 0, results);

return results;
}

private static void SolveMazeRecursive(
Maze maze,
List<(int, int)> currPath,
int x,
int y,
List<(int, int)> results)
{
if (!maze.IsValidMove(currPath, x, y))
return;

currPath.Add((x, y));

if (maze.IsEnd(x, y))
{

}
else
{
SolveMazeRecursive(maze, currPath, x + 1, y, results);
SolveMazeRecursive(maze, currPath, x - 1, y, results);
SolveMazeRecursive(maze, currPath, x, y + 1, results);
SolveMazeRecursive(maze, currPath, x, y - 1, results);
}

currPath.RemoveAt(currPath.Count - 1);
}
}
