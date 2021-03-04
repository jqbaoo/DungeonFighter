/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，NPC主城对话脚本
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
using UnityEngine.UI;

namespace View
{

    public class View_NPCDialogs_InMajorCity : MonoBehaviour
    {
        public GameObject goDialogsPanel;                                                       //对话面板

        private Image _img_BGDialogs;                                                           //背景对话贴图

        private e_CommonTriggerType _commonTriggerType = e_CommonTriggerType.None;              //当前触发对话目标




        void Start()
        {
            goDialogsPanel = transform.parent.Find("Background").gameObject;

            //获取背景贴图
            _img_BGDialogs = this.transform.parent.Find("Background").GetComponent<Image>();
            //注册"触发器，对话系统"(准备的对话)
            RegisterTriggerDialog();
            //注册"背景贴图"
            RegisterBGTexture();
            //开始不显示对话贴图
            _img_BGDialogs.gameObject.SetActive(false);
        }

        #region 对话准备阶段

        /// <summary>
        /// 注册"触发器，对话系统"(准备的对话)
        /// </summary>
        private void RegisterTriggerDialog()
        {
            TriggerCommonEvent.event_CommonTrigger += StartDialogPrepare;
        }
        /// <summary>
        /// 开始对话准备
        /// </summary>
        /// <param name="_CTT"></param>
        private void StartDialogPrepare(e_CommonTriggerType _CTT)
        {
            switch (_CTT)
            {
                case e_CommonTriggerType.None:
                    break;
                case e_CommonTriggerType.NPC1_Dialog:
                    ActiveNPC1_Dialog();
                    break;
                case e_CommonTriggerType.NPC2_Dialog:
                    ActiveNPC2_Dialog();
                    break;
                case e_CommonTriggerType.NPC3_Dialog:
                    break;
                case e_CommonTriggerType.NPC4_Dialog:
                    break;
                case e_CommonTriggerType.NPC5_Dialog:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 激活NPC1对话
        /// </summary>
        private void ActiveNPC1_Dialog()
        {
            //给NPC1动态加载贴图
            LoadNPC1Texture();
            //赋值当前对话状态
            _commonTriggerType = e_CommonTriggerType.NPC1_Dialog;
            //禁用ET
            View_PlayerInfoResponse.Instance.HideET();
            //显示对话UI面板
            if (goDialogsPanel != null)
            {
                goDialogsPanel.gameObject.SetActive(true);
            }
            //显示首句对话
            DisplayNextDialog(5);
        }

        /// <summary>
        /// 激活NPC2对话
        /// </summary>
        private void ActiveNPC2_Dialog()
        {
            //给NPC1动态加载贴图
            LoadNPC2Texture();
            //赋值当前对话状态
            _commonTriggerType = e_CommonTriggerType.NPC2_Dialog;
            //禁用ET
            View_PlayerInfoResponse.Instance.HideET();
            //显示对话UI面板
            if (goDialogsPanel != null)
            {
                goDialogsPanel.gameObject.SetActive(true);
            }
            //显示首句对话
            DisplayNextDialog(6);
        }

        /// <summary>
        /// 动态加载NPC1的贴图
        /// </summary>
        private void LoadNPC1Texture()
        {
            DialogUIManager.Instance.spr_NPC_Right[0] = ResourcesManager.GetInstance().LoadResource<Sprite>("Texture/BigScales/NPCTrue_1", true);
            DialogUIManager.Instance.spr_NPC_Right[1] = ResourcesManager.GetInstance().LoadResource<Sprite>("Texture/BigScales/NPCBW_1", true);

        }

        /// <summary>
        /// 动态加载NPC2的贴图
        /// </summary>
        private void LoadNPC2Texture()
        {
            DialogUIManager.Instance.spr_NPC_Right[0] = ResourcesManager.GetInstance().LoadResource<Sprite>("Texture/BigScales/NPCTrue_2", true);
            DialogUIManager.Instance.spr_NPC_Right[1] = ResourcesManager.GetInstance().LoadResource<Sprite>("Texture/BigScales/NPCBW_2", true);

        }
        #endregion


        #region 正式对话阶段

        /// <summary>
        /// 注册"背景贴图"，点击贴图可显示下一条数据
        /// </summary>
        private void RegisterBGTexture()
        {
            if (_img_BGDialogs != null)
            {
                EventTriggerListener.Get(_img_BGDialogs.gameObject).onClick += DisplayDialogByNPC;
            }
        }


        private void DisplayDialogByNPC(GameObject _go)
        {
            switch (_commonTriggerType)
            {
                case e_CommonTriggerType.None:
                    break;
                case e_CommonTriggerType.NPC1_Dialog:
                    DisplayNextDialog(5);
                    break;
                case e_CommonTriggerType.NPC2_Dialog:
                    DisplayNextDialog(6);
                    break;
                default:
                    break;
            }
        }

        private void DisplayNextDialog(int _sectionNum)
        {
            bool tmp_Result = DialogUIManager.Instance.DisplayNextDialog(e_DialogType.DoubleDialogs, _sectionNum);

            if (tmp_Result)
            {
                //对话结束，关闭对话面板
                if (goDialogsPanel != null)
                {
                    goDialogsPanel.gameObject.SetActive(false);
                }
                View_PlayerInfoResponse.Instance.DisplayET();
            }
        }

        #endregion


    }//class end
}