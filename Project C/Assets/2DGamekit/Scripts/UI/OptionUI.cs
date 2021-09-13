using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class OptionUI : MonoBehaviour
    {
        public void ExitPause()
        {
            PlayerCharacter.PlayerInstance.Unpause("UIMenus");
        }

        public void RestartLevel()
        {
            ExitPause();
            SceneController.RestartZone();
        }
    }
}