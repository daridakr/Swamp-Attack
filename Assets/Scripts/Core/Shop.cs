using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Hero _purchaser;
    [SerializeField] private WeaponView _itemViewPrefab;
    [SerializeField] private GameObject _itemsContainer;
    [SerializeField] private TMP_Text _moneyDisplay;

    private void Start()
    {
        _moneyDisplay.text = _purchaser.Money.ToString();

        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        WeaponView view = Instantiate(_itemViewPrefab, _itemsContainer.transform);
        view.BuyButtonClicked += OnBuyButtonClicked;
        view.Render(weapon);
    }

    private void OnBuyButtonClicked(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (weapon.Price <= _purchaser.Money)
        {
            _purchaser.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.BuyButtonClicked -= OnBuyButtonClicked;
        }
    }
}
