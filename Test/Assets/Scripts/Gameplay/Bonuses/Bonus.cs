using UnityEngine;
using System.Collections;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Weapons;

namespace Gameplay.Bonus
{

    public abstract class Bonus : MonoBehaviour
    {
        [SerializeField]
        protected MovementSystem _movementSystem;

        public void Update()
        {
            _movementSystem.LongitudinalMovement(Time.deltaTime);
        }
        /// <summary>
        /// Метод который реализует какой-то бонус
        /// </summary>
        /// <param name="player">Игрок который получит бонус</param>
        protected virtual void Apply(Spaceship player) { }
        
        /// <summary>
        /// При столкновении проверяем наличие IDamagable  и что это не враг.
        /// Потом если есть компонент корабля, то дадим ему бонус.
        /// </summary>
        /// <param name="other"></param>
        protected void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();

            if (damagableObject != null && damagableObject.BattleIdentity == UnitBattleIdentity.Ally)
            {
                if (other.gameObject.GetComponent<Spaceship>() != null)
                    Apply(other.gameObject.GetComponent<Spaceship>());
                Destroy(gameObject);
            }
        }
    }
}
