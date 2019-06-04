using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{

    private Board board;

    private void Awake()
    {
        board = FindObjectOfType<Board>();
    }

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnMouseUp()
    {
        SwapDots();
    }


    private void SwapDots()
    {

    }

}
