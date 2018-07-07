using UnityEngine;

public interface IUserParameter
{
    /// <summary>
    /// Add count point
    /// </summary>
    /// <param name="count"></param>
    void AddScorePoint(int count);

    /// <summary>
    /// Getter of score
    /// </summary>
    /// <returns></returns>
    int GetScore();
}

public class UserParameter : IUserParameter
{
    private int _score;
    private IUserInterface _userInterface;

    public UserParameter(IUserInterface userinterface)
    {
        _userInterface = userinterface;
        _score = 0;
    }

    public void AddScorePoint(int count)
    {
        _score += count;
        _userInterface.PrintScore(_score);
    }

    public int GetScore()
    {
        return _score;
    }
}

