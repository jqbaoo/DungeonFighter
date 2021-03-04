/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层主城UI界面_内购商城内部逻辑实现
 * 
 * Description:
 *      具体作用：
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kernal;
using Global;
using Model;

namespace Control
{
    public class Ctrl_PanelMarket : BaseControl
    {
        public static Ctrl_PanelMarket Instance;
        void Awake()
        {
            Instance = this;
        }


        /// <summary>
        /// 钻石充值
        /// </summary>
        /// <returns></returns>
        public bool AddDiamond()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddDiamonds(10);
            return true;
        }
        /// <summary>
        /// 购买10个金币
        /// </summary>
        /// <returns></returns>
        public bool PurchaseGold()
        {
            bool tmp_Result;
            bool tmp_Flat = Model_PlayerExtenalDataProxy.GetInstance().DecreaseDiamonds(1);
            if (tmp_Flat)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddGold(10);
                tmp_Result = true;
            }
            else
            {
                tmp_Result = false;
            }
            return tmp_Result;
        }

        /// <summary>
        /// 购买5个血瓶
        /// </summary>
        /// <returns></returns>
        public bool PurchaseBloodBottle()
        {
            bool tmp_Result;
            bool tmp_Flat = Model_PlayerExtenalDataProxy.GetInstance().DecreaseGold(50);
            if (tmp_Flat)
            {
                Model_PlayerPackageDataProxy.GetInstance().IncreaseBloodBottleNumber(5);
                tmp_Result = true;
            }
            else
            {
                tmp_Result = false;
            }
            return tmp_Result;
        }

        /// <summary>
        /// 购买5个蓝瓶
        /// </summary>
        /// <returns></returns>
        public bool PurchaseMagicBottle()
        {
            bool tmp_Result;
            bool tmp_Flat = Model_PlayerExtenalDataProxy.GetInstance().DecreaseGold(50);
            if (tmp_Flat)
            {
                Model_PlayerPackageDataProxy.GetInstance().IncreaseMagicBottleNumber(5);
                tmp_Result = true;
            }
            else
            {
                tmp_Result = false;
            }
            return tmp_Result;
        }

        /// <summary>
        /// 购买攻击力道具
        /// </summary>
        /// <returns></returns>
        public bool PurchaseAttackProp()
        {
            bool tmp_Result;
            bool tmp_Flat = Model_PlayerExtenalDataProxy.GetInstance().DecreaseGold(500);
            if (tmp_Flat)
            {
                Model_PlayerPackageDataProxy.GetInstance().IncreaseATKPropNumber(1);
                tmp_Result = true;
            }
            else
            {
                tmp_Result = false;
            }
            return tmp_Result;
        }

        /// <summary>
        /// 购买防御力道具
        /// </summary>
        /// <returns></returns>
        public bool PurchaseDefenceProp()
        {
            bool tmp_Result;
            bool tmp_Flat = Model_PlayerExtenalDataProxy.GetInstance().DecreaseGold(500);
            if (tmp_Flat)
            {
                Model_PlayerPackageDataProxy.GetInstance().IncreaseDEFPropNumber(5);
                tmp_Result = true;
            }
            else
            {
                tmp_Result = false;
            }
            return tmp_Result;
        }

        /// <summary>
        /// 购买敏捷道具
        /// </summary>
        /// <returns></returns>
        public bool PurchaseDexterityProp()
        {
            bool tmp_Result;
            bool tmp_Flat = Model_PlayerExtenalDataProxy.GetInstance().DecreaseGold(300);
            if (tmp_Flat)
            {
                Model_PlayerPackageDataProxy.GetInstance().IncreaseDEXPropNumber(5);
                tmp_Result = true;
            }
            else
            {
                tmp_Result = false;
            }
            return tmp_Result;
        }
    }
}