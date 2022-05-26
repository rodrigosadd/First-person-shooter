using UnityEngine;

public interface IMonoBehaviourPool
{
    MonoBehaviour MonoBehaviourReference { get; }
    GameObject GameObjectReference { get; }
}
