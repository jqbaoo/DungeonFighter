/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，新手引导模块--新手引导管理器
 * 
 * Description:
 *      具体作用：
 *      控制协调所有具体新手新到业务脚本的检查与执行。
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

namespace View
{
    public class GuideManager : MonoBehaviour
    {
        /// <summary>
        /// 所有"新手引导"业务逻辑集合
        /// </summary>
        private List<IGuideTrigger> _listGuideTrigger = new List<IGuideTrigger>();
        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);

            //加入所有的"业务逻辑"脚本
            IGuideTrigger tmp_ITri_1 = TriggerDialogs.Instance;
            IGuideTrigger tmp_ITri_2 = TriggerOperationET.Instance;
            IGuideTrigger tmp_ITri_3 = TriggerOperationVitualKey.Instance;

            _listGuideTrigger.Add(tmp_ITri_1);
            _listGuideTrigger.Add(tmp_ITri_2);
            _listGuideTrigger.Add(tmp_ITri_3);

            //启动业务逻辑脚本的检查
            StartCoroutine("CheckGuideState");
        }

        /// <summary>
        /// 检查引导状态
        /// </summary>
        IEnumerator CheckGuideState()
        {
            //Log.Write(GetType() + "/CheckGuideState()");
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                for (int i = 0; i < _listGuideTrigger.Count; i++)
                {
                    //检查每个业务脚本是否可以运行
                    IGuideTrigger tmp_ITrigger = _listGuideTrigger[i];
                    if (tmp_ITrigger.CheckCondition())
                    {
                        //每个业务脚本执行业务逻辑
                        if (tmp_ITrigger.RunOperation())
                        {
                            //Log.Write(GetType() + "/CheckGuideState()/编号为:" + i + "业务逻辑执行完毕，即将在集合中删除");
                            _listGuideTrigger.Remove(tmp_ITrigger);
                        }
                    }
                }
            }
        }//CheckGuideState() end
    }//class end
}