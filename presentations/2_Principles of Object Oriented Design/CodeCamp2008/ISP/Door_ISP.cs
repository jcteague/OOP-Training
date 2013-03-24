using System;

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





























    public interface IDoor_ISP
    {
        void Lock();
        void UnLock();
        bool IsDoorOpen();
    }

















    public class Door_ISP : IDoor_ISP
    {
        private bool _isLock;

        public void Lock()
        {
            _isLock = true;
        }
        public void UnLock()
        {
            _isLock = false;
        }
        public bool IsDoorOpen()
        {
            return !_isLock;
        }
    }

























    
    public class SecurityDoor_ISP : IDoor_ISP, ITimerClient_ISP
    {
        private bool _isLock;

        public void Lock()
        {
            _isLock = true;
        }
        public void UnLock()
        {
            _isLock = false;
        }
        public bool IsDoorOpen()
        {
            return !_isLock;
        }

        public void TimeOut()
        {
            Console.WriteLine("Time out occured SecurityDoor");
        }
    }














}