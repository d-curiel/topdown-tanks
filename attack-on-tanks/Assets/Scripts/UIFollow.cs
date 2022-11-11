using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{

    [SerializeField]
    Transform _ObjectToFollow;

    RectTransform _RectTransform;

    private void Awake()
    {
        _RectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _RectTransform.anchoredPosition = _ObjectToFollow.localPosition;
    }
}
