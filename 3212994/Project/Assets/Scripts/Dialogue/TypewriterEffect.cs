using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public static bool StillTyping;
    [SerializeField] private float typewriterSpeed = 0.03f;

    //function that starts the coroutine and uses the string we give it from the DialogueUI script
    public void Run(string textToType, TMP_Text textLabel) 
    {
        // enables our static bool that checks if the typewriter is typing
        StillTyping = true;
        // starts the typing coroutine
        StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        // sets the text label to an empty string
        textLabel.text = string.Empty;
        // creates an index that is 0
        int index = 0;
        // creates a current text string that is empty
        string currentText = string.Empty;

        // while the index is less than the string length...
        while (index < textToType.Length)
        {
            // sets our current text string to textToType with an added index of 1
            string currentChars = textToType.Substring(index, 1);
            // checks if there is an < symbol, and if there is, it doesn't print whatever is within the <> (such as italics)
            if (currentChars == "<")
            {
                
                do
                {
                    index++;
                    currentText += currentChars;
                    currentChars = textToType.Substring(index, 1);
                } while (currentChars != ">");
            }

            // adds the current character to the string
            currentText += currentChars;
            // sets the TMP text fields to the string generated above
            textLabel.text = currentText;
            // increases the index of the character
            index++;
            // waits for real time seconds based on our typewriter speed float (0.03)
            yield return new WaitForSecondsRealtime(typewriterSpeed);
        }

        // stops the typing
        StillTyping = false;
    }
}
