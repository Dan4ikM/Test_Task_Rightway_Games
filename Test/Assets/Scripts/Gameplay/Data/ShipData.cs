using UnityEngine;
using System.Collections;

namespace Gameplay.Data
{
    /// <summary>
    /// Хранит данные корабля, незнаю стоит ли сюда прокидывать cooldown орудий
    /// </summary>
    public class ShipData : MonoBehaviour
    {
        [SerializeField]
        private int _points;

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        [SerializeField]
        private int _health;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
}
