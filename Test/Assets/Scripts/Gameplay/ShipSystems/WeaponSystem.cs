using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
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
        /// <summary>
        /// Берёт словарь орудия и кудлауна, 
        /// хотя тогда зачем мне словарь если бы простого списка хватило бы...
        /// </summary>
        /// <returns></returns>
        public Dictionary<Weapon, float> GetWeaponsCooldown(){
            Dictionary<Weapon, float> weaponsCooldown = new Dictionary<Weapon, float>();
            _weapons.ForEach(w => weaponsCooldown.Add(w, w.Cooldown));
            return weaponsCooldown;
        }
    }
}
