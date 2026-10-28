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
        // 1. Create a result array with the requested number of elements.
        // 2. Visit each array position from the beginning to the end.
        // 3. Store the input number multiplied by the position's 1-based index.
        // 4. Return the array of multiples.

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
        // 1. Find the index where the final 'amount' elements begin.
        // 2. Save those elements so they remain available after removing them.
        // 3. Remove that suffix from the list.
        // 4. Insert the saved elements at the beginning of the same list.

        int startOfSuffix = data.Count - amount;
        List<int> suffix = data.GetRange(startOfSuffix, amount);
        data.RemoveRange(startOfSuffix, amount);
        data.InsertRange(0, suffix);
    }
}
