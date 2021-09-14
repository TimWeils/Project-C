using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class RainSwitch : MonoBehaviour
    {
        public static bool IsRaining = false;

        public GameObject rainGenerator;

        // Start is called before the first frame update
        void Start()
        {
            IsRaining = false;
            Rain();
        }

        // Update is called once per frame
        void Update()
        {
            Rain();
        }

        private void Rain()
        {
            int random = Random.Range(0, 100000);
            if (random < 5)
            {
                IsRaining = true;
                rainGenerator.SetActive(true);
            }
        }
    }
}