using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text wordToFind;
    private float time;
    private string[] textList = { "CAT", "BOAT" ,"HORSE" ,"BUFFALO", "YO YO SO"};
    private string textToDisplay;
    private string hiddenText;
    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = textList[Random.Range(0,textList.Length)];
        hiddenText="";
        for (int i = 0; i < textToDisplay.Length; i++) {
            if (char.IsWhiteSpace(textToDisplay[i]))
            {
                hiddenText += "  ";
            }
            else {
                hiddenText += "_ ";
            }

        }
        wordToFind.text = hiddenText;
        Debug.Log(textToDisplay.Length);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = "Timer:" + time.ToString();
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length ==1) {
            string pressedLetter = e.keyCode.ToString();
            if (textToDisplay.Contains(pressedLetter)) {
                int i = textToDisplay.IndexOf(pressedLetter);
                Debug.Log(i);
                while (i!=-1) {
                    hiddenText = hiddenText.Substring(0, 2 * i) + pressedLetter + " " + hiddenText.Substring(2*(i+1)); 
                    textToDisplay = textToDisplay.Substring(0,i) + "_"+  textToDisplay.Substring(i+1);
                    i = textToDisplay.IndexOf(pressedLetter);
                }
                wordToFind.text = hiddenText;
            }
        }
    }
}
