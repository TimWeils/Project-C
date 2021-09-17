using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Book : MonoBehaviour
    {
        public GameObject readText;
        public DialogueCanvasController controller;
        public string bookText;

        private bool playerIsHere = false;

        // Update is called once per frame
        void Update()
        {
            if (playerIsHere && Input.GetKeyDown("e"))
            {
                readText.SetActive(false);
                controller.ActivateCanvasWithText(bookText);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                playerIsHere = true;
                readText.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                playerIsHere = false;
                readText.SetActive(false);
                controller.DeactivateCanvasWithDelay(0);
            }
        }
    }
}