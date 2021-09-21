using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class BlacksmithDialogue : Dialogue
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
                            controller.ActivateCanvasWithText("Good day to you! My name is Bertholdt and I have forge behind my house.");
                            SetOptionText(1, 2, "That's impressive. Could you forge me something?");
                            SetOptionText(2, 2, "I wish you good smithing then. Bye!");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Well I could make you one of these.";
                            SetOptionText(1, 2, "Axe.");
                            SetOptionText(2, 2, "Pickaxe.");
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
                            mainText.text = "Before I get to work I would really appreciate if you could bring me 1x drink, 1x baguette and 1x bread. It would give me energy for the hard work.";
                            if (PlayerInventory.inventory["drink"] > 0 && PlayerInventory.inventory["bread"] > 0 && PlayerInventory.inventory["baguette"] > 0)
                            {
                                dialogueStage = 4;
                                SetOptionText(1, 2, "Here is your order");
                                SetOptionText(2, 2, "Wait. I think I actually don't need it. Bye!");
                            }
                            else
                            {
                                dialogueStage = 3;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "No problem. Just wait a minute.");
                            }
                        }
                        if (DetectKey("2"))
                        {
                            mainText.text = "Today it's really hot at the forge. Do you think you could bring me 1x ice cream and 1x drink before I start the work?";
                            if (PlayerInventory.inventory["drink"] > 0 && PlayerInventory.inventory["iceCream"] > 0)
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "Here is your order");
                                SetOptionText(2, 2, "Wait. I think I actually don't need it. Bye!");
                            }
                            else
                            {
                                dialogueStage = 3;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "No problem. Just wait a minute.");
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 4:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 3;
                            mainText.text = "Here is your tool. I hope it will last long.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "It looks marvelous. Thank you.");
                            PlayerInventory.inventory["bread"]--;
                            PlayerInventory.inventory["baguette"]--;
                            PlayerInventory.inventory["drink"]--;
                            if (!PlayerInventory.inventory.ContainsKey("axe"))
                            {
                                PlayerInventory.inventory.Add("axe", 0);
                            }
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 5:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 3;
                            mainText.text = "Here is your tool. I hope it will last long.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "It looks marvelous. Thank you.");
                            PlayerInventory.inventory["iceCream"]--;
                            PlayerInventory.inventory["drink"]--;
                            if (!PlayerInventory.inventory.ContainsKey("pickaxe"))
                            {
                                PlayerInventory.inventory.Add("pickaxe", 0);
                            }
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