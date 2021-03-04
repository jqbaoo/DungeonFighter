/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，"连击"管理器
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

namespace Global
{
    public class ComboCountManager : MonoBehaviour
    {
        public static ComboCountManager Instance;

        public float comboCountPrefabLength = 2f;
        public float comboCountPrefabHeight = 2f;

        private int _comboCount = 0;                                                //连击次数
        private float _comboDelayTime = 3;                                          //连击计算延迟时间
        private float _floComboCountPrefabLength;                                   //当前实际长度
        private float _floComboCountPrefabHeight;                                   //当前实际高度
        //控件
        private Text txt_DisplayComboCount;
        void Awake()
        {
            Instance = this;
            txt_DisplayComboCount = GetComponent<Text>();
        }
        void Start()
        {
            _floComboCountPrefabHeight = comboCountPrefabHeight + 1f;
            _floComboCountPrefabLength = comboCountPrefabLength + 1f;
            this.transform.localScale = new Vector3(_floComboCountPrefabLength, _floComboCountPrefabHeight, 0);
        }

        void Update()
        {
            //逐步缩小预设的外观尺寸
            if (_floComboCountPrefabLength >= comboCountPrefabLength || _floComboCountPrefabHeight >= comboCountPrefabHeight)
            {
                _floComboCountPrefabHeight -= 0.1f;
                _floComboCountPrefabLength -= 0.1f;
            }
            this.transform.localScale = new Vector3(_floComboCountPrefabLength, _floComboCountPrefabHeight, 0);
            //如果"连击"次数大于0则显示，否则隐藏
            if (_comboCount>0)
            {
                txt_DisplayComboCount.enabled = true;
            }
            else
            {
                txt_DisplayComboCount.enabled = false;
            }
            //显示控件与统计数字
            txt_DisplayComboCount.text = "Combo " + _comboCount.ToString();
            //判断连击
            if (_comboCount>0)
            {
                //规定时间统计
                _comboDelayTime -= Time.deltaTime;
                if (_comboDelayTime<=0)
                {
                    _comboCount = 0;
                    //控件尺寸恢复
                    _floComboCountPrefabHeight = comboCountPrefabHeight + 1f;
                    _floComboCountPrefabLength = comboCountPrefabLength + 1f;
                }
            }
        }//update() end


        /// <summary>
        /// 重置连击数
        /// 用途：给其他脚本进行调用
        /// </summary>
        public void ResetNumber()
        {
            ++_comboCount;
            _comboDelayTime = 3f;
            _floComboCountPrefabHeight = comboCountPrefabHeight + 1f;
            _floComboCountPrefabLength = comboCountPrefabLength + 1f;

        }

    }//class end
}