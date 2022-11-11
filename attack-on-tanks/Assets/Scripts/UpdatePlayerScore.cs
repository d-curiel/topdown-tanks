using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerScore : MonoBehaviour
{
    [SerializeField]
    PlayerScoreData _PlayerScoreData;
    [SerializeField]
    PointsData _PointsData;

    public void AddScoreToPlayer()
    {
        _PlayerScoreData.PlayerPoints += _PointsData.Points;
    }
}
