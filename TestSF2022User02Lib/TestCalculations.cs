using SF2022User02Lib.dll;

namespace TestSF2022User02Lib;

[TestClass]
public class TestCalculations
{
    [TestMethod]
    public void TestAvailablePeriods()
    {
        //test datas
        TimeSpan[] startTimes =
        {
            new(10, 0, 0), new(11, 0, 0), new(15, 0, 0),
            new(15, 30, 0), new(16, 50, 0)
        };
        int[] durations = { 60, 30, 10, 10, 40 };
        TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
        int consultationTime = 30;

        string[] expected =
        {
            "08:00-08:30", "08:30-09:00", "09:00-09:30", "09:30-10:00", "11:30-12:00", "12:00-12:30", "12:30-13:00",
            "13:00-13:30", "13:30-14:00", "14:00-14:30", "14:30-15:00", "15:40-16:10", "16:10-16:40", "17:30-18:00"
        };

        string[] actual =
            new Calculations().AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

        CollectionAssert.AreEqual(expected, actual);

        Console.WriteLine();
    }
}