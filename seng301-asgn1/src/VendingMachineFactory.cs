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

        public VendingMachineFactory()
        {

        }

        public int createVendingMachine(List<int> coinKinds, int selectionButtonCount) {
            // TODO: Implement

            Console.WriteLine("Creates new vending machine with coins");
            Dictionary<int, VendingMachine> vendingMachines = new Dictionary<int, VendingMachine>();
            vendingMachines.Add(counter, new VendingMachine(coinKinds, selectionButtonCount));

            foreach(var a in vendingMachines)
            {
                Console.WriteLine("Displaying dictionary");
                Console.WriteLine(a);
                
            }

            int prevCoin = 0;
            foreach (int coin in coinKinds)
            {

                if(coin <= 0)
                {
                    Console.WriteLine("One of the coins given is less than or equal to zero");
                }

                else if(coin == prevCoin)
                {
                    Console.WriteLine("There are duplicate coins");
                }

                prevCoin = coin;
            }

            counter++;
            Console.WriteLine("Instances" +counter);
            Console.WriteLine("And " + selectionButtonCount + " buttons");
            return counter;
        }

        public void configureVendingMachine(int vmIndex, List<string> popNames, List<int> popCosts)
        {
            // TODO: Implement

            Console.WriteLine("Configs the machine by giving the pop names and the cost of each one");

            foreach (string pop in popNames)
            {
                Console.WriteLine(pop);
            }

            Console.WriteLine("With respective costs");
            int prevPopCost = 0;
            foreach(int cost in popCosts)
            {

                if(cost <= 0)
                {
                    Console.WriteLine("One or more of the pops has a cost less than or equal to zero");
                }

                prevPopCost = cost;
                Console.WriteLine(cost);
            }

            if(popNames.Count != popCosts.Count)
            {
                Console.WriteLine("The number of pop names is different then the number of costs, or vise versa");
            }
        }

        public void loadCoins(int vmIndex, int coinKindIndex, List<Coin> coins) {
            // TODO: Implement
            Console.WriteLine("Loads starting coins into machine");

            List<List<Coin>> chuteList = new List<List<Coin>>();

            chuteList.Add(new List<Coin>());

            foreach(List<Coin> a in chuteList)
            {
                foreach(Coin b in coins)
                {
                    Console.Write(b + ",");
                }
            }

        }

        public void loadPops(int vmIndex, int popKindIndex, List<Pop> pops) {
            // TODO: Implement
            Console.WriteLine("load machine with pop");

            foreach (Pop pop in pops)
            {
                Console.WriteLine(pop);
            }
        }

        public void insertCoin(int vmIndex, Coin coin) {
            // TODO: Implement
            Console.WriteLine("user enters coins" + coin);
        }

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