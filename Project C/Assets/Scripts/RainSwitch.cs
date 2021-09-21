using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class RainSwitch : MonoBehaviour
    {
        public static bool isRaining = false;

        public GameObject rainGenerator;

        // Start is called before the first frame update
        void Start()
        {
            isRaining = false;
            Rain();
        }

        // Update is called once per frame
        void Update()
        {
            Rain();
        }

        private void Rain()
        {
            int random = Random.Range(0, 1000000);
            if (random > 999997)
            {
                isRaining = true;
                rainGenerator.SetActive(true);
            }
        }
    }
}