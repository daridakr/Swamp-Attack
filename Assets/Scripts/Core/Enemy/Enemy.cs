using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    // Temporal.
    [SerializeField] private Hero _target;

    public Hero Target => _target;

    public event UnityAction Died;

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
        Died?.Invoke();
    }
}
