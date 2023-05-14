namespace Homework.Comparer;

internal class Helper
{
    public static void CheckData(object x, object y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("no data");
        }
    }
}
