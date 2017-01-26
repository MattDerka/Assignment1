using System.Collections;
using System.Collections.Generic;
using System;

using Frontend1;



namespace seng301_asgn1 {
    /// <summary>
    /// Represents the concrete virtual vending machine factory that you will implement.
    /// This implements the IVendingMachineFactory interface, and so all the functions
    /// are already stubbed out for you.
    /// 
    /// Your task will be to replace the TODO statements with actual code.
    /// 
    /// Pay particular attention to extractFromDeliveryChute and unloadVendingMachine:
    /// 
    /// 1. These are different: extractFromDeliveryChute means that you take out the stuff
    /// that has already been dispensed by the machine (e.g. pops, money) -- sometimes
    /// nothing will be dispensed yet; unloadVendingMachine is when you (virtually) open
    /// the thing up, and extract all of the stuff -- the money we've made, the money that's
    /// left over, and the unsold pops.
    /// 
    /// 2. Their return signatures are very particular. You need to adhere to this return
    /// signature to enable good integration with the other piece of code (remember:
    /// this was written by your boss). Right now, they return "empty" things, which is
    /// something you will ultimately need to modify.
    /// 
    /// 3. Each of these return signatures returns typed collections. For a quick primer
    /// on typed collections: https://www.youtube.com/watch?v=WtpoaacjLtI -- if it does not
    /// make sense, you can look up "Generic Collection" tutorials for C#.
    /// </summary>
    public class VendingMachineFactory : IVendingMachineFactory {

        static int counter = 0;
        List<VendingMachine> vendingMachines = new List<VendingMachine>();


        public VendingMachineFactory()
        {

        }

        public int createVendingMachine(List<int> coinKinds, int selectionButtonCount) {

            vendingMachines.Add(new VendingMachine(coinKinds, selectionButtonCount));

            int prevCoin = 0;
            foreach (int coin in coinKinds)
            {

                if(coin <= 0)
                {
                    throw new Exception("One of the coins given is less than or equal to zero");
                }

                else if(coin == prevCoin)
                {
                    throw new Exception("There are duplicate coins");
                }

                prevCoin = coin;
            }

            counter++;
            return counter;
        }

        public void configureVendingMachine(int vmIndex, List<string> popNames, List<int> popCosts)
        {
            VendingMachine var = vendingMachines[vmIndex];

            var.setPopNames(popNames);
            var.setPopCosts(popCosts);

            int prevPopCost = 0;
            foreach(int cost in popCosts)
            {

                if(cost <= 0)
                {
                    throw new Exception("One or more of the pops has a cost less than or equal to zero");
                }

                prevPopCost = cost;
            }

            if(popNames.Count != popCosts.Count)
            {
                throw new Exception("The number of pop names is different then the number of costs, or vise versa");
            }

        }

        public void loadCoins(int vmIndex, int coinKindIndex, List<Coin> coins) {

            VendingMachine var = vendingMachines[vmIndex];

            var.setCoinChutes(coinKindIndex, coins);

            //var.setChutes(coins);

        }

        public void loadPops(int vmIndex, int popKindIndex, List<Pop> pops) {

            VendingMachine var = vendingMachines[vmIndex];

            var.setPopChutes(popKindIndex, pops);
           // var.setPopChutes(pops);
        }

        public void insertCoin(int vmIndex, Coin coin) {

            VendingMachine var = vendingMachines[vmIndex];

            List<int> temp = var.getCoinTypes();

            if(!temp.Contains(coin.Value))
            {
                var.setDeliveryChute(coin);
            }
            else
            {
                var.setLimbo(coin);
            }

        }

        public void pressButton(int vmIndex, int value)
        {

            VendingMachine var = vendingMachines[vmIndex];
            Dictionary<int, List<Pop>> popChutes = var.getPopChutes();
            Dictionary<int, List<Coin>> coinChutes = var.getCoinChutes();
            List<Pop> foo = new List<Pop>();
            List<Coin> coins = new List<Coin>();
            List<Coin> boo = var.getMoneyMade();
            List<int> too = var.getPopCosts();
            List<Coin> limbo = var.getLimbo();


            Console.WriteLine("limbo at pres");

            int cost = too[value];
            int total = 0;
            int change = 0;


            foreach (Coin a in limbo)
            {
                total += a.Value;
            }

            change = total - cost;
            Console.WriteLine(total);

            popChutes.TryGetValue(value, out foo);
            //Console.WriteLine("pop chute");
            //foo.ForEach(Console.WriteLine);

            if(limbo.Count != 0 && total >= cost)
            {
                Pop pop = foo[0];
                foo.Remove(pop);

                var.setDeliveryChute(pop);

                foreach (Coin a in limbo)
                {
                    var.setMoneyMade(a);
                }
                limbo.Clear();


                for(int i= coinChutes.Count-1; i >= 0; i--)
                {
                    coinChutes.TryGetValue(i, out coins);
                    Coin coin = coins[0];
                    while (change % coin.Value == 0 && change != 0)
                    {

                            var.setDeliveryChute(coin);
                            change -= coin.Value;
                        

                    }
                }


                Console.WriteLine("money made");
                var.getMoneyMade().ForEach(Console.WriteLine);

            }


        }

        public List<Deliverable> extractFromDeliveryChute(int vmIndex) {

            VendingMachine var = vendingMachines[vmIndex];

            List<Deliverable> temp = var.getDeliveryChute();

            Console.WriteLine("deil chute");
            temp.ForEach(Console.WriteLine);

            return temp;
        }

        public List<IList> unloadVendingMachine(int vmIndex) {

            VendingMachine var = vendingMachines[vmIndex];
            List<Coin> moneyMade = var.getMoneyMade();
            List<Coin> moneyChange = new List<Coin>();

          //  moneyMade.ForEach(Console.WriteLine);



            return new List<IList>() {
                new List<Coin>(),
                moneyMade,
                new List<Pop>() };
            }
    }
}
