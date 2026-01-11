public static class Arrays
{
    
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new array of doubles with the specified length.
        // 2. Loop from 0 to length - 1.
        // 3. For each index i, calculate the multiple as (i + 1) * number.
        //    - i = 0 → 1 * number = first multiple
        //    - i = 1 → 2 * number = second multiple, etc.
        // 4. Assign each calculated multiple to the corresponding index in the array.
        // 5. Return the array after the loop completes.

        double[] multiples = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            multiples[i] = number * (i + 1); // Step 3 & 4
        }

        return multiples; // Step 5
    }

    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list 
    /// after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Find the starting point for the rotation: this is where the last 'amount' elements start.
        //    startIndex = data.Count - amount
        // 2. Extract the last 'amount' elements using GetRange.
        // 3. Remove the last 'amount' elements from the original list.
        // 4. Insert the extracted elements at the beginning of the list using InsertRange.
        // 5. This will modify the original list in-place.

        int startIndex = data.Count - amount; // Step 1

        List<int> tail = data.GetRange(startIndex, amount); // Step 2

        data.RemoveRange(startIndex, amount); // Step 3

        data.InsertRange(0, tail); // Step 4
    }
}