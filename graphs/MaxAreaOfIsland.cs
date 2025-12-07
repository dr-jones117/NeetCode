using System.Diagnostics;

var sol = new Solution();

Debug.Assert(sol.MaxAreaOfIsland(
    [[0,1,1,0,1],
    [1,0,1,0,1],
    [0,1,1,0,1],
    [0,1,0,0,1]]
) == 6);

public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        var visited = new HashSet<Tuple<int,int>>();
        var maxVisted = 0;
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                var currPos = new Tuple<int,int>(i,j);
                maxVisted = Math.Max(maxVisted, DFS(ref currPos, ref grid, ref visited));
            }
        }
        return maxVisted;
    }

    private int DFS(ref Tuple<int,int> currPos, ref int[][] grid, ref HashSet<Tuple<int,int>> visited)
    {
        if(visited.Contains(currPos)) return 0;
        visited.Add(currPos);
        if(grid[currPos.Item1][currPos.Item2] == 0) return 0;

        int amount = 1;
        
        var left = new Tuple<int,int>(currPos.Item1, currPos.Item2 - 1);
        var right = new Tuple<int,int>(currPos.Item1, currPos.Item2 + 1);
        var up = new Tuple<int,int>(currPos.Item1 - 1, currPos.Item2);
        var down = new Tuple<int,int>(currPos.Item1 + 1, currPos.Item2);

        if(left.Item2 >= 0) amount += DFS(ref left, ref grid, ref visited);
        if(right.Item2 < grid[currPos.Item1].Length) amount += DFS(ref right, ref grid, ref visited);
        if(up.Item1 >= 0) amount += DFS(ref up, ref grid, ref visited);
        if(down.Item1 < grid.Length) amount += DFS(ref down, ref grid, ref visited);

        return amount;
    }
}