using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    private float shakeTimer;
    
    private CinemachineBasicMultiChannelPerlin _cmBasicMultiChannelPerlin;
    void Start()
    {
        _cmBasicMultiChannelPerlin =
            GetComponent<CinemachineVirtualCamera>().GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            _cmBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        }
        
        
    }

    public void ShakeScreen(float intensity, float duration)
    {
        _cmBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        shakeTimer = duration;
    }
}
