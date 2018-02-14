using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptPanel : MonoBehaviour {
    public TextAsset textFile;
    public Text textObject;
    private string[] prompts;


    private void Awake()
    {
        prompts = textFile.text.Split('\n');
        textObject = transform.Find("PromptText").GetComponent<Text>();
        int rnd = Random.Range(0, prompts.Length);
        textObject.text = prompts[rnd];
    }

}
