using System;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {

        [SerializeField]
        private float _speed;

        [SerializeField] 
        private float _damage;


        private UnitBattleIdentity _battleIdentity;


        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;

        

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        

        private void Update()
        {
            Move(_speed);
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.ToString());
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            Debug.Log($"{damagableObject.BattleIdentity} {BattleIdentity}");
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                Debug.Log("Damage object!");
                damagableObject.ApplyDamage(this);
            }
        }
        


        protected abstract void Move(float speed);
    }
}
