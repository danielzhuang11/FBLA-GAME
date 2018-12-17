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
     public void StartDialogue(Dialogue dialogue)
     {

         nextbtn.SetActive(true);
         dialogueActive = true;
         PauseMenu.GameIsPaused = true;
         sentences = new Queue<string>();
          nameText.text = dialogue.name;
          sentences.Clear();


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
         nextbtn.SetActive(false);
         PauseMenu.GameIsPaused = false;
         dialoguetext.text ="END TRANSMISION";

         if (GameController.level == 2)
         {
             GameController thing = GameObject.Find("Game Controller").GetComponent<GameController>();
             thing.goodAns = thing.newQuestion();
         }
         dialogueActive = false;
     }

}
