using UnityEngine;
using System.Collections;

public class BulletDestroyEvent : IChronoEvent
{
    private GameObject instance;


    public BulletDestroyEvent(GameObject instance)
    {
        this.instance = instance;
    }

    public void doEvent()
    {
        this.instance.SetActive(false);
    }

    public void undoEvent()
    {
        this.instance.SetActive(true);
        this.instance.GetComponent<ChronoBreakBullet>().ChangeState();
    }
}
