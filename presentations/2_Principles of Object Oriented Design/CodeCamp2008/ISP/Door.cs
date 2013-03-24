using System;

namespace CodeCamp2008.ISP
{
    public interface IDoor
    {
        void Lock();
        void UnLock();
        bool IsDoorOpen();
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
    }

    public class SecurityDoor : ISecurityDoor
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

        public bool Lockedout()
        {
            return true;
        }
    }

    public interface ISecurityDoor : IDoor
    {
        bool Lockedout();
    }





























    public class Timer
    {
        //        public void Register(IDoor client)
        //        {
        //            client.TimeOut();
        //        }
    }
}