using UnityEngine;

public class CharacterState
{
    Vector3 position;
    Vector3 localScale;

    public CharacterState(Transform t)
    {
        this.position = t.position;
        this.localScale = t.localScale;
    }

    public void loadState(Transform t)
    {
        t.position = this.position;
        t.localScale = this.localScale;
    }
}
