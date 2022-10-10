using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shotPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private int _money;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shotPoint);
        }
    }

    public void OnEnemyKilled(int reward)
    {
        _money += reward;
    }
}
