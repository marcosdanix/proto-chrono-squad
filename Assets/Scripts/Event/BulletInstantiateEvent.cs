using UnityEngine;
using System.Collections;

public class BulletInstantiateEvent : IChronoEvent
{
    private GameObject instance;
    

    public BulletInstantiateEvent(GameObject instance)
    {
        this.instance = instance;
    }
    
    public void doEvent()
    {
        this.instance.SetActive(true);
    }

    public void undoEvent()
    {
        this.instance.SetActive(false);
    }
}
