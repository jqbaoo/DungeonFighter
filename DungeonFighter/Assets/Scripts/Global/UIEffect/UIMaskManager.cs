/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，UI遮罩管理器
 * 
 * Description:
 *      具体作用：实现弹出"模态窗体"
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class UIMaskManager : MonoBehaviour
    {
        public GameObject goTopPanel;                                       //顶层面板(根节点)
        public GameObject goMaskPanel;                                      //遮罩面板
        private Camera _uiCamera;                                           //UI摄像机
        private float _originalUICameraDepth;                               //原始UI摄像机的层深
        void Start()
        {
            //获取UI摄像机的原始层深
            _uiCamera = transform.parent.Find("UICamera").GetComponent<Camera>();
            if (_uiCamera != null)
            {
                _originalUICameraDepth = _uiCamera.depth;
            }
            else
            {
                Debug.LogError(GetType() + "/Start()/_uiCamera is null!!");
            }
        }

        /// <summary>
        /// 设置遮罩状态
        /// </summary>
        /// <param name="_goDisplayPanel">需要显示的窗体</param>
        public void SetMaskWindow(GameObject _goDisplayPanel)
        {
            //顶层窗体下移
            goTopPanel.transform.SetAsLastSibling();
            //启动遮罩窗体
            goMaskPanel.SetActive(true);
            //遮罩窗体下移
            goMaskPanel.transform.SetAsLastSibling();
            //显示窗体下移
            _goDisplayPanel.transform.SetAsLastSibling();
            //增加当前UI摄像机的"层深"
            if (_uiCamera!=null)
            {
                _uiCamera.depth = _uiCamera.depth + 20;
            }
        }

        /// <summary>
        /// 取消遮罩窗体
        /// </summary>
        public void CancelMaskWindow()
        {
            //顶层窗体上移
            goTopPanel.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            goMaskPanel.SetActive(false);
            //恢复UI摄像机原来"层深"
            _uiCamera.depth = _originalUICameraDepth;
        }
    }
}