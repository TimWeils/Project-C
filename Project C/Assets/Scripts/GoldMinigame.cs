using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gamekit2D
{
    public class GoldMinigame : MonoBehaviour
    {
        public TextMeshProUGUI message;
        public GameObject messageObject;

        private bool isPlaying = false;
        private bool press1 = false;
        private bool press3 = false;
        private bool playerLeft = false;
        private bool playerIsHere = false;
        private float time;
        private int count;

        // Update is called once per frame
        void Update()
        {
            if (isPlaying)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                    if (press1 && Input.GetKeyDown("1"))
                    {
                        press1 = false;
                        press3 = true;
                        count++;
                        message.text = "Press 3 to swirl with the pan";
                    }
                    if (press3 && Input.GetKeyDown("3"))
                    {
                        press3 = false;
                        press1 = true;
                        count++;
                        message.text = "Press 1 to swirl with the pan";
                    }
                }
                else
                {
                    isPlaying = false;
                    press1 = false;
                    press3 = false;
                    if (count > 25)
                    {
                        count = 25 - (count / 4);
                        if (count < 0)
                        {
                            count = 0;
                        }
                    }
                    message.text = "You obtained " + count + "x golden dust! Press E to pan again";
                    PlayerInventory.inventory["dust"] += count;
                }
            }
            else if (playerLeft)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    playerLeft = false;
                    messageObject.SetActive(false);
                }
            }
            else
            {
                if (playerIsHere && Input.GetKeyDown("e"))
                {
                    isPlaying = true;
                    press1 = true;
                    message.text = "Press 1 to swirl with the pan";
                    time = 10;
                    count = 0;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag") && PlayerInventory.inventory.ContainsKey("pan"))
            {
                playerIsHere = true;
                playerLeft = false;
                message.text = "Press E to start gold panning";
                messageObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                if (isPlaying)
                {
                    playerLeft = true;
                    time = 1;
                    message.text = "Gold panning failed!";
                }
                isPlaying = false;
                press3 = false;
                press1 = false;
                if (!playerLeft)
                {
                    messageObject.SetActive(false);
                }
            }
        }
    }
}