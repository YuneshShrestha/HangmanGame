using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text wordToFind;
    private float time;
    private string[] textList = { "Cat", "Boat" ,"Horse" ,"Buffalo", "Game Manager"};
    // Start is called before the first frame update
    void Start()
    {
        string textToDisplay = textList[Random.Range(0, textList.Length)];
        string hiddenText="";
        for (int i = 0; i < textToDisplay.Length; i++) {
            if (char.IsWhiteSpace(textToDisplay[i]))
            {
                hiddenText += " ";
            }
            else {
                hiddenText += "_ ";
            }

        }
        wordToFind.text = hiddenText;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = "Timer:" + time.ToString();
    }
}
