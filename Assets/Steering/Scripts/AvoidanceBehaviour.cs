using UnityEngine;

namespace Steering
{
    [CreateAssetMenu(menuName = "Steering/Avoidance", fileName = "Avoidance")]
    public class AvoidanceBehaviour : SteeringBehaviour
    {
        [SerializeField, Min(1f)] private float viewDistance = 1f;
        [SerializeField, Range(.1f, .9f)] private float normalRatio = .35f;
        [SerializeField, Range(45f, 180f)] private float viewAngle = 45f;

        public override Vector3 Calculate(SteeringAgent _agent)
        {
            // May the force be with you.
            Vector3 force = _agent.CurrentForce;

            foreach(Vector3 direction in SteeringAgentHelper.DirectionsInCone(viewAngle, _agent.Forward))
            {
                // Shoot a ray from the boid in the calculated direction as far as the view distance
                if(Physics.Raycast(_agent.Position, direction, out RaycastHit hit, viewDistance))
                {
                    // Visual the collision
                    Debug.DrawLine(_agent.Position, hit.point, Color.red);

                    // Interpolate the normal by the forward over the normalRatio variable
                    force += Vector3.Lerp(_agent.Forward, hit.normal, normalRatio);
                }
            }

            // Use the force Luke - JaJa Bunks - The Sith Lad 20000AD
            return force;
        }
    }
}