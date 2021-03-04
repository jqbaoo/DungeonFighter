/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，新手引导模块--触发对话引导
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

namespace View
{
    public class TriggerDialogs : MonoBehaviour, IGuideTrigger
    {

        public static TriggerDialogs Instance;
        public GameObject goBackground;                                     //背景游戏对象

        private bool _isExistNextDialogsRecorder = false;                   //是否存在下一条对话记录
        private Image _img_BGDialogs;                                       //背景对话贴图
        private e_DialogStateStep _dialogState = e_DialogStateStep.None;    //当前对话状态
        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //Log.Write(GetType() + "/Start()");
            _dialogState = e_DialogStateStep.Step1_DoublePersonDialog;
            //背景贴图获取
            _img_BGDialogs = transform.parent.Find("Background").GetComponent<Image>();
            //注册背景贴图
            RegisterDialogs();
            //讲解第一句话
            DialogUIManager.Instance.DisplayNextDialog(e_DialogType.DoubleDialogs, 1);
        }

        /// <summary>
        /// 注册背景贴图
        /// </summary>
        public void RegisterDialogs()
        {
            if (_img_BGDialogs != null)
            {
                EventTriggerListener.Get(_img_BGDialogs.gameObject).onClick += DisplayNextDialogRecord;
            }
        }

        /// <summary>
        /// 取消注册背景贴图
        /// </summary>
        private void DeregisterDialogs()
        {
            if (_img_BGDialogs != null)
            {
                EventTriggerListener.Get(_img_BGDialogs.gameObject).onClick -= DisplayNextDialogRecord;
            }
        }

        /// <summary>
        /// 显示下一条对话记录
        /// </summary>
        /// <param name="_go">注册的游戏对象</param>
        private void DisplayNextDialogRecord(GameObject _go)
        {
            //Log.Write(GetType() + "/DisplayNextDialogRecord()");
            if (_go == _img_BGDialogs.gameObject)
            {
                _isExistNextDialogsRecorder = true;
            }
        }

        /// <summary>
        /// 检查触发条件
        /// </summary>
        /// <returns>true: 表示条件成立，触发后续业务逻辑</returns>
        public bool CheckCondition()
        {
            //Log.Write(GetType() + "/CheckCondition()");
            if (_isExistNextDialogsRecorder)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 运行业务逻辑
        /// </summary>
        /// <returns>true:表示业务逻辑执行完毕</returns>
        public bool RunOperation()
        {
            //Log.Write(GetType() + "/RunOperation()");
            bool tmp_BoolResult = false;                                                        //本方法运行是否结束
            bool tmp_BoolCurrentDialogResult = false;                                           //当前对话是否结束
            _isExistNextDialogsRecorder = false;
            //业务逻辑判断
            switch (_dialogState)
            {
                case e_DialogStateStep.None:
                    break;
                case e_DialogStateStep.Step1_DoublePersonDialog:
                    tmp_BoolCurrentDialogResult = DialogUIManager.Instance.DisplayNextDialog(e_DialogType.DoubleDialogs, 1);
                    break;
                case e_DialogStateStep.Step2_AliceSpeakET:
                    //Log.Write(GetType() + "/RunOperation()/##### Alick 开始介绍ET");
                    tmp_BoolCurrentDialogResult = DialogUIManager.Instance.DisplayNextDialog(e_DialogType.SingleDialogs, 2);
                    break;
                case e_DialogStateStep.Step3_AliceSperkVirtualKey:
                    tmp_BoolCurrentDialogResult = DialogUIManager.Instance.DisplayNextDialog(e_DialogType.SingleDialogs, 3);
                    break;
                case e_DialogStateStep.Step4_AliceLastWord:
                    tmp_BoolCurrentDialogResult = DialogUIManager.Instance.DisplayNextDialog(e_DialogType.SingleDialogs, 4);
                    break;
                default:
                    break;
            }

            //当前对话结束处理
            if (tmp_BoolCurrentDialogResult)
            {
                switch (_dialogState)
                {
                    case e_DialogStateStep.None:
                        break;
                    case e_DialogStateStep.Step1_DoublePersonDialog:
                        break;
                    case e_DialogStateStep.Step2_AliceSpeakET:                      //Alice 介绍ET完毕，发生后台处理
                        //显示"ET贴图"，控制权暂时转移到TriggerOperationET.cs
                        TriggerOperationET.Instance.DisplayGuideET();
                        //暂停会话
                        DeregisterDialogs();
                        break;
                    case e_DialogStateStep.Step3_AliceSperkVirtualKey:              //Alice 介绍"虚拟按键"完毕
                        //显示"引导虚拟按键贴图"，控制权暂时转移到TriggerOperationVitualKey.cs
                        TriggerOperationVitualKey.Instance.DisplayGuideVirtualKey();
                        //暂停会话
                        DeregisterDialogs();
                        break;
                    case e_DialogStateStep.Step4_AliceLastWord:                     //Alice 全部介绍完毕
                        //显示ET
                        View_PlayerInfoResponse.Instance.DisplayET();
                        //显示所有虚拟攻击按键
                        View_PlayerInfoResponse.Instance.DisplayAllUIKey();
                        //显示英雄UI信息界面
                        View_PlayerInfoResponse.Instance.DisplayHeroUIInfo();
                        //允许生成敌人
                        //GameObject.Find("GameManager/SceneControl").GetComponent<View_Level1Scene>().enabled = true;
                        //GameObject.Find("GameManager/SceneControl").GetComponent<Control.Ctrl_Level1Scene>().enabled = true;
                        //对话界面隐藏
                        goBackground.SetActive(false);

                        tmp_BoolResult = true;
                        break;
                    default:
                        break;
                }
                //进入下一个状态
                EnterNextState();
            }


            return tmp_BoolResult;
        }//RunOperation() end

        /// <summary>
        /// 进入下一个状态
        /// </summary>
        private void EnterNextState()
        {
            switch (_dialogState)
            {
                case e_DialogStateStep.None:
                    break;
                case e_DialogStateStep.Step1_DoublePersonDialog:
                    _dialogState = e_DialogStateStep.Step2_AliceSpeakET;
                    break;
                case e_DialogStateStep.Step2_AliceSpeakET:
                    _dialogState = e_DialogStateStep.Step3_AliceSperkVirtualKey;
                    break;
                case e_DialogStateStep.Step3_AliceSperkVirtualKey:
                    _dialogState = e_DialogStateStep.Step4_AliceLastWord;
                    break;
                case e_DialogStateStep.Step4_AliceLastWord:
                    _dialogState = e_DialogStateStep.None;
                    break;
                default:
                    break;
            }
        }

        public enum e_DialogStateStep
        {
            None,
            Step1_DoublePersonDialog,                                                   //双人对话
            Step2_AliceSpeakET,                                                         //Alice介绍ET
            Step3_AliceSperkVirtualKey,                                                 //Alice介绍虚拟按键
            Step4_AliceLastWord,                                                        //Alice最后祝福
        }
    }//class end
}