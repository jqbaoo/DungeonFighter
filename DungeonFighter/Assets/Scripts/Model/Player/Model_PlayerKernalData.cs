/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，玩家核心数据
 * 
 * Description:
 *      具体作用：提供玩家核心数据的存取数值
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Model
{
    public class Model_PlayerKernalData
    {
        public static event del_PlayerKernalModel event_PlayerKernal;       //事件：玩家的核心数值

        private float _floHealth;                                       //血条
        private float _floMagic;                                        //魔法
        private float _floAttack;                                       //攻击力
        private float _floDefence;                                      //防御力
        private float _floDexterity;                                    //敏捷

        private float _floMaxHealth;                                    //最大血条
        private float _floMaxMagic;                                     //最大魔法
        private float _floMaxAttack;                                    //最大攻击力
        private float _floMaxDenfence;                                  //最大防御力
        private float _floMaxDexterity;                                 //最大敏捷
        private float _floAttackByProp;                                 //武器攻击力
        private float _floDefenceByProp;                                //武器防御力
        private float _floDexterityByProp;                              //道具敏捷

        #region 属性
        public float Health
        {
            get { return _floHealth; }
            set
            {
                _floHealth = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Health", Health);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float Magic
        {
            get { return _floMagic; }
            set
            {
                _floMagic = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Magic", Magic);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float Attack
        {
            get { return _floAttack; }
            set
            {
                _floAttack = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Attack", Attack);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float Defence
        {
            get { return _floDefence; }
            set
            {
                _floDefence = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Defence", Defence);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float Dexterity
        {
            get { return _floDexterity; }
            set
            {
                _floDexterity = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Dexterity", Dexterity);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }

        public float MaxHealth
        {
            get { return _floMaxHealth; }
            set
            {
                _floMaxHealth = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("MaxHealth", MaxHealth);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float MaxMagic
        {
            get { return _floMaxMagic; }
            set
            {
                _floMaxMagic = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("MaxMagic", MaxMagic);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float MaxAttack
        {
            get { return _floMaxAttack; }
            set
            {
                _floMaxAttack = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("MaxAttack", MaxAttack);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float MaxDefence
        {
            get { return _floMaxDenfence; }
            set
            {
                _floMaxDenfence = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("MaxDefence", MaxDefence);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float MaxDexterity
        {
            get { return _floMaxDexterity; }
            set
            {
                _floMaxDexterity = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("MaxDexterity", MaxDexterity);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }

        public float AttackByProp
        {
            get { return _floAttackByProp; }
            set
            {
                _floAttackByProp = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("AttackByProp", AttackByProp);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float DefenceByProp
        {
            get { return _floDefenceByProp; }
            set
            {
                _floDefenceByProp = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("DefenceByProp", DefenceByProp);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        public float DexterityByProp
        {
            get { return _floDexterityByProp; }
            set
            {
                _floDexterityByProp = value;
                if (event_PlayerKernal != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("DexterityByProp", DexterityByProp);
                    event_PlayerKernal(tmp_KV);
                }
            }
        }
        #endregion

        //私有默认构造函数
        private Model_PlayerKernalData()
        {

        }

        public Model_PlayerKernalData(float _health, float _magic, float _attack, float _defence, float _dexterity,
            float _maxHealth, float _maxMagic, float _maxAttack, float _maxDefence, float _maxDexterity,
            float _attackByProp, float _defenceByProp, float _dexterityByProp)
        {
            this._floHealth = _health;
            this._floMagic = _magic;
            this._floAttack = _attack;
            this._floDefence = _defence;
            this._floDexterity = _dexterity;

            this._floMaxHealth = _maxHealth;
            this._floMaxMagic = _maxMagic;
            this._floMaxAttack = _maxAttack;
            this._floMaxDenfence = _maxDefence;
            this._floMaxDexterity = _maxDexterity;

            this._floAttackByProp = _attackByProp;
            this._floDefenceByProp = _defenceByProp;
            this._floDexterityByProp = _dexterityByProp;
        }
    }
}