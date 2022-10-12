using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RiseState))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Hero _target;
    private RiseState _rise;

    public Hero Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Died;

    private void Awake()
    {
        _rise = GetComponent<RiseState>();
    }

    public void Init(Hero target)
    {
        _target = target;
    }

    public void TakeDamage(int damge)
    {
        if (!_rise.enabled)
        {
            _health -= damge;

            if (_health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke(this);
    }
}
