using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Start()
    {
      
        gameOverScreen.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void HideGameOver()
    {
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
       
        Application.Quit();
    }

}
