using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Hero _target;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;

        SetState(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }
        
        var nextState = _currentState.GetNext();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        SetState(nextState);
    }

    private void SetState(State state)
    {
        _currentState = state;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
