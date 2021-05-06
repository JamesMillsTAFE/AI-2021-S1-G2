using UnityEngine;

namespace Steering
{
    [CreateAssetMenu(menuName = "Steering/Wander", fileName = "Wander")]
    public class WanderBehaviour : SteeringBehaviour
    {
        [SerializeField, Range(.01f, .1f)] private float jitter = .05f;

        public override Vector3 Calculate(SteeringAgent _agent)
        {
            // I have the high ground.
            Vector3 force = _agent.CurrentForce;

            // You were supposed to be the chosen one!
            Vector2 offset = new Vector2(Random.Range(-jitter, jitter), Random.Range(-jitter, jitter));

            // You were supposed to destroy the sith not join them.
            force += _agent.Right * offset.x;
            force += _agent.Up * offset.y;

            // May the force be with you.
            // ANAKIN NOOOOOOO....
            return force;
        }
    }
}