/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 核心层，核心层的参数
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

namespace Kernal
{
    public class KernalParameter
    {
///////已弃用
//#if UNITY_STANDALONE_WIN
//        //系统配置信息_日志路径
//        internal static readonly string SysyemConfigInfo_LogPath = "file://" + Application.dataPath + "/StreamingAssets/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//        internal static readonly string SysyemConfigInfo_LogRootNodePath = "SystemConfigInfo";

//        //对话系统XML路径                 
//        internal static readonly string DialogsXMLConfig_XMLPath = Application.dataPath + "/StreamingAssets/SystemDialogsInfo.xml";
//        //对话系统XML根节点名称
//        internal static readonly string DialogsXMLConfig_XMLRootNodeName = "Dialogs_CN";
//#elif UNITY_ANDROID
//        //系统配置信息_日志路径
//        internal static readonly string SysyemConfigInfo_LogPath = Application.dataPath + "!/Assets/StreamingAssets/SystemConfigInfo";
//        //系统配置信息_日志根节点名称
//        internal static readonly string SysyemConfigInfo_LogRootNodePath = "SystemConfigInfo";

//        //对话系统XML路径
//        internal static readonly string DialogsXMLConfig_XMLPath = Application.dataPath + "!/Assets/SystemDialogsInfo.xml";
//        //对话系统XML根节点名称
//        internal static readonly string DialogsXMLConfig_XMLRootNodeName = "Dialogs_CN";
//#elif UNITY_IPHONE
//        //系统配置信息_日志路径
//        internal static readonly string SysyemConfigInfo_LogPath = Application.dataPath + "/Raw/SystemConfigInfo";
//        //系统配置信息_日志根节点名称
//        internal static readonly string SysyemConfigInfo_LogRootNodePath = "SystemConfigInfo";

//        //对话系统XML路径
//        internal static readonly string DialogsXMLConfig_XMLPath = Application.dataPath + "/Raw/SystemDialogsInfo.xml";
//        //对话系统XML根节点名称
//        internal static readonly string DialogsXMLConfig_XMLRootNodeName = "Dialogs_CN";
//#endif

        /// <summary>
        /// 得到日志路径
        /// </summary>
        /// <returns></returns>
        public static string GetLogPath()
        {
            string tmp_LogPath = null;
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                tmp_LogPath = Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }
            else
            {
                tmp_LogPath = "file://" + Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }
            return tmp_LogPath;
        }

        /// <summary>
        /// 得到日志根节点名称
        /// </summary>
        /// <returns></returns>
        public static string GetLogRootNodeName()
        {
            string tmp_LogXMLRootNodeName = "SystemConfigInfo";

            return tmp_LogXMLRootNodeName;
        }

        /// <summary>
        /// 得到对话XML文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetDialogConfigXMLPath()
        {
            string tmp_DialogConfigXMLPath = null;
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                tmp_DialogConfigXMLPath = Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }
            else
            {
                tmp_DialogConfigXMLPath = "file://" + Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }
            return tmp_DialogConfigXMLPath;
        }

        /// <summary>
        /// 得到对话XML根节点名称
        /// </summary>
        /// <returns></returns>
        public static string GetDialogConfigXMLRootNodeName()
        {
            string tmp_DialogConfigXMLRootNodeName = "Dialogs_CN";

            return tmp_DialogConfigXMLRootNodeName;
        }
    }
}