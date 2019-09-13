using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    private Vector3 position;
    private int pieceType;
    private GameObject piece;
    private Collider

    public Vector3 Position 
    {
        get { return position; }
        set { position = value; }
    }
    public GameObject Piece
    {
        get { return piece; }
        set { piece = value;}
    }
    public int PieceType
    {
        get { return pieceType; }
        set { pieceType = value; }
    }
}