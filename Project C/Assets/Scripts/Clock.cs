using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gamekit2D
{
    public class Clock : MonoBehaviour
    {
        public TextMeshProUGUI clock;

        // Start is called before the first frame update
        void Start()
        {
            SetTime();
        }

        // Update is called once per frame
        void Update()
        {
            SetTime();
        }

        private void SetTime()
        {
            clock.text = GameTime.hours + " : " + string.Format("{0:00}", GameTime.minutes);
        }
    }
}