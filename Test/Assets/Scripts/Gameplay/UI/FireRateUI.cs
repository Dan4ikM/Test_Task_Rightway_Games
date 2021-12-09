using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay.ShipUI
{
/// <summary>
/// Класс отображения скорострельности корабля
/// </summary>
    public class FireRateUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fireRateText;

        public void UpdateText(float cooldown, string weaponName)
            => _fireRateText.text = $"{weaponName} fire rate:{60f/cooldown} shoots per seconds";
    }
}
