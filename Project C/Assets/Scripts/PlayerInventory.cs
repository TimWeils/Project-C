using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class PlayerInventory : MonoBehaviour
    {
        static public Dictionary<string, int> inventory = new Dictionary<string, int>();

        void InitializeInventory()
        {
            inventory.Add("axe", 0);
            inventory.Add("pickaxe", 0);

            inventory.Add("apple", 0);
            inventory.Add("pear", 0);
            inventory.Add("plum", 0);
            inventory.Add("corn", 0);
            inventory.Add("wheat", 0);
            inventory.Add("cornFlour", 0);
            inventory.Add("wheatFlour", 0);
            inventory.Add("berry", 0);
            inventory.Add("mushroom", 0);
            inventory.Add("dust", 0);
            inventory.Add("diamond", 0);
            inventory.Add("emerald", 0);
            inventory.Add("ruby", 0);
            inventory.Add("fish", 0);
            inventory.Add("pumpkin", 0);
            inventory.Add("watermelon", 0);
            inventory.Add("ring", 1);
            inventory.Add("necklace", 0);
            inventory.Add("bread", 0);
            inventory.Add("baguette", 0);
            inventory.Add("muffin", 0);
            inventory.Add("pie", 0);
            inventory.Add("cake", 0);
            inventory.Add("iceCream", 0);
            inventory.Add("newspaper", 0);
            inventory.Add("drink", 0);
            inventory.Add("milk", 0);
            inventory.Add("chocolate", 0);
        }

        // Start is called before the first frame update
        void Start()
        {
            if (inventory.Count == 0)
            {
                InitializeInventory();
            }
        }
    }
}