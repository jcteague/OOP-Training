namespace CodeCamp2008.ISP
{
    public interface ITimerClient_ISP
    {
        void TimeOut();
    }

    public class Timer_ISP
    {
        public void Register(int timeout, ITimerClient_ISP client)
        {
            client.TimeOut();
        }
    }
}