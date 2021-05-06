using UnityEngine;

using System;
using System.Collections.Generic;

namespace Steering
{
    [CreateAssetMenu(menuName = "Steering/Composite", fileName = "Composite", order = -100)]
    public class CompositeBehaviour : SteeringBehaviour
    {
        [Serializable]
        public struct WeightedBehaviour
        {
            public float weighting;
            public SteeringBehaviour behaviour;
        }

        [SerializeField] private List<WeightedBehaviour> behaviours = new List<WeightedBehaviour>();

        public override Vector3 Calculate(SteeringAgent _agent)
        {
            Vector3 force = _agent.CurrentForce;

            behaviours.ForEach(weighted => force += weighted.behaviour.Calculate(_agent) * weighted.weighting);

            return force;
        }
    }
}