using System;
using System.Collections;
using System.Collections.Generic;

namespace Project6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] scores = new int[] { 77, 12, 74, 34, 56, 78, 234, 678 };
            Console.WriteLine("\n1) Array:");
            for (int i = 0; i < scores.Length; i++)
                Console.WriteLine(scores[i]);

            Array.Sort(scores);

            Console.WriteLine("\n2) Sorted scores : ");
            foreach (int i in scores)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nIndex of number 56 is " + Array.IndexOf(scores, 56));

            int[] new_scores = new int[scores.Length];
            for (int a = 0; a < scores.Length; a++)

            {
                for (int i = 0; i < scores.Length; i++)
                { new_scores[i] = scores[i]; }
            }

            List<int> var_scores = new List<int>(new_scores);
            var_scores.RemoveAt(Array.IndexOf(scores, 56));
            new_scores = var_scores.ToArray();

            Console.WriteLine("\n3) New array : ");
            foreach (int i in new_scores)

            {
                Console.WriteLine(i);
            }

            int[,] matrix1 = new int[,] { { 1, 0 }, { 1, 4 } };
            int[,] matrix2 = new int[,] { { 1, 2 }, { 0, 1 } };
            int[,] resultmatrix = new int[2, 2];
            resultmatrix[0, 0] = matrix1[0, 0] * matrix2[0, 0];
            resultmatrix[1, 0] = matrix1[1, 0] * matrix2[0, 1];
            resultmatrix[0, 1] = matrix1[0, 1] * matrix2[1, 0];
            resultmatrix[1, 1] = matrix1[1, 1] * matrix2[1, 1];
            Console.WriteLine("\n4) matrix1 * matrix 2 :\n" + resultmatrix[0, 0] + "  " + resultmatrix[0, 1] + "\n" + resultmatrix[1, 0] + "  " + resultmatrix[1, 1]);
        
        
            Hashtable myTable = new Hashtable();
            for (int i = 0; i < scores.Length; i++)
            {
                myTable.Add(i , scores[i]);
            }
			
            ICollection key = myTable.Keys;

            Console.WriteLine("\n5) hashtable:");

            foreach (int k in key)
			{
                Console.WriteLine(k + ": " + myTable[k]);
			}

            myTable.ContainsKey(2);
            Console.WriteLine("\n" + myTable[2]);
        }


    }
}