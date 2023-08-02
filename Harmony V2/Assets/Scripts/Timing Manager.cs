using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public int BPS;
    [SerializeField] public int BPM;
    public int BeatsPerMeasure;
    public float MeasureTime;
    public float BeatInterval;

    // Start is called before the first frame update
    void Start()
    {
        BPS = BPM / 60;
        MeasureTime = BeatsPerMeasure / BPS;
        BeatInterval = MeasureTime / BPM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
