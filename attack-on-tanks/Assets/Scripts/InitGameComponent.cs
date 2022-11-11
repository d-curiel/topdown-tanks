using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGameComponent : MonoBehaviour
{
    [SerializeField]
    Image _InstructionsPanel;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Start()
    {
        _InstructionsPanel.gameObject.SetActive(true);
    }

    public void InitGame()
    {
        _InstructionsPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
