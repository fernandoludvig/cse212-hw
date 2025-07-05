using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>Array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size "length"
        double[] result = new double[length];

        // Step 2: Loop from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the i-th multiple: number * (i + 1)
            result[i] = number * (i + 1);
        }

        // Step 4: Return the filled array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by the given 'amount'.
    /// For example, if data = {1,2,3,4,5,6,7,8,9} and amount = 3, 
    /// the result should be: {7,8,9,1,2,3,4,5,6}.
    /// </summary>
    /// <param name="data">List of integers to be rotated</param>
    /// <param name="amount">Number of positions to rotate to the right</param>
    public static void RotateListRight(List<int> data, int amount)
    {

        if (amount == data.Count)
        {
            return;
        }
        // Step 1: Extract the last 'amount' elements from the list
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Step 2: Extract the first part (everything before the rotated section)
        List<int> head = data.GetRange(0, data.Count - amount);

        // Step 3: Clear the original list
        data.Clear();

        // Step 4: Add the rotated elements (from the end) to the beginning
        data.AddRange(tail);

        // Step 5: Add the rest of the original list
        data.AddRange(head);
    }
}
