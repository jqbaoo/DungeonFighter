/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，玩家背包数据代理类
 * 
 * Description:
 *      具体作用：封装背包数据，向外提供各种调用方法
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
    public class Model_PlayerPackageDataProxy : Model_PlayerPackageData
    {
        private static Model_PlayerPackageDataProxy _instance;
        public Model_PlayerPackageDataProxy(int _bloodBottleNum, int _magicBottleNum, int _atkNum, int _defNum, int _dexNum)
            : base(_bloodBottleNum, _magicBottleNum, _atkNum, _defNum, _dexNum)
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "//PlayerPackageDataProxy()/构造函数不允许重复实例化");
            }
        }
        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static Model_PlayerPackageDataProxy GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                Debug.LogError("PlayerPackageDataProxy/GetInstance()/请先调用构造函数");
                return null;
            }
        }

        #region 血瓶
        /// <summary>
        /// 增加血瓶数量
        /// </summary>
        /// <param name="_bloodNum"></param>
        public void IncreaseBloodBottleNumber(int _bloodNum)
        {
            base.BloodBottleNumber += Mathf.Abs(_bloodNum);
        }

        /// <summary>
        /// 减少血瓶数量
        /// </summary>
        /// <param name="_bloodNum"></param>
        public void DecreaseBloodBottleNumber(int _bloodNum)
        {
            if (base.BloodBottleNumber-Mathf.Abs(_bloodNum)>=0)
            {
                base.BloodBottleNumber -= Mathf.Abs(_bloodNum);
            }
        }

        /// <summary>
        /// 显示当前血瓶数量
        /// </summary>
        public int DisplayBloodBottleNumber()
        {
            return base.BloodBottleNumber;
        }
        #endregion

        #region 蓝瓶
        /// <summary>
        /// 增加蓝瓶数量
        /// </summary>
        /// <param name="_maigcNum"></param>
        public void IncreaseMagicBottleNumber(int _maigcNum)
        {
            base.MagicBottleNumber += Mathf.Abs(_maigcNum);
        }

        /// <summary>
        /// 减少蓝瓶数量
        /// </summary>
        /// <param name="_maigcNum"></param>
        public void DecreaseMagicBottleNumber(int _maigcNum)
        {
            if (base.MagicBottleNumber - Mathf.Abs(_maigcNum) >= 0)
            {
                base.MagicBottleNumber -= Mathf.Abs(_maigcNum);
            }
        }

        /// <summary>
        /// 显示当前蓝瓶数量
        /// </summary>
        public int DisplayMagicBottleNumber()
        {
            return base.MagicBottleNumber;
        }
        #endregion

        #region 攻击力道具
        /// <summary>
        /// 增加攻击力道具数量
        /// </summary>
        /// <param name="_atkNum"></param>
        public void IncreaseATKPropNumber(int _atkNum)
        {
            base.PropATKNumber += Mathf.Abs(_atkNum);
        }

        /// <summary>
        /// 减少攻击力道具数量
        /// </summary>
        /// <param name="_atkNum"></param>
        public void DecreaseATKPropNumber(int _atkNum)
        {
            if (base.PropATKNumber - Mathf.Abs(_atkNum) >= 0)
            {
                base.PropATKNumber -= Mathf.Abs(_atkNum);
            }
        }

        /// <summary>
        /// 显示当前攻击力道具数量
        /// </summary>
        public int DisplayATKPropNumber()
        {
            return base.PropATKNumber;
        }
        #endregion

        #region 防御力道具
        /// <summary>
        /// 增加防御力道具数量
        /// </summary>
        /// <param name="_defNum"></param>
        public void IncreaseDEFPropNumber(int _defNum)
        {
            base.PropDEFNumber += Mathf.Abs(_defNum);
        }

        /// <summary>
        /// 减少防御力道具数量
        /// </summary>
        /// <param name="_atkNum"></param>
        public void DecreaseDEFPropNumber(int _defNum)
        {
            if (base.PropDEFNumber - Mathf.Abs(_defNum) >= 0)
            {
                base.PropDEFNumber -= Mathf.Abs(_defNum);
            }
        }

        /// <summary>
        /// 显示当前防御力道具数量
        /// </summary>
        public int DisplayDEFPropNumber()
        {
            return base.PropDEFNumber;
        }
        #endregion

        #region 敏捷度道具
        /// <summary>
        /// 增加敏捷度道具数量
        /// </summary>
        /// <param name="_dexNum"></param>
        public void IncreaseDEXPropNumber(int _dexNum)
        {
            base.PropDEXNumber += Mathf.Abs(_dexNum);
        }

        /// <summary>
        /// 减少敏捷度道具数量
        /// </summary>
        /// <param name="_dexNum"></param>
        public void DecreaseDEXPropNumber(int _dexNum)
        {
            if (base.PropDEXNumber - Mathf.Abs(_dexNum) >= 0)
            {
                base.PropDEXNumber -= Mathf.Abs(_dexNum);
            }
        }

        /// <summary>
        /// 显示当前敏捷度道具数量
        /// </summary>
        public int DisplayDEXPropNumber()
        {
            return base.PropDEXNumber;
        }
        #endregion
    }//class end
}