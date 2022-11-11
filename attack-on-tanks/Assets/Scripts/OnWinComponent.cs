using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OnWinComponent : MonoBehaviour
{
    [SerializeField]
    PlayerInput _PlayerInput;
    public UnityEvent OnWin;
    [SerializeField]
    PlayerScoreData _PlayerScoreData;
    [SerializeField]
    Text _ScoreText;
    [SerializeField]
    Text _MaxScoreText;
    private void Awake()
    {
        _MaxScoreText.text = _PlayerScoreData.MaxPlayerPoints.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            _PlayerInput.actions.actionMaps[0].Disable();
            Time.timeScale = 0;
            if (_PlayerScoreData.PlayerPoints.CompareTo(_PlayerScoreData.MaxPlayerPoints) > 0)
            {
                _PlayerScoreData.MaxPlayerPoints = _PlayerScoreData.PlayerPoints;
            }
            _ScoreText.text = _PlayerScoreData.PlayerPoints.ToString();
            _MaxScoreText.text = _PlayerScoreData.MaxPlayerPoints.ToString();

            Win();
        }
    }

    private void Win()
    {
        OnWin?.Invoke();
    }
}
