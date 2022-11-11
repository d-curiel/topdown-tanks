using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FeedbackBeforeExplosion : MonoBehaviour
{
    private SpriteRenderer _SpriteRenderer;
    private float _SecondsToExplode = 1.5f;

    public UnityEvent OnFinish;
    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void BeginExplosion()
    {
        StartCoroutine(FinishWithExplosion());
    }

    private IEnumerator FinishWithExplosion()
    {
        float _progress = 0.0f;

        while (_progress < 1)
        {
            Color _tmpColor = _SpriteRenderer.color;
            _SpriteRenderer.color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, Mathf.Lerp(0, 1, _progress)); //startAlpha = 0 <-- value is in tmp.a
            _progress += Time.deltaTime * _SecondsToExplode;
            yield return null;
        }
        OnFinish?.Invoke();

    }
}
