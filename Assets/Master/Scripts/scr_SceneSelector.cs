using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scr_SceneSelector : MonoBehaviour {

    public void SceneLoader(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitRequest()
    {
        Application.Quit();
    }
}
