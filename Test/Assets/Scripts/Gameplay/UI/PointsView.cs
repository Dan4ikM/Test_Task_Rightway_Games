using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay.ShipUI
{
    /// <summary>
    /// Класс для отображения количества очков игрока
    /// </summary>
    public class PointsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pointsText;

        public void UpdateText(int points)
            => _pointsText.text = $"Points:{points}";
    }
}
