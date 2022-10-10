using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _distance;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _distance += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _distance)
        {
            NeedTransit = true;
        }
    }
}
