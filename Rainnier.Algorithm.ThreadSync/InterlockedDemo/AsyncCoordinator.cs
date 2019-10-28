using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.ThreadSync.InterlockedDemo
{
    internal class AsyncCoordinator
    {
        int m_opCount = 1;
        int m_statusReported = 0;
        Action<CoordinationStatus> m_callback;
        Timer m_timer;
        internal void AboutToBegin(int v=1)
        {
            //Interlocked.Add(ref m_opCount, v);
            m_opCount++;
        }

        internal void JustEnd()
        {
            //if(Interlocked.Decrement(ref m_opCount) == 0)
            if(--m_opCount==0)
            {
                ReportStatus(CoordinationStatus.AllDone);
            }
        }

        private void ReportStatus(CoordinationStatus status)
        {
            //if(Interlocked.Exchange(ref m_statusReported, 1) == 0)
            if(m_statusReported==0)
            {
                m_callback(status);
                m_statusReported = 1;
            }
        }

        internal void AllBegun(Action<CoordinationStatus> action, int n = Timeout.Infinite)
        {
            m_callback = action;
            if (n != Timeout.Infinite)
            {
                m_timer = new Timer(TimeExpired, null, n, Timeout.Infinite);
            }
            JustEnd();
        }

        private void TimeExpired(object state)
        {
            ReportStatus(CoordinationStatus.Timeout);
        }

        internal void Cancel()
        {
            ReportStatus(CoordinationStatus.Cancel);
        }

        
    }
}
