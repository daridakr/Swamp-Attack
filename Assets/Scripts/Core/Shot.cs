using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }
}
