using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private object application;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
        public void QuitGame () 
    
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
  

