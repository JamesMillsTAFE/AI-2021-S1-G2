using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachines
{
    public enum States
    {
        Translate,
        Rotate,
        Scale
    }

    // The delegate dictates what the functions for each state will look like.
    public delegate void StateDelegate();

    public class StateMachine : MonoBehaviour
    {
        // How we reference each State's node.
        private Dictionary<States, StateDelegate> states = new Dictionary<States, StateDelegate>();

        [SerializeField] private States currentState = States.Translate;
        [SerializeField] private Transform controlled; // The thing that will be affected by our statemachine
        [SerializeField] private float speed = 1f; // Just for testing the statemachine

        public void ChangeState(States _newState)
        {
            if(currentState != _newState)
                currentState = _newState;
        }

        // Start is called before the first frame update
        void Start()
        {
            // null-coalescing assignment operator - this checks if the left-hand side is null
            // if it is, it will assign it to the right value, otherwise retain it's current value
            controlled ??= transform;

            // Challenge starts here
            states.Add(States.Translate, Translate);
            states.Add(States.Rotate, Rotate);
            states.Add(States.Scale, Scale);
        }

        // Update is called once per frame
        void Update()
        {
            // These two lines are what actually runs the state machine.
            // It works by attempting to retrieve the relevant function for the current state,
            // then running the function if it successfully found it.
            if (states.TryGetValue(currentState, out StateDelegate state))
                state.Invoke();
            else
                Debug.LogError($"No state function set for state {currentState}.");
        }

        // the functions that will run for each state. This is the translate state function
        private void Translate() => controlled.position += controlled.forward * Time.deltaTime * speed;
        private void Rotate() => controlled.Rotate(Vector3.up, speed * .5f);
        private void Scale() => controlled.localScale += Vector3.one * Time.deltaTime * speed;
    }
}