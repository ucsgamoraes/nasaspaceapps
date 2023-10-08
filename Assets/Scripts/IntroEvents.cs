using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class IntroEvents : MonoBehaviour
{
    public string sceneToLoad;
    
    public void GoToNextScene ()
    {
        Debug.Log("Loadddd");
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}