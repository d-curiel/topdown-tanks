using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerScore", menuName = "Data/PlayerScore")]
public class PlayerScoreData : ScriptableObject
{
    public int PlayerPoints = 0;
    public int MaxPlayerPoints;
}
