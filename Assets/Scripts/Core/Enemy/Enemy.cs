using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Hero _target;

    public Hero Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Died;

    public void Init(Hero target)
    {
        _target = target;
    }

    public void TakeDamage(int damge)
    {
        _health -= damge;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke(this);
    }
}
