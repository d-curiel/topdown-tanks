using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneComponent : MonoBehaviour
{

    [SerializeField]
    private int _Scene;

    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_Scene);
    }
}
