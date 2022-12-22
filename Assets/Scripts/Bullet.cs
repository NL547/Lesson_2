using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        public float StartTime;
        public float EndTime;
        private GameObject _enemy;
        public void SetEnemy(GameObject enemy)
        {
            _enemy = enemy;
        }
        
        
        void FixedUpdate()
        {
            if (_enemy != null)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _enemy.transform.position, 10 * Time.deltaTime);
                StartTime += 0.1f * Time.deltaTime;
                if (StartTime >= EndTime)
                {
                    Destroy(gameObject);
                }
            }
        }       
    }
}