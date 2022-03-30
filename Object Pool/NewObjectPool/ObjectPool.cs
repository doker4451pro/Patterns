using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private List<PoolItem> _poolObjectsList;

    private Dictionary<Type,List<MonoBehaviour>> _dictPoolObjects;

    private void Awake()
    {
        Instance = this;
        _dictPoolObjects = new Dictionary<Type, List<MonoBehaviour>>();

        foreach (var item in _poolObjectsList)
        {
            var poolList = new List<MonoBehaviour>();
            for (int i = 0; i < item.StartCapacity; i++)
            {
                var gameObject = Instantiate(item.ObjectToPool);
                gameObject.gameObject.SetActive(false);
                poolList.Add(gameObject);
            }
            _dictPoolObjects.Add(item.ObjectToPool.GetType(), poolList);
        }
    }



    public T GetObject<T>() where T : MonoBehaviour
    {
        var list = new List<MonoBehaviour>();
        if (_dictPoolObjects.TryGetValue(typeof(T), out list))
        {
            MonoBehaviour gameObject = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].isActiveAndEnabled)
                {
                    gameObject = list[i];
                }
            }
            gameObject = Instantiate(list[0]);
            list.Add(gameObject);

            ((IPoolObject)gameObject).GetFromPool();
            return (T)gameObject;
        }
        else
        {
            return null;
        }
    }


    public T GetObject2<T>() where T : MonoBehaviour
    {
        var list = new List<MonoBehaviour>();
        if (_dictPoolObjects.TryGetValue(typeof(T), out list))
        {
            MonoBehaviour gameObject = null;
            if (list.Count != 0)
            {
                gameObject = list[0];
                list.RemoveAt(0);
            }
            else
            {
                foreach (var item in _poolObjectsList)
                {
                    if (item.ObjectToPool.GetType() == typeof(T))
                    {
                        gameObject = Instantiate(item.ObjectToPool);
                    }
                }
            }

            ((IPoolObject)gameObject).GetFromPool();
            return (T)gameObject;
        }
        else
        {
            return null;
        }
    }
    public void ReturnToPool(MonoBehaviour monoBehaviour) 
    {
        var list = new List<MonoBehaviour>();
        if (_dictPoolObjects.TryGetValue(monoBehaviour.GetType(),out list)) 
        {
            ((IPoolObject)monoBehaviour).ReturnToPool();
            list.Add(monoBehaviour);
        }
    }

    #region SerializableClass
    [System.Serializable]
    private class PoolItem
    {
        public string Name;
        [Header("Only IPoolObject")]
        public MonoBehaviour ObjectToPool;
        public int StartCapacity = 10;
    }
    #endregion

}
