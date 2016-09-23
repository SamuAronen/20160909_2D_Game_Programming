using UnityEngine;
using System.Collections;

namespace Runner
{

    public class Player : MonoBehaviour
    {
        private void OnDisable()
        {
            GameManager.Instance.GameOver();
        }
       
    }
}