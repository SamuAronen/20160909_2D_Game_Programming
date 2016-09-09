using UnityEngine;
using System.Collections;

namespace Runner { 
public class CameraFollow : MonoBehaviour {
        [SerializeField] private Transform _player;

	// Update is called once per frame
	void Update ()
    {
            transform.position = new Vector3(_player.position.x + 6,0,transform.position.z);
	}
}
}