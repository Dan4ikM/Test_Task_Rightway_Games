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
        public void UpdateFireRate(Dictionary<Weapon, float> weaponsCooldown)
        {
            int i = 0;
            foreach (KeyValuePair<Weapon, float> w in weaponsCooldown)
            {
                fireRateUIs[i].UpdateText(w.Value, w.Key.name);
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
