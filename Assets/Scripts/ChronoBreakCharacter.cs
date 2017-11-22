using System;
using System.Collections;
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
    private ChronoBreakManager manager;

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
        var managerObject = GameObject.Find("Chrono Break Manager");
        this.manager = managerObject.GetComponent<ChronoBreakManager>();
        this.manager.registerObject(this);

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
            GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            this.isRewindState = !this.isRewindState; //State pattern is overrated
        }
    }

    internal void Rewind()
    {
        this.manager.Rewind();
    }

    internal void recordEvent(IChronoEvent e) 
    {
        this.manager.recordEvent(e);
    }

}
