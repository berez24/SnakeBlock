using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    //public int Value;

    public int MinValue;
    public int MaxValue;
    public TextMeshPro PointsText;
    public Game Game;

    public int Value = 1;
    Color lerpedColor = Color.white;

    void Start()
    {

        Value = Random.Range(MinValue, MaxValue);

        PointsText.SetText(Value.ToString());

        lerpedColor = Color.Lerp(Color.white, Color.red, (float)Value / 20f);
        this.GetComponent<Renderer>().material.color = lerpedColor;
    }

}
