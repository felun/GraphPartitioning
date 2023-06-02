
using System.ComponentModel.DataAnnotations;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var set = new int[] { 1, 1, 1, 1, 1 };
        var vrx = new string[] { "A", "B", "C", "D", "E"};
        var newVrx = vrx;
        while (set != null)
        {
            if (set.Length == vrx.Length)
            { 
                Print(set, newVrx);
            }
            set = GetNextPartition(set);
            //Print(set, newVrx);
            var sets = GetAllPermutations(set);
            foreach (var item in sets)
            {
                newVrx = GetNewVertexes(item, vrx);
                Print(item, newVrx);
            }
        }
    }

    private static List<int[]> GetAllPermutations(int[] set)
    {
        var list = new List<int[]>();
        if (set != null)
        {
            Permute(list, set.ToArray(), set.Length, 0);
        }
        return list.ToList();
    }


    private static void Permute(List<int[]>list, int[] s, int n, int i)
    {
        if (i >= n - 1)
        {
            if (!list.Any(x=>string.Join("",x) == string.Join("",s)))
            {
                list.Add(s);
            }
        }
        else
        {
            Permute(list, s.ToArray(), n, i + 1);
            for (int j = i + 1; j < n; j++)
            {
                Swap(ref s[i], ref s[j]);
                Permute(list, s.ToArray(), n, i + 1);
                Swap(ref s[i], ref s[j]);
            }
        }
    }

    private static void Swap(ref int x, ref int y) 
    {
        int t = x;
        x = y; 
        y = t;
    }

    private static string[] GetNewVertexes(int[] part, string[] vrx)
    {
        if (part == null)
            return null;

        var newVrx = new string[part.Length];
        var sum = 0;
        var prevSum = 0;
        for (int i = 0; i < part.Length; i++)
        {
            sum += part[i];
            var subGraph = "";
            for (int j = prevSum; j < sum; j++)
            {
                subGraph += vrx[j];
            }
            newVrx[i] = subGraph;
            prevSum = sum;
        }
        return newVrx;
    }

    private static int[] GetNextPartition(int[] partition)
    {
        if (partition.Length == 1)
        {
            return null;
        }
        var minIndex = GetMinIndex(partition);
        partition[minIndex] += 1;
        partition[partition.Length-1] -= 1;
        var sum = GetRightSum(partition, minIndex);

        var newLen = minIndex + 1 + sum;
        var newPartition = new int[newLen];
        for (int i= 0; i< minIndex+1; i++)
        {
            newPartition[i] = partition[i];
        }
        for (int i= minIndex+1; i< newLen; i++)
        {
            newPartition[i] = 1;
        }
        return newPartition;

    }

    private static int GetMinIndex(int[] partition)
    {
        var minIndex = 0;
        for (int i = 0; i < partition.Length-1; i++)
        {
            if (partition[i] < partition[minIndex])
            {
                minIndex = i;
            }
        }
        return minIndex;   
    }

    private static void Print(int[] partition, string[] vrx)
    {
        if (partition != null)
        {
            Console.WriteLine(string.Join(" ", partition) + "   " + string.Join(" ", vrx));
        }
    }

    private static int GetRightSum(int[] partition, int rightIndex)
    {
        int sum = 0;
        for (int i = rightIndex+1; i < partition.Length; i++)
        {
            sum += partition[i];
        }
        return sum;
    }
}
