using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class NPCController : MonoBehaviour
    {
        public GameObject npcTexture;
        public GameObject dialogueObject;
        public Dialogue dialogue;


        // Start is called before the first frame update
        void Start()
        {
            SetNPC();
        }

        // Update is called once per frame
        void Update()
        {
            SetNPC();
        }

        private void SetNPC()
        {
            if (GameTime.isDay)
            {
                npcTexture.SetActive(true);
                dialogueObject.SetActive(true);
            }
            else
            {
                if (!dialogue.playerIsHere)
                {
                    npcTexture.SetActive(false);
                    dialogueObject.SetActive(false);
                }
            }
        }
    }
}