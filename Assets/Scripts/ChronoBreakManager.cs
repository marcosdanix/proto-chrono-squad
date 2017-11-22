using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoBreakManager : MonoBehaviour {

    public const int RECORDLENGTH = 600;
    public Text text;
    private Dictionary<int, List<IChronoEvent>> events = new Dictionary<int, List<IChronoEvent>>();
    private int frame = 0;
    private bool rewindState = false;
    private List<IChronoObject> objects = new List<IChronoObject>();

    public GameObject player;
    public Vector3 spawn;
    
	
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
            var newPlayer = Instantiate(player, spawn, Quaternion.identity);
            CameraController.player = newPlayer;

        }


        if (!rewindState && events.ContainsKey(frame))
        {
            foreach (var _event in events[frame])
            {
                _event.doEvent();
            }
        }
        else if (rewindState && events.ContainsKey(frame))
        {
            foreach (var _event in events[frame])
            {
                _event.undoEvent();
            }
        }
    }
    
    internal void recordEvent(IChronoEvent addedEvent)
    {
        if (!events.ContainsKey(frame))
        {
            events[frame] = new List<IChronoEvent>();
        }

        events[frame].Add(addedEvent);
    }

    internal void registerObject(IChronoObject chronoBreakCharacter)
    {
        objects.Add(chronoBreakCharacter);
    }

    internal void Rewind()
    {
        if (!rewindState)
        {
            rewindState = true;
            foreach (var obj in objects)
            {
                obj.ChangeState();
            }
        }
    }
}
