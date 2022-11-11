using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenAudioFinish : MonoBehaviour
{
    AudioSource _AudioSource;


    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_AudioSource.clip.length);
        Destroy(gameObject);
    }
}
