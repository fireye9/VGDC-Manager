using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomClick : MonoBehaviour {

    // Use this for initialization
    Canvas gameCanvas;
    Text moneytext;
    int currentmoney = 0;
    bool clickable;
    private Rigidbody rb;
    public int count=0;
    public int timer;
    public Material mat;
    public Color col;
    Vector3 movement;

	void Start () {
        gameCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        moneytext=gameCanvas.transform.Find("Money").GetComponent<Text>();
        clickable = false;
        timer = Random.Range(0, 10);
        rb = GetComponent<Rigidbody>();
        mat.color = Color.black;
        float moveHorizontal = Random.Range(0, 2);
        float moveVertical = Random.Range(0, 2);
        movement = new Vector3();
        if (moveHorizontal < .5f && moveVertical <= .5f)
        {
            movement = new Vector3(1 * Time.deltaTime, 1 * Time.deltaTime, 0);
        }
        else if (moveHorizontal < .5f && moveVertical >= .5f)
        {
            movement = new Vector3(1 * Time.deltaTime, -1 * Time.deltaTime, 0);
        }
        else if (moveHorizontal > .5f && moveVertical <= .5f)
        {
            movement = new Vector3(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
        }
        else if (moveHorizontal > .5f && moveVertical >= .5f)
        {
            movement = new Vector3(-1 * Time.deltaTime, -1 * Time.deltaTime, 0);
        }
    }
    void OnMouseDown()
    {
        if (clickable == true)
        {
            currentmoney = Random.Range(1, 10);
            moneytext.text="$"+(int.Parse(moneytext.text.Substring(1))+currentmoney);
            clickable = false;
            mat.color = Color.black;
            timer =Random.Range(4, 10);
            float moveHorizontal = Random.Range(0, 2);
            float moveVertical = Random.Range(0, 2);
            movement = new Vector3();
            if (moveHorizontal < .5f && moveVertical <= .5f)
            {
                movement = new Vector3(1 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            else if (moveHorizontal < .5f && moveVertical >= .5f)
            {
                movement = new Vector3(1 * Time.deltaTime, -1 * Time.deltaTime, 0);
            }
            else if (moveHorizontal > .5f && moveVertical <= .5f)
            {
                movement = new Vector3(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            else if (moveHorizontal > .5f && moveVertical >= .5f)
            {
                movement = new Vector3(-1 * Time.deltaTime, -1 * Time.deltaTime, 0);
            }
        }
    }

    private IEnumerator Randomize()
    {
       yield return new WaitForSeconds(Random.Range(1, 5));
        
    }
	// Update is called once per frame
	void Update () {
        
        if (clickable == false)
        {
            if (transform.position.x <= -9)
            {
                movement.x = -movement.x;
            }
            if (transform.position.y <= -4.5)
            {
                movement.y = -movement.y;
            }
            if (transform.position.x >= 9)
            {
                movement.x = -movement.x;
            }
            if (transform.position.y >= 2.5)
            {
                movement.y = -movement.y;
            }
            count += 1;
            transform.Translate(movement);
            if (timer * 50<=count)
            {
                mat.color = Color.green;
                clickable = true;
                count = 0;
                timer = Random.Range(2,4);
            }
        }
        else if (clickable == true)
        {
            count += 1;
            if (timer * 50 <= count)
            {
                mat.color = Color.black;
                clickable = false;
                count = 0;
                timer = Random.Range(1, 5);
                float moveHorizontal = Random.Range(0, 2);
                float moveVertical = Random.Range(0, 2);
                movement = new Vector3();
                if (moveHorizontal < .5f && moveVertical <= .5f)
                {
                    movement = new Vector3(1 * Time.deltaTime, 1 * Time.deltaTime, 0);
                }
                else if (moveHorizontal < .5f && moveVertical >= .5f)
                {
                    movement = new Vector3(1 * Time.deltaTime, -1 * Time.deltaTime, 0);
                }
                else if (moveHorizontal > .5f && moveVertical <= .5f)
                {
                    movement = new Vector3(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
                }
                else if (moveHorizontal > .5f && moveVertical >= .5f)
                {
                    movement = new Vector3(-1 * Time.deltaTime, -1 * Time.deltaTime, 0);
                }
            }
        }
    }
}
