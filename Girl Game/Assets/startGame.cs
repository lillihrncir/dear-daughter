//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class startGame : MonoBehaviour
//{
//    public float blinkInterval = 0.5f; // Time interval for blinking in seconds
//    private Text textComponent;

//    private void Start()
//    {
//        textComponent = GetComponent<Text>();
//        StartCoroutine(Blink());
//    }

//    private IEnumerator Blink()
//    {
//        while (true) // Infinite loop for continuous blinking
//        {
//            textComponent.enabled = !textComponent.enabled; // Toggle visibility

//            yield return new WaitForSeconds(blinkInterval);
//        }
//    }
//}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;

public class UITextTypeWriter : MonoBehaviour
{
    public Text text;
    public bool playOnAwake = true;
    public float delayToStart;
    public float delayBetweenChars = 0.125f;
    public float delayAfterPunctuation = 0.5f;

    private string story;
    private float originDelayBetweenChars;
    private bool lastCharPunctuation = false;
    private char charComma;
    private char charPeriod;

    void Awake()
    {
        text = GetComponent<Text>();
        originDelayBetweenChars = delayBetweenChars;

        charComma = Convert.ToChar(44);
        charPeriod = Convert.ToChar(46);

        if (playOnAwake)
        {
            ChangeText(text.text, delayToStart);
        }
    }

    //Update text and start typewriter effect
    public void ChangeText(string textContent, float delayBetweenChars = 0f)
    {
        StopCoroutine(PlayText()); //stop Coroutime if exist
        story = textContent;
        text.text = ""; //clean text
        Invoke("Start_PlayText", delayBetweenChars); //Invoke effect
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {

        foreach (char c in story)
        {
            delayBetweenChars = originDelayBetweenChars;

            if (lastCharPunctuation)  //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSeconds(delayBetweenChars = delayAfterPunctuation);
                lastCharPunctuation = false;
            }

            if (c == charComma || c == charPeriod)
            {
                lastCharPunctuation = true;
            }

            text.text += c;
            yield return new WaitForSeconds(delayBetweenChars);
        }
    }
}
