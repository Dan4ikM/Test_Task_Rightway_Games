using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Data;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private ShipData _shipData;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        /// <summary>
        /// События на смерть корабля, на изменения жизней и изменения кулдауна.
        /// </summary>
        public event Action<int, Transform> OnDie;
        public event Action<int> OnChangeHealth;
        public event Action<List<Weapon>> OnChangeCooldown;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            //Получаем урон
            ApplyHealth(-(int)damageDealer.Damage);

            if (_shipData.Health <= 0)
            {
                OnDie?.Invoke(_shipData.Points, transform);
                Destroy(gameObject);
            }
        }
        /// <summary>
        /// Метод получения урона
        /// </summary>
        /// <param name="addingHealth"></param>
        public void ApplyHealth(int addingHealth)
        {
            _shipData.Health += addingHealth;
            OnChangeHealth?.Invoke(_shipData.Health);
        }
        /// <summary>
        /// Запускает корутину временного бонуса кулдауна
        /// </summary>
        /// <param name="multiplyer"></param>
        /// <param name="time"></param>
        public void StartFireRateBonus(float multiplyer, float time)
        {
            StartCoroutine(FireRateBonus(multiplyer, time));
        }

        /// <summary>
        /// Корутина бонуса кулдауна 
        /// </summary>
        /// <param name="multiplyer"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerator FireRateBonus(float multiplyer, float time)
        {
            _weaponSystem.AllChangeCooldown(multiplyer);
            OnChangeCooldown?.Invoke(GetWeaponsCooldown());
            yield return new WaitForSeconds(time);
            _weaponSystem.AllChangeCooldown(1f / multiplyer);
            OnChangeCooldown?.Invoke(GetWeaponsCooldown());
        }
        /// <summary>
        /// Словарь для получения имён оружий и кулдаунов, который можно заменить списком
        /// </summary>
        /// <returns></returns>
        public List<Weapon> GetWeaponsCooldown()
        {
            return _weaponSystem._weapons;
        }
    }
}
