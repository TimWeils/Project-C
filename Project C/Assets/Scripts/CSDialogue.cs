using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class CSDialogue : Dialogue
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
                            controller.ActivateCanvasWithText("Hi my name is Rose and I'm working in this cake shop. Are you looking for some sweets sweetie?");
                            SetOptionText(1, 2, "Yes.");
                            SetOptionText(2, 2, "Actually no.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "So what type of confection do you want?";
                            DeactivateOptions(2);
                            SetOptionText(1, 4, "Muffin.");
                            SetOptionText(2, 4, "Pie.");
                            SetOptionText(3, 4, "Cake.");
                            SetOptionText(4, 4, "Ice cream.");
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
                            mainText.text = "Muffin. Alright! I need 2x corn flour and 5x chocolate for that.";
                            DeactivateOptions(4);
                            if (PlayerInventory.inventory["cornFlour"] > 1 && PlayerInventory.inventory["chocolate"] > 4)
                            {
                                dialogueStage = 4;
                                SetOptionText(1, 2, "That's not a problem.");
                                SetOptionText(2, 2, "When I think about it I don't need it now. Bye!");
                            }
                            else
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "Sorry, but I can't afford that.");
                            }
                        }
                        if (DetectKey("2"))
                        {
                            mainText.text = "Pie. Alright! I need 3x wheat flour, 5x apple, 5x pear and 5x plum for that.";
                            DeactivateOptions(4);
                            if (PlayerInventory.inventory["wheatFlour"] > 2 && PlayerInventory.inventory["apple"] > 4 && PlayerInventory.inventory["pear"] > 4 && PlayerInventory.inventory["plum"] > 4)
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "That's not a problem.");
                                SetOptionText(2, 2, "When I think about it I don't need it now. Bye!");
                            }
                            else
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "Sorry, but I can't afford that.");
                            }
                        }
                        if (DetectKey("3"))
                        {
                            mainText.text = "Cake. Alright! I need 4x wheat flour, 10x berry and 5x chocolate for that.";
                            DeactivateOptions(4);
                            if (PlayerInventory.inventory["wheatFlour"] > 3 && PlayerInventory.inventory["berry"] > 9 && PlayerInventory.inventory["chocolate"] > 4)
                            {
                                dialogueStage = 6;
                                SetOptionText(1, 2, "That's not a problem.");
                                SetOptionText(2, 2, "When I think about it I don't need it now. Bye!");
                            }
                            else
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "Sorry, but I can't afford that.");
                            }
                        }
                        if (DetectKey("4"))
                        {
                            mainText.text = "Ice cream. Alright! I need 2x watermelon and 1x milk for that.";
                            DeactivateOptions(4);
                            if (PlayerInventory.inventory["watermelon"] > 2 && PlayerInventory.inventory["milk"] > 0)
                            {
                                dialogueStage = 7;
                                SetOptionText(1, 2, "That's not a problem.");
                                SetOptionText(2, 2, "When I think about it I don't need it now. Bye!");
                            }
                            else
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "Sorry, but I can't afford that.");
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
                            mainText.text = "Here it is! Chocolate muffin. Nice and warm.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Nice. Just what I wanted.");
                            PlayerInventory.inventory["cornFlour"] -= 2;
                            PlayerInventory.inventory["chocolate"] -= 5;
                            PlayerInventory.inventory["muffin"]++;
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
                            mainText.text = "Here it is! Fruit pie. Nice and warm.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Nice. Just what I wanted.");
                            PlayerInventory.inventory["wheatFlour"] -= 3;
                            PlayerInventory.inventory["apple"] -= 5;
                            PlayerInventory.inventory["pear"] -= 5;
                            PlayerInventory.inventory["plum"] -= 5;
                            PlayerInventory.inventory["pie"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 6:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 3;
                            mainText.text = "Here it is! Chocolate cake with berries. Nice and fresh.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Nice. Just what I wanted.");
                            PlayerInventory.inventory["wheatFlour"] -= 4;
                            PlayerInventory.inventory["berry"] -= 10;
                            PlayerInventory.inventory["chocolate"] -= 5;
                            PlayerInventory.inventory["cake"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 7:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 3;
                            mainText.text = "Here it is! Watermelon ice cream. Nice and cool.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Nice. Just what I wanted.");
                            PlayerInventory.inventory["watermelon"] -= 2;
                            PlayerInventory.inventory["milk"]--;
                            PlayerInventory.inventory["iceCream"]++;
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