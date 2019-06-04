using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{

    #region Public Variables
    public static SwipeController INSTANCE;
    public enum SwipeDirection { Top, Right, Bottom, Left, None };
    public SwipeDirection swipeDirection;
    #endregion

    #region Private Variables
    private Vector2 mouseDown;
    private Vector2 mouseUp;
    [SerializeField] private float swipeAngle;
    #endregion


    private void Awake()
    {
        if (INSTANCE == null) INSTANCE = this;
        else gameObject.SetActive(false);
    }

    void OnEnable()
    {
        swipeDirection = SwipeDirection.None;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculateSwipeAngle();
        }

    }

    private void CalculateSwipeAngle()
    {
        swipeAngle = Mathf.Atan2(mouseUp.y - mouseDown.y, mouseUp.x - mouseDown.x);
        swipeAngle = swipeAngle * 180 / Mathf.PI;

        if (swipeAngle > 45 && swipeAngle <= 135) swipeDirection = SwipeDirection.Top;
        else if (swipeAngle > 135 || swipeAngle <= -135) swipeDirection = SwipeDirection.Left;
        else if (swipeAngle > -135 && swipeAngle <= -45) swipeDirection = SwipeDirection.Bottom;
        else if (swipeAngle <= 45 && swipeAngle > -45) swipeDirection = SwipeDirection.Right;

    }
}
