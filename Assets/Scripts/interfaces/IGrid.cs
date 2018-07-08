using UnityEngine;

public interface IGrid
{
    /// <summary>
    /// Updates array of grid
    /// </summary>
    /// <param name="figure">transform of figure</param>
    void UpdateGrid(Transform figure);

    /// <summary>
    /// Check figure for inside border
    /// </summary>
    /// <param name="figure"></param>
    /// <returns>true if figure is inside</returns>
    bool CheckForInsideBorder(Transform figure);

    /// <summary>
    /// Check for collision with other figures or floor
    /// </summary>
    /// <param name="figure">transform of figure</param>
    /// <returns>true if not collision</returns>
    bool CheckForCollisionWithFigureOrFloor(Transform figure);

    /// <summary>
    /// Deletes all full rows
    /// </summary>
    void DeleteFullRows();

    /// <summary>
    /// Return width
    /// </summary>
    /// <returns></returns>
    int GetWidth();

    /// <summary>
    /// Return height
    /// </summary>
    /// <returns></returns>
    int GetHeight();
}

public class TetrisGrid : IGrid
{
	private int _width, _height;
	private Transform[,] _arrayOfGridCells;
    private IGraphic _graphic;
    private IUserParameter _userParameter;

    /// <summary>
    /// Instance the grid
    /// </summary>
    /// <param name="width">width</param>
    /// <param name="height">height</param>
    /// <param name="iGraphic">Instance o type "IGraphic"</param>
    /// <param name="userInterface">Instance of type "IUserInterface"</param>
	public TetrisGrid(int width, int height, IGraphic iGraphic, IUserParameter userParameter)
	{
		_width = width;
		_height = height;
        _graphic = iGraphic;
        _userParameter = userParameter;
		_arrayOfGridCells = new Transform[_width, _height];
	}

    public void UpdateGrid(Transform figure)
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (_arrayOfGridCells[i, j] != null &&
                    _arrayOfGridCells[i, j].parent == figure)
                {
                    _arrayOfGridCells[i, j] = null;
                }
            }
        }

        foreach (Transform child in figure)
        {
            Vector2 positionChild = VectorsMath.RoundVector2(child.position);
            _arrayOfGridCells[(int)positionChild.x, (int)positionChild.y] = child;
        }

        /*
        string mes = "";
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (_arrayOfGridCells[i, j] == null)
                    mes += ".";
                else
                    mes += "0";
            }
            Debug.Log(mes);
            mes = "";
        }
        */
    }

    public bool CheckForInsideBorder(Transform figure)
    {
        foreach (Transform child in figure)
        {
            Vector2 positionChild = VectorsMath.RoundVector2(child.position);

            Debug.Log(positionChild.x);
            if (positionChild.x < 0 || positionChild.x >= _width)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckForCollisionWithFigureOrFloor(Transform figure)
    {
        foreach (Transform child in figure)
        {
            Vector2 positionChild = VectorsMath.RoundVector2(child.position);

            if (positionChild.y < 0)
            {
                return false;
            }

            Transform arrayPosition = _arrayOfGridCells[(int)positionChild.x, (int)positionChild.y];

            if (arrayPosition != null &&
                arrayPosition.parent != figure)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteFullRows()
    {
        for(int i = 0; i < _height; i++)
        {
            if(isRowFull(i))
            {
                _userParameter.AddScorePoint(1);
                _graphic.DeleteRow(i, _arrayOfGridCells);
                lowerRows(i);
                --i;
            }
        }
    }

    /// <summary>
    /// Check for full row on grid
    /// </summary>
    /// <param name="numberRow"></param>
    /// <returns>true if row is full</returns>
    private bool isRowFull(int numberRow)
    {
        for(int i = 0; i < _width; i++)
        {
            if(_arrayOfGridCells[i, numberRow] == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Lower all rows, which are higher "numberRow"
    /// </summary>
    /// <param name="numberRow">number of row</param>
    private void lowerRows(int numberRow)
    {
        for(int j = numberRow + 1; j < _height; j++)
        {
            for(int i = 0; i < _width; i++)
            {
                if (_arrayOfGridCells[i, j] != null)
                {
                    _arrayOfGridCells[i, j - 1] = _arrayOfGridCells[i, j];
                    _arrayOfGridCells[i, j] = null;

                    _arrayOfGridCells[i, j - 1].position += Vector3.down;
                }
            }
        }
    }

    public int GetWidth()
    {
        return _width;
    }

    public int GetHeight()
    {
        return _height;
    }
}

public class TetrisGridV2 : IGrid
{
    private int _width, _height;
    private Transform[,] _arrayOfGridCells;
    private IGraphic _graphic;
    private IUserParameter _userParameter;

    /// <summary>
    /// Instance the grid
    /// </summary>
    /// <param name="width">width</param>
    /// <param name="height">height</param>
    /// <param name="iGraphic">Instance o type "IGraphic"</param>
    /// <param name="userInterface">Instance of type "IUserInterface"</param>
	public TetrisGridV2(int width, int height, IGraphic iGraphic, IUserParameter userParameter)
    {
        _width = width;
        _height = height;
        _graphic = iGraphic;
        _userParameter = userParameter;
        _arrayOfGridCells = new Transform[_width, _height];
    }

    public void UpdateGrid(Transform figure)
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (_arrayOfGridCells[i, j] != null &&
                    _arrayOfGridCells[i, j].parent == figure)
                {
                    _arrayOfGridCells[i, j] = null;
                }
            }
        }

        foreach (Transform child in figure)
        {
            Vector2 positionChild = VectorsMath.RoundVector2(child.position);
            _arrayOfGridCells[(int)positionChild.x, (int)positionChild.y] = child;
        }

        /*
        string mes = "";
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (_arrayOfGridCells[i, j] == null)
                    mes += ".";
                else
                    mes += "0";
            }
            Debug.Log(mes);
            mes = "";
        }
        */
    }

    public bool CheckForInsideBorder(Transform figure)
    {
        foreach (Transform child in figure)
        {
            Vector2 positionChild = VectorsMath.RoundVector2(child.position);

            if (positionChild.x < 0 || positionChild.x >= _width)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckForCollisionWithFigureOrFloor(Transform figure)
    {
        foreach (Transform child in figure)
        {
            Vector2 positionChild = VectorsMath.RoundVector2(child.position);

            if (positionChild.y < 0)
            {
                return false;
            }

            Transform arrayPosition = _arrayOfGridCells[(int)positionChild.x, (int)positionChild.y];

            if (arrayPosition != null &&
                arrayPosition.parent != figure)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteFullRows()
    {
        int countFullRows = 0;

        for (int i = 0; i < _height; i++)
        {
            if (isRowFull(i))
            {
                ++countFullRows;
                if (countFullRows >= 2)
                {
                    for (int j = 0; j < _height; j++)
                    {
                        if (isRowFull(j))
                        {
                            _graphic.DeleteRow(j, _arrayOfGridCells);
                            lowerRows(j);
                            _userParameter.AddScorePoint(1);
                            --j;
                        }
                    }
                    countFullRows = 0;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Check for full row on grid
    /// </summary>
    /// <param name="numberRow"></param>
    /// <returns>true if row is full</returns>
    private bool isRowFull(int numberRow)
    {
        for (int i = 0; i < _width; i++)
        {
            if (_arrayOfGridCells[i, numberRow] == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Lower all rows, which are higher "numberRow"
    /// </summary>
    /// <param name="numberRow">number of row</param>
    private void lowerRows(int numberRow)
    {
        for (int j = numberRow + 1; j < _height; j++)
        {
            for (int i = 0; i < _width; i++)
            {
                if (_arrayOfGridCells[i, j] != null)
                {
                    _arrayOfGridCells[i, j - 1] = _arrayOfGridCells[i, j];
                    _arrayOfGridCells[i, j] = null;

                    _arrayOfGridCells[i, j - 1].position += Vector3.down;
                }
            }
        }
    }

    public int GetWidth()
    {
        return _width;
    }

    public int GetHeight()
    {
        return _height;
    }

}