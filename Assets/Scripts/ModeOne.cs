using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeOne : MonoBehaviour 
{
	public List<ModelProbStruct> Figures;
	public GameObject GridCell;
    public float speed = 1;

    private Transform _currentFigure = null;
    private float _counter = 0;

	private IGraphic _tetrisGraphic;
	private IGrid _tetrisGrid;
    private IMovement _figureMovement;
    private ICollection _tetrisCollection;

	#region Start
	void Start () 
	{
        _tetrisCollection = new TetrisCollection(Figures);
		_tetrisGraphic = new TetrisGraphic ();
		_tetrisGraphic.DrawGrid (10, 20, GridCell);
    
		_tetrisGrid = new TetrisGrid (10, 20, _tetrisGraphic);
        _figureMovement = new FigureMovement(_tetrisGrid);

        speed = (speed == 0) ? 1 : speed;
	}
	#endregion

	#region Update
	void Update()
	{
        if (_currentFigure == null)
        {
            GameObject figure = _tetrisCollection.GetRandomFigure();
            _currentFigure = _tetrisGraphic.DrawFigure(figure);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _figureMovement.MoveFigureHorizontally(_currentFigure, false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _figureMovement.MoveFigureHorizontally(_currentFigure, true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _figureMovement.RotateFigure(_currentFigure);
        }

        if (_counter >= 1)
        {
            if (_figureMovement.FallFigure(_currentFigure))
            {
                _tetrisGrid.DeleteFullRows();
                _currentFigure = null;
            }

            _counter = 0;
        }

        _counter += speed * Time.deltaTime;
	}
	#endregion
}
