using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] protected float life;
    [SerializeField] protected float speed;

    protected Vector3 move;
    protected Vector3 velocity;

    public virtual void Movement()
    {
    }
}
