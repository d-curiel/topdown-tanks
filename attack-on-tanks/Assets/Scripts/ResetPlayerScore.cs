using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerScore : MonoBehaviour
{
    [SerializeField]
    PlayerScoreData _PlayerScoreData;
    private void Awake()
    {
        _PlayerScoreData.PlayerPoints = 0;
    }
}
