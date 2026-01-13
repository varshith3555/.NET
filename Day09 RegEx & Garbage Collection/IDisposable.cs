using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyConsoleApp.Day9
{
    public class BigBoy : IDisposable
    {
        public ArrayList Names { get; set; }

        public BigBoy()
        {

        }
        public void Dispose()
        {
            Names = null;
        }
        ~BigBoy()
        {
            Names = null;
        }
    }

    public class BigBoyMain
    {
        static void Main()
        {
            BigBoy boy = new BigBoy();
            try
            {
                boy.Names = new ArrayList();
                for (int i = 0; i < 5; i++)
                {
                    boy.Names.Add(i.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                boy.Dispose();
            }
        }
    }
}
