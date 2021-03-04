/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，场景的淡出淡入
 * 
 * Description:
 *      具体作用：
 *      1、改变图片的alpha通道
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

namespace Global
{
    public class FadeInAndOut : MonoBehaviour
    {
        public static FadeInAndOut Instance;                    //单例

        public float floColorChangeSpeed = 1f;                  //颜色变化速度

        public GameObject goRawImage;
        private RawImage _rawImage;

        private bool _boolScenesToClear = true;                 //屏幕逐渐清晰
        private bool _boolScenesToBlack = false;                 //屏幕逐渐暗淡
        void Awake()
        {
            Instance = this;

            if (goRawImage)
            {
                _rawImage = goRawImage.GetComponent<RawImage>();
            }
        }

        void Update()
        {
            if (_boolScenesToClear)
            {
                ScenesToClear();
            }
            else if (_boolScenesToBlack)
            {
                ScenesToBlack();
            }
        }

        #region 供外部调用方法
        /// <summary>
        /// 设置场景的淡入
        /// </summary>
        public void SetsSceneToClear()
        {
            _boolScenesToClear = true;
            _boolScenesToBlack = false;
        }
        /// <summary>
        /// 设置场景的淡出
        /// </summary>
        public void SetsSceneToBlack()
        {
            _boolScenesToClear = false;
            _boolScenesToBlack = true;
        }
        #endregion

        #region 内部私有方法
        /// <summary>
        /// 颜色淡入效果(颜色由暗到亮)
        /// </summary>
        private void FadeToClear()
        {
            _rawImage.color = Color.Lerp(_rawImage.color, Color.clear, Time.deltaTime * floColorChangeSpeed);
        }
        /// <summary>
        /// 颜色淡出效果(颜色由亮到暗)
        /// </summary>
        private void FadeToBlack()
        {
            _rawImage.color = Color.Lerp(_rawImage.color, Color.black, Time.deltaTime * floColorChangeSpeed);
        }
        /// <summary>
        /// 屏幕淡入(颜色由暗到亮)
        /// </summary>
        private void ScenesToClear()
        {
            FadeToClear();
            if (_rawImage.color.a <= 0.05f)
            {
                _rawImage.color = Color.clear;
                _rawImage.enabled = false;
                _boolScenesToClear = false;
            }
        }
        /// <summary>
        /// 屏幕淡出(颜色由亮到暗)
        /// </summary>
        private void ScenesToBlack()
        {
            _rawImage.enabled = true;
            FadeToBlack();
            if (_rawImage.color.a >= 0.95)
            {
                _rawImage.color = Color.black;
                _boolScenesToBlack = false;
            }
        }
        #endregion
    }
}