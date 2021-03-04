/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，开始场景
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

namespace Control
{
    public class Ctrl_StartScene : BaseControl
    {
        public static Ctrl_StartScene Instance;
        public AudioClip audioClip;
        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground(audioClip);
        }

        /// <summary>
        /// 点击新的游戏
        /// </summary>
        internal void ClickNewGame()
        {
            //场景淡出(变暗)
            FadeInAndOut.Instance.SetsSceneToBlack();
            //转到下一个场景
            StartCoroutine("EnterNewGame");
            
        }

        /// <summary>
        /// 点击游戏连接
        /// </summary>
        internal void ClickGameContinue()
        {
            StartCoroutine("ContinueGame");
        }

        /// <summary>
        /// 进入下一个场景
        /// </summary>
        IEnumerator EnterNewGame()
        {
            //调用控制层的"新的游戏"方法
            FadeInAndOut.Instance.SetsSceneToBlack();
            yield return new WaitForSeconds(2f);

            base.EnterNextScene(e_ScenesEnum.MajorCity);
        }

        IEnumerator ContinueGame()
        {
            //读取单机进度
            SaveAndLoading.GetInstance().LoadingGame_GlobalParameter();
            //场景淡出
            FadeInAndOut.Instance.SetsSceneToBlack();
            yield return new WaitForSeconds(2f);
            base.EnterNextScene(GlobalParaMgr.NextScenesName);
        }
    }
}