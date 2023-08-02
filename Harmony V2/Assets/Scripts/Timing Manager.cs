using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimingManager : MonoBehaviour
{
    protected float BPS;
    [SerializeField] public float BPM;
    [SerializeField] public int BeatsPerMeasure;
    protected float MeasureTime;
    protected float BeatInterval;
    private float CurrentTime;
    private int CurrentBeat;

    public string TextBPM;
    public string TextCurrentBeat;
    public string TextTime;
    public string Feedback;

    public TMP_Text DisplayText;

    float perfect;
    float good;
    float miss;

    bool BeatHasBeenPressed;

    // Start is called before the first frame update
    void Start()
    {
        BPS = BPM / 60;
        MeasureTime = BeatsPerMeasure / BPS;
        BeatInterval = MeasureTime / BeatsPerMeasure;
        CurrentTime = 0;
        CurrentBeat = 0;

        perfect = BeatInterval / 8;
        good = BeatInterval / 4;

        //BeatHasBeenPressed = true;

        TextBPM = BPM.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;


        #region Code for determining what beat it currently is
        if (CurrentTime >= BeatInterval * CurrentBeat && CurrentTime < BeatInterval * (CurrentBeat+1))
        {
            CurrentBeat++;
            if(BeatHasBeenPressed == false)
            {
                Feedback += "Miss! ";
            }
            else
            {
            BeatHasBeenPressed = false;
            }
        }
        if(CurrentTime > BeatInterval * 4)
        {
            CurrentTime = 0;
            CurrentBeat = 0;
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BeatHasBeenPressed == false && (CurrentTime > ((BeatInterval * CurrentBeat) - perfect) || (CurrentTime < ((BeatInterval * CurrentBeat) + perfect))))
            {
                Feedback += "Perfect! ";
                //BeatHasBeenPressed = true;
            }
            else if (BeatHasBeenPressed == false && (CurrentTime > ((BeatInterval * CurrentBeat) - good) || (CurrentTime < ((BeatInterval * CurrentBeat) + good))))
            {
                Feedback += "Good! ";
                //BeatHasBeenPressed = true;
            }
        }

        if (CurrentBeat == 0)
        {
            Feedback = "";
        }
        else
        {
            //Feedback = "Miss!";
        }
        TextCurrentBeat = CurrentBeat.ToString();
        TextTime = CurrentTime.ToString();

        DisplayText.text = $"Current BPM: {TextBPM}\nCurrent Beat: {TextCurrentBeat}\nTime: {TextTime}\nResponse: {Feedback}";
    }
}
