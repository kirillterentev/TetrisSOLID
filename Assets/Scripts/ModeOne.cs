using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeOne : MonoBehaviour 
{
	public List<ModelProbStruct> Figures;
	public GameObject GridCell;
    public float Speed = 1;

    private Transform _currentFigure = null;
    private float _counter = 0;

    private IUserInterface _userInterface;
    private IGraphic _tetrisGraphic;
	private IGrid _tetrisGrid;
    private IMovement _figureMovement;
    private ICollection _tetrisCollection;
    private IUserParameter _userParameter;

	#region Start
	void Start () 
	{
        _userInterface = FindObjectOfType<TetrisUI>();
        _userParameter = new UserParameter(_userInterface);
        _tetrisCollection = new TetrisCollection(Figures);
		_tetrisGraphic = new TetrisGraphic ();
		_tetrisGrid = new TetrisGrid (10, 20, _tetrisGraphic, _userParameter);
        _figureMovement = new FigureMovement(_tetrisGrid);

        _tetrisGraphic.DrawGrid(10, 20, GridCell);

        Speed = (Speed == 0) ? 1 : Speed;
	}
	#endregion

	#region Update
	void Update()
	{
        if (_currentFigure == null)
        {
            GameObject figure = _tetrisCollection.GetRandomFigure();
            _currentFigure = _tetrisGraphic.DrawFigure(figure);

            if (!_tetrisGrid.CheckForCollisionWithFigureOrFloor(_currentFigure))
            {
                _userInterface.LoadMainMenu();
            }

        }

        #region Input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _figureMovement.MoveFigureHorizontally(_currentFigure, -1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _figureMovement.MoveFigureHorizontally(_currentFigure, 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _figureMovement.RotateFigure(_currentFigure);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            _userInterface.PrintMenu();
        }
        #endregion

        if (_counter >= 1)
        {
            if (_figureMovement.FallFigure(_currentFigure))
            {
                _tetrisGrid.DeleteFullRows();
                _currentFigure = null;
            }

            _counter = 0;
        }

        _counter += Speed * Time.deltaTime;
	}
	#endregion
}
