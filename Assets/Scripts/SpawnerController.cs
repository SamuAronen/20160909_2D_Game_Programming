using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Runner
{

    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs;
        [SerializeField] private int _objectsInPool;

        private Dictionary<string, GameObjectPool> _pools = new Dictionary<string, GameObjectPool>();

        private List<string> _poolNames = new List<string>();

        private Spawner[] _spawners;

        private void Awake()
        {
            for(int i = 0; i < _prefabs.Length; i++)
            {
                _poolNames.Add(_prefabs[i].name);
                var pool = new GameObjectPool(_prefabs[i], _objectsInPool);
                _pools.Add(_prefabs[i].name, pool);
            }
            _spawners = GetComponentsInChildren<Spawner>(true);

            foreach (var spawner in _spawners)
            {
                spawner.Init(this);
            }
        }


        public GameObject GetRandomObject()
        {
            return GetObject(Random.Range(0,_poolNames.Count));
        }


        public bool AddToPool (GameObject go)
        {
            var result = false;

            foreach (KeyValuePair<string, GameObjectPool> kvp in _pools)
            {
                if (go.name.Contains(kvp.Key))
                {
                    kvp.Value.AddObjectToPool(go);
                    result = true;
                    break;
                    
                }
            }

            return result;
        }
        
       private GameObject GetObject(int index)
        {
            GameObject result = null;

            if (index < _poolNames.Count && index >= 0)
            {
                var poolName = _poolNames[index];

                if (_pools.ContainsKey(poolName))
                {
                    result = _pools[poolName].GetObject();
                }

            }

            return result;

        }
    }
}
