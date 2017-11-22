using UnityEngine;
using System.Collections;

public class BulletInstantiateEvent : IChronoEvent
{
    private Vector2 position;
    private bool direction;
    private bool belongsToPlayer;
    private GameObject instance;
    

    public BulletInstantiateEvent(GameObject instance, float direction)
    {
        this.instance = instance;
        var bc = this.instance.GetComponent<BulletController>();
        this.position = bc.transform.position;
        this.belongsToPlayer = bc.belongsToPlayer;
        this.direction = (direction > 0.0f);
    }
    
    public void doEvent()
    {        
        float dir = direction ? 1.0f : -1.0f;
        this.instance = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Bullet"), position, Quaternion.identity);
        var bc = this.instance.GetComponent<BulletController>();
        bc.belongsToPlayer = this.belongsToPlayer;
        bc.SetDirection(direction ? 1.0f : -1.0f);        
    }

    public void undoEvent()
    {
        Object.Destroy(this.instance);
    }
}
