﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChronoBreakCharacter : MonoBehaviour, IChronoObject {

    //State
    private bool isRecordState;
    private bool isRewindState;
    //private CircularList<CharacterState> stateRecord;
    private CharacterState[] stateRecord;
    private Rigidbody2D rb;
    private int frame;

    //initial state is record
    void Awake()
    {
        this.isRecordState = true;
        this.isRewindState = false;
        this.stateRecord = new CharacterState[ChronoBreakManager.RECORDLENGTH];
        this.rb = GetComponent<Rigidbody2D>();
        this.frame = 0;
    }

    //Tell ChronoBreakManager I was created (and it knows about me)
    void Start ()
    {
        var manager = GameObject.Find("Chrono Break Manager");
        //manager.GetComponent<ChronoBreakManager>().recordEvent(new CreatedEvent(this));
        manager.GetComponent<ChronoBreakManager>().registerObject(this);

    }
	
	//Save state
	void Update()
    { 
        if (this.isRecordState)
        {
            stateRecord[frame++] = new CharacterState(this.transform);
        }
        else if (this.isRewindState)
        {
            stateRecord[frame--].loadState(this.transform);
        }
        else
        {
            stateRecord[frame++].loadState(this.transform);
        }
	}

    public void ChangeState()
    {
        if (isRecordState)
        {
            this.isRecordState = false;
            this.isRewindState = true;
            this.rb.simulated = false;
        }
        else
        {
            this.isRewindState = !this.isRewindState; //State pattern is overrated
        }
    }
}