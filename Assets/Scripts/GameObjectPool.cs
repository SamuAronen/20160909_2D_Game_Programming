using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Runner
{
    public class GameObjectPool
    {

        private Queue<GameObject> _objectQueue;
        private GameObject _prefab;

        public GameObjectPool(GameObject prefab, int initialSize)
        {
            _prefab = prefab;
            _objectQueue = new Queue<GameObject>(initialSize);

            for (int i = 0; i < initialSize; i++)
            {
                var go = Object.Instantiate(_prefab);

                AddObjectToPool(go);
            }
        }

        public void AddObjectToPool(GameObject go)
        {
            go.SetActive(false);
            _objectQueue.Enqueue(go);
        }

        public GameObject GetObject()
        {
            if (_objectQueue.Count > 0)
            {
                var go = _objectQueue.Dequeue();
                go.SetActive(true);
                return go;
            }

            var obj =  Object.Instantiate(_prefab);
            obj.SetActive(true);
            return obj;
        }
    }
}
