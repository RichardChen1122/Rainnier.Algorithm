using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.ThreadSync
{
    public class ThreadSharingData
    {
        private int m_flag = 0;
        private int m_value = 0;

        public void Thread1()
        {
            m_value = 5;
            m_flag = 1;
        }

        public void Thread2()
        {
            if (m_flag == 1)
            {
                Console.Write(m_value);
            }
        }
    }
}
