using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gamekit2D
{
    public class FishingMinigame : MonoBehaviour
    {
        public TextMeshProUGUI message;
        public GameObject messageObject;

        private bool isFishing = false;
        private bool isReeling = false;
        private bool playerLeft = false;
        private bool playerIsHere = false;
        private float time;

        // Update is called once per frame
        void Update()
        {
            if (isFishing)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    isFishing = false;
                    isReeling = true;
                    time = 2;
                    message.text = "Press E to reel in the fish";
                }
            }
            else if (isReeling)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                    if (playerIsHere && Input.GetKeyDown("e"))
                    {
                        isReeling = false;
                        message.text = "Success! Press E to fish again";
                        PlayerInventory.inventory["fish"]++;
                    }
                }
                else
                {
                    isReeling = false;
                    message.text = "Fail! Press E to fish again";
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
                    message.text = "Waiting for fish";
                    isFishing = true;
                    time = Random.Range(5, 20);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag") && PlayerInventory.inventory.ContainsKey("rod"))
            {
                playerIsHere = true;
                playerLeft = false;
                message.text = "Press E to start fishing";
                messageObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                if (isFishing || isReeling)
                {
                    playerLeft = true;
                    time = 1;
                    message.text = "Fishing failed!";
                }
                isFishing = false;
                isReeling = false;
                playerIsHere = false;
                if (!playerLeft)
                {
                    messageObject.SetActive(false);
                }
            }
        }
    }
}