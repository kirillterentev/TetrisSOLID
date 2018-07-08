using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeOne : MonoBehaviour 
{
	public List<ModelProbStruct> Figures;
	public GameObject GridCell;
<<<<<<< HEAD
    public float Speed = 1;
=======
    public float speed = 1;
>>>>>>> 59e48246e7cf9f10f5abcae490388e0481106080

    private Transform _currentFigure = null;
    private float _counter = 0;

<<<<<<< HEAD
    private IUserInterface _userInterface;
    private IGraphic _tetrisGraphic;
	private IGrid _tetrisGrid;
    private IMovement _figureMovement;
    private ICollection _tetrisCollection;
    private IUserParameter _userParameter;
=======
	private IGraphic _tetrisGraphic;
	private IGrid _tetrisGrid;
    private IMovement _figureMovement;
    private ICollection _tetrisCollection;
>>>>>>> 59e48246e7cf9f10f5abcae490388e0481106080

	#region Start
	void Start () 
	{
<<<<<<< HEAD
        _userInterface = FindObjectOfType<TetrisUI>();
        _userParameter = new UserParameter(_userInterface);
        _tetrisCollection = new TetrisCollection(Figures);
		_tetrisGraphic = new TetrisGraphic ();
		_tetrisGrid = new TetrisGrid (10, 20, _tetrisGraphic, _userParameter);
        _figureMovement = new FigureMovement(_tetrisGrid);

        _tetrisGraphic.DrawGrid(10, 20, GridCell);

        Speed = (Speed == 0) ? 1 : Speed;
=======
        _tetrisCollection = new TetrisCollection(Figures);
		_tetrisGraphic = new TetrisGraphic ();
		_tetrisGraphic.DrawGrid (10, 20, GridCell);
    
		_tetrisGrid = new TetrisGrid (10, 20, _tetrisGraphic);
        _figureMovement = new FigureMovement(_tetrisGrid);

        speed = (speed == 0) ? 1 : speed;
>>>>>>> 59e48246e7cf9f10f5abcae490388e0481106080
	}
	#endregion

	#region Update
	void Update()
	{
        if (_currentFigure == null)
        {
            GameObject figure = _tetrisCollection.GetRandomFigure();
            _currentFigure = _tetrisGraphic.DrawFigure(figure);
<<<<<<< HEAD

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
=======
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _figureMovement.MoveFigureHorizontally(_currentFigure, false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _figureMovement.MoveFigureHorizontally(_currentFigure, true);
>>>>>>> 59e48246e7cf9f10f5abcae490388e0481106080
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _figureMovement.RotateFigure(_currentFigure);
        }
<<<<<<< HEAD
        if(Input.GetKey(KeyCode.Escape))
        {
            _userInterface.PrintMenu();
        }
        #endregion
=======
>>>>>>> 59e48246e7cf9f10f5abcae490388e0481106080

        if (_counter >= 1)
        {
            if (_figureMovement.FallFigure(_currentFigure))
            {
                _tetrisGrid.DeleteFullRows();
                _currentFigure = null;
            }

            _counter = 0;
        }

<<<<<<< HEAD
        _counter += Speed * Time.deltaTime;
=======
        _counter += speed * Time.deltaTime;
>>>>>>> 59e48246e7cf9f10f5abcae490388e0481106080
	}
	#endregion
}
