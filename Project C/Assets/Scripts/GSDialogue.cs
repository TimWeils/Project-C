using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class GSDialogue : Dialogue
    {
        private static bool firstNecklace = true;
        private static int pumpkins = 0;

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
                            controller.ActivateCanvasWithText("Greetings fellow villager! My name is Catherine but everybody calls me Crazy Catherine. Why? Because I'm crazy and so are the deals in this shop. Wanna see them?");
                            SetOptionText(1, 2, "Sure.");
                            SetOptionText(2, 2, "Sorry, but no.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1") && firstNecklace)
                        {
                            dialogueStage = 2;
                            mainText.text = "Since you are new I can offer you only this apple. And in return I want... umm... necklace. Yes, NECKLACE!";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "What?!");
                        }
                        else if (DetectKey("1"))
                        {
                            if (PlayerInventory.inventory["necklace"] > 0)
                            {
                                dialogueStage = 11;
                                mainText.text = "Ohhh! What a shiny necklace. I WANT IT!!!";
                                SetOptionText(1, 2, "What can you offer for it?");
                                SetOptionText(2, 2, "No! It's mine.");
                            }
                            else
                            {
                                dialogueStage = 6;
                                mainText.text = "If you have enough pumpkins you can have one of these. So what do you want?";
                                DeactivateOptions(2);
                                SetOptionText(1, 4, "Newspaper.");
                                SetOptionText(2, 4, "Drink.");
                                SetOptionText(3, 4, "Milk.");
                                SetOptionText(4, 4, "Chocolate.");
                            }
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
                            dialogueStage = 3;
                            mainText.text = "Oh! I see. The offer is not good. Well then I will give you 2 apples";
                            SetOptionText(1, 2, "That's still not worth it.");
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = "I would give you more but I have only 2 apples.";
                            if (PlayerInventory.inventory["necklace"] > 0)
                            {
                                dialogueStage = 4;
                                SetOptionText(1, 2, "Ok. Fine. Here it is.");
                                SetOptionText(2, 2, "Sorry, but I can't do it just for 2 apples. Bye!");
                            }
                            else
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "I see. But I don't have the necklace anyway. So maybe next time.");
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 1;
                            mainText.text = "Thank you! It looks beautiful. Now you can check out my other deals. Currently I'm selling these things for pumpkins because I'm creating a pumpkin collection.";
                            SetOptionText(1, 2, "Oh. Ok, show me.");
                            SetOptionText(2, 2, "Sorry but no. Maybe next time.");
                            firstNecklace = false;
                            PlayerInventory.inventory["necklace"]--;

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
                            EndDialogue();
                        }
                        break;
                    }
                case 6:
                    {
                        if (DetectKey("1"))
                        {
                            DeactivateOptions(4);
                            mainText.text = "That will be 5x pumpkin.";
                            if (PlayerInventory.inventory["pumpkin"] > 4)
                            {
                                dialogueStage = 7;
                                SetOptionText(1, 2, "Here they are.");
                                SetOptionText(2, 2, "That's too pricy!");
                            }
                            else
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "I'm sorry but it seems I don't have enough pumpkins.");
                            }
                        }
                        if (DetectKey("2"))
                        {
                            DeactivateOptions(4);
                            mainText.text = "That will be 7x pumpkin.";
                            if (PlayerInventory.inventory["pumpkin"] > 6)
                            {
                                dialogueStage = 8;
                                SetOptionText(1, 2, "Here they are.");
                                SetOptionText(2, 2, "That's too pricy!");
                            }
                            else
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "I'm sorry but it seems I don't have enough pumpkins.");
                            }
                        }
                        if (DetectKey("3"))
                        {
                            DeactivateOptions(4);
                            mainText.text = "That will be 10x pumpkin.";
                            if (PlayerInventory.inventory["pumpkin"] > 9)
                            {
                                dialogueStage = 9;
                                SetOptionText(1, 2, "Here they are.");
                                SetOptionText(2, 2, "That's too pricy!");
                            }
                            else
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "I'm sorry but it seems I don't have enough pumpkins.");
                            }
                        }
                        if (DetectKey("4"))
                        {
                            DeactivateOptions(4);
                            mainText.text = "That will be 3x pumpkin.";
                            if (PlayerInventory.inventory["pumpkin"] > 2)
                            {
                                dialogueStage = 10;
                                SetOptionText(1, 2, "Here they are.");
                                SetOptionText(2, 2, "That's too pricy!");
                            }
                            else
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "I'm sorry but it seems I don't have enough pumpkins.");
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 5;
                            mainText.text = "What a nice pumpkins for my collection!";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "I'm glad you like them.");
                            PlayerInventory.inventory["pumpkin"] -= 5;
                            PlayerInventory.inventory["newspaper"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 8:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 5;
                            mainText.text = "What a nice pumpkins for my collection!";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "I'm glad you like them.");
                            PlayerInventory.inventory["pumpkin"] -= 7;
                            PlayerInventory.inventory["drink"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 9:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 5;
                            mainText.text = "What a nice pumpkins for my collection!";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "I'm glad you like them.");
                            PlayerInventory.inventory["pumpkin"] -= 10;
                            PlayerInventory.inventory["milk"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 10:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 5;
                            mainText.text = "What a nice pumpkins for my collection!";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "I'm glad you like them.");
                            PlayerInventory.inventory["pumpkin"] -= 3;
                            PlayerInventory.inventory["chocolate"]++;
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 11:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 12;
                            mainText.text = "It's so S H I N Y! I need it. You can have my entire pumpkin collection.";
                            SetOptionText(1,2,"Fine if you insist.");
                            SetOptionText(2, 2, "No way!");
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 12:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 5;
                            mainText.text = "Thank you! You are the best person I ever met!";
                            SetOptionText(1, 2, "I'm happy when you are happy.");
                            PlayerInventory.inventory["necklace"]--;
                            PlayerInventory.inventory["pumpkin"] += pumpkins;
                            pumpkins = 0;
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