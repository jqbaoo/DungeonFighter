/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，玩家核心数值代理类
 * 
 * Description:
 *      具体作用：
 *      1、简化数值开发，降低耦合，把数值的直接存取转换成使用该类操作
 *      2、带有构造函数的"单例"模式     
 * 
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Model_PlayerKernalDataProxy : Model_PlayerKernalData
    {
        private const int ENEMY_MIN_ATK = 1;                                        //敌人最低攻击力
        private static Model_PlayerKernalDataProxy _instance = null;
        public Model_PlayerKernalDataProxy(float _health, float _magic, float _attack, float _defence, float _dexterity,
            float _maxHealth, float _maxMagic, float _maxAttack, float _maxDefence, float _maxDexterity,
            float _attackByProp, float _defenceByProp, float _dexterityByProp)
            : base(_health, _magic, _attack, _defence, _dexterity,
            _maxHealth, _maxMagic, _maxAttack, _maxDefence, _maxDexterity,
            _attackByProp, _defenceByProp, _dexterityByProp)
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "/Model_PlayerKernalDataProxy()/构造函数不允许重复实例化");
            }
        }
        public static Model_PlayerKernalDataProxy GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                Debug.LogWarning("GetInstance()/需要先调用构造函数");
                return null;
            }
        }

        /// <summary>
        /// 显示所有原始数据
        /// </summary>
        public void DisplayAllOriginalValues()
        {
            base.Health = base.Health;
            base.Magic = base.Magic;
            base.Attack = base.Attack;
            base.Defence = base.Defence;
            base.Dexterity = base.Dexterity;

            base.MaxHealth = base.MaxHealth;
            base.MaxMagic = base.MaxMagic;
            base.MaxAttack = base.MaxAttack;
            base.MaxDefence = base.MaxDefence;
            base.MaxDexterity = base.MaxDexterity;

            base.AttackByProp = base.AttackByProp;
            base.DefenceByProp = base.DefenceByProp;
            base.DexterityByProp = base.DexterityByProp;
        }

        #region 生命数值操作 5个

        /// <summary>
        /// 减少血条数值(被攻击)
        /// 公式：_health = _health - (敌人攻击力-主角防御力-道具防御力)
        /// </summary>
        /// <param name="_enemyAttackValue">敌人攻击力</param>
        public void DecreaseHealthValues(float _enemyAttackValue)
        {
            float tmp_EnemyReallyATK = 0f;
            tmp_EnemyReallyATK = _enemyAttackValue - base.Defence - base.DefenceByProp;
            if (tmp_EnemyReallyATK > 0)
            {
                base.Health -= tmp_EnemyReallyATK;
            }
            else
            {
                base.Health -= ENEMY_MIN_ATK;
            }
            base.Health = base.Health >= 0 ? base.Health : 0;

            //更新攻击力、防御力、敏捷度
            UpdateATKValue();
            UpdateDEFValue();
            UpdateDEXValue();
        }

        /// <summary>
        /// 增加血条数值(吃血)
        /// </summary>
        /// <param name="_healthValue">增量</param>
        public void IncreaseHealthValues(float _healthValue)
        {
            float tmp_ReallyIncreaseHealthValues = 0f;                      //真实增加量
            tmp_ReallyIncreaseHealthValues = base.Health + _healthValue;
            //防止突破血条上限
            if (tmp_ReallyIncreaseHealthValues < base.MaxHealth)
            {
                base.Health += _healthValue;
            }
            else
            {
                base.Health = base.MaxHealth;
            }

            //更新攻击力、防御力、敏捷度
            UpdateATKValue();
            UpdateDEFValue();
            UpdateDEXValue();
        }

        /// <summary>
        /// 得到当前血条数值
        /// </summary>
        /// <param name="_healthValue"></param>
        /// <returns></returns>
        public float GetCurrentHealth()
        {
            return base.Health;
        }

        /// <summary>
        /// 增加最大血条上限(升级)
        /// </summary>
        /// <param name="_increaseHealth"></param>
        public void IncreaseMaxHealth(float _increaseHealth)
        {
            base.MaxHealth += Mathf.Abs(_increaseHealth);
        }

        /// <summary>
        /// 得到最大血条上限
        /// </summary>
        /// <returns></returns>
        public float GetMaxHealth()
        {
            return base.MaxHealth;
        }

        #endregion

        #region 魔法数值操作 5个
        /// <summary>
        /// 减少魔法数值(使用魔法)
        /// 公式：_maigc = _maigc - (技能所需损耗)
        /// </summary>
        /// <param name="_magicValue">魔法损耗</param>
        public void DecreaseMagicValues(float _magicValue)
        {
            float tmp_ReallyMagicValuesResult = 0;                                  //实际剩余魔法
            tmp_ReallyMagicValuesResult = base.Magic - Mathf.Abs(_magicValue);
            if (tmp_ReallyMagicValuesResult>0)
            {
                base.Magic -= Mathf.Abs(_magicValue);
            }
            else
            {
                base.Magic = 0;
            }
        }

        /// <summary>
        /// 增加魔法数值(吃蓝)
        /// </summary>
        /// <param name="_magicValue"></param>
        public void IncreaseMagicValues(float _magicValue)
        {
            float tmp_ReallyIncreaseMagicValues = 0f;                      //真实增加量
            tmp_ReallyIncreaseMagicValues = base.Magic + _magicValue;
            //防止突破魔法上限
            if (tmp_ReallyIncreaseMagicValues < base.MaxMagic)
            {
                base.Magic += _magicValue;
                Debug.Log("false" + base.Magic);
            }
            else
            {
                base.Magic = base.MaxMagic;
                Debug.Log("true" + base.Magic);

            }
        }

        /// <summary>
        /// 得到当前魔法数值
        /// </summary>
        /// <param name="_healthValue"></param>
        /// <returns></returns>
        public float GetCurrentMagic()
        {
            return base.Magic;
        }

        /// <summary>
        /// 增加最大魔法上限(升级)
        /// </summary>
        /// <param name="_increaseMagic"></param>
        public void IncreaseMaxMagic(float _increaseMagic)
        {
            base.MaxMagic += Mathf.Abs(_increaseMagic);
        }

        /// <summary>
        /// 得到最大魔法上限
        /// </summary>
        /// <returns></returns>
        public float GetMaxMagic()
        {
            return base.MaxMagic;
        }
        #endregion

        #region 攻击力数值操作 4个
        
        /// <summary>
        /// 更新攻击力(更换武器)
        /// 公式：_attack = _maxAttack/2 * (_healthValue/_maxHealth) + _newWeaponValue
        /// </summary>
        /// <param name="_healthValue">血量数值</param>
        /// <param name="_newWeaponATKValue">新武器数值</param>
        public void UpdateATKValue(float _newWeaponATKValue = 0)
        {
            float tmp_ReallyATKValue = 0f;                                      //实际攻击力
            //没有得到新的武器道具
            if (_newWeaponATKValue == 0)
            {
                //tmp_ReallyATKValue = base.MaxAttack / 2 * (base.Health / base.MaxHealth) + base.AttackByProp;
                tmp_ReallyATKValue = base.MaxAttack / 2 + base.AttackByProp;

            }
            //得到了武器道具
            else if (_newWeaponATKValue > 0)
            {
                //tmp_ReallyATKValue = base.MaxAttack / 2 * (base.Health / base.MaxHealth) + _newWeaponATKValue;
                tmp_ReallyATKValue = base.MaxAttack / 2 + _newWeaponATKValue;

                base.AttackByProp = _newWeaponATKValue;
            }
            if (tmp_ReallyATKValue > base.MaxAttack)
            {
                base.Attack = base.MaxAttack;
            } 
            else
            {
                base.Attack = tmp_ReallyATKValue;
            }
        }
        /// <summary>
        /// 得到当前攻击力
        /// </summary>
        /// <returns></returns>
        public float GetCurrentATK()
        {
            return base.Attack;
        }
        /// <summary>
        /// 增加最大攻击力(升级)
        /// </summary>
        /// <param name="_increaseATK">增加攻击力的增量数值</param>
        public void IncreaseMaxATK(float _increaseATK)
        {
            base.MaxAttack += Mathf.Abs(_increaseATK);
        }
        /// <summary>
        /// 得到最大的攻击力
        /// </summary>
        /// <returns></returns>
        public float GetMaxATK()
        {
            return base.MaxAttack;
        }
        #endregion

        #region 防御力数值操作 4个
        /// <summary>
        /// 更新防御力(更换武器)
        /// 公式：_defence = _maxDefence/2 * (_healthValue/_maxHealth) + _newWeaponDEFValue
        /// </summary>
        /// <param name="_healthValue">当前血量</param>
        /// <param name="_newWeaponDEFValue">新武器防御数值</param>
        public void UpdateDEFValue(float _newWeaponDEFValue = 0)
        {
            float tmp_ReallyDEFValue = 0f;                                      //实际防御力
            //没有得到新的武器道具
            if (_newWeaponDEFValue == 0)
            {
                //tmp_ReallyDEFValue = base.MaxDefence / 2 * (base.Health / base.MaxHealth) + base.DefenceByProp;
                tmp_ReallyDEFValue = base.MaxDefence / 2  + base.DefenceByProp;

            }
            //得到了武器道具
            else if (_newWeaponDEFValue > 0)
            {
                //tmp_ReallyDEFValue = base.MaxDefence / 2 * (base.Health / base.MaxHealth) + _newWeaponDEFValue;
                tmp_ReallyDEFValue = base.MaxDefence / 2 + _newWeaponDEFValue;

                base.DefenceByProp = _newWeaponDEFValue;
            }
            if (tmp_ReallyDEFValue > base.MaxDefence)
            {
                base.Defence = base.MaxDefence;
            }
            else
            {
                base.Defence = tmp_ReallyDEFValue;
            }
        }
        /// <summary>
        /// 得到当前防御力
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEF()
        {
            return base.Defence;
        }
        /// <summary>
        /// 增加最大防御力(升级)
        /// </summary>
        /// <param name="_increaseATK">增加攻击力的增量数值</param>
        public void IncreaseMaxDEF(float _increaseDEF)
        {
            base.MaxDefence += Mathf.Abs(_increaseDEF);
        }
        /// <summary>
        /// 得到最大的防御力
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEF()
        {
            return base.MaxDefence;
        }
        #endregion

        #region 敏捷数值操作 4个
        /// <summary>
        /// 更新敏捷度(更换武器)
        /// 公式：_MoveSpeed = MaxMoveSpeed/2*(_Health/MaxHealth)-_Defence+[道具敏捷力]  
        /// </summary>
        /// <param name="_healthValue">血量数值</param>
        /// <param name="_newWeaponDEXValue">新武器数值</param>
        public void UpdateDEXValue(float _newWeaponDEXValue = 0)
        {
            float tmp_ReallyDEXValue = 0f;                                      //实际敏捷度
            //没有得到新的武器道具
            if (_newWeaponDEXValue == 0)
            {
                //tmp_ReallyDEXValue = base.MaxDexterity / 2 * (base.Health / base.MaxHealth) - base.Defence + base.DexterityByProp;
                tmp_ReallyDEXValue = base.MaxDexterity / 2 - base.Defence + base.DexterityByProp;

            }
            //得到了武器道具
            else if (_newWeaponDEXValue > 0)
            {
                //tmp_ReallyDEXValue = base.MaxDexterity / 2 * (base.Health / base.MaxHealth) + _newWeaponDEXValue;
                tmp_ReallyDEXValue = base.MaxDexterity / 2 + _newWeaponDEXValue;

                base.DexterityByProp = _newWeaponDEXValue;
            }
            if (tmp_ReallyDEXValue > base.MaxDexterity)
            {
                base.Dexterity = base.MaxDexterity;
            }
            else
            {
                base.Dexterity = tmp_ReallyDEXValue;
            }
        }
        /// <summary>
        /// 得到当前敏捷度
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEX()
        {
            return base.Dexterity;
        }
        /// <summary>
        /// 增加最大敏捷度(升级)
        /// </summary>
        /// <param name="_increaseATK">增加敏捷度的增量数值</param>
        public void IncreaseMaxDEX(float _increaseDEX)
        {
            base.MaxDexterity += Mathf.Abs(_increaseDEX);
        }
        /// <summary>
        /// 得到最大的敏捷度
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEX()
        {
            return base.MaxDexterity;
        }
        #endregion
    }
}