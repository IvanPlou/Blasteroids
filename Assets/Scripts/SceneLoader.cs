using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages scene loading using a editable strin in the inspector that follows the scene naming on Build settings.
public class SceneLoader : MonoBehaviour
{    
    //Loads a specific scene matching the string used in the inspector.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Closes the game when called.
    public void QuitGame()
    {
        Application.Quit();
    }
}
