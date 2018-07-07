using System.Collections.Generic;
using UnityEngine;

public interface ICollection 
{
	/// <summary>
	/// Returns random figure.
	/// </summary>
	/// <returns>GameObject random figure</returns>
	GameObject GetRandomFigure();
}

public class TetrisCollection : ICollection
{
	private List<ModelProbStruct> _figureList;
	private float _totalProbability = 0;

    /// <summary>
    /// Instance TetrisCollection
    /// </summary>
    /// <param name="figureList"></param>
	public TetrisCollection(List<ModelProbStruct> figureList)
	{
		_figureList = figureList;
		for (int i = 0; i < _figureList.Count; i++) 
		{
			_totalProbability += _figureList [i].Probability;
		}
	}

	public GameObject GetRandomFigure()
	{
		float randomValue = Random.value * _totalProbability - 0.01f;

		for (int i = 0; i < _figureList.Count; i++) 
		{
			float currentProbability = _figureList [i].Probability;

			if (randomValue > currentProbability) 
			{
				randomValue -= currentProbability;
			} 
			else 
			{
				return _figureList [i].FigureObject;
			}
		}
		return _figureList[0].FigureObject;
	}
}