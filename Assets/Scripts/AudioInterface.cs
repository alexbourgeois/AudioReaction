using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInterface : MonoBehaviour
{
    public static AudioInterface instance;

    public FFTWindow window;
    private int _spectrumSize = 512;
    public int SpectrumSize
    {
        get
        {
            return _spectrumSize;
        }
        set
        {
            _spectrumSize = value;
            InitSpectrum();
        }
    }
    public List<float> fftSpectrum;
    public List<float> logIndexes;

    private float[] _spectrum;

    void InitSpectrum()
    {
        _spectrum = new float[_spectrumSize];
        logIndexes = new List<float>();
        fftSpectrum = new List<float>();
        for (int i = 0; i < SpectrumSize; i++)
        {
            logIndexes.Add(Mathf.Log(i));
            fftSpectrum.Add(0.0f);
        }
    }

    private void Awake()
    {
        instance = this;
        InitSpectrum();
    }

    void Update()
    {
        AudioListener.GetSpectrumData(_spectrum, 0, window);

        for (int i = 1; i < _spectrum.Length - 1; i++)
        {
            fftSpectrum[i] = _spectrum[i];
            Debug.DrawLine(transform.position + new Vector3(i - 1, _spectrum[i] + 10, 0), transform.position + new Vector3(i, _spectrum[i + 1] + 10, 0), Color.red);
            //Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(transform.position + new Vector3(Mathf.Log(i - 1), (_spectrum[i - 1]), 1), transform.position + new Vector3(Mathf.Log(i), (_spectrum[i]), 1), Color.green);
            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }

       // AudioAnalyzer.instance.RunKernel();
    }
}
