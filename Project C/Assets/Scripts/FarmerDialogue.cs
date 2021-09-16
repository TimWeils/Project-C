using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class FarmerDialogue : Dialogue
    {
        void Update()
        {
            switch (dialogueStage)
            {
                case 0:
                    {
                        if (playerIsHere && Input.GetKeyDown("e"))
                        {
                            talkText.SetActive(false);
                            dialogueStage = 1;
                            controller.ActivateCanvasWithText("Hello, my name is Josh and I'm local farmer.");
                            SetOptionText(1, 2, "1. What are you doing here?");
                            SetOptionText(2, 2, "2. Bye!");

                        }
                        break;
                    }
                case 1:
                    {
                        if (playerIsHere && Input.GetKeyDown("1"))
                        {
                            mainText.text = ("I'm just chilling.");
                            DeactivateOptions(2);
                            SetOptionText(1, 4, "1. Oh, OK. I will stop bothering you.");
                            SetOptionText(2, 4, "This is not an option. Just a test.");
                            dialogueStage = 2;
                        }
                        if (playerIsHere && Input.GetKeyDown("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 2:
                    {
                        if (playerIsHere && Input.GetKeyDown("1"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
            }
        }
    }
}