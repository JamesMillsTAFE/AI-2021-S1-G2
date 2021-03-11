using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Wander,
    Target,
    Attack,
    Damage,
    Die,
    MAX_VALUE
}

public class CustomStateMachine : MonoBehaviour
{
    [SerializeField]
    private State initialState;
    
    private Dictionary<State, string> stateCoroutines = new Dictionary<State, string>();

    private Coroutine currentCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        FillDictionary();

        SwapState(initialState);
    }

    private void FillDictionary()
    {
        int maxValue = (int)State.MAX_VALUE;

        for (int i = 0; i < maxValue; i++)
        {
            // Convert the iterator into a state
            State state = (State)i;

            // Generate the coroutine string from the state
            string functionName = state.ToString() + "State";

            // Add them to the dictionary
            stateCoroutines.Add(state, functionName);

            // Log the new name and value
            Debug.Log(state.ToString() + ", " + functionName);
        }
    }

    public void SwapState(State _newState)
    {
        // Is there a coroutine currently running?
        if(currentCoroutine != null)
        {
            // There is, so we need to stop it
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }

        // Attempts to start the passed coroutine and cache it so that we know which one is running
        currentCoroutine = StartCoroutine(stateCoroutines[_newState]);
    }

    private IEnumerator WanderState()
    {
        Debug.Log("I am at the start of the Coroutine!");

        yield return new WaitForSeconds(3);

        Debug.Log("I am after the 3 second delay of the Coroutine!");
    }

    private IEnumerator TargetState()
    {
        Debug.Log("I am at the start of the Coroutine!");

        yield return new WaitForSeconds(3);

        Debug.Log("I am after the 3 second delay of the Coroutine!");
    }

    private IEnumerator AttackState()
    {
        Debug.Log("I am at the start of the Coroutine!");

        yield return new WaitForSeconds(3);

        Debug.Log("I am after the 3 second delay of the Coroutine!");
    }

    private IEnumerator DamageState()
    {
        Debug.Log("I am at the start of the Coroutine!");

        yield return new WaitForSeconds(3);

        Debug.Log("I am after the 3 second delay of the Coroutine!");
    }

    private IEnumerator DieState()
    {
        Debug.Log("I am at the start of the Coroutine!");

        yield return new WaitForSeconds(3);

        Debug.Log("I am after the 3 second delay of the Coroutine!");
    }
}
