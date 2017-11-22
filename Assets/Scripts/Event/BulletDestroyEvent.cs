using UnityEngine;
using System.Collections;

public class BulletDestroyEvent : IChronoEvent
{
    private Vector2 position;
    private bool direction;
    private bool belongsToPlayer;
    private GameObject instance;
    //private GameObject culprit;
    //private GameObject casualty;

    public BulletDestroyEvent(BulletController bc, float direction)
    {
        this.position = bc.transform.position;
        this.belongsToPlayer = bc.belongsToPlayer;
        this.direction = direction > 0.0f;
        this.instance = bc.gameObject;

    }
    
    public void doEvent()
    {
        Object.Destroy(this.instance);
    }

    public void undoEvent()
    {
        float dir = direction ? 1.0f : -1.0f;
        this.instance = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Bullet"), position, Quaternion.identity);
        var bc = this.instance.GetComponent<BulletController>();
        bc.belongsToPlayer = this.belongsToPlayer;
        bc.SetDirection(-dir); //this is rewind
    }
}
