using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetector : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField]
    private float _ViewRadius = 11;
    [SerializeField]
    private float _DetectionCheckDelay = 0.5f;

    [SerializeField]
    private Transform _Target = null;
    [SerializeField]
    private LayerMask _PlayerLayerMask;
    [SerializeField]
    private LayerMask _VisibilityLayer;

    [field: SerializeField]
    public bool TargetVisible { get; private set; }

    public Transform Target
    {
        get => _Target;
        set
        {
            _Target = value;
            TargetVisible = false;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update()
    {
        if(Target != null)
        {
            TargetVisible = CheckTargetVisible();
        }
    }

    private bool CheckTargetVisible()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Target.position - transform.position, _ViewRadius, _VisibilityLayer);
        if (raycast.collider != null)
        {
            return (_PlayerLayerMask & (1 << raycast.collider.gameObject.layer)) != 0;
        }
        return false;
    }
    private void DetectTarget()
    {
        if (Target != null)
        {
            DetectIfOutOfRange();
        } else 
        {
            CheckIfPlayerIsInRange();
        }
    }

    private void DetectIfOutOfRange()
    {
        if(Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position, Target.position) > _ViewRadius + 1)
        {
            Target = null;
        }
    }

    private void CheckIfPlayerIsInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, _ViewRadius, _PlayerLayerMask);
        if(collision != null)
        {
            Target = collision.transform;
        }
    }
    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(_DetectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _ViewRadius);
    }
}
