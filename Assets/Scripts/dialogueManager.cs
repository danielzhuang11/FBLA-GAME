using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialoguetext;
    private Queue<string> sentences;
	// Use this for initialization
	

     public void StartDialogue(Dialogue dialogue)
     {
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
         dialoguetext.text ="END TRANSMISION";
     }

}
