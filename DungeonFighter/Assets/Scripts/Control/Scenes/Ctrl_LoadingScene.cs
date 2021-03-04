/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，加载场景
 * 
 * Description:
 *      具体作用：
 *      1、场景异步加载，后台逻辑处理
 *      2、初始化各种数据
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
    public class Ctrl_LoadingScene : BaseControl
    {

        void Start()
        {
            //关卡预处理逻辑
            StartCoroutine("ScenePreProgressing");
            //垃圾收集工作
            StartCoroutine("HandleGC");
        }

        /// <summary>
        /// 关卡预处理
        /// </summary>
        /// <returns></returns>
        IEnumerator ScenePreProgressing()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            switch (GlobalParaMgr.NextScenesName)
            {
                case e_ScenesEnum.StartScene:
                    break;
                case e_ScenesEnum.LoginScene:
                    StartCoroutine("ScenePreProgressing_Level1");
                    break;
                case e_ScenesEnum.MajorCity:
                    StartCoroutine("ScenePreProgressing_Level1");
                    break;
                case e_ScenesEnum.Level1:                                                       //第一关卡
                    StartCoroutine("ScenePreProgressing_Level1");
                    break;
                case e_ScenesEnum.Level2:                                                       //第二关卡
                    break;
                case e_ScenesEnum.BaseScene:
                    break;
                case e_ScenesEnum.TestScene:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 预处理第一关卡
        /// </summary>
        /// <returns></returns>
        IEnumerator ScenePreProgressing_Level1()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            ////TODO   这段代码必须放到视图层才能凑效？？？？
            //Log.ClearLogFileAndBufferDate();
            //XMLDialogsDataAnalysisManager.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            //yield return new WaitForSeconds(0.9f);
            //List<DialogDataFormat> tmp_ListDialogsArray = XMLDialogsDataAnalysisManager.GetInstance().GetAllXMLDataArray();
            //bool tmp_Resule = DialogDataManager.GetInstance().LoadAllDialogData(tmp_ListDialogsArray);
            //Debug.Log(tmp_Resule);
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
        }


        /// <summary>
        /// 垃圾资源收集
        /// </summary>
        /// <returns></returns>
        IEnumerator HandleGC()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //卸载无用资源
            Resources.UnloadUnusedAssets();
            //强制垃圾收集
            System.GC.Collect();
        }
    }//class end
}