/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，玩家拓展数值
 * 
 * Description:
 *      具体作用：提供玩家拓展数据的存取数值
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
    public class Model_PlayerExtenalData
    {
        public static event del_PlayerKernalModel event_PlayerExtenalData;

        private int _intExperience;                                     //经验值
        private int _intKillNumber;                                     //杀敌数量
        private int _intLevel;                                          //当前等级
        private int _intGold;                                           //金币
        private int _intDiamonds;                                       //钻石

        #region 属性
        /// <summary>
        /// 经验
        /// </summary>
        public int Experience
        {
            get { return _intExperience; }
            set
            {
                _intExperience = value;
                if (event_PlayerExtenalData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Experience", Experience);
                    event_PlayerExtenalData(tmp_KV);
                }
            }
        }
        /// <summary>
        /// 杀敌数
        /// </summary>
        public int KillNumber
        {
            get { return _intKillNumber; }
            set
            {
                _intKillNumber = value;
                if (event_PlayerExtenalData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("KillNumber", KillNumber);
                    event_PlayerExtenalData(tmp_KV);
                }
            }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level
        {
            get { return _intLevel; }
            set
            {
                _intLevel = value;
                if (event_PlayerExtenalData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Level", Level);
                    event_PlayerExtenalData(tmp_KV);
                }
            }
        }
        /// <summary>
        /// 金币
        /// </summary>
        public int Gold
        {
            get { return _intGold; }
            set
            {
                _intGold = value;
                if (event_PlayerExtenalData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Gold", Gold);
                    event_PlayerExtenalData(tmp_KV);
                }
            }
        }
        /// <summary>
        /// 钻石
        /// </summary>
        public int Diamonds
        {
            get { return _intDiamonds; }
            set
            {
                _intDiamonds = value;
                if (event_PlayerExtenalData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("Diamond", Diamonds);
                    event_PlayerExtenalData(tmp_KV);
                }
            }
        }
        #endregion

        private Model_PlayerExtenalData()
        {

        }

        public Model_PlayerExtenalData(int _experience,int _killNumber,int _level,int _gold,int _diamonds)
        {
            this._intExperience = _experience;
            this._intKillNumber = _killNumber;
            this._intLevel = _level;
            this._intGold = _gold;
            this._intDiamonds = _diamonds;
        }
    }
}