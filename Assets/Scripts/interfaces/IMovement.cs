using UnityEngine;

public interface IMovement
{
	/// <summary>
	/// Moves the figure horizontally.
	/// </summary>
	/// <param name="figure">Figure.</param>
    /// <param name="direction">true - right, false - left</param>
	void MoveFigureHorizontally (Transform figure, bool direction);

	/// <summary>
	/// Rotates the figure.
	/// </summary>
	/// <param name="figure">Figure.</param>
	void RotateFigure(Transform figure);

    /// <summary>
    /// Move down figure
    /// </summary>
    /// <param name="figure">transform of figure</param>
    /// <returns>true if figure is stopped</returns>
    bool FallFigure(Transform figure);
}

public class FigureMovement : IMovement
{
    private IGrid _grid;

    /// <summary>
    /// Instanse of FigureMovement
    /// </summary>
    /// <param name="iGrid">instance of type "IGrid"</param>
    public FigureMovement(IGrid iGrid)
    {
        _grid = iGrid;
    }

	public void MoveFigureHorizontally(Transform figure, bool direction)
	{
		if (!direction) 
		{
            figure.position += Vector3.left;

            if(!_grid.CheckForInsideBorder(figure) || !_grid.CheckForCollisionWithFigureOrFloor(figure))
            {
                figure.position += Vector3.right;
            }
            else
            {
                _grid.UpdateGrid(figure);
            }
        }
		else
		{
            figure.position += Vector3.right;

            if (!_grid.CheckForInsideBorder(figure) ||
                !_grid.CheckForCollisionWithFigureOrFloor(figure))
            {
                figure.position += Vector3.left;
            }
            else
            {
                _grid.UpdateGrid(figure);
            }
        }
	}

	public void RotateFigure(Transform figure)
	{
        figure.Rotate(new Vector3(0, 0, -90));

        if (!_grid.CheckForInsideBorder(figure) || !_grid.CheckForCollisionWithFigureOrFloor(figure))
        {
            figure.Rotate(new Vector3(0, 0, 90));
        }
        else
        {
            _grid.UpdateGrid(figure);
        }
	}

    public bool FallFigure(Transform figure)
    {
        figure.position += Vector3.down;

        if (_grid.CheckForCollisionWithFigureOrFloor(figure))
        {
            _grid.UpdateGrid(figure);
            return false;
        }
        else
        {
            figure.position += Vector3.up;
            return true;
        }
    }
}
