using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    private AudioSource _AudioSource;

    private float _MinVolume = 0.05f, _MaxVolume = 0.1f;
    private float _VolumeIncrease = 0.01f;
    private float _CurrentVolume;

    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
        _CurrentVolume = _MinVolume;
    }
    void Start()
    {
        _AudioSource.volume = _CurrentVolume;
    }

    public void ControlEngineVolume(float speed)
    {
        if(speed > 0)
        {
            if(_CurrentVolume < _MaxVolume)
            {
                _CurrentVolume += _VolumeIncrease * Time.deltaTime;
            }
        }else
        {
            if (_CurrentVolume > _MinVolume)
            {
                _CurrentVolume -= _VolumeIncrease * Time.deltaTime;
            }
        }

        _AudioSource.volume = Mathf.Clamp(_CurrentVolume, _MinVolume, _MaxVolume);
    }

}
