using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayfieldGrid grid;
    private Raycaster raycaster;

    private void Start()
    {
        grid = GetComponent<PlayfieldGrid>();
        grid.ResetGrid();
    }

    private void Update()
    {
        grid.SwapPiece();
    }
}