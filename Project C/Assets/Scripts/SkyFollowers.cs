using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class SkyFollowers : MonoBehaviour
    {
        public GameObject player;

        public GameObject sun;
        public GameObject moon;
        public GameObject cloud01;
        public GameObject cloud02;

        // Start is called before the first frame update
        void Start()
        {
            SwitchFollower();
            Follow();
        }

        // Update is called once per frame
        void Update()
        {
            SwitchFollower();
            Follow();
        }

        private void Follow()
        {
            var playerPos = player.transform.position;
            var thisPos = transform.position;
            transform.position = new Vector3(playerPos.x, thisPos.y, 0);
        }

        private void SwitchFollower()
        {
            if (GameTime.IsDay)
            {
                moon.SetActive(false);

                if (RainSwitch.IsRaining)
                {
                    cloud01.SetActive(true);
                    cloud02.SetActive(true);
                }
                else
                {
                    cloud01.SetActive(false);
                    cloud02.SetActive(false);
                }

                sun.SetActive(true);
            }
            else
            {
                sun.SetActive(false);

                if (RainSwitch.IsRaining)
                {
                    cloud01.SetActive(true);
                    cloud02.SetActive(true);
                }
                else
                {
                    cloud01.SetActive(false);
                    cloud02.SetActive(false);
                }

                moon.SetActive(true);
            }
        }
    }
}