using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderStateUnity : StateMachineBehaviour
{
    // Runs the first update frame that we are in this state
    // Similar to MonoBehaviour's Start function
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
    {
        base.OnStateEnter(_animator, _stateInfo, _layerIndex);

        Debug.Log("Yo wassup homies!");
    }

    // Runs every update frame that we are in this state, except the first and last ones
    // Similar to MonoBehaviour's Update Function
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
    {
        base.OnStateUpdate(_animator, _stateInfo, _layerIndex);
    }

    // Runs the last update frame that we are in this state
    // Similar to MonoBehaviour's OnDestroy function
    public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
    {
        base.OnStateExit(_animator, _stateInfo, _layerIndex);

        _animator.SetTrigger("Target");
    }
}
