using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ShipUI;
using Gameplay.Weapons;

namespace Gameplay.ShipUI
{
    /// <summary>
    /// Класс для отображения скорострельности каждого оружия
    /// </summary>
    public class WeaponsUI : MonoBehaviour
    {
        [SerializeField] private FireRateUI prefab;

        [SerializeField] private Transform prefabsParent;

        private List<FireRateUI> fireRateUIs = new List<FireRateUI>();

        /// <summary>
        /// Метод для добавления нового оружия
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="cooldown"></param>
        public void AddNewFireRateUI(string weaponName, float cooldown)
        {
            FireRateUI fireRateUI = Instantiate(prefab, prefabsParent);
            fireRateUI.UpdateText(cooldown, weaponName);
            fireRateUIs.Add(fireRateUI);
        }

        /// <summary>
        /// Метод для обновления значений скорострельности у каждого оружия
        /// </summary>
        /// <param name="weaponsCooldown"></param>
        public void UpdateFireRate(List<Weapon> weapons)
        {
            int i = 0;
            foreach (var weapon in weapons)
            {
                fireRateUIs[i].UpdateText(weapon.Cooldown, weapon.name);
                ++i;
            }
        }
        /// <summary>
        /// Метод очистки UI всех орудий
        /// </summary>
        public void ClearAllWeapons()
        {
            for (int i = 0; i < fireRateUIs.Count; i++)
            {
                Destroy(fireRateUIs[i].gameObject);
            }
            fireRateUIs.Clear();
        }
    }
}
