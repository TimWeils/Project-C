using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class BackgroundSwitch : MonoBehaviour
    {
        public GameObject daySky;
        public GameObject day;

        public GameObject nightSky;
        public GameObject night;

        public GameObject rainSky;
        public GameObject rain;

        // Start is called before the first frame update
        void Start()
        {
            SwitchBackgroud();
        }

        // Update is called once per frame
        void Update()
        {
            SwitchBackgroud();
        }

        private void SwitchBackgroud()
        {
            if (GameTime.isDay)
            {
                nightSky.SetActive(false);
                night.SetActive(false);

                if (RainSwitch.isRaining)
                {
                    rainSky.SetActive(true);
                    rain.SetActive(true);

                    daySky.SetActive(false);
                    day.SetActive(false);
                }
                else
                {
                    rainSky.SetActive(false);
                    rain.SetActive(false);

                    daySky.SetActive(true);
                    day.SetActive(true);
                }
            }
            else
            {
                daySky.SetActive(false);
                day.SetActive(false);

                rainSky.SetActive(false);
                rain.SetActive(false);

                nightSky.SetActive(true);
                night.SetActive(true);
            }
        }
    }
}