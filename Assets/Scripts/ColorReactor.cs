using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReactor : AudioReaktor
{
    public Material mat;

    [Header("Color")]
    [Range(0.0f, 1.0f)]
    public float Saturation;
    [Range(0.0f, 1.0f)]
    public float Variance;
    [Range(0.0f, 1.0f)]
    public float Alpha;

    public override void React()
    {
        var color = Color.HSVToRGB(Random.value, Saturation, Variance);
        color.a = Alpha;
        mat.SetColor("_BaseColor", color);
        mat.SetColor("_EmissionColor", color);
        //mat.SetColor("_BaseColor", Color.HSVToRGB(Random.value, Saturation, Variance));
    }
}
