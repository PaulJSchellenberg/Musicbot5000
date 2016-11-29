﻿using UnityEngine;
using System.Collections;


public class fingerStickToggler : MonoBehaviour
{
    
    public GameObject Hand;
    public GameObject Finger;
    public GameObject DrumStick, Mallet;
    private GameObject Tip, Knuckle;
    private Vector3 FingerVector, KnuckleVector;
    private GameObject Stick;
    GameController GameCon;

    // Use this for initialization
    void Awake()
    {
    }

    void Start()
    {
        Stick = DrumStick;
        Tip = Finger.transform.FindChild("bone3").gameObject;
        Knuckle = Finger.transform.FindChild("bone1").gameObject;

        FingerVector = Tip.transform.position - Knuckle.transform.position;
        Stick.transform.rotation = Quaternion.LookRotation(FingerVector.normalized);
        Stick.transform.position = Knuckle.transform.position;


        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        FingerVector = Tip.transform.position - Knuckle.transform.position;
        Stick.transform.rotation = Quaternion.LookRotation(FingerVector.normalized);
        KnuckleVector = Knuckle.transform.position;
        KnuckleVector.z -= 0.11f;
        Stick.transform.position = KnuckleVector;

        if (GameCon.MenuOpen)
        {
            HideStick();
        }
    }

    public void ShowStick()
    {
        StartCoroutine(ActivateStick(true));
    }

    public void HideStick()
    {
        StartCoroutine(ActivateStick(false));
    }

    IEnumerator ActivateStick(bool active)
    {
        if (!GameCon.MenuOpen || !active)
        {
            Hand.SetActive(!active);

            Debug.Log(GameCon.InstrumentID);
            switch (GameCon.InstrumentID)
            {
                case 0:
                    Stick = Mallet;
                    break;
                case 1:
                    Stick = DrumStick;
                    break;
            }

            Stick.SetActive(active);
        }
        yield return null;
    }
}