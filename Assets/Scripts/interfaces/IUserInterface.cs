using UnityEngine;

public interface IUserInterface
{
    /// <summary>
    /// Print score on the screen
    /// </summary>
    void PrintScore(int score);
    /// <summary>
    /// Print menu on the screen
    /// </summary>
    void PrintMenu();
    /// <summary>
    /// Closed Application
    /// </summary>
    void CloseApplication();
    /// <summary>
    /// Loaded Main Menu
    /// </summary>
    void LoadMainMenu();
    /// <summary>
    /// Continued Play
    /// </summary>
    void ContinuePlay();
 
}

