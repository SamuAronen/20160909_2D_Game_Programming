using UnityEngine;
using System.Collections;

namespace Runner
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private bool _follow = true;

        // Update is called once per frame
        void Update()
        {
            if (_follow)
            {
                transform.position = new Vector3(_player.position.x + 6, 0, transform.position.z);
            }
        }

        public void GameOver()
        {
            _follow = false;
        }
    }
}