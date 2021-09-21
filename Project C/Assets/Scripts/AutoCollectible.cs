using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class AutoCollectible : MonoBehaviour
    {
        public GameObject texture;
        public string type;

        private bool spawned = false;
        private float timeToRespawn;

        void Update()
        {
            if (!spawned)
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
                    texture.SetActive(false);
                    PlayerInventory.inventory[type]++;
                    spawned = false;
                    timeToRespawn = Random.Range(5, 30);
                }
            }
        }
    }
}
