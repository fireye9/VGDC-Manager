using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedPrompt : MonoBehaviour {

    public GameObject promptPrefab;
    GameObject newPrompt;
    GameObject gameManager;

    public void CreateNewPrompt()
    {
        newPrompt = Instantiate(promptPrefab);
        newPrompt.transform.SetParent(GameObject.Find("UICanvas").transform,false); 
        Button[] buttons = newPrompt.GetComponentsInChildren<Button>();
        foreach (Button bt in buttons)
        {
            bt.onClick.AddListener(delegate { OnChoiceClick(); });
        }
        //todo: be able to consolidate all relevant prompt situations and change the prompt's contents randomly
        //look here: https://answers.unity.com/questions/711778/adding-prefabs-to-a-list-or-an-array-from-a-folder.html

    }
    public void OnChoiceClick()
    {
        Time.timeScale = 1;
        Destroy(newPrompt);
    }
}
