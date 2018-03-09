using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

	public void CloseResults()
    {
        Time.timeScale = 1;
        Destroy(this.transform.parent.gameObject);
    }
}
