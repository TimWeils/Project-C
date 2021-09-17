using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class BakerDialogue : Dialogue
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
                            controller.ActivateCanvasWithText("Hi, I'm Tom and this is my bakery. Do you want to buy something?");
                            SetOptionText(1, 2, "Yes, please.");
                            SetOptionText(2, 2, "Nope.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Fresh from the oven as always.";
                            SetOptionText(1, 2, "Bread.");
                            SetOptionText(2, 2, "Baguette.");
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
                            mainText.text = "For bread I need 10x wheat flour and 2x mushroom.";
                            if (PlayerInventory.inventory["wheatFlour"] > 9 && PlayerInventory.inventory["mushroom"] > 1)
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "No problem.");
                            }
                            else
                            {
                                dialogueStage = 7;
                                SetOptionText(1, 2, "I need to get some resources first.");
                            }
                            SetOptionText(2, 2, "Mushrooms!?");
                        }
                        if (DetectKey("2"))
                        {
                            mainText.text = "For baguette I need 5x wheat flour and 1x mushroom.";
                            if (PlayerInventory.inventory["wheatFlour"] > 4 && PlayerInventory.inventory["mushroom"] > 0)
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "No problem.");
                            }
                            else
                            {
                                dialogueStage = 7;
                                SetOptionText(1, 2, "I need to get some resources first.");
                            }
                            SetOptionText(2, 2, "Mushrooms!?");
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = "Here's your bread m'lady and thanks for the shrooms";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Thank you!");
                            PlayerInventory.inventory["wheatFlour"] -= 10;
                            PlayerInventory.inventory["mushroom"] -= 2;
                            PlayerInventory.inventory["bread"]++;
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 6;
                            mainText.text = "Yes. I love mushrooms but unfortunately as a baker I don't have time to go into the forest to pick them up. So instead I want mushrooms from my customers.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "That's clever idea.");
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
                            mainText.text = "Here's your baguette m'lady and thanks for the shrooms";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Thank you!");
                            PlayerInventory.inventory["wheatFlour"] -= 5;
                            PlayerInventory.inventory["mushroom"] -= 1;
                            PlayerInventory.inventory["baguette"]++;
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 6;
                            mainText.text = "Yes. I love mushrooms but unfortunately as a baker I don't have time to go into the forest to pick them up. So instead I want mushrooms from my customers.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "That's clever idea.");
                        }
                        break;
                    }
                case 6:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Yeah. People around here are so friendly and kind that they accept my request. So what did you want?";
                            SetOptionText(1, 2, "Bread.");
                            SetOptionText(2, 2, "Baguette.");
                        }
                        break;
                    }
                case 7:
                    {
                        if (DetectKey("1"))
                        {
                            EndDialogue();
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 6;
                            mainText.text = "Yes. I love mushrooms but unfortunately as a baker I don't have time to go into the forest to pick them up. So instead I want mushrooms from my customers.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "That's clever idea.");
                        }
                        break;
                    }
            }
        }
    }
}