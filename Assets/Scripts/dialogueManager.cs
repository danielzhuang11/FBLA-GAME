using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialoguetext;
    private Queue<string> sentences;
    public static bool dialogueActive;
    public GameObject nextbtn;
    public GameObject fireChoose;
     public void  StartDialogue(Dialogue dialogue)
     {

         nextbtn.SetActive(true);
         dialogueActive = true;
         PauseMenu.GameIsPaused = true;
         sentences = new Queue<string>();
          nameText.text = dialogue.name;
          sentences.Clear();
          Time.timeScale = 0.0f;


         foreach (string sentence in dialogue.sentences)
         {
             sentences.Enqueue(sentence);
         }

         DisplayNextSentence();
     }

     public void DisplayNextSentence()
     {
         if (sentences.Count == 0)
         {
             EndDialogue();
             return;
         }
         string sentence = sentences.Dequeue();
         dialoguetext.text = sentence;
     }

     void EndDialogue()
     {
         Time.timeScale = 1.0f;
         nextbtn.SetActive(false);
         PauseMenu.GameIsPaused = false;
         dialoguetext.text ="END TRANSMISION";

         if (GameController.level == 1)
         {
             GameObject.Find("Panel").SetActive(false);
         }
         if (GameController.level == 2)
         {
             GameObject.Find("name").SetActive(false);
             fireChoose.SetActive(true);
             GameController thing = GameObject.Find("Game Controller").GetComponent<GameController>();
             thing.goodAns = GameObject.Find("Game Controller").GetComponent<Questions>().newQuestion();
         }
         
         dialogueActive = false;
     }

}
