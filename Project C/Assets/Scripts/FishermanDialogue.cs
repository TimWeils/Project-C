using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class FishermanDialogue : Dialogue
    {
        public GameObject transitionStart;

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
                            controller.ActivateCanvasWithText("Hi, I'm Marco and I'm local fisherman.");
                            SetOptionText(1, 2, "There are fishes here?");
                            SetOptionText(2, 2, "Do you live here? I mean it's pretty far away from the town.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Yeah. Plenty of them are living in these waters. Wanna learn how to catch them?";
                            SetOptionText(1, 2, "Hell yeah!");
                            SetOptionText(2, 2, "No. Sounds boring.");
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 8;
                            mainText.text = "Yes, I live here. The long way to town is compensated by the fresh air and this beeautiful lake with the island in the middle.";
                            SetOptionText(1, 2, "There is an island?!");
                            SetOptionText(2, 2, "Yeah. Thanks for the talk.");
                        }
                        break;
                    }
                case 2:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 3;
                            mainText.text = "First, you need a fishing rod. Do you have one?";
                            SetOptionText(1, 2, "Yes.");
                            SetOptionText(2, 2, "No.");
                        }
                        if (DetectKey("2"))
                        {
                            EndDialogue();
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = "Then it's easy. Just stand near water and start angling. Patiently wait for the fish and then just reel it in.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Ok, got it!");
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 5;
                            mainText.text = "Well that's pretty essential part. I could give you one of mines but in return I would need something from you.";
                            SetOptionText(1, 2, "Sure thing.");
                            SetOptionText(2, 2, "No way!");
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
                            mainText.text = "I want to propose to my girlfriend. But I don't have any ring. Could you bring me one?";
                            if (PlayerInventory.inventory["ring"] > 0)
                            {
                                dialogueStage = 6;
                                SetOptionText(1, 2, "Well I have this diamond ring rigth there.");
                            }
                            else
                            {
                                dialogueStage = 7;
                                SetOptionText(1, 2, "Sure. I will bring you the pretiest one I found.");
                            }
                            SetOptionText(2, 2, "Ring for the fishing rod?! Are you nuts?");
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
                            dialogueStage = 4;
                            mainText.text = "WOW! It's beautiful. You have my huge thanks. Here is the promised fishing rod.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "No problem and thanks for the rod.");
                            PlayerInventory.inventory["ring"]--;
                            if (!PlayerInventory.inventory.ContainsKey("rod"))
                            {
                                PlayerInventory.inventory.Add("rod", 0);
                            }
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
                            EndDialogue();
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
                            dialogueStage = 9;
                            mainText.text = "Do you want to go there? I have a boat here. I used to play on this island with my friends when I was young.";
                            SetOptionText(1, 2, "Yes!");
                            SetOptionText(2, 2, "No, I have seasickness.");
                                                    
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
                            mainText.text = "Ok. But first I need to fill up my hungry stomach. And what's better for that then a fish. Unfortunatelly I already ate all of my supplies. Do you have any fish to spare?";
                            if (PlayerInventory.inventory["fish"] > 0)
                            {
                                dialogueStage = 10;
                                SetOptionText(1, 2, "Yes, here.");
                                SetOptionText(2, 2, "Umm, I have changed my mind.");
                            }
                            else
                            {
                                dialogueStage = 4;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "No, I don't have any.");
                            }
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
                            dialogueStage = 4;
                            mainText.text = "Tasty as always. Now let's go. When you want to go back just use the signal pole.";
                            transitionStart.SetActive(true);
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Ok. Here we go island!");
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