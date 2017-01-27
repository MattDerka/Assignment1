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
        //private ArrayList allChutes = new ArrayList();
        private Dictionary<int , List<Coin>> coinChutes = new Dictionary<int, List<Coin>>();
        private Dictionary<int, List<Pop>> popChutes = new Dictionary<int, List<Pop>>();
        private ArrayList allChutesPop = new ArrayList();
        private List<int> popCosts = new List<int>();
        private List<Deliverable> deliveryChute = new List<Deliverable>();
        private List<Coin> moneyMade = new List<Coin>();
        private List<Coin> limbo = new List<Coin>();

        private List<Pop> finalPop = new List<Pop>();
        private List<Coin> finalCoin = new List<Coin>();


        public VendingMachine(List<int> coinKinds, int numOfButtons)
        {
            coinType = coinKinds;
            num = numOfButtons;
        }

        public void setCoinChutes(int index, List<Coin> coin)
        {
            coinChutes.Add(index, coin);
        }

        public Dictionary<int, List<Coin>> getCoinChutes()
        {
            return coinChutes;
        }

        public void setPopChutes(int index, List<Pop> pop)
        {
            popChutes.Add(index, pop);
        }

        public Dictionary<int, List<Pop>> getPopChutes()
        {
            return popChutes;
        }

        public void setPopNames(List<string> popList )
        {
            popNames = popList;
        }

        public void setPopCosts(List<int> popCost)
        {
            popCosts = popCost;
        }

        public List<int> getPopCosts()
        {
            return popCosts;
        }

        /*public void setChute(List<Coin> coinChute)
        {
            allChutes.Add(coinChute);
        }*/

        /*public ArrayList getChutes()
        {
            return allChutes;
        }*/

        /*public void setChutes(List<Coin> d )
        {
            allChutes.Add(d);
        }*/

        public void setPopChutes(List<Pop> a)
        {
            allChutesPop.Add(a);
        }

        /*public ArrayList getPopChutes()
        {
            return allChutesPop;
        }*/



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

        public void setMoneyMade(Coin i)
        {
            moneyMade.Add(i);
        }

        public List<Coin> getMoneyMade()
        {
            return moneyMade;
        }

        public void setLimbo(Coin i)
        {
            limbo.Add(i);
        }

        public List<Coin> getLimbo()
        {
            return limbo;
        }

        public void setFinalCoin(Coin i)
        {
            finalCoin.Add(i);
        }

        public List<Coin> getFinalCoin()
        {
            return finalCoin;
        }

        public void setFinalPop(Pop i)
        {
            finalPop.Add(i);
        }

        public List<Pop> getFinalPop()
        {
            return finalPop;
        }
        
    }
}
