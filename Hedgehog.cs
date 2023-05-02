using System;
using System.Collections.Generic;

class HedgehogPopulation
{
    static int[] dx = { 1, 0, 0 };
    static int[] dy = { 0, 1, 0 };
    static int[] dz = { 0, 0, 1 };

    static int bfs(int[] population, int targetColor)
    {
        int total = population[0] + population[1] + population[2];
        bool[,,] visited = new bool[total+1,total+1,total+1];
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(population);
        visited[population[0], population[1], population[2]] = true;
        int steps = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                int[] current = queue.Dequeue();
                if (current[targetColor] == total)
                {
                    return steps;
                }
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (j != k && current[j] > 0 && current[k] < total)
                        {
                            int[] next = new int[3] { current[0], current[1], current[2] };
                            int transfer = Math.Min(current[j], total - current[k]);
                            next[j] -= transfer;
                            next[k] += transfer;
                            if (!visited[next[0], next[1], next[2]])
                            {
                                visited[next[0], next[1], next[2]] = true;
                                queue.Enqueue(next);
                            }
                        }
                    }
                }
            }
            steps++;
        }
        return -1;
    }

    static void Main()
    {
        int[] population = { 8, 1, 9 };
        int targetColor
