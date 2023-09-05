using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown; //static booleans to indicate the different swipe and tap gestures
    //variables to track touch information
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false; //Resets the touch/swipe at every update/frame
        //For PC controls
        #region Standalone Inputs
        //Check if left mouse button is being pressed and set the respective variables while tracking its starting point till left mouse button is released
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        //For mobile controls
        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            //track starting point of touch and set the respective variables
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance between the startingPoint of touch and the final point
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Check if the swipe distance has passed a certain distance
        if (swipeDelta.magnitude > 100)
        {
            //Find out what direction the swipe was
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right swipe
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down swipe
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset(); //Resets the variables after a boolean has been set regarding the swipe information
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
