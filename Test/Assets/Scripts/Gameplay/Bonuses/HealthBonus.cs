using UnityEngine;
using System.Collections;
using Gameplay.Spaceships;

namespace Gameplay.Bonus
{
    public class HealthBonus : Bonus
    {
        [SerializeField]
        private int addingHealth = 1;
        /// <summary>
        /// Добавим жизни кораблю
        /// </summary>
        /// <param name="player"></param>
        protected override void Apply(Spaceship player)
        {
            player.ApplyHealth(addingHealth);
        }
    }
}
