using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject canvasIntro;
    public GameObject canvasJuego;

    public void GoToMainScene()
    {
        SceneManager.LoadScene("PatronesMenu");
    }

    public void GotoGameScene()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "Juego")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
            SceneManager.LoadScene("Juego");

    }

    public void GoToFGGame(){
        //SceneManager.LoadScene("FigurasGeom");
        canvasIntro.SetActive(false);
        canvasJuego.SetActive(true);
    }
}
