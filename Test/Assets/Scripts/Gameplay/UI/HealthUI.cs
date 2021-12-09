using UnityEngine;
using TMPro;
using System.Collections;

namespace Gameplay.ShipUI
{
    /// <summary>
    /// Класс отображения здоровья корабля
    /// </summary>
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;

        public void UpdateText(int health)
            => _healthText.text = $"Health:{health}";
        
    }
}
