using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class MinesEntrance : MonoBehaviour
    {
        public GameObject interactText;
        public DialogueCanvasController controller;

        private bool playerIsHere;
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
            if (playerIsHere && Input.GetKeyDown("e") && !PlayerInventory.inventory.ContainsKey("axe"))
            {
                interactText.SetActive(false);
                controller.ActivateCanvasWithText("I can't break these planks without an axe.");
            }
            if (playerIsHere && Input.GetKeyDown("e") && PlayerInventory.inventory.ContainsKey("axe"))
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