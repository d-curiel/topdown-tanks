using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderPlayerScore : MonoBehaviour
{
    [SerializeField]
    Text _ScoreText;

    [SerializeField]
    PlayerScoreData _PlayerScoreData;

    private void Awake()
    {
        _ScoreText.text = _PlayerScoreData.PlayerPoints.ToString();
    }

    private void Update()
    {
        _ScoreText.text = _PlayerScoreData.PlayerPoints.ToString();
    }
}
