/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，场景加载
 * 
 * Description:
 *      具体作用：
 *      1、实现场景异步加载控制
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
using Global;
using Kernal;

namespace View
{
    public class View_LoadingScene : MonoBehaviour
    {
        public Slider sliderLoadingProgress;
        private float _floProgressNumber;                    //进度条数值
        private AsyncOperation _asyOper;
        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);

            #region 测试代码
            //测试3 XML对话解析
            //参数赋值
            //Log.ClearLogFileAndBufferDate();
            //XMLDialogsDataAnalysisManager.GetInstance().InitXMLDialogsData();
            ////XMLDialogsDataAnalysisManager.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            ////TODO.....延迟时间太短导致XMLDialogsDataAnalysisManager的InitXMLConfig()方法未执行完就执行下面的代码，导致获取了空的链表
            //yield return new WaitForSeconds(0.5f);
            ////得到XML中所有的数据
            //List<DialogDataFormat> tmp_ListDialogsArray = XMLDialogsDataAnalysisManager.GetInstance().GetAllXMLDataArray();
            //Debug.Log(tmp_ListDialogsArray);
            //foreach (DialogDataFormat tmp_DiaDataFormatItem in tmp_ListDialogsArray)
            //{
            //    Log.Write("");
            //    Log.Write("DialogSecNum" + tmp_DiaDataFormatItem.DialogSecNum);
            //    Log.Write("DialogSecName" + tmp_DiaDataFormatItem.DialogSecName);
            //    Log.Write("SectionIndex" + tmp_DiaDataFormatItem.SectionIndex);
            //    Log.Write("DialogSide" + tmp_DiaDataFormatItem.DialogSide);
            //    Log.Write("DialogPerson" + tmp_DiaDataFormatItem.DialogPerson);
            //    Log.Write("DialogContent" + tmp_DiaDataFormatItem.DialogContent);
            //    Log.SyncLogArrayToFile();
            //}

            #endregion

            //测试4 给"对话数据管理器"加载数据
            //Log.ClearLogFileAndBufferDate();
            //初始化XML对话数据
            XMLDialogsDataAnalysisManager.GetInstance().InitXMLDialogsData();
            yield return new WaitForSeconds(0.9f);
            //获取所有对话数据
            List<DialogDataFormat> tmp_ListDialogsArray = XMLDialogsDataAnalysisManager.GetInstance().GetAllXMLDataArray();
            //把对话数据加载到DialogDataManager中
            DialogDataManager.GetInstance().LoadAllDialogData(tmp_ListDialogsArray);

            StartCoroutine("LoadingSceneProgress");
        }

        /// <summary>
        /// 异步加载协程
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadingSceneProgress()
        {
            _asyOper = Application.LoadLevelAsync(ConvertEnumToStr.GetInstance().GetSrtByEnumScene(GlobalParaMgr.NextScenesName));
            _floProgressNumber = _asyOper.progress;
            yield return _asyOper;
        }

        void Update()
        {
            if (_floProgressNumber <= 1f)
            {
                _floProgressNumber += 0.01f;
            }
            sliderLoadingProgress.value = _floProgressNumber;
        }
    }
}