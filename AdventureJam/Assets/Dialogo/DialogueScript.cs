using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public GameObject dialogueBox;

    private string bufferText = "";
    private string textCommand = "";
    public int i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.H))
        {
            
            WakeUpText();
        }

	}

    void WakeUpText ()
    {
        dialogueBox.SetActive(true);
        i++;
        WriteBuffer(i); //Trocar essa rotina para outros dialogos possíveis
        switch(textCommand)
        {
            case "":
                dialogueBox.GetComponent<Text>().text = dialogueBox.GetComponent<Text>().text + bufferText;
                break;
            case "clean":
                dialogueBox.GetComponent<Text>().text = "";
                break;
            case "close":
                dialogueBox.SetActive(false);
                ResetText();
                break;
        }
        /*
        if(bufferText != "BREAK")
        {
            dialogueBox.GetComponent<Text>().text = dialogueBox.GetComponent<Text>().text + bufferText;
        }
        else
        {
            dialogueBox.SetActive(false);
        }
        */
        
    }

    void WriteBuffer (int i)
    {
        switch (i)
        {
            case 1:
                bufferText = "Hello Word!";
                break;
            case 2:
                bufferText = "\n" + "It's a nice day, isn't it?";
                break;
            case 3:
                textCommand = "close";
                break;
        }
    }

    void ResetText ()
    {
        i = 0;
        bufferText = "";
        textCommand = "";
        dialogueBox.GetComponent<Text>().text = "";
    }
}
