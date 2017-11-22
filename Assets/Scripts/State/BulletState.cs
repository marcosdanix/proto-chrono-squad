using UnityEngine;

public class BulletState
{
    Vector3 position;

    public BulletState(Transform t)
    {
        this.position = t.position;
    }

    public void loadState(Transform t)
    {
        t.position = this.position;
    }
}
