using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TetrisUI : MonoBehaviour, IUserInterface
{
    public Text scoreText;
    public GameObject menu;

    public void PrintScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void PrintMenu()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void LoadModeOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadModeTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinuePlay()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

}
