using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spawners;
using Gameplay.Data;
using Gameplay.ShipUI;
using Gameplay.Spaceships;
using Gameplay.Weapons;

namespace Gameplay
{
    /// <summary>
    /// Игровой менеджер, который отвечает за запуск игры - является сингтоном
    /// 
    /// В него добавлено много UI компонентов, которые можно вынести в один класс.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PointsView _pointsView;

        [SerializeField] private HealthUI _healthUI;

        [SerializeField] private FireRateUI[] _weaponsUI;

        [SerializeField] private Spawner[] spawners;

        [SerializeField] private WeaponsUI weaponsUI;

        [SerializeField] private BonusSpawner bonusSpawner;

        [SerializeField] private float bonusDropChance = 0.1f;

        [SerializeField] private Spaceship player;

        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        private void Start()
        {
            PlayerSetup();

            EnableSpawners();
        }

        private void PlayerSetup()
        {
            foreach (Weapon weapon in player.GetWeaponsCooldown())
            {
                weaponsUI.AddNewFireRateUI(weapon.name, weapon.Cooldown);
            }

            player.OnDie += PlayerDeath;
            player.OnChangeHealth += _healthUI.UpdateText;
            player.OnChangeCooldown += weaponsUI.UpdateFireRate;

            player.ApplyHealth(0);
            UpdatePoints(0);
        }

        private void EnableSpawners()
        {
            foreach (Spawner spawner in spawners)
            {
                spawner.StartSpawn();
            }
        }
        /// <summary>
        /// Метод, вызываемый при смерти противника
        /// Увеличивает количество очков и может заспавнить бонус на нём
        /// </summary>
        /// <param name="addingPoints"></param>
        /// <param name="enemyTransform"></param>
        public void EnemyDie(int addingPoints, Transform enemyTransform)
        {
            UpdatePoints(addingPoints);
            if(Random.Range(0f,1f) <= bonusDropChance)
                bonusSpawner?.SpawnRandomBonus(enemyTransform);
        }
        /// <summary>
        /// Метод обновляющий число очков у игрока
        /// </summary>
        /// <param name="addingPoints"></param>
        public void UpdatePoints(int addingPoints)
        {
            player.gameObject.GetComponent<ShipData>().Points += addingPoints;
            _pointsView.UpdateText(player.gameObject.GetComponent<ShipData>().Points);
        }
        /// <summary>
        /// Метод вызываемый со смертью игрока
        /// Из него как раз можно вызвать окно поражения с количеством очков и возможностью запустить игру заново
        /// Так же если в игре есть возможность вокреситься с того же места, например за просмотр рекламы,
        /// то у нас есть позиция игрока, хотя так же не обязательно его уничтожать, 
        /// а можно просто класть в пулл объектов типа игрок и по трансформу включать обратно.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="playerTranstorm"></param>
        public void PlayerDeath(int points, Transform playerTranstorm)
        {
            weaponsUI.ClearAllWeapons();
            //Show points menu
            //Transform could be help to player resurrection
            foreach (Spawner spawner in spawners)
            {
                spawner.StopSpawn();
            }
        }

    }
}
