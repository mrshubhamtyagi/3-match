using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    #region Public Variables
    public int column;
    public int row;
    #endregion


    #region Private Variables
    private Board board;
    private DotSpawner dotSpawner;
    private GameObject otherDot;
    private float transitionSpeed = 1f;
    #endregion


    private void Awake()
    {
        if (FindObjectOfType<Board>()) board = FindObjectOfType<Board>();
        else Debug.Log("Board Script is missing");

        if (FindObjectOfType<Board>()) dotSpawner = FindObjectOfType<DotSpawner>();
        else Debug.Log("DotSpawner Script is missing");
    }

    void Start()
    {

    }

    void Update()
    {
        //transform.position = Vector2.Lerp(transform.position, new Vector2(column, row), 0.2f);
    }


    private void OnMouseUp()
    {
        Invoke("SwapDots", .25f);

    }


    private void SwapDots()
    {
        // Swipe TOP
        if (SwipeController.swipeDirection == SwipeController.SwipeDirection.Top)
        {
            print("Top Swipe");
        }

        // Swipe RIGHT
        if (SwipeController.swipeDirection == SwipeController.SwipeDirection.Right)
        {
            print("Right Swipe");

            otherDot = dotSpawner.allDots[column + 1, row].gameObject;
            Dot dot = otherDot.GetComponent<Dot>();
            dot.column--;
            column++;

            dot.DotTransition());
            DotTransition();
        }

        // Swipe BOTTOM
        if (SwipeController.swipeDirection == SwipeController.SwipeDirection.Bottom)
        {
            print("Bottom Swipe");
        }

        // Swipe LEFT
        if (SwipeController.swipeDirection == SwipeController.SwipeDirection.Left)
        {
            print("Left Swipe");

            otherDot = dotSpawner.allDots[column - 1, row].gameObject;
            Dot dot = otherDot.GetComponent<Dot>();
            dot.column++;
            column--;

            dot.DotTransition();
            DotTransition();
        }
    }

    // Actual movement of dot
    public void DotTransition()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector2(column, row), "time", transitionSpeed, "easeType", iTween.EaseType.easeInBounce));
    }

}
