using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

    GameStateManager gsm;
    private void Awake()
    {
        gsm = GetComponent(typeof(GameStateManager)) as GameStateManager;
    }
    public void CloseResults()
    {
        Time.timeScale = 1;
        gsm.SetProductivity(10f);
        Destroy(this.transform.parent.gameObject);
    }
}
