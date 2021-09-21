using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class GemCollectible : MonoBehaviour
    {
        public GameObject infoText;
        public GameObject texture;
        public string type;
        public DialogueCanvasController controller;

        private bool spawned = false;
        private bool playerIsHere = false;
        private float timeToRespawn;

        void Update()
        {
            if (spawned)
            {
                if (playerIsHere && PlayerInput.Instance.Interact.Down && !PlayerInventory.inventory.ContainsKey("pickaxe"))
                {
                    infoText.SetActive(false);
                    controller.ActivateCanvasWithText("I can't dig it up without a pickaxe.");
                }

                if (playerIsHere && PlayerInput.Instance.Interact.Down && PlayerInventory.inventory.ContainsKey("pickaxe"))
                {
                    texture.SetActive(false);
                    infoText.SetActive(false);
                    PlayerInventory.inventory[type]++;
                    spawned = false;
                    timeToRespawn = Random.Range(5, 30);
                }
            }
            else
            {
                if (timeToRespawn > 0)
                {
                    timeToRespawn -= Time.deltaTime;
                }
                else
                {
                    texture.SetActive(true);
                    spawned = true;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                if (spawned)
                {
                    infoText.SetActive(true);
                }
                playerIsHere = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                if (spawned)
                {
                    infoText.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                infoText.SetActive(false);
                playerIsHere = false;
                controller.DeactivateCanvasWithDelay(0);
            }
        }
    }
}