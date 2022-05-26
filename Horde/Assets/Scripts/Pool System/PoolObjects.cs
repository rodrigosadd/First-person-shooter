using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private PoolSystem _poolSystem;
    [SerializeField] private PoolableObject _prefabObjPool;
    [SerializeField] private int _initialAmountPoolableObjs;
    [SerializeField] private PoolableObject[] _objsPool;

    GameObject _objsPoolHolder;
    PoolableObject _currentPoolableObj;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        _objsPoolHolder = new GameObject("=== Poolable Objects");
        _objsPoolHolder.transform.position = Vector2.zero;
        _poolSystem.InitializePool(ref _objsPool, _prefabObjPool, _initialAmountPoolableObjs, _objsPoolHolder);
    }

    public PoolableObject GetMonoBehaviourFromPool()
    {
        _currentPoolableObj = (PoolableObject)_poolSystem.TryGetMonoBehaviourFromPool<PoolableObject>(ref _objsPool, _prefabObjPool, _objsPoolHolder);
        _currentPoolableObj.IsBeenUsed = true;
        return _currentPoolableObj;
    }
}
