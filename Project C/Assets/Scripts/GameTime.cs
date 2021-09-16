using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Gamekit2D
{
    public class GameTime : MonoBehaviour
    {
        static public double hours;
        static public double minutes;
        static public bool isDay = true;

        static private double time = 2260;

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            hours = Math.Floor((time / 120) % 24);
            minutes = Math.Floor((time % 120) / 2);

            if (hours >= 6 && hours <= 19)
            {
                isDay = true;
            }
            else
            {
                isDay = false;
            }
        }
    }
}