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

            var.setChutes(coins);

        }

        public void loadPops(int vmIndex, int popKindIndex, List<Pop> pops) {

            VendingMachine var = vendingMachines[vmIndex];

            var.setPopChutes(pops);
        }

        public void insertCoin(int vmIndex, Coin coin) {
            // TODO: Implement
            Console.WriteLine("user enters coins" + coin);

            VendingMachine var = vendingMachines[vmIndex];

            List<int> temp = var.getCoinTypes();

            foreach(int a in temp)
            {
                if(temp.Contains(coin.Value))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("coin is bad");
                    throw new Exception("Coin entered is not accepted");
                }
            }
        }
        sd

        public void pressButton(int vmIndex, int value)
        {
            // TODO: Implement
            Console.WriteLine("user presses button" + value);
        }

        public List<Deliverable> extractFromDeliveryChute(int vmIndex) {
            // TODO: Implement
            Console.WriteLine("take out stuff from chute");
            return new List<Deliverable>();
        }

        public List<IList> unloadVendingMachine(int vmIndex) {
            // TODO: Implement
            Console.WriteLine("Open vending machine and remove all items");
            return new List<IList>() {
                new List<Coin>(),
                new List<Coin>(),
                new List<Pop>() };
            }
    }
}