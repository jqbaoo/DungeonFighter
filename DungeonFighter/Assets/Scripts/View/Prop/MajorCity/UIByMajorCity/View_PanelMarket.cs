/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，主城UI界面_内购商城
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
using Global;
using Kernal;
using UnityEngine.UI;
using Control;

namespace View
{
    public class View_PanelMarket : MonoBehaviour
    {
        //道具说明
        public Text txt_Diamond;                                            //钻石
        public Text txt_Gold;                                               //金币
        public Text txt_BooldBottle;                                        //血瓶
        public Text txt_MagicBottle;                                        //蓝瓶
        public Text txt_AttackProp;                                         //攻击力道具
        public Text txt_DefenceProp;                                        //防御力道具
        public Text txt_DexterityProp;                                      //敏捷道具

        public Image img_Diamond;                                            //钻石
        public Image img_Gold;                                               //金币
        public Image img_BooldBottle;                                        //血瓶
        public Image img_MagicBottle;                                        //蓝瓶
        public Image img_AttackProp;                                         //攻击力道具
        public Image img_DefenceProp;                                        //防御力道具
        public Image img_DexterityProp;                                      //敏捷道具

        //响应的按键
        public Button btn_Diamond;                                          //钻石
        public Button btn_Gold;                                             //金币
        public Button btn_BloodBottle;                                      //血瓶
        public Button btn_MagicBottle;                                      //蓝瓶
        public Button btn_AttackProp;                                       //攻击力道具
        public Button btn_DefenceProp;                                      //防御力道具
        public Button btn_DexterityProp;                                    //敏捷道具
        //具体道具的文字说明
        public Text txt_GoodsDescription;

        void Awake()
        {
            //注册按钮
            RegisteTxtAndBtn();
        }

        /// <summary>
        /// 注册相关按钮
        /// </summary>
        private void RegisteTxtAndBtn()
        {
            /* 文字注册 */
            if (img_Diamond != null)
            {
                EventTriggerListener.Get(img_Diamond.gameObject).onClick += DisplayDiamond;
            }
            if (img_Gold != null)
            {
                EventTriggerListener.Get(img_Gold.gameObject).onClick += DisplayGold;
            }
            if (img_BooldBottle != null)
            {
                EventTriggerListener.Get(img_BooldBottle.gameObject).onClick += DisplayBooldBottle;
            }
            if (img_MagicBottle != null)
            {
                EventTriggerListener.Get(img_MagicBottle.gameObject).onClick += DisplayMagicBottle;
            }
            if (img_AttackProp != null)
            {
                EventTriggerListener.Get(img_AttackProp.gameObject).onClick += DisplayAttackProp;
            }
            if (img_DefenceProp != null)
            {
                EventTriggerListener.Get(img_DefenceProp.gameObject).onClick += DisplayDefenceProp;
            }
            if (img_DexterityProp != null)
            {
                EventTriggerListener.Get(img_DexterityProp.gameObject).onClick += DisplayDexterityProp;
            }

            ///* 按钮注册 */
            if (btn_Diamond != null)
            {
                EventTriggerListener.Get(btn_Diamond.gameObject).onClick += PurchaseDiamend;
            }
            if (btn_Gold != null)
            {
                EventTriggerListener.Get(btn_Gold.gameObject).onClick += PurchaseGold;
            }
            if (btn_BloodBottle != null)
            {
                EventTriggerListener.Get(btn_BloodBottle.gameObject).onClick += PurchaseBloodBottle;
            }
            if (btn_MagicBottle != null)
            {
                EventTriggerListener.Get(btn_MagicBottle.gameObject).onClick += PurchaseMagicBottle;
            }
            if (btn_AttackProp != null)
            {
                EventTriggerListener.Get(btn_AttackProp.gameObject).onClick += PurchaseAttackProp;
            }
            if (btn_DefenceProp != null)
            {
                EventTriggerListener.Get(btn_DefenceProp.gameObject).onClick += PurchaseDefenceProp;
            }
            if (btn_DexterityProp != null)
            {
                EventTriggerListener.Get(btn_DexterityProp.gameObject).onClick += PurchaseDexterityProp;
            }
        }

        #region  商品的显示信息
        //钻石
        private void DisplayDiamond(GameObject _go)
        {
            if (_go == img_Diamond.gameObject)
            {
                txt_GoodsDescription.text = "充值10颗钻石，1颗钻石等于1RMB";
            }
        }

        //金币
        private void DisplayGold(GameObject _go)
        {
            if (_go == img_Gold.gameObject)
            {
                txt_GoodsDescription.text = "1钻石可以购买10金币";
            }
        }

        //血瓶
        private void DisplayBooldBottle(GameObject _go)
        {
            if (_go == img_BooldBottle.gameObject)
            {
                txt_GoodsDescription.text = "50金币购买5个血瓶";
            }
        }
        //蓝瓶
        private void DisplayMagicBottle(GameObject _go)
        {
            if (_go == img_MagicBottle.gameObject)
            {
                txt_GoodsDescription.text = "50金币购买5个蓝瓶";
            }
        }
        //攻击力道具
        private void DisplayAttackProp(GameObject _go)
        {
            if (_go == img_AttackProp.gameObject)
            {
                txt_GoodsDescription.text = "500金币升1级攻击力";
            }
        }
        //防御力道具
        private void DisplayDefenceProp(GameObject _go)
        {
            if (_go == img_DefenceProp.gameObject)
            {
                txt_GoodsDescription.text = "500金币升1级防御力";
            }
        }
        //敏捷道具
        private void DisplayDexterityProp(GameObject _go)
        {
            if (_go == img_DexterityProp.gameObject)
            {
                txt_GoodsDescription.text = "300金币升级1级敏捷";
            }
        }

        #endregion

        #region 商品的点击相应
        /// <summary>
        /// 重置10个钻石
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseDiamend(GameObject _go)
        {
            if (_go == btn_Diamond.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = Ctrl_PanelMarket.Instance.AddDiamond();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "钻石充值成功";
                }
                else
                {
                    txt_GoodsDescription.text = "钻石充值失败";
                }
            }
        }
        
        /// <summary>
        /// 购买10个金币
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseGold(GameObject _go)
        {
            if (_go == btn_Gold.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = tmp_Result = Ctrl_PanelMarket.Instance.PurchaseGold();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "金币充值成功";
                }
                else
                {
                    txt_GoodsDescription.text = "金币充值失败";
                }
            }
        }
        
        /// <summary>
        /// 购买5个血瓶
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseBloodBottle(GameObject _go)
        {
            if (_go == btn_BloodBottle.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = Ctrl_PanelMarket.Instance.PurchaseBloodBottle();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "血瓶购买成功";
                }
                else
                {
                    txt_GoodsDescription.text = "血瓶购买失败";
                }
            }
        }

        /// <summary>
        /// 购买5个蓝瓶
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseMagicBottle(GameObject _go)
        {
            if (_go == btn_MagicBottle.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = Ctrl_PanelMarket.Instance.PurchaseMagicBottle();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "蓝瓶购买成功";
                }
                else
                {
                    txt_GoodsDescription.text = "蓝瓶购买失败";
                }
            }
        }
        
        /// <summary>
        /// 购买攻击力道具
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseAttackProp(GameObject _go)
        {
            if (_go == btn_AttackProp.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = Ctrl_PanelMarket.Instance.PurchaseAttackProp();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "攻击力购买成功";
                }
                else
                {
                    txt_GoodsDescription.text = "攻击力购买失败";
                }
            }
        }

        /// <summary>
        /// 购买防御力道具
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseDefenceProp(GameObject _go)
        {
            if (_go == btn_DefenceProp.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = Ctrl_PanelMarket.Instance.PurchaseDefenceProp();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "防御力购买成功";
                }
                else
                {
                    txt_GoodsDescription.text = "防御力购买失败";
                }
            }
        }

        /// <summary>
        /// 敏捷道具
        /// </summary>
        /// <param name="_go"></param>
        private void PurchaseDexterityProp(GameObject _go)
        {
            if (_go == btn_DexterityProp.gameObject)
            {
                //返回结果
                bool tmp_Result = false;
                tmp_Result = Ctrl_PanelMarket.Instance.PurchaseDexterityProp();
                //调用商城的逻辑层脚本
                if (tmp_Result)
                {
                    txt_GoodsDescription.text = "敏捷购买成功";
                }
                else
                {
                    txt_GoodsDescription.text = "敏捷购买失败";
                }
            }
        }
        #endregion
    }
}