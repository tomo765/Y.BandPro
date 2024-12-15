using System.Linq;

public static class GameSettings
{
    /// <summary> 中間発表の週 </summary>
    private static int[] InterimPerformances = new int[] { 5, 10 };
    /// <summary> 最終公演週 </summary>
    private static int LastPerformanceWeeks = 15;

    public static bool IsInterimWeek(int week) => InterimPerformances.Contains(week);
    public static bool IsLastWeek(int week) => week == LastPerformanceWeeks;
}