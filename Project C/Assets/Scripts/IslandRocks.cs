using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class IslandRocks : MonoBehaviour
    {
        public GameObject interactText;
        public DialogueCanvasController controller;

        private bool playerIsHere = false;
        private static bool isDestroyed = false;

        private void Start()
        {
            if (isDestroyed)
            {
                gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (playerIsHere && Input.GetKeyDown("e") && !PlayerInventory.inventory.ContainsKey("pickaxe"))
            {
                interactText.SetActive(false);
                controller.ActivateCanvasWithText("I can't break these rocks without a pickaxe.");
            }
            if (playerIsHere && Input.GetKeyDown("e") && PlayerInventory.inventory.ContainsKey("pickaxe"))
            {
                gameObject.SetActive(false);
                isDestroyed = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                playerIsHere = true;
                interactText.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                playerIsHere = false;
                interactText.SetActive(false);
                controller.DeactivateCanvasWithDelay(0);
            }
        }
    }
}