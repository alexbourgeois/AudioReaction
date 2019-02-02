using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReaktor : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float From;
    [Range(0.0f, 1.0f)]
    public float To;

    public float Threshold;

    public Color GizmoColor;
    public float delay;
    private float _lastTime;
    private bool _bounce;

    private bool triggered;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("From : " + Mathf.FloorToInt(From * AudioInterface.instance.fftSpectrum.Count) + " to : " + Mathf.FloorToInt(To * AudioInterface.instance.fftSpectrum.Count) + " on " + AudioInterface.instance.fftSpectrum.Count);
        for (var i = Mathf.FloorToInt(From * AudioInterface.instance.fftSpectrum.Count); i < Mathf.FloorToInt(To * AudioInterface.instance.fftSpectrum.Count); i++)
        {
            //Debug.Log(i);
            if (AudioInterface.instance.fftSpectrum[i] > Threshold && Time.time - _lastTime > delay)
            {
                _lastTime = Time.time;

                if (!triggered)
                    React();

                triggered = true;
                _bounce = !_bounce;
            }
            else
            {
                triggered = false;
            }
        }
    }

    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = GizmoColor;

        Gizmos.DrawSphere(AudioInterface.instance.transform.position + new Vector3(From * 6.25f, 0.0f, 1.0f), 0.05f);

        Gizmos.DrawSphere(AudioInterface.instance.transform.position + new Vector3(To * 6.25f, 0.0f, 1.0f), 0.05f);

        Gizmos.DrawLine(AudioInterface.instance.transform.position +    new Vector3(0.0f, Threshold, 1.0f), AudioInterface.instance.transform.position + new Vector3(6.25f, Threshold, 1.0f));
    }

    public virtual void React()
    {
    }
}
