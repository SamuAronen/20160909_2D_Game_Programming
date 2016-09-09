using UnityEngine;
using System.Collections;

namespace Runner
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _spawnPrefabs;
        [SerializeField] private float _spawnTimeMin;
        [SerializeField] private float _spawnTimeMax;


        private void Awake()
        {
            Spawn();
        }


        private void Spawn()
        {

            var prefab = _spawnPrefabs[Random.Range(0, _spawnPrefabs.Length)];
            Instantiate(prefab, transform.position, Quaternion.identity);

            // Hacky method?
            Invoke("Spawn",Random.Range(_spawnTimeMin,_spawnTimeMax));
        }
    }
}