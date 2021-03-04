/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主城的场景控制
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

namespace Control
{
    public class Ctrl_MajorCityScene : BaseControl
    {
        public AudioClip ac_Background;                                         //主城背景音乐

        IEnumerator Start()
        {
            TriggerCommonEvent.event_CommonTrigger += EnterLevel2;

            //播放背景音乐
            if (ac_Background != null)
            {
                AudioManager.PlayBackground(ac_Background);
            }
            //读取游戏数据进度
            if (GlobalParaMgr.CurrentGameType == e_CurrentGameType.Continue)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_2);

                SaveAndLoading.GetInstance().LoadingGame_PlayerData();
            }
        }

        private void EnterLevel2(e_CommonTriggerType _ctt)
        {
            switch (_ctt)
            {
                case e_CommonTriggerType.EnterLevel1:
                    base.EnterNextScene(e_ScenesEnum.Level1);
                    break;
                case e_CommonTriggerType.EnterLevel2:
                    base.EnterNextScene(e_ScenesEnum.Level2);
                    break;
                default:
                    break;
            }
        }
    }
}