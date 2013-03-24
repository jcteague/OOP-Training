using System;

namespace CodeCamp2008.ISP
{
    public interface IDoor
    {
        void Lock();
        void UnLock();
        bool IsDoorOpen();
        void TimeOut();
    }

    public class Door : IDoor
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
            throw new NotImplementedException();
        }
    }

    public class SecurityDoor : IDoor
    {
        private bool _isLock;

        public void Lock()
        {
            _isLock = true;
        }
        public void UnLock()
        {
            _isLock = false;
            #region step 2
//                        Timer timer = new Timer();
//                        timer.Register(this);
            #endregion
        }
        public bool IsDoorOpen()
        {
            return !_isLock;
        }

        public void TimeOut()
        {
            Console.WriteLine("Time out occured for security door");
        }
    }
}