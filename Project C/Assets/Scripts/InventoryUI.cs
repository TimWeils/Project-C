using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gamekit2D
{
    public class InventoryUI : MonoBehaviour
    {
        public TextMeshProUGUI axe;
        public TextMeshProUGUI pickaxe;
        public TextMeshProUGUI rod;
        public TextMeshProUGUI pan;

        public TextMeshProUGUI apple;
        public TextMeshProUGUI pear;
        public TextMeshProUGUI plum;
        public TextMeshProUGUI corn;
        public TextMeshProUGUI wheat;
        public TextMeshProUGUI cornFlour;
        public TextMeshProUGUI wheatFlour;
        public TextMeshProUGUI berry;
        public TextMeshProUGUI mushroom;
        public TextMeshProUGUI dust;
        public TextMeshProUGUI diamond;
        public TextMeshProUGUI emerald;
        public TextMeshProUGUI ruby;
        public TextMeshProUGUI fish;
        public TextMeshProUGUI pumpkin;
        public TextMeshProUGUI watermelon;
        public TextMeshProUGUI ring;
        public TextMeshProUGUI necklace;
        public TextMeshProUGUI bread;
        public TextMeshProUGUI baguette;
        public TextMeshProUGUI muffin;
        public TextMeshProUGUI pie;
        public TextMeshProUGUI cake;
        public TextMeshProUGUI iceCream;
        public TextMeshProUGUI newspaper;
        public TextMeshProUGUI drink;

        public void ExitPause()
        {
            PlayerCharacter.PlayerInstance.Unpause("Inventory");
        }

        void Awake()
        {
            int count;

            if (PlayerInventory.inventory.TryGetValue("axe",out count))
            {
                axe.color = Color.green;
            }
            else
            {
                axe.color = Color.red;
            }

            if (PlayerInventory.inventory.TryGetValue("pickaxe", out count))
            {
                pickaxe.color = Color.green;
            }
            else
            {
                pickaxe.color = Color.red;
            }

            if (PlayerInventory.inventory.TryGetValue("rod", out count))
            {
                rod.color = Color.green;
            }
            else
            {
                rod.color = Color.red;
            }

            if (PlayerInventory.inventory.TryGetValue("pan", out count))
            {
                pan.color = Color.green;
            }
            else
            {
                pan.color = Color.red;
            }

            PlayerInventory.inventory.TryGetValue("apple", out count);
            apple.text = "Apple " + count + "x";

            PlayerInventory.inventory.TryGetValue("pear", out count);
            pear.text = "Pear " + count + "x";

            PlayerInventory.inventory.TryGetValue("plum", out count);
            plum.text = "Plum " + count + "x";

            PlayerInventory.inventory.TryGetValue("corn", out count);
            corn.text = "Corn " + count + "x";

            PlayerInventory.inventory.TryGetValue("wheat", out count);
            wheat.text = "Wheat " + count + "x";

            PlayerInventory.inventory.TryGetValue("cornFlour", out count);
            cornFlour.text = "Corn Flour " + count + "x";

            PlayerInventory.inventory.TryGetValue("wheatFlour", out count);
            wheatFlour.text = "Wheat Flour " + count + "x";

            PlayerInventory.inventory.TryGetValue("berry", out count);
            berry.text = "Berry " + count + "x";

            PlayerInventory.inventory.TryGetValue("mushroom", out count);
            mushroom.text = "Mushroom " + count + "x";

            PlayerInventory.inventory.TryGetValue("dust", out count);
            dust.text = "Golden Dust " + count + "x";

            PlayerInventory.inventory.TryGetValue("diamond", out count);
            diamond.text = "Diamond " + count + "x";

            PlayerInventory.inventory.TryGetValue("emerald", out count);
            emerald.text = "Emerald " + count + "x";

            PlayerInventory.inventory.TryGetValue("ruby", out count);
            ruby.text = "Ruby " + count + "x";

            PlayerInventory.inventory.TryGetValue("fish", out count);
            fish.text = "Fish " + count + "x";

            PlayerInventory.inventory.TryGetValue("pumpkin", out count);
            pumpkin.text = "Pumpkin " + count + "x";

            PlayerInventory.inventory.TryGetValue("watermelon", out count);
            watermelon.text = "Watermelon " + count + "x";

            PlayerInventory.inventory.TryGetValue("ring", out count);
            ring.text = "Ring " + count + "x";

            PlayerInventory.inventory.TryGetValue("necklace", out count);
            necklace.text = "Necklace " + count + "x";

            PlayerInventory.inventory.TryGetValue("bread", out count);
            bread.text = "Bread " + count + "x";

            PlayerInventory.inventory.TryGetValue("baguette", out count);
            baguette.text = "Baguette " + count + "x";

            PlayerInventory.inventory.TryGetValue("muffin", out count);
            muffin.text = "Muffin " + count + "x";

            PlayerInventory.inventory.TryGetValue("pie", out count);
            pie.text = "Pie " + count + "x";

            PlayerInventory.inventory.TryGetValue("cake", out count);
            cake.text = "Cake " + count + "x";

            PlayerInventory.inventory.TryGetValue("iceCream", out count);
            iceCream.text = "Ice Cream " + count + "x";

            PlayerInventory.inventory.TryGetValue("newspaper", out count);
            newspaper.text = "Newspaper " + count + "x";

            PlayerInventory.inventory.TryGetValue("drink", out count);
            drink.text = "Drink " + count + "x";
        }
    }
}