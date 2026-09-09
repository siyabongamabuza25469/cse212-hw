public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new double array with the requested length.
        // 2. Use a loop to visit each position in the array.
        // 3. The first position should contain number multiplied by 1.
        // 4. Each following position should contain number multiplied by
        //    its one-based position in the array.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Determine the number of items in the list.
        // 2. A right rotation by amount places the last amount items
        //    at the beginning of the list.
        // 3. Copy the last amount items into a temporary list.
        // 4. Remove those items from the end of the original list.
        // 5. Insert the temporary items at the beginning of the original list.
        // 6. The original list is now rotated in place.

        int count = data.Count;

        List<int> itemsToMove = data.GetRange(count - amount, amount);

        data.RemoveRange(count - amount, amount);

        data.InsertRange(0, itemsToMove);
    }
}