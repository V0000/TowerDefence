﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Health
{
    public class HealthController : MonoBehaviour
    {
        private float maxHealth;
        private float currentHealth;
        private float armor;
        private float goldForDeath;
        private float xpForDeath;
		private GameObject deadUnit;

		void OnDestroy()
        {
            GameObject spawnedUnit = Instantiate(healthController.deadUnit);
            //spawnedUnit.transform.parent = parent.transform;
            spawnedUnit.transform.localPosition = transform.localPosition;
        }
		
        #region Setters and getters


        public float MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                if (value > 0)
                {
                    maxHealth = value;
                }
            }
        }

        public float Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value > 0 && value < 1)
                {
                    armor = value;
                }
            }
        }


        public float Health
        {
            get
            {
                return currentHealth;
            }
            set
            {
                if (value > 0)
                {
                    currentHealth = value;
                }
            }

        }

        public float Gold
        {
            get
            {
                return goldForDeath;
            }
            set
            {
                if (value > 0)
                {
                    goldForDeath = value;
                }
            }
        }

        public float Hp
        {
            get
            {
                return xpForDeath;
            }
            set
            {
                if (value > 0)
                {
                    xpForDeath = value;
                }
            }
        }
		
		public float DeadUser
        {
            get
            {
                return deadUnit;
            }
            set
            {
                deadUnit = value;
            }
        }
        #endregion


        public void TakeDamage(float damage)
        {
            if (damage <= 0)
            {
                return;
            }
            currentHealth -= damage;
        }

        /// <summary>
        /// If this instance is at max health.
        /// </summary>
        public bool isAtMaxHealth
        {
            get { return Mathf.Approximately(currentHealth, maxHealth); }
        }

        protected void AddHealth(float healthIncrement)
        {
            if (healthIncrement <= 0)
            {
                return;
            }
            if (currentHealth + healthIncrement > maxHealth)
            {
                currentHealth = maxHealth;
            }
            currentHealth += healthIncrement;
        }

        public bool IsDead
        {
            get { return currentHealth <= 0f; }
        }
		
		void CheckDeath()
        {
            if (IsDead)
            {
                ObjectRegistry.RemoveUnit(gameObject, isEnemy);
				Destroy(gameObject);
            }
        }
    }
}
