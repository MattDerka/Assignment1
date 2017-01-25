using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend1;

namespace seng301_asgn1
{
    class VendingMachine
    {
        public int num;
        private List<int> coinType = new List<int>();
        private List<string> popNames = new List<string>();
        private List<Coin> chutes = new List<Coin>();
        private ArrayList allChutes = new ArrayList();
        private ArrayList allChutesPop = new ArrayList();
        private List<int> popCosts = new List<int>();
        private List<Deliverable> deliveryChute = new List<Deliverable>();


        public VendingMachine(List<int> coinKinds, int numOfButtons)
        {
            coinType = coinKinds;
            num = numOfButtons;
        }

        public void setPopNames(List<string> popList )
        {
            popNames = popList;
        }

        public void setPopCosts(List<int> popCost)
        {
            popCosts = popCost;
        }

        public void setChute(List<Coin> coinChute)
        {
            allChutes.Add(coinChute);
        }

        public ArrayList getChutes()
        {
            return allChutes;
        }

        public void setChutes(List<Coin> d )
        {
            allChutes.Add(d);
        }

        public void setPopChutes(List<Pop> a)
        {
            allChutesPop.Add(a);
        }

        public ArrayList getPopChutes()
        {
            return allChutesPop;
        }

        public List<int> getCoinTypes()
        {
            return coinType;
        }

        public void setDeliveryChute(Deliverable item)
        {
            deliveryChute.Add(item);
        }

        public List<Deliverable> getDeliveryChute()
        {
            return deliveryChute;
        }

        

        
    }
}
