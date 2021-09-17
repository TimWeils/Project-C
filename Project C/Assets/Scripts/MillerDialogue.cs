using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class MillerDialogue : Dialogue
    {
        void Update()
        {
            switch (dialogueStage)
            {
                case 0:
                    {
                        if (DetectKey("e"))
                        {
                            talkText.SetActive(false);
                            dialogueStage = 1;
                            controller.ActivateCanvasWithText("Hello, my name is Nathan and I'm miller in this mill. Do you have something for milling?");
                            SetOptionText(1, 2, "Yeah!");
                            SetOptionText(2, 2, "Nope.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "I can process either corn or wheat. Which one will it be?";
                            SetOptionText(1, 2, "Corn.");
                            SetOptionText(2, 2, "Wheat.");
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 2:
                    {
                        if (DetectKey("1"))
                        {
                            mainText.text = "Ok. I will need 5x corn in order to produce 1x corn flour.";
                            if (PlayerInventory.inventory["corn"] > 4)
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "Sure.");
                                SetOptionText(2, 2, "Nah, I don't actually need it");
                            }
                            else
                            {
                                dialogueStage = 4;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "Whoa. I don't have that much.");
                            }
                        }
                        if (DetectKey("2"))
                        {
                            mainText.text = "Ok. I will need 5x wheat in order to produce 1x wheat flour.";
                            if (PlayerInventory.inventory["wheat"] > 4)
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "Sure.");
                                SetOptionText(2, 2, "Nah, I don't actually need it");
                            }
                            else
                            {
                                dialogueStage = 4;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "Whoa. I don't have that much.");
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = "Here is the corn flour you wanted.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Thanks.");
                            PlayerInventory.inventory["corn"] -= 5;
                            PlayerInventory.inventory["cornFlour"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 4:
                    {
                        if (DetectKey("1"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 5:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = "Here is the wheat flour you wanted.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Thanks.");
                            PlayerInventory.inventory["wheat"] -= 5;
                            PlayerInventory.inventory["wheatFlour"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
            }
        }
    }
}