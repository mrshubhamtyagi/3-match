using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    public Dot[] dotsPrefab;

    private Board board;

    private Dot[,] allDots;

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

        for (int i = 0; i < board.widht; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                int randomNo = Random.Range(0, dotsPrefab.Length);
                Dot dot = Instantiate(dotsPrefab[randomNo], new Vector2(i, j), Quaternion.identity, transform);
                //dot.name = string.Format("{0} , {1}", i, j);
                dot.name = "Dot";
                allDots[i, j] = dot;
            }
        }
    }
}
