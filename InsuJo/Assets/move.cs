using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class move : MonoBehaviour
{
    int speed;
    int state;
    public GameObject moveFlag;
    public GameObject GameoverPanel;
    public Text m_text;
    int count;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;
    // Start is called before the first frame update
    public void init()
    {
        GameObject[] trap = GameObject.FindGameObjectsWithTag("trap");
        for (int i = 0; i < trap.Length; i++)
            Destroy(trap[i]);

        moveFlag.GetComponent<RandomCreate>().FlagPosition();
        moveFlag.GetComponent<RandomCreate>().TrapPosition();

        speed = 20;
        state = 0;
        count = 0;

        this.GetComponent<Transform>().position = Vector3.zero;
       
    }
    void Rotate()
    {
        switch (state) {
            case 1:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            case 4:
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                break;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "flag")
        {
            SoundManager.instance.PlaySound();
            count += 1;
            speed += 2;
            GameObject[] trap = GameObject.FindGameObjectsWithTag("trap");
            for(int i = 0; i < trap.Length; i++)
                Destroy(trap[i]);

            moveFlag.GetComponent<RandomCreate>().FlagPosition();
            for (int i = 0; i < count; i++)
            {
                moveFlag.GetComponent<RandomCreate>().TrapPosition();
            }
           
            Debug.Log(count);
        }

       
        if(col.gameObject.tag == "trap")
        {
            state = 0;
            GameoverPanel.gameObject.SetActive(true);
            this.gameObject.SetActive(false);

        }
        if(col.gameObject.tag == "wall")
        {
            state = 0;
            GameoverPanel.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        init();
        
        dragDistance = Screen.height * 5 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            state = 1;
                        }
                        else
                        {   //Left swipe
                            state = 2;
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            state = 3;
                        }
                        else
                        {   //Down swipe
                            state = 4;
                        }
                    }
                }
            }
                
            }
            /*if (Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                state = 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                state = 2;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                state = 3;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) == true)
            {
                state = 4;
            }*/
            Rotate();
            m_text.text = "Score : " + count.ToString();
        
    }
}
