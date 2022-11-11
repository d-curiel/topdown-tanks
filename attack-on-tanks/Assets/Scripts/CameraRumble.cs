using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraRumble : MonoBehaviour
{
    CinemachineVirtualCamera _VCam;

    private float _RumbleSeconds = 0.5f;
    [SerializeField]
    float _Intensity;

    public UnityEvent OnFinish;
    private void Awake()
    {
        _VCam = FindObjectOfType<CinemachineVirtualCamera>();
    }
    
    public void Rumble()
    {
        StartCoroutine(RumbleCoroutine());
    }

    IEnumerator RumbleCoroutine()
    {
        _VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = _Intensity;
        yield return new WaitForSeconds(_RumbleSeconds);
        _VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        OnFinish?.Invoke();
        Destroy(gameObject);
    }
}
