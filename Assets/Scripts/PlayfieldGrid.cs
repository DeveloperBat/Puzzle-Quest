using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldGrid : MonoBehaviour
{
    #region Grid Settings
    [SerializeField]
    private Vector2 gridSpacing = new Vector2(1f, 1f);
    [SerializeField]
    private Vector2 gridOffset = new Vector2(0.5f, 0.5f);
    [SerializeField]
    private int gridColumns = 5;
    [SerializeField]
    private int gridRows = 5;
    [SerializeField]
    private List<GameObject> pieceList;
    #endregion
    #region Private Variables
    private Slot[,] grid;
    #endregion
    #region Grid Functions

    private void Start()
    {
        GenerateGrid();
    }

    /// <summary>
    /// Generates the grid with positions based on columns and rows.
    /// </summary>
    private void GenerateGrid()
    {
        // Create a new grid
        grid = new Slot[gridColumns, gridRows];

        // Initialize grid positions
        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                Slot slot = new Slot();

                // Set position.
                slot.Position = new Vector3(x * gridSpacing.x - (gridColumns - 1) * gridSpacing.x * gridOffset.x,
                                            y * gridSpacing.y - (gridRows - 1) * gridSpacing.y * gridOffset.y);

                // Insert slot in array.
                grid[x, y] = slot;
            }
        }
    }

    /// <summary>
    /// Removes all Gameobjects from the existing grid.
    /// </summary>
    private void ClearGrid()
    {
        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                if (grid[x, y].Piece != null)
                {
                    GameObject.Destroy(grid[x, y].Piece);
                }
            }
        }
    }

    /// <summary>
    /// Resets existing grid and creates a new playfield with new Gameobjects.
    /// </summary>
    /// <param name="gameObjectList">List of GameObjects to populate the grid with.</param>
    public void ResetGrid()
    {
        if (pieceList.Count > 0)
        {
            // Remove all pieces.
            ClearGrid();

            // Fill grid with new pieces.
            for (int y = 0; y < gridRows; y++)
            {
                for (int x = 0; x < gridColumns; x++)
                {
                    GameObject go;
                    int pieceNumber = Random.Range(0, pieceList.Count);

                    go = Instantiate(pieceList[pieceNumber], grid[x, y].Position, Quaternion.identity);

                    grid[x, y].Piece = go;
                }
            }
        }
        else
        {
            Debug.LogError("The gameObjectList is null!");
        }
    }

    public void SwapPiece(GameObject pFirst, GameObject pSecond)
    {
        Slot slot0 = new Slot();
        Slot slot1 = new Slot();
        Slot slot2 = new Slot();

        // Look for the slots. (x+y)
        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                if (grid[x, y].Position == pFirst.transform.position)
                {
                    slot1 = grid[x, y];
                }
                if (grid[x, y].Position == pSecond.transform.position)
                {
                    slot2 = grid[x, y];
                }
            }
        }

        // Swap Slots
        slot0 = slot1;
        slot1 = slot2;
        slot2 = slot0;

        // Update positions.
        Vector3 temp = pSecond.transform.position;
        pSecond.transform.position = pFirst.transform.position;
        pFirst.transform.position = temp;
    }
    #endregion
}