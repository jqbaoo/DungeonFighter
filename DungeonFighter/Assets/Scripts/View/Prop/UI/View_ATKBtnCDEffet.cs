/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，UI虚拟按键CD冷却特效
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
using UnityEngine.UI;

namespace View
{
    public class View_ATKBtnCDEffet : MonoBehaviour
    {
        public Text txt_CountDownNumber;                                                //技能数字冷却时间
        public float floCDTime = 5f;                                                    //技能冷却时间
        public Image img_Circle;                                                        //外部圆圈转动特效
        public GameObject goWhiteAndBlack;

        private float _floTimeDelta = 0f;
        private bool _boolIsStartTime = false;                                          //是否开始计时
        private Button _btn_Self;
        private bool _boolEnable = false;
        void Start()
        {
            _btn_Self = GetComponent<Button>();
            txt_CountDownNumber.enabled = false;

            EnableSelf();
        }

        void Update()
        {
            if (_boolEnable)
            {
                //键盘输入
                if (Input.GetKeyDown(KeyCode.K))
                {
                    _boolIsStartTime = true;
                    txt_CountDownNumber.enabled = true;
                }

                if (_boolIsStartTime)
                {
                    goWhiteAndBlack.SetActive(true);
                    _floTimeDelta += Time.deltaTime;
                    img_Circle.fillAmount = _floTimeDelta / floCDTime;
                    //Text控件显示
                    txt_CountDownNumber.enabled = true;
                    txt_CountDownNumber.text = Mathf.RoundToInt(floCDTime - _floTimeDelta).ToString();

                    _btn_Self.interactable = false;
                    if (_floTimeDelta >= floCDTime)
                    {
                        txt_CountDownNumber.enabled = false;
                        _boolIsStartTime = false;
                        img_Circle.fillAmount = 1;
                        _floTimeDelta = 0;
                        goWhiteAndBlack.SetActive(false);
                        _btn_Self.interactable = true;
                    }
                }
            }
        }

        /// <summary>
        /// 响应用户点击(虚拟按键)
        /// </summary>
        public void ResponseBtnClick()
        {
            _boolIsStartTime = true;
        }

        /// <summary>
        /// 启用本控件
        /// </summary>
        public void EnableSelf()
        {
            _boolEnable = true;
            goWhiteAndBlack.SetActive(false);
            if (_btn_Self)
            {
                _btn_Self.interactable = true;
            }
        }

        /// <summary>
        /// 禁用本控件
        /// </summary>
        public void DisableSelf()
        {
            _boolEnable = false;
            goWhiteAndBlack.SetActive(true);
            if (_btn_Self)
            {
                _btn_Self.interactable = false;
            }
        }
    }
}