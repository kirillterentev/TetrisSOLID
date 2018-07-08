using UnityEngine;

public interface IMovement
{
	/// <summary>
	/// Moves the figure horizontally.
	/// </summary>
	/// <param name="figure">Figure.</param>
    /// <param name="direction">1 - right, -1 - left</param>
	void MoveFigureHorizontally (Transform figure, int direction);

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

	public void MoveFigureHorizontally(Transform figure, int direction)
	{
        figure.position += new Vector3(direction, 0, 0);

        if (!_grid.CheckForInsideBorder(figure) ||
            !_grid.CheckForCollisionWithFigureOrFloor(figure))
        {
            figure.position += new Vector3(-direction, 0, 0);
        }
        else
        {
            _grid.UpdateGrid(figure);
        }
    }

	public void RotateFigure(Transform figure)
	{
        figure.Rotate(new Vector3(0, 0, -90));

        if (!_grid.CheckForInsideBorder(figure) ||
            !_grid.CheckForCollisionWithFigureOrFloor(figure))
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

public class FigureMovementV2 : IMovement
{
    private IGrid _grid;

    /// <summary>
    /// Instanse of FigureMovement
    /// </summary>
    /// <param name="iGrid">instance of type "IGrid"</param>
    public FigureMovementV2(IGrid iGrid)
    {
        _grid = iGrid;
    }

    public void MoveFigureHorizontally(Transform figure, int direction)
    {
        figure.position += new Vector3(direction, 0, 0);

        if (figure.position.x >= _grid.GetWidth() || figure.position.x < 0)
        {
            //Смещаем родителя, а всё что осталось за границами возвращаем обратно
            figure.position += new Vector3(-direction * _grid.GetWidth(), 0, 0);

            foreach (Transform child in figure)
            {
                Vector2 positionChild = VectorsMath.RoundVector2(child.position);

                if (positionChild.x >= _grid.GetWidth() || positionChild.x < 0)
                {
                    child.position += new Vector3(direction * _grid.GetWidth(), 0, 0);
                }
            }
        }
        else
        {
            //смещаем дочерние объекты
            foreach (Transform child in figure)
            {
                Vector2 positionChild = VectorsMath.RoundVector2(child.position);

                if (positionChild.x >= _grid.GetWidth() || positionChild.x < 0)
                {
                    child.position += new Vector3(-direction * _grid.GetWidth(), 0, 0);
                }
            }
        }
        if (_grid.CheckForCollisionWithFigureOrFloor(figure))
        {
            _grid.UpdateGrid(figure);
        }
        else
        {
            MoveFigureHorizontally(figure, -direction);
        }
    }

    public void RotateFigure(Transform figure)
    {
        figure.Rotate(new Vector3(0, 0, -90));

        if (!_grid.CheckForInsideBorder(figure) ||
            !_grid.CheckForCollisionWithFigureOrFloor(figure))
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
