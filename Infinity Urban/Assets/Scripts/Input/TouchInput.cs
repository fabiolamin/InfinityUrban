using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;
 
    void Start()
    {
        dragDistance = Screen.height * 10 / 100;
    }
 
    public int Swipe()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    { 
                        if ((lp.x > fp.x)) 
                        {   //Right swipe
                            return 1;
                        }
                        else
                        {   //Left swipe
                            return -1;
                        }
                    }
                    else
                    {   
                        if (lp.y > fp.y)  
                        {
                            return 2;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                }
                else
                {
                    //Tap
                }
            }
        }
        return 0;
    }
}
