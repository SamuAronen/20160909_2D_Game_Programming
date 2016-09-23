using UnityEngine;
using System.Collections;

namespace Runner
{
    public class Collectables : MonoBehaviour
    {
        [SerializeField] private int _points;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null)
            {
                GameManager.Instance.AddPoints(_points);

                Destroy(gameObject);
            }
        }
      
    }
}