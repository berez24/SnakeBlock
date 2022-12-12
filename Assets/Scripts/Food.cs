using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int MinValue;
    public int MaxValue;
    public TextMeshPro PointsText;

    public int Value = 1;

    void Start()
    {
        Value = Random.Range(MinValue, MaxValue);

        PointsText.SetText(Value.ToString());
    }
}
