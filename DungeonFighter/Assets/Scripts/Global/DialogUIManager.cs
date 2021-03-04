/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，通用对话UI管理器
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
using UnityEngine.UI;

namespace Global
{
    public class DialogUIManager : MonoBehaviour
    {
        public static DialogUIManager Instance;
        //UI对象
        public GameObject goHero;                                               //英雄
        public GameObject goNPC_Left;                                           //左边的NPC
        public GameObject goNPC_Right;                                          //右边的NPC
        public GameObject goSingleDialogArea;                                   //单人对话信息区域
        public GameObject goDoubleDialogArea;                                   //双人对话信息区域

        //对话显示控件
        public Text txt_PersonName;                                             //人名
        public Text txt_SingleDialogContent;                                    //单人对话内容
        public Text txt_DoubleDialogContent;                                    //双人对话内容

        //Sprite资源数组  (规定0为彩色，1为黑白)
        public Sprite[] spr_Hero;
        public Sprite[] spr_NPC_Left;
        public Sprite[] spr_NPC_Right;

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 显示下一条对话，true 对话结束，flase 对话继续
        /// </summary>
        /// <param name="_dialogType">对话类型(单人/双人)</param>
        /// <param name="_dialogSectionNum">对话段落编号</param>
        /// <returns>true 对话结束  flase 对话继续</returns>
        public bool DisplayNextDialog(e_DialogType _dialogType, int _dialogSectionNum)
        {
            bool tmp_IsDialogEnd = false;
            e_DialogSide tmp_DialogSide = e_DialogSide.None;
            string tmp_StrPersonName;
            string tmp_StrDialogContent;

            //切换(选择)对话类型
            ChangeDialogType(_dialogType);

            //得到会话信息(数据)
            bool tmp_IsFlag = DialogDataManager.GetInstance().GetNextDialogInfoRecoder(_dialogSectionNum, out tmp_DialogSide, out tmp_StrPersonName, out tmp_StrDialogContent);
            if (tmp_IsFlag)
            {
                //显示对话信息
                DisplayDialogInfo(_dialogType, tmp_DialogSide, tmp_StrPersonName, tmp_StrDialogContent);
            }
            else
            {
                //对话结束
                tmp_IsDialogEnd = true;
            }
            return tmp_IsDialogEnd;
        }

        /// <summary>
        /// 切换(选择)对话类型，切换图片
        /// </summary>
        /// <param name="_dialogType">对话类型(单人/双人)</param>
        private void ChangeDialogType(e_DialogType _dialogType)
        {
            switch (_dialogType)
            {
                case e_DialogType.None:
                    goHero.SetActive(false);
                    goNPC_Left.SetActive(false);
                    goNPC_Right.SetActive(false);
                    goSingleDialogArea.SetActive(false);
                    goDoubleDialogArea.SetActive(false);
                    break;
                case e_DialogType.DoubleDialogs:
                    goHero.SetActive(true);
                    goNPC_Left.SetActive(false);
                    goNPC_Right.SetActive(true);
                    goSingleDialogArea.SetActive(false);
                    goDoubleDialogArea.SetActive(true);

                    break;
                case e_DialogType.SingleDialogs:
                    goHero.SetActive(false);
                    goNPC_Left.SetActive(true);
                    goNPC_Right.SetActive(false);
                    goSingleDialogArea.SetActive(true);
                    goDoubleDialogArea.SetActive(false);

                    break;
                default:
                    goHero.SetActive(false);
                    goNPC_Left.SetActive(false);
                    goNPC_Right.SetActive(false);
                    goSingleDialogArea.SetActive(false);
                    goDoubleDialogArea.SetActive(false);
                    break;
            }
        }

        /// <summary>
        /// 显示对话信息
        /// </summary>
        /// <param name="_dialogType">对话类型(单人/双人)</param>
        /// <param name="tmp_DialogSide">对话双方</param>
        /// <param name="tmp_StrPersonName">对话人名</param>
        /// <param name="tmp_StrDialogContent">对话内容</param>
        private void DisplayDialogInfo(e_DialogType _dialogType, e_DialogSide _dialogSide, string _personName, string _dialogContent)
        {
            switch (_dialogType)
            {
                case e_DialogType.None:
                    break;
                case e_DialogType.DoubleDialogs:
                    //显示人名、对话txt信息
                    if (!string.IsNullOrEmpty(_personName)&&!string.IsNullOrEmpty(_dialogContent))
                    {
                        if (_dialogSide == e_DialogSide.HersoSide)
                        {
                            txt_PersonName.text = GlobalParaMgr.PlayerName;
                        }
                        else
                        {
                            txt_PersonName.text = _personName;
                        }
                        txt_DoubleDialogContent.text = _dialogContent;
                    }
                    //确定显示sprite精灵
                    switch (_dialogSide)
	                {
                        case e_DialogSide.None:
                            break;
                        case e_DialogSide.HersoSide:
                            goHero.GetComponent<Image>().overrideSprite = spr_Hero[0];
                            goNPC_Right.GetComponent<Image>().overrideSprite = spr_NPC_Right[1];
                            break;
                        case e_DialogSide.NPCSide:
                            goHero.GetComponent<Image>().overrideSprite = spr_Hero[1];
                            goNPC_Right.GetComponent<Image>().overrideSprite = spr_NPC_Right[0];
                            break;
                        default:
                            break;
	                }
                    break;
                case e_DialogType.SingleDialogs:
                    txt_SingleDialogContent.text = _dialogContent;
                    break;
                default:
                    break;
            }
        }

    }//class end

    /// <summary>
    /// 对话类型
    /// </summary>
    public enum e_DialogType
    {
        None,                                                                   //无
        DoubleDialogs,                                                          //双人会话
        SingleDialogs,                                                          //单人会话
    }
}
