using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gamekit2D
{
    public class TextColorController : MonoBehaviour
    {
        public TextMeshProUGUI text; 

        // Update is called once per frame
        void Update()
        {
            if (GameTime.isDay)
            {
                text.color = Color.black;        
            }
            else
            {
                text.color = Color.white;
            }
        }
    }
}