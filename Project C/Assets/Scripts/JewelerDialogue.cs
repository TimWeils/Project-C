using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class JewelerDialogue : Dialogue
    {
        private bool firstEncounter = true;

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
                            controller.ActivateCanvasWithText("Hello my friend I'm Paul local jeweler. If it's shiny and valueble I have it. Take a closer look.");
                            SetOptionText(1, 2, "Show me.");
                            if (firstEncounter)
                            {
                                SetOptionText(2, 2, "We are friends!?");
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Look at my treasures. You won't be disappointed my friend. Pick whatever you want.";
                            SetOptionText(1, 2, "Ring");
                            SetOptionText(2, 2, "Necklace");
                        }
                        if (DetectKey("2") && firstEncounter)
                        {
                            dialogueStage = 3;
                            mainText.text = "Of course my friend. Have this necklace as a proof of our friendship.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Ok... Thanks.");
                        }
                        break;
                    }
                case 2:
                    {
                        if (DetectKey("1"))
                        {
                            mainText.text = "Finest ring with the shining diamond in it. Good choice my friend. Just give me 50x golden dust and 1x diamond so I can make a new one and this one is yours.";
                            if (PlayerInventory.inventory["dust"] > 49 && PlayerInventory.inventory["diamond"] > 0)
                            {
                                dialogueStage = 5;
                                SetOptionText(1, 2, "Ok. Here it is");
                                SetOptionText(2, 2, "That's pretty expensive. I think I will pass on the offer.");
                            }
                            else
                            {
                                dialogueStage = 4;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "That's too expensive. I have to go get the materials first.");
                            }
                            
                        }
                        if (DetectKey("2"))
                        {
                            mainText.text = "I see, you want to display your wealth my friend. This one is exceptional. Golden necklace with multiple gemstones on it. I will need 100x golden dust, 3x diamond, 5x ruby and 7x emerald for it so I can make a new one for future customers.";
                            if (PlayerInventory.inventory["dust"] > 99 && PlayerInventory.inventory["diamond"] > 2 && PlayerInventory.inventory["ruby"] > 4 && PlayerInventory.inventory["emerald"] > 6)
                            {
                                dialogueStage = 6;
                                SetOptionText(1, 2, "Ok. Here it is");
                                SetOptionText(2, 2, "That's pretty expensive. I think I will pass on the offer.");
                            }
                            else
                            {
                                dialogueStage = 4;
                                option2_2Object.SetActive(false);
                                SetOptionText(1, 2, "That's too expensive. I have to go get the materials first.");
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 4;
                            firstEncounter = false;
                            PlayerInventory.inventory["necklace"]++;
                            mainText.text = "No problem my friend. I hope you will visit me again soon.";
                            SetOptionText(1, 2, "Sure. Have a nice day.");
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
                            mainText.text = "That's one diamond ring for you my friend.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Thanks.");
                            PlayerInventory.inventory["dust"] -= 50;
                            PlayerInventory.inventory["diamond"]--;
                            PlayerInventory.inventory["ring"]++;
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
                            mainText.text = "Here is your necklace. You will look gorgeous with it.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Thanks.");
                            PlayerInventory.inventory["dust"] -= 100;
                            PlayerInventory.inventory["diamond"] -= 3;
                            PlayerInventory.inventory["ruby"] -= 5;
                            PlayerInventory.inventory["emerald"] -= 7;
                            PlayerInventory.inventory["necklace"]++;
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