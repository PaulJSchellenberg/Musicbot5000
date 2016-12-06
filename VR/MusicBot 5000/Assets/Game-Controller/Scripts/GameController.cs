﻿using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

    // Use this for initialization
    public Transform InstrumentSpot;
    public GameObject[] Instruments;
    GameObject InstrumentInst;
    public int InstrumentID;
    public bool LMenuOpen;
    public bool RMenuOpen;

	void Start () {
        InstrumentID = -1;
        LMenuOpen = false;
        RMenuOpen = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeInstrument(int Id)
    {
        if (InstrumentInst != null && Id!=InstrumentID)
        {
            Destroy(InstrumentInst);
        }
        if (Id >= 0 && Id!=InstrumentID)
        {
            InstrumentInst = Instantiate(Instruments[Id], InstrumentSpot) as GameObject;
        }
        InstrumentID = Id;
    }

}
