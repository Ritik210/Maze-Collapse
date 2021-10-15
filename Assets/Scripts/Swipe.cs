using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector3 startTouch, swipeDelta;
    private bool isDragging = false;

    public Vector3 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Reset()
    {
        startTouch = swipeDelta =  Vector3.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }

        #endregion

        #region Mobile Input
        if(Input.touches.Length>0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector3.zero;
        if(isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = (Vector3)Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButtonDown(0))
            {
                swipeDelta = (Vector3)Input.mousePosition - startTouch;
            }
        }
        if(swipeDelta.magnitude > 130)
        {
            float x = swipeDelta.x;
            float z = swipeDelta.z;
            if(Mathf.Abs(x)>Mathf.Abs(z))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (z < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            Reset();
        }
        
    }
}
