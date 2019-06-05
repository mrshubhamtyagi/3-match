using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    #region Public Variables
    public Dot[] dotsPrefab;
    public Dot[,] allDots;
    #endregion

    private Board board;


    private void Awake()
    {
        board = FindObjectOfType<Board>();
    }

    void Start()
    {
        DotsSetup();
    }

    private void DotsSetup()
    {
        allDots = new Dot[board.widht, board.height];

        for (int col = 0; col < board.widht; col++)
        {
            for (int row = 0; row < board.height; row++)
            {
                int randomNo = Random.Range(0, dotsPrefab.Length);
                Dot dot = Instantiate(dotsPrefab[randomNo], new Vector2(col, row), Quaternion.identity, transform);
                dot.name = "Dot";
                allDots[col, row] = dot;
                if (dot.GetComponent<Dot>())
                {
                    dot.GetComponent<Dot>().column = col;
                    dot.GetComponent<Dot>().row = row;
                }
                else Debug.Log("Dot script is missing");
            }
        }
    }
}
