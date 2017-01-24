using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seng301_asgn1
{
    class VendingMachine
    {
        private int num;

        public VendingMachine(List<int> coinKinds, int numOfButtons)
        {
            List<int> type = new List<int>();
            type = coinKinds;

            int num = numOfButtons;
        }

        public int getNum()
        {
            return num;
        }

        
    }
}
