using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gamekit2D
{
    public class Dialogue : MonoBehaviour
    {
        public GameObject talkText;
        public DialogueCanvasController controller;
        public TextMeshProUGUI mainText;

        public TextMeshProUGUI option1_2;
        public GameObject option1_2Object;

        public TextMeshProUGUI option2_2;
        public GameObject option2_2Object;

        public TextMeshProUGUI option1_4;
        public GameObject option1_4Object;

        public TextMeshProUGUI option2_4;
        public GameObject option2_4Object;

        public TextMeshProUGUI option3_4;
        public GameObject option3_4Object;

        public TextMeshProUGUI option4_4;
        public GameObject option4_4Object;


        public bool playerIsHere = false;

        protected int dialogueStage = 0;

        protected void DeactivateOptions(int count)
        {
            switch (count)
            {
                case 2:
                    {
                        option1_2Object.SetActive(false);
                        option2_2Object.SetActive(false);
                        break;
                    }
                case 3:
                    {
                        option1_4Object.SetActive(false);
                        option2_4Object.SetActive(false);
                        option3_4Object.SetActive(false);
                        break;
                    }
                case 4:
                    {
                        option1_4Object.SetActive(false);
                        option2_4Object.SetActive(false);
                        option3_4Object.SetActive(false);
                        option4_4Object.SetActive(false);
                        break;
                    }
            }
        }

        protected void SetOptionText(int optionIndex, int optionCount, string text)
        {
            switch (optionCount)
            {
                case 2:
                    {
                        switch (optionIndex)
                        {
                            case 1:
                                {
                                    option1_2Object.SetActive(true);
                                    option1_2.text = (text);
                                    break;
                                }
                            case 2:
                                {
                                    option2_2Object.SetActive(true);
                                    option2_2.text = (text);
                                    break;
                                }
                        }
                        break;
                    }
                case 4:
                    {
                        switch (optionIndex)
                        {
                            case 1:
                                {
                                    option1_4Object.SetActive(true);
                                    option1_4.text = (text);
                                    break;
                                }
                            case 2:
                                {
                                    option2_4Object.SetActive(true);
                                    option2_4.text = (text);
                                    break;
                                }
                            case 3:
                                {
                                    option3_4Object.SetActive(true);
                                    option3_4.text = (text);
                                    break;
                                }
                            case 4:
                                {
                                    option4_4Object.SetActive(true);
                                    option4_4.text = (text);
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        protected void EndDialogue()
        {
            controller.DeactivateCanvasWithDelay(0);
            option1_2Object.SetActive(false);
            option2_2Object.SetActive(false);
            option1_4Object.SetActive(false);
            option2_4Object.SetActive(false);
            option3_4Object.SetActive(false);
            option4_4Object.SetActive(false);
            dialogueStage = 0;
            talkText.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                playerIsHere = true;
                talkText.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerTag"))
            {
                playerIsHere = false;
                dialogueStage = 0;
                controller.DeactivateCanvasWithDelay(0);
                EndDialogue();
                talkText.SetActive(false);
            }
        }
    }
}