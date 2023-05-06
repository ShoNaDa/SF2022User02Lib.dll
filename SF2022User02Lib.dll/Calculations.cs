namespace SF2022User02Lib.dll;

public class Calculations
{
    public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations,
        TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
    {
        TimeSpan firstTime = beginWorkingTime, secondTime = firstTime + new TimeSpan(0, consultationTime, 0);
        var res = new List<string>();

        while (secondTime <= endWorkingTime)
        {
            bool mayAdd = true;
            for (int i = 0; i < startTimes.Length; i++)
            {
                if (firstTime >= startTimes[i] &&
                    firstTime < startTimes[i] + new TimeSpan(0, durations[i], 0) ||
                    secondTime > startTimes[i] &&
                    secondTime <= startTimes[i] + new TimeSpan(0, durations[i], 0))
                {
                    firstTime = startTimes[i] + new TimeSpan(0, durations[i], 0);

                    mayAdd = false;
                    break;
                }
            }

            if (mayAdd)
            {
                res.Add(firstTime.ToString(@"hh\:mm") + "-" + secondTime.ToString(@"hh\:mm"));

                firstTime += new TimeSpan(0, consultationTime, 0);
            }

            secondTime = firstTime + new TimeSpan(0, consultationTime, 0);
        }

        return res.ToArray();
    }
}