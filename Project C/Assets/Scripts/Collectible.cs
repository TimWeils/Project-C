using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Collectible : MonoBehaviour
    {
        public GameObject infoText;
        public GameObject texture;
        public string type;

        private bool spawned = false;
        private bool playerIsHere = false;
        private float timeToRespawn;

        void Update()
        {
            if (spawned)
            {
                if (playerIsHere && PlayerInput.Instance.Interact.Down)
                {
                    texture.SetActive(false);
                    infoText.SetActive(false);
                    PlayerCharacter.inventory[type]++;
                    spawned = false;
                    timeToRespawn = Random.Range(1, 5);
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
            }
        }
    }
}
