using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> BuyButtonClicked;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
        _buyButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
        _buyButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }    

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
        {
            _buyButton.interactable = false;
        }
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClicked?.Invoke(_weapon, this);
    }
}
