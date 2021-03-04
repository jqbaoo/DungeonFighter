/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，新手引导模块--触发虚拟摇杆(ET)
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
using Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TriggerOperationET : MonoBehaviour, IGuideTrigger
    {
        public static TriggerOperationET Instance;
        public GameObject goBackground;                                     //背景游戏对象

        private bool _isExistNextDialogsRecorder = false;                   //是否存在下一条对话记录
        private Image _img_GuideET;                                         //引导ET贴图

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //背景贴图获取
            _img_GuideET = transform.parent.Find("Img_ET").GetComponent<Image>();
            //注册"引导ET贴图"
            RegisterGuideET();
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
            //隐藏"引导ET贴图"
            _img_GuideET.gameObject.SetActive(false);
            //激活ET
            View_PlayerInfoResponse.Instance.DisplayET();
            //恢复对话系统
            StartCoroutine("ResumeDialog");

            return true;
        }

        /// <summary>
        /// 显示"引导ET贴图"
        /// </summary>
        public void DisplayGuideET()
        {
            _img_GuideET.gameObject.SetActive(true);
        }

        /// <summary>
        /// 注册"引导ET贴图"
        /// </summary>
        private void RegisterGuideET()
        {
            if (_img_GuideET != null)
            {
                EventTriggerListener.Get(_img_GuideET.gameObject).onClick += GuideETOperation;
            }
        }

        private void GuideETOperation(GameObject _go)
        {
            if (_go == _img_GuideET.gameObject)
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
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_2);
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