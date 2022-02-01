using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {
        public List<Weapon> _weapons;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
            object obj = new object();
        }

        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        /// <summary>
        /// Домножает параметр кулдауна каждому орудию
        /// </summary>
        /// <param name="multiplyer"></param>
        public void AllChangeCooldown(float multiplyer)
        {
            _weapons.ForEach(w => w.ChangeCooldown(multiplyer));
        }
    }
}
