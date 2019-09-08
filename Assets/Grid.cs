using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    #region Grid Settings
    [SerializeField]
    private Vector2 gridSpacing = new Vector2(1f,1f);
    [SerializeField]
    private Vector2 offset = new Vector2(0.5f, 0.5f);
    [SerializeField]
    private int gridColumns = 5;
    [SerializeField]
    private int gridRows = 5;
    [SerializeField]
    private List<GameObject> gems;
    #endregion
    #region Private Variables
    private Vector2[,] grid;
    #endregion
    #region Grid Functions

    private void Start()
    {
        GenerateGridPositions();
        PopulateGrid();
    }

    // Generate the positions in the grid based on columns and rows.
    private void GenerateGridPositions()
    {
        // Create a new grid
        grid = new Vector2[gridColumns, gridRows];

        // Initialize grid positions
        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                grid[x, y] = new Vector2(
                    x * gridSpacing.x - (gridColumns - 1) * gridSpacing.x * offset.x,
                    y * gridSpacing.y - (gridRows - 1) * gridSpacing.y * offset.y);
            }
        }
    }

    private void PopulateGrid()
    {
        if (gems.Count != 0)
            // Spawn Gems
            for (int y = 0; y < gridRows; y++)
            {
                for (int x = 0; x < gridColumns; x++)
                {
                    Instantiate(gems[Random.Range(0, gems.Count)], new Vector3(grid[x, y].x, grid[x, y].y, 0), Quaternion.identity);
                }
            }
        else
        {
            Debug.LogAssertion("No GameObjects found when populating grid.");
        }
    }
    #endregion
}