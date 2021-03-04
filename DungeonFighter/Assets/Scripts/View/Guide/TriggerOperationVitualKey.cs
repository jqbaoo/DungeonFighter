/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，新手引导模块--触发虚拟按键
 * 
 * Description:
 *      具体作用：
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using Kernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using UnityEngine.UI;

namespace View
{
    public class TriggerOperationVitualKey : MonoBehaviour,IGuideTrigger
    {
        public static TriggerOperationVitualKey Instance;

        public GameObject goBackground;                                     //背景游戏对象

        private bool _isExistNextDialogsRecorder = false;                   //是否存在下一条对话记录
        private Image _img_GuideVirtualKey;                                 //引导虚拟按键贴图

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //背景贴图获取
            _img_GuideVirtualKey = transform.parent.Find("Img_VirtualKey").GetComponent<Image>();
            //注册"引导ET贴图"
            RegisterGuideVirtualKey();
        }
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

        public bool RunOperation()
        {
            //Log.Write(GetType() + "/RunOperation()");
            _isExistNextDialogsRecorder = false;
            //隐藏对话界面
            goBackground.SetActive(false);
            //隐藏"引导虚拟按键"
            _img_GuideVirtualKey.gameObject.SetActive(false);
            //激活"普攻虚拟按键"
            View_PlayerInfoResponse.Instance.DisplayMainATK();
            //激活"虚拟按键"

            //恢复对话系统
            StartCoroutine("ResumeDialog");

            return true;
        }

        /// <summary>
        /// 显示"引导虚拟按键贴图"
        /// </summary>
        public void DisplayGuideVirtualKey()
        {
            _img_GuideVirtualKey.gameObject.SetActive(true);
        }

        /// <summary>
        /// 注册"引导虚拟按键"
        /// </summary>
        private void RegisterGuideVirtualKey()
        {
            if (_img_GuideVirtualKey != null)
            {
                EventTriggerListener.Get(_img_GuideVirtualKey.gameObject).onClick += GuideVirtualKeyOperation;
            }
        }

        private void GuideVirtualKeyOperation(GameObject _go)
        {
            if (_go == _img_GuideVirtualKey.gameObject)
            {
                _isExistNextDialogsRecorder = true;
            }
        }

        /// <summary>
        /// 恢复对话
        /// </summary>
        /// <returns></returns>
        private IEnumerator ResumeDialog()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_5);
            //隐藏ET
            View_PlayerInfoResponse.Instance.HideET();
            //注册会话系统，允许继续会话
            TriggerDialogs.Instance.RegisterDialogs();
            //运行对话系统，直接显示下一条对话
            TriggerDialogs.Instance.RunOperation();
            //显示对话界面
            goBackground.SetActive(true);
        }
    }
}
