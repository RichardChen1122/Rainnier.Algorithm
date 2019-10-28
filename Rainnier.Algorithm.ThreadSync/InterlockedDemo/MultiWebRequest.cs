using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.ThreadSync.InterlockedDemo
{
    internal sealed class MultiWebRequest
    {
        AsyncCoordinator m_ac = new AsyncCoordinator();

        private WebRequest[] m_requests = new WebRequest[]
        {
            WebRequest.Create("http://www.baidu.com"),
            WebRequest.Create("http://www.sina.com")
        };

        private WebResponse[] m_results = new WebResponse[2];

        public MultiWebRequest(int timeout = Timeout.Infinite)
        {
            for(int n = 0; n < m_requests.Length; n++)
            {
                m_ac.AboutToBegin(1);
                m_requests[n].BeginGetResponse(EndGetResponse, n);
            }

            m_ac.AllBegun(AllDone, timeout);
        }

        public void Cancel()
        {
            m_ac.Cancel();
        }

        private void EndGetResponse(IAsyncResult ar)
        {
            int n = (int)ar.AsyncState;
            m_results[n] = m_requests[n].EndGetResponse(ar);

            m_ac.JustEnd();
        }

        private void AllDone(CoordinationStatus status)
        {
            switch (status)
            {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("The operation was canceled");
                    break;
                case CoordinationStatus.Timeout:
                    Console.WriteLine("The operation was time-out");
                    break;
                case CoordinationStatus.AllDone:
                    Console.WriteLine("HERE ARE:");
                    for (int n = 0; n < m_requests.Length; n++)
                    {
                        Console.WriteLine($"{m_results[n].ResponseUri} returned {m_results[n].ContentLength} bytes.");
                    }
                    break;
            }
        }
    }
}
