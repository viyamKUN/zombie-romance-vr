using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    Start, Stage, Game
}
public class ChangeScene : MonoBehaviour
{
    public void CallScene(SceneName sceneName)
    {
        SceneManager.LoadScene((int)sceneName);
    }
}
