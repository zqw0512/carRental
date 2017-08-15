using System;
using System.Collections.Generic;
using System.Text;

namespace Car_rental_system
{
    class DLbh
    {
         private static DLbh c;
         private DLbh()
        { 
        }
         public static DLbh getIns()
        {
            if (c==null)
            {
                c = new DLbh();
                return c;
            }
            else
            {
                return c;
            }
        }
        private int num = 0;
        public int Num
        {
            get
            {
                return num;
            }
            set 
            {
                num = value;
            }
        }
    }
}
