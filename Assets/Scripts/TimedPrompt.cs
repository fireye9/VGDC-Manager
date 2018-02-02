using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedPrompt : MonoBehaviour {

    public GameObject promptPrefab;
    GameObject newPrompt;

    void Awake () {
        Invoke("CreateNewPrompt", 2f);
	}
	
    void CreateNewPrompt()
    {
        newPrompt = Instantiate(promptPrefab);
        newPrompt.transform.parent = GameObject.Find("UICanvas").transform;
        Button[] buttons = newPrompt.GetComponentsInChildren<Button>();
        foreach (Button bt in buttons)
        {
            bt.onClick.AddListener(delegate { OnChoiceClick(); });
        }

    }
    public void OnChoiceClick()
    {
        //Create an event for GameManager to listen to for gamestate effects
        Destroy(newPrompt);
    }
}
