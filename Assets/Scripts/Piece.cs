using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private string pieceName;

    private int xPosition;
    private int yPosition;

    private void Start()
    {
        gameObject.name = pieceName;
    }

    public string Name
    {
        get
        {
            return pieceName;
        }
        set
        {
            pieceName = value;
        }
    }

    public int XPosition
    {
        get
        {
            return xPosition;
        }
        set
        {
            xPosition = value;
        }
    }

    public int YPosition
    {
        get
        {
            return yPosition;
        }
        set
        {
            yPosition = value;
        }
    }
}