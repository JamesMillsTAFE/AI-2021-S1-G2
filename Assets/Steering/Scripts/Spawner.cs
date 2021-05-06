using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SteeringAgent prefab;
        [SerializeField, Min(1f)] private float spawnRadius = 10f;
        [SerializeField, Range(10, 500)] private int spawnCount = 10;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            for(int i = 0; i < spawnCount; i++)
            {
                Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
                SteeringAgent boid = Instantiate(prefab);
                boid.transform.position = pos;
                boid.transform.forward = Random.insideUnitSphere.normalized;

                boid.SetColor(Random.ColorHSV(0, 1, 1, 1, 1, 1));
            }
        }

        // Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, .3f);
            Gizmos.DrawSphere(transform.position, spawnRadius);
        }
    }
}