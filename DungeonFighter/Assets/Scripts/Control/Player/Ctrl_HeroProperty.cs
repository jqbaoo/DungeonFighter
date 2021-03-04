/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，英雄属性脚本
 * 
 * Description:
 *      具体作用：
 *      1、实例化并初始化对应模型层的数据。
 *      2、整合模型层关于"玩家"模块的核心方法，供控制层的其他脚本调用
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
using Model;

namespace Control
{
    public class Ctrl_HeroProperty : BaseControl
    {
        public static Ctrl_HeroProperty Instance;   

        /* 核心数值 */
        public float floPlayerCurrentHP = 100;                                          //当前生命值
        public float floPlayerMaxHP = 100;                                              //最大生命值
        public float floPlayerCurrentMP = 100;                                          //当前魔法值
        public float floPlayerMaxMP = 100;                                              //最大魔法值
        public float floPlayerCurrentATK = 10;                                          //攻击力
        public float floPlayerMaxATK = 10;                                              //最大攻击力
        public float floPlayerCurrentDEF = 5;                                           //防御力
        public float floPlayerMaxDEF = 5;                                               //最大防御力
        public float floPlayerCurrentDEX = 45;                                          //敏捷
        public float floPlayerMaxDEX = 50;                                              //最大敏捷
        public float floATKByProp = 0;                                                  //道具攻击力
        public float floDEFByProp = 0;                                                  //道具防御力
        public float floDEXByProp = 0;                                                  //道具敏捷度

        /* 扩展数值 */
        public int intEXP = 0;                                                          //经验值
        public int intLevel = 1;                                                        //等级
        public int intKillNumber = 0;                                                   //杀敌数 
        public int intGold = 0;                                                         //金币
        public int intDiamond = 0;                                                      //钻石

        /* 玩家背包数值 */
        public int intBloodBottleNum = 0;                                               //血瓶数量
        public int intMagicBottleNum = 0;                                               //蓝瓶数量
        public int intATKNum = 0;                                                       //攻击力数量
        public int intDEFNum = 0;                                                       //防御力数量
        public int intDEXNum = 0;                                                       //敏捷度道具

        public AudioClip ac_PlayerLevelUp;                                              //升级音效单次开关，防止开始没升级就有音效
        void OnEnable()
        {
            Model_PlayerExtenalData.event_PlayerExtenalData += LevelUp;
        }

        void OnDisable()
        {
            Model_PlayerExtenalData.event_PlayerExtenalData -= LevelUp;
        }
        void LevelUp(KeyValueUpdate _kv)
        {
            base.LevelUp(_kv, ac_PlayerLevelUp);
        }
        void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            Model_PlayerKernalDataProxy tmp_PlayerKernalDataProxy = new Model_PlayerKernalDataProxy(floPlayerCurrentHP, floPlayerCurrentMP, floPlayerCurrentATK, floPlayerCurrentDEF, floPlayerCurrentDEX, floPlayerMaxHP, floPlayerMaxMP, floPlayerMaxATK, floPlayerMaxDEF, floPlayerMaxDEX, floATKByProp, floDEFByProp, floDEXByProp);            

            Model_PlayerExtenalDataProxy tmp_PlayerExtenalDataProxy = new Model_PlayerExtenalDataProxy(intEXP, intKillNumber, intLevel, intGold, intDiamond);

            Model_PlayerPackageDataProxy tmp_PlayerPackageDataProx = new Model_PlayerPackageDataProxy(intBloodBottleNum, intMagicBottleNum, intATKNum, intDEFNum, intDEXNum);
        }

        #region 生命数值操作 5个

        /// <summary>
        /// 减少血条数值(被攻击)
        /// 公式：_health = _health - (敌人攻击力-主角防御力-道具防御力)
        /// </summary>
        /// <param name="_enemyAttackValue">敌人攻击力</param>
        public void DecreaseHealthValues(float _enemyAttackValue)
        {
            if (_enemyAttackValue > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().DecreaseHealthValues(_enemyAttackValue);
            }
        }

        /// <summary>
        /// 增加血条数值(吃血)
        /// </summary>
        /// <param name="_healthValue">增量</param>
        public void IncreaseHealthValues(float _healthValue)
        {
            if (_healthValue > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().IncreaseHealthValues(_healthValue);
            }
        }

        /// <summary>
        /// 得到当前血条数值
        /// </summary>
        /// <param name="_healthValue"></param>
        /// <returns></returns>
        public float GetCurrentHealth()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentHealth();
        }

        /// <summary>
        /// 增加最大血条上限(升级)
        /// </summary>
        /// <param name="_increaseHealth"></param>
        public void IncreaseMaxHealth(float _increaseHealth)
        {
            if (_increaseHealth>0)
            {
                Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(_increaseHealth);
            }
        }

        /// <summary>
        /// 得到最大血条上限
        /// </summary>
        /// <returns></returns>
        public float GetMaxHealth()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxHealth();
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
            Model_PlayerKernalDataProxy.GetInstance().DecreaseMagicValues(_magicValue);
        }

        /// <summary>
        /// 增加魔法数值(吃蓝)
        /// </summary>
        /// <param name="_magicValue"></param>
        public void IncreaseMagicValues(float _magicValue)
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMagicValues(_magicValue);
        }

        /// <summary>
        /// 得到当前魔法数值
        /// </summary>
        /// <param name="_healthValue"></param>
        /// <returns></returns>
        public float GetCurrentMagic()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentMagic();
        }

        /// <summary>
        /// 增加最大魔法上限(升级)
        /// </summary>
        /// <param name="_increaseMagic"></param>
        public void IncreaseMaxMagic(float _increaseMagic)
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(_increaseMagic);
        }

        /// <summary>
        /// 得到最大魔法上限
        /// </summary>
        /// <returns></returns>
        public float GetMaxMagic()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxMagic();
        }
        #endregion

        #region 攻击力数值操作 4个

        /// <summary>
        /// 更新攻击力(更换武器、血量变化)
        /// 公式：_attack = _maxAttack/2 * (_healthValue/_maxHealth) + _newWeaponValue
        /// </summary>
        /// <param name="_healthValue">血量数值</param>
        /// <param name="_newWeaponATKValue">新武器数值</param>
        public void UpdateATKValue(float _newWeaponATKValue = 0)
        {
            Model_PlayerKernalDataProxy.GetInstance().UpdateATKValue(_newWeaponATKValue);
        }
        /// <summary>
        /// 得到当前攻击力
        /// </summary>
        /// <returns></returns>
        public float GetCurrentATK()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentATK();
        }
        /// <summary>
        /// 增加最大攻击力(升级)
        /// </summary>
        /// <param name="_increaseATK">增加攻击力的增量数值</param>
        public void IncreaseMaxATK(float _increaseATK)
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxATK(_increaseATK);
        }
        /// <summary>
        /// 得到最大的攻击力
        /// </summary>
        /// <returns></returns>
        public float GetMaxATK()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxATK();
        }
        #endregion

        #region 防御力数值操作 4个
        /// <summary>
        /// 更新防御力(更换武器、血量变化)
        /// 公式：_defence = _maxDefence/2 * (_healthValue/_maxHealth) + _newWeaponDEFValue
        /// </summary>
        /// <param name="_healthValue">当前血量</param>
        /// <param name="_newWeaponDEFValue">新武器防御数值</param>
        public void UpdateDEFValue(float _newWeaponDEFValue = 0)
        {
            Model_PlayerKernalDataProxy.GetInstance().UpdateDEFValue(_newWeaponDEFValue);
        }
        /// <summary>
        /// 得到当前防御力
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEF()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentDEF();
        }
        /// <summary>
        /// 增加最大防御力(升级)
        /// </summary>
        /// <param name="_increaseATK">增加攻击力的增量数值</param>
        public void IncreaseMaxDEF(float _increaseDEF)
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDEF(_increaseDEF);
        }
        /// <summary>
        /// 得到最大的防御力
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEF()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxDEF();
        }
        #endregion

        #region 敏捷数值操作 4个
        /// <summary>
        /// 更新敏捷度(更换武器、血量变化)
        /// 公式：_MoveSpeed = MaxMoveSpeed/2*(_Health/MaxHealth)-_Defence+[道具敏捷力]  
        /// </summary>
        /// <param name="_healthValue">血量数值</param>
        /// <param name="_newWeaponDEXValue">新武器数值</param>
        public void UpdateDEXValue(float _newWeaponDEXValue = 0)
        {
            Model_PlayerKernalDataProxy.GetInstance().UpdateDEXValue(_newWeaponDEXValue);
        }
        /// <summary>
        /// 得到当前敏捷度
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEX()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentDEX();
        }
        /// <summary>
        /// 增加最大敏捷度(升级)
        /// </summary>
        /// <param name="_increaseATK">增加敏捷度的增量数值</param>
        public void IncreaseMaxDEX(float _increaseDEX)
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDEX(_increaseDEX);
        }
        /// <summary>
        /// 得到最大的敏捷度
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEX()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxDEX();
        }
        #endregion

        #region 经验值
        /// <summary>
        /// 增加经验
        /// </summary>
        public void AddExp(int _erperience)
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddExp(_erperience);
        }
        /// <summary>
        /// 获取当前经验值
        /// </summary>
        /// <returns></returns>
        public int GetExp()
        {
            return Model_PlayerExtenalDataProxy.GetInstance().GetExp();
        }
        #endregion

        #region 杀敌数量
        /// <summary>
        /// 增加杀敌数
        /// </summary>
        public void AddKillNumber()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddKillNumber();
        }
        /// <summary>
        /// 获取杀敌数
        /// </summary>
        /// <returns></returns>
        public int GetKillNumber()
        {
            return Model_PlayerExtenalDataProxy.GetInstance().GetKillNumber();
        }
        #endregion

        #region 等级
        /// <summary>
        /// 升级
        /// </summary>
        public void AddLevel()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
        }
        /// <summary>
        /// 获取当前等级
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return Model_PlayerExtenalDataProxy.GetInstance().GetLevel();
        }
        #endregion

        #region 金币
        /// <summary>
        /// 增加金币
        /// </summary>
        /// <param name="_goldNumber"></param>
        public void AddGold(int _goldNumber)
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddGold(_goldNumber);
        }
        /// <summary>
        /// 获取当前金币
        /// </summary>
        /// <returns></returns>
        public int GetGold()
        {
            return Model_PlayerExtenalDataProxy.GetInstance().GetGold();
        }
        #endregion

        #region 钻石
        /// <summary>
        /// 增加钻石
        /// </summary>
        /// <param name="_diamondsNumber"></param>
        public void AddDiamonds(int _diamondsNumber)
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddDiamonds(_diamondsNumber);
        }
        /// <summary>
        /// 获取当前钻石
        /// </summary>
        /// <returns></returns>
        public int GetDiamonds()
        {
            return Model_PlayerExtenalDataProxy.GetInstance().GetDiamonds();
        }
        #endregion
    }
}