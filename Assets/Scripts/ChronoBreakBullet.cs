using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChronoBreakBullet : MonoBehaviour, IChronoObject {

    //State
    private bool isRecordState;
    private bool isRewindState;
    private BulletState[] stateRecord;
    private Rigidbody2D rb;
    private int frame;
    private ChronoBreakManager manager;

    //initial state is record
    void Awake()
    {
        this.isRecordState = true;
        this.isRewindState = false;
        this.stateRecord = new BulletState[ChronoBreakManager.RECORDLENGTH];
        this.frame = 0;
    }

    //Tell ChronoBreakManager I was created (and it knows about me)
    void Start ()
    {
        var managerObject = GameObject.Find("Chrono Break Manager");
        this.manager = managerObject.GetComponent<ChronoBreakManager>();
        this.manager.registerObject(this);
        this.manager.recordEvent(new BulletInstantiateEvent(this.gameObject));

    }
	
	//Save state
	void Update()
    { 
        if (this.isRecordState)
        {
            stateRecord[frame++] = new BulletState(this.transform);
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

    internal void recordEvent(IChronoEvent e) 
    {
        this.manager.recordEvent(e);
    }

}
