using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class MayorDialogue : Dialogue
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
                            controller.ActivateCanvasWithText("Welcome to Boudiff! My name is Kevin and I'm the mayor of this town. Would you like to know something about it and its surroundings?");
                            SetOptionText(1, 2, "Yes, please.");
                            SetOptionText(2, 2, "Maybe later. Bye!");
                        }
                        break;
                    }
                case 1:
                    {
                        if (DetectKey("1"))
                        {
                            dialogueStage = 2;
                            mainText.text = "Town is at least 500 years old. Its landmark is this town hall. You can find multiple shops in there and all villager are kind and friendly. Should I continue with the talk about surroundings?";
                            SetOptionText(1, 2, "Absolutely. I want to know more.");
                            SetOptionText(2, 2, "I think that's enough information for now. See ya!");
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
                            mainText.text = "At the west there is a forest. On its end are old mines, which are closed now. To the east are fields and orchard. And after that there is a big beautiful lake Uto. I hope that you enjoyed this little history course.";
                            option2_2Object.SetActive(false);
                            SetOptionText(1, 2, "Yes. It was very informative.");
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
                            EndDialogue();
                        }
                        break;
                    }
            }
        }
    }
}