using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoBreakManager : MonoBehaviour {

    public const int RECORDLENGTH = 600;
    public Text text;
    //private Dictionary<int, List<IChronoEvent>> events;
    private int frame = 0;
    private bool rewindState = false;
    private List<IChronoObject> objects = new List<IChronoObject>();

    public GameObject player;
    public Vector3 spawn;

	// Use this for initialization
	void Start () {

    }
	
	void LateUpdate () {
        text.text = "FRAME: " + frame;

		if (!rewindState && ++frame == RECORDLENGTH)
        {
            rewindState = true;
            foreach (var obj in objects)
            {
                obj.ChangeState();
            }
        }
        else if (rewindState && --frame == 0)
        {
            rewindState = false;
            foreach (var obj in objects)
            {
                obj.ChangeState();
            }
            Instantiate(player, spawn, Quaternion.identity);
            
        }
	}
    
    /*
    internal void recordEvent(IChronoEvent addedEvent)
    {
        if (!events.ContainsKey(frame))
        {
            events[frame] = new List<IChronoEvent>();
        }

        events[frame].Add(addedEvent);
    }
    */

    internal void registerObject(ChronoBreakCharacter chronoBreakCharacter)
    {
        objects.Add(chronoBreakCharacter);
    }
}
