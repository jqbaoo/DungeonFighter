/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，显示玩家信息
 * 
 * Description:
 *      具体作用：
 *      1、显示各种信息：等级、生命值、魔法值、攻击力、防御力、敏捷、经验、金币、钻石、杀敌数等。
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Model;
using Global;

namespace View
{
    public class View_DisplayPlayerInfo : MonoBehaviour
    {
        //屏幕信息显示
        public Text txt_PlayerNameByScreen;                          //玩家姓名
        public Slider sli_HP;                                        //生命值
        public Slider sli_MP;                                        //魔法值
        public Text txt_LevelByScreen;                               //等级
        public Text txt_CurrentHPByScreen;                           //当前生命值
        public Text txt_MaxHPByScreen;                               //最大生命值
        public Text txt_CurrentMPByScreen;                           //当前魔法值
        public Text txt_MaxMPByScreen;                               //最大魔法值
        public Text txt_ExpByScreen;                                 //经验值
        public Text txt_GoldByScreen;                                //金币
        public Text txt_DiamondByScreen;                             //钻石

        //玩家详细信息
        public Text txt_PlayerName;                                  //详细面板中玩家姓名
        public Text txt_Level;                                       //当前等级
        public Text txt_CurrentHP;                                   //当前生命值
        public Text txt_MaxHP;                                       //最大生命值
        public Text txt_CurrentMP;                                   //当前魔法值
        public Text txt_MaxMP;                                       //最大魔法值
        public Text txt_ATK;                                         //攻击力
        public Text txt_MaxATK;                                      //最大攻击力
        public Text txt_DEF;                                         //防御力
        public Text txt_MaxDEF;                                      //最大防御力
        public Text txt_DEX;                                         //敏捷
        public Text txt_MaxDEX;                                      //最大敏捷
        public Text txt_KillNumber;                                  //杀敌数
        public Text txt_Exp;                                         //经验值
        public Text txt_Gold;                                        //金币
        public Text txt_Diamond;                                     //钻石

        public const float WAIT_FOR_SECONDS_ON_START = 0.2f;        //延迟执行Start

        void Awake()
        {
            Model_PlayerKernalData.event_PlayerKernal += DisplayHP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayATK;
            Model_PlayerKernalData.event_PlayerKernal += DisplayDEF;
            Model_PlayerKernalData.event_PlayerKernal += DisplayDEX;

            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxHP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxMP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxATK;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxDEF;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxDEX;

            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayExp;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayKillNumber;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayLevel;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayGold;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayDiamond;
        }
        IEnumerator Start()
        {
            yield return new WaitForSeconds(WAIT_FOR_SECONDS_ON_START);
            Model_PlayerKernalDataProxy.GetInstance().DisplayAllOriginalValues();
            Model_PlayerExtenalDataProxy.GetInstance().DisplayAllOriginalValue();

            if (!string.IsNullOrEmpty(GlobalParaMgr.PlayerName))
            {
                txt_PlayerNameByScreen.text = GlobalParaMgr.PlayerName;
                txt_PlayerName.text = GlobalParaMgr.PlayerName;
            }
        }


        #region 事件注册方法
        /// <summary>
        /// 显示当前生命值
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayHP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Health"))
            {
                if (txt_CurrentHPByScreen && txt_CurrentHP)
                {
                    txt_CurrentHPByScreen.text = _kv.Value.ToString();
                    txt_CurrentHP.text = _kv.Value.ToString();

                    sli_HP.value = (int)_kv.Value;
                }
            }
        }

        /// <summary>
        /// 显示当前最大生命值
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayMaxHP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxHealth"))
            {
                if (txt_CurrentHPByScreen && txt_CurrentHP)
                {
                    txt_MaxHPByScreen.text = _kv.Value.ToString();
                    txt_MaxHP.text = _kv.Value.ToString();

                    sli_HP.maxValue = _kv.Value;
                    sli_HP.minValue = 0;
                }
            }
        }

        /// <summary>
        /// 显示魔法值
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayMP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Magic"))
            {
                if (txt_CurrentMPByScreen && txt_CurrentMP)
                {
                    txt_CurrentMPByScreen.text = _kv.Value.ToString();
                    txt_CurrentMP.text = _kv.Value.ToString();
                    sli_MP.value = _kv.Value;
                }
            }
        }

        /// <summary>
        /// 显示最大魔法值
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayMaxMP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxMagic"))
            {
                if (txt_MaxMPByScreen && txt_MaxMP)
                {
                    txt_MaxMPByScreen.text = _kv.Value.ToString();
                    txt_MaxMP.text = _kv.Value.ToString();

                    sli_MP.maxValue = _kv.Value;
                    sli_MP.minValue = 0;
                }
            }
        }

        /// <summary>
        /// 显示攻击力
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayATK(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Attack"))
            {
                if (txt_ATK)
                {
                    txt_ATK.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示最大攻击力
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayMaxATK(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxAttack"))
            {
                if (txt_MaxATK)
                {
                    txt_MaxATK.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示防御力
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayDEF(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Defence"))
            {
                if (txt_DEF)
                {
                    txt_DEF.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示防御力
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayMaxDEF(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxDefence"))
            {
                if (txt_MaxDEF)
                {
                    txt_MaxDEF.text = _kv.Value.ToString();
                }
            }
        }

        /// <summary>
        /// 显示敏捷
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayDEX(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Dexterity"))
            {
                if (txt_DEX)
                {
                    txt_DEX.text = _kv.Value.ToString();
                }
            }
        }

        /// <summary>
        /// 显示最大敏捷
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayMaxDEX(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxDexterity"))
            {
                if (txt_MaxDEX)
                {
                    txt_MaxDEX.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示经验
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayExp(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Experience"))
            {
                if (txt_ExpByScreen && txt_Exp)
                {
                    txt_ExpByScreen.text = _kv.Value.ToString();
                    txt_Exp.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示杀敌数
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayKillNumber(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("KillNumber"))
            {
                if (txt_KillNumber)
                {
                    txt_KillNumber.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示等级
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayLevel(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Level"))
            {
                if (txt_LevelByScreen && txt_Level)
                {
                    txt_LevelByScreen.text = _kv.Value.ToString();
                    txt_Level.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示金币
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayGold(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Gold"))
            {
                if (txt_GoldByScreen && txt_Gold)
                {
                    txt_GoldByScreen.text = _kv.Value.ToString();
                    txt_Gold.text = _kv.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 显示钻石
        /// </summary>
        /// <param name="_kv"></param>
        private void DisplayDiamond(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Diamond"))
            {
                if (txt_DiamondByScreen && txt_Diamond)
                {
                    txt_DiamondByScreen.text = _kv.Value.ToString();
                    txt_Diamond.text = _kv.Value.ToString();
                }
            }
        }
        #endregion
    }//class end
}