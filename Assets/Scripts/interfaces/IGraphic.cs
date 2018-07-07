using UnityEngine;

public interface IGraphic
{
	/// <summary>
	/// Draws the grid.
	/// </summary>
	/// <param name="width">Width.</param>
	/// <param name="height">Height.</param>
	/// <param name="gridCell">Grid cell.</param>
	void DrawGrid (int width, int height, GameObject gridCell);

    /// <summary>
    /// Draws the figure.
    /// </summary>
    /// <param name="figure">Figure.</param>
    /// <returns>transform of figure</returns>
    Transform DrawFigure (GameObject figure);

    /// <summary>
    /// Deletes row with number
    /// </summary>
    /// <param name="numberRow">number of row</param>
    /// <param name="grid">array of grid</param>
    void DeleteRow(int numberRow, Transform[,] grid);
}

public class TetrisGraphic : MonoBehaviour, IGraphic
{
	private Transform _parentFigure;
    private Vector3 _spawnPoint;

    /// <summary>
    /// Instance of TetrisGraphic
    /// </summary>
	public TetrisGraphic()
	{
		_parentFigure = new GameObject ("Figures").transform;
	}

	public void DrawGrid(int width, int height, GameObject gridCell)
	{
		Transform parent = new GameObject ("Grid").transform;

		for (int i = 0; i < width; i++) 
		{
			for (int j = 0; j < height; j++) 
			{
				Instantiate (gridCell, new Vector2(i, height - j - 1), Quaternion.identity, parent);
			}
		}

        _spawnPoint = new Vector3(width / 2, height - 3, 0);
	}

	public Transform DrawFigure(GameObject figure)
	{
		GameObject go = Instantiate (figure, _spawnPoint, Quaternion.identity, _parentFigure);
		return go.transform;
	}

    public void DeleteRow(int numberRow, Transform[,] grid)
    {
        int widthArray = grid.GetLength(0);

        for(int i = 0; i < widthArray; i++)
        {
            Destroy(grid[i, numberRow].gameObject);
            grid[i, numberRow] = null;
        }
    }
}