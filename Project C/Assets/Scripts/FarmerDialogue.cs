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
                        if (DetectKey("e"))
                        {
                            talkText.SetActive(false);
                            dialogueStage = 1;
                            controller.ActivateCanvasWithText("Hello, my name is Josh. I'm farming on these fields because I want to forget about my foolish dream.");
                            SetOptionText(1, 2, "Foolish dream?!");
                            SetOptionText(2, 2, "Ok. Have a nice day!");

                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Yes. When I was young I wanted to become rich. I sneaked into the old mines and panned under the waterfalls. Unfortunately I was out of luck.";
                            SetOptionText(1, 2, "Sneaked into mines?");
                            SetOptionText(2, 2, "Panned under waterfalls?");
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
                            mainText.text = "Yeah. But before I tell you more, do you have newspaper? I want to be in touch with the rest of the world.";
                            option2_2Object.SetActive(false);
                            if (PlayerInventory.inventory["newspaper"] > 0)
                            {
                                dialogueStage = 3;
                                SetOptionText(1, 2, "Yeah. Here.");
                            }
                            else
                            {
                                dialogueStage = 4;
                                SetOptionText(1, 2, "No, unfortunately.");
                            }
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 5;
                            mainText.text = "You bet! But it was not much profitable. So I ended up on this farm. But you can try it out if you want.";
                            SetOptionText(1, 2, "I don't know how.");
                            SetOptionText(2, 2, "I'm on my way!");
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = "Thanks. Now about the mines. It's easy to get in. Just take an axe and break through the closed entrance. But then you enter a huge maze of underground tunnels. I think you need a bit of luck to find something here. Unfortunately I was not the lucky one.";
                            SetOptionText(1, 2, "Thanks for the story. I will definitely try my luck there too.");
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
                            dialogueStage = 6;
                            mainText.text = "Well you definitely need a pan. Do you have one?";
                            SetOptionText(1, 2, "Sure thing.");
                            SetOptionText(2, 2, "No.");
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
                            mainText.text = "Perfect! So now just go into the water and start panning. But don't swirl with the pan too much. Manipulate with it gently and results will come your way. And by results I mean gold.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Ok, I think I'm ready. Bye!");
                        }
                        if (DetectKey("2"))
                        {
                            dialogueStage = 7;
                            mainText.text = "No pan means no gold. But don't be sad I think I still have my old pan. I could give it to you if you want.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "That would be awesome!");
                        }
                        break;
                    }
                case 7:
                    {
                        if (DetectKey("1"))
                        {
                            mainText.text = "But it won't be free. I will give it to you if you bring me some sweets. 1x muffin, 1x pie and 1x cake to be precise.";
                            if (PlayerInventory.inventory["muffin"] > 0 && PlayerInventory.inventory["pie"] > 0 && PlayerInventory.inventory["cake"] > 0)
                            {
                                dialogueStage = 8;
                                SetOptionText(1, 2, "Here is your order.");
                            }
                            else
                            {
                                dialogueStage = 4;
                                SetOptionText(1, 2, "I will be right back.");
                            }
                        }
                        break;
                    }
                case 8:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            mainText.text = " This is exactly what I wanted. Thank you. Here is the pan.";
                            SetOptionText(1, 2, "No problem and thanks for the pan.");
                            if (!PlayerInventory.inventory.ContainsKey("pan"))
                            {
                                PlayerInventory.inventory.Add("pan", 0);
                            }
                        }
                        break;
                    }
            }
        }
    }
}