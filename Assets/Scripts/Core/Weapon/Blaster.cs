using UnityEngine;

public class Blaster : Weapon
{
    public override void Shoot(Transform shotPoint)
    {
        Instantiate(Shot, shotPoint.position, Quaternion.identity);
    }
}
