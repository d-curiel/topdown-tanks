using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _PatrolPoints = new List<Transform>();
    public int _PatrolLength  { get => _PatrolPoints.Count; }

    [Header("Gizmos")]
    public Color PointsColor = Color.cyan; 
    public Color LineColor = Color.red;
    public float PointsSize = 0.3f;

    public struct PathPoint
    {
        public int Index;
        public Vector2 Position;
    }

    public PathPoint GetClosestPathPosition(Vector2 patrolerPosition)
    {
        var minDistance = float.MaxValue;
        var index = -1;
        for(int i = 0; i < _PatrolPoints.Count; i++)
        {
            var tempDistance = Vector2.Distance(patrolerPosition, _PatrolPoints[i].position);
            if(tempDistance < minDistance)
            {
                minDistance = tempDistance;
                index = i;
            }
        }
        return new PathPoint { Index = index, Position = _PatrolPoints[index].position };
    }

    public PathPoint GetNextPAthPoint(int index)
    {
        var newIndex = index + 1 >= _PatrolPoints.Count ? 0 : index + 1;
        return new PathPoint { Index = newIndex, Position = _PatrolPoints[newIndex].position };
    }

    private void OnDrawGizmos()
    {
        if (_PatrolPoints.Count == 0)
        {
            return;
        }
        for (int i = _PatrolPoints.Count - 1; i > _PatrolPoints.Count; i--)
        {
            if(_PatrolPoints[i] == null)
            {
                return;
            }
            Gizmos.color = PointsColor;
            Gizmos.DrawSphere(_PatrolPoints[i].position, PointsSize);

            if (_PatrolPoints.Count == 1 || i == 0)
            {
                return;
            }
            Gizmos.color = LineColor;
            Gizmos.DrawLine(_PatrolPoints[i].position, _PatrolPoints[i - 1].position);
            if(_PatrolPoints.Count > 2 && i == _PatrolPoints.Count - 1)
            {

                Gizmos.DrawLine(_PatrolPoints[i].position, _PatrolPoints[0].position);
            }
        }
    }
}
