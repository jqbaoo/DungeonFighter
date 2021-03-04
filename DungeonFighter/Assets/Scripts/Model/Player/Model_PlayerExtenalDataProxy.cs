/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，玩家拓展数值代理类
 * 
 * Description:
 *      具体作用：简化数值开发，降低耦合，把数值的直接存取转换成使用该类操作
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
    public class Model_PlayerExtenalDataProxy : Model_PlayerExtenalData
    {
        private static Model_PlayerExtenalDataProxy _instance = null;
        public Model_PlayerExtenalDataProxy(int _exp, int _killNumber, int _level, int _gold, int _diamonds)
            : base(_exp, _killNumber, _level, _gold, _diamonds)
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "/Model_PlayerExtenalDataProxy()/构造函数不允许重复实例化");
            }
        }

        public static Model_PlayerExtenalDataProxy GetInstance()
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

        public void DisplayAllOriginalValue()
        {
            base.Experience = base.Experience;
            base.KillNumber = base.KillNumber;
            base.Level = base.Level;
            base.Gold = base.Gold;
            base.Diamonds = base.Diamonds;
        }

        #region 经验值
        /// <summary>
        /// 增加经验
        /// </summary>
        public void AddExp(int _erperience)
        {
            base.Experience += _erperience;
            UpgradeRule.GetInstance().GetUpgradeCondition(base.Experience);
        }
        /// <summary>
        /// 获取当前经验值
        /// </summary>
        /// <returns></returns>
        public int GetExp()
        {
            return base.Experience;
        }
        #endregion

        #region 杀敌数量
        /// <summary>
        /// 增加杀敌数
        /// </summary>
        public void AddKillNumber()
        {
            ++base.KillNumber;
        }
        /// <summary>
        /// 获取杀敌数
        /// </summary>
        /// <returns></returns>
        public int GetKillNumber()
        {
            return base.KillNumber;
        }
        #endregion

        #region 等级
        /// <summary>
        /// 升级
        /// </summary>
        public void AddLevel() 
        {
            ++base.Level;

            //属性修改
            UpgradeRule.GetInstance().UpgradeOperation((e_LevelName)base.Level);
        }

        /// <summary>
        /// 获取当前等级
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return base.Level;
        }
        #endregion

        #region 金币
        /// <summary>
        /// 增加金币
        /// </summary>
        /// <param name="_goldNumber"></param>
        public void AddGold(int _goldNumber)
        {
            base.Gold += Mathf.Abs(_goldNumber);
        }
        public bool DecreaseGold(int _goldNumber)
        {
            bool tmp_HandleFlag = false;
            if (GetGold() - Mathf.Abs(_goldNumber) >= 0)
            {
                base.Gold -= Mathf.Abs(_goldNumber);
                tmp_HandleFlag = true;
            }
            else
            {
                tmp_HandleFlag = false;
            }
            return tmp_HandleFlag;
        }

        /// <summary>
        /// 获取当前金币
        /// </summary>
        /// <returns></returns>
        public int GetGold()
        {
            return base.Gold;
        }
        #endregion

        #region 钻石
        /// <summary>
        /// 增加钻石
        /// </summary>
        /// <param name="_diamondsNumber"></param>
        public void AddDiamonds(int _diamondsNumber)
        {
            base.Diamonds += Mathf.Abs(_diamondsNumber);
        }
        /// <summary>
        /// 减少钻石数量
        /// </summary>
        /// <param name="_diamondNumber"></param>
        /// <returns>
        /// true，处理成功
        /// </returns>
        public bool DecreaseDiamonds(int _diamondNumber)
        {
            bool tmp_HandleFlag = false;
            //钻石的余额
            if (GetDiamonds() - Mathf.Abs(_diamondNumber) >= 0)
            {
                base.Diamonds -= Mathf.Abs(_diamondNumber);
                tmp_HandleFlag = true;
            }
            else
            {
                tmp_HandleFlag = false;
            }

            return tmp_HandleFlag;
        }
        /// <summary>
        /// 获取当前钻石
        /// </summary>
        /// <returns></returns>
        public int GetDiamonds()
        {
            return base.Diamonds;
        }
        #endregion
    }
}