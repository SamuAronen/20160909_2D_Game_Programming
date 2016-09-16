using UnityEngine;
using System.Collections;

namespace Runner
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _spawnPrefabs;
        [SerializeField]
        private float _spawnTimeMin;
        [SerializeField]
        private float _spawnTimeMax;


        private SpawnerController _spawnerController;


        public void Init(SpawnerController spawnerController)
        {
            _spawnerController = spawnerController;

        }

        private void Start()
        {
            Spawn();
        }


        private void Spawn()
        {
            if (_spawnerController == null)
            {
                var prefab = _spawnPrefabs[Random.Range(0, _spawnPrefabs.Length)];
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
            else
            {
                var spawnedObject = _spawnerController.GetRandomObject();
                spawnedObject.transform.position = transform.position;
            }
            // Hacky method?
            Invoke("Spawn", Random.Range(_spawnTimeMin, _spawnTimeMax));
        }
    }
}