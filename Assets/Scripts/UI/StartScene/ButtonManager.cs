using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeScene = null;
    public void ClickQuit()
    {
        Application.Quit();
    }
    public void ClickOption()
    {
        Debug.Log("Option");
    }
    public void ClickStart()
    {
        _changeScene.CallScene(SceneName.Stage);
    }
}
