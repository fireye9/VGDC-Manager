using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptPanel : MonoBehaviour {
    public TextAsset textFile;
    public Text textObject;

    private void Awake()
    {
        textObject = transform.Find("PromptText").GetComponent<Text>();
        textObject.text = textFile.text;
    }

}
