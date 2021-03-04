/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，背包系统控制
 * 
 * Description:
 *      具体作用：根据背包系统模型层后台的数据，显示背包系统的道具
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
using Model;
using Global;
using UnityEngine.UI;

namespace View
{
    public class View_PackageCtrl : MonoBehaviour
    {
        //道具对象
        public GameObject goPropBloodBottle;                                                //血瓶
        public GameObject goPropMaigBottle;                                                 //蓝瓶
        public GameObject goPropATK;                                                        //攻击力道具
        public GameObject goPropDEF;                                                        //防御力道具
        public GameObject goPropDEX;                                                        //敏捷度道具

        //道具数量
        public Text txt_PropBloodBottleNum;                                                 //血瓶数量
        public Text txt_PropMagicBottleNum;                                                 //蓝瓶数量



        void Awake()
        {
            //事件注册
            Model_PlayerPackageData.event_PlayerPackageData += DisplayBloodBottle;
            Model_PlayerPackageData.event_PlayerPackageData += DisplayMagicBottle;
            Model_PlayerPackageData.event_PlayerPackageData += DisplayATKBottle;
            Model_PlayerPackageData.event_PlayerPackageData += DisplayDEFBottle;
            Model_PlayerPackageData.event_PlayerPackageData += DisplayDEXBottle;
        }

        #region 注册方法

        /// <summary>
        /// 显示血瓶以及数量
        /// </summary>
        /// <param name="_kv"></param>
        public void DisplayBloodBottle(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("BloodBottleNumber"))
            {
                if (goPropBloodBottle && txt_PropBloodBottleNum)
                {
                    //如果道具数量大于等于1,则显示道具
                    if (System.Convert.ToInt32(_kv.Value) >= 1)
                    {
                        goPropBloodBottle.SetActive(true);
                        txt_PropBloodBottleNum.text = _kv.Value.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 显示蓝瓶以及数量
        /// </summary>
        /// <param name="_kv"></param>
        public void DisplayMagicBottle(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MagicBottleNumber"))
            {
                if (goPropMaigBottle && txt_PropMagicBottleNum)
                {
                    //如果道具数量大于等于1,则显示道具
                    if (System.Convert.ToInt32(_kv.Value) >= 1)
                    {
                        goPropMaigBottle.SetActive(true);
                        txt_PropMagicBottleNum.text = _kv.Value.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 显示攻击力道具
        /// </summary>
        /// <param name="_kv"></param>
        public void DisplayATKBottle(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("PropATKNumber"))
            {
                if (goPropATK)
                {
                    //如果道具数量大于等于1,则显示道具
                    if (System.Convert.ToInt32(_kv.Value) >= 1)
                    {
                        goPropATK.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// 显示防御力道具
        /// </summary>
        /// <param name="_kv"></param>
        public void DisplayDEFBottle(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("PropDEFNumber"))
            {
                if (goPropDEF)
                {
                    //如果道具数量大于等于1,则显示道具
                    if (System.Convert.ToInt32(_kv.Value) >= 1)
                    {
                        goPropDEF.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// 显示敏捷度道具
        /// </summary>
        /// <param name="_kv"></param>
        public void DisplayDEXBottle(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("PropDEXNumber"))
            {
                if (goPropDEX && txt_PropBloodBottleNum)
                {
                    //如果道具数量大于等于1,则显示道具
                    if (System.Convert.ToInt32(_kv.Value) >= 1)
                    {
                        goPropDEX.SetActive(true);
                    }
                }
            }
        }

        #endregion

    }//class end
}