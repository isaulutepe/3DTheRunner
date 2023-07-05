using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    private Scene ActiveScene;
    private void Start()
    {
        ActiveScene = SceneManager.GetActiveScene();
    }
    public void restart()
    {

        SceneManager.LoadScene(ActiveScene.name);

    }
}
