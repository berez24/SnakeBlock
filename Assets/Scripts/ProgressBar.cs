using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform Finish;
    public Slider Slider;
    public float AcceptableFinishPlayerDistance = 1f;

    private float _startZ;
    private float _minimumReachedZ;

    void Start()
    {
        _startZ = Player.transform.position.z;
    }

    void Update()
    {
        _minimumReachedZ = Mathf.Min(_minimumReachedZ, Player.transform.position.z);
        float finishZ = Finish.position.z;
        float t = Mathf.InverseLerp(_startZ, finishZ + AcceptableFinishPlayerDistance, _minimumReachedZ);

        Slider.value = t;
    }
}
