/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 核心词，自定义异常：XML解析异常
 * 
 * Description:
 *      具体作用：专门定位XML解析的异常，如果出现异常，说明XML格式定义错误
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace Kernal
{
    public class XMLAnalysisException:Exception
    {
        public XMLAnalysisException()
            : base()
        {

        }
        public XMLAnalysisException(string _exceptionMessage)
            : base(_exceptionMessage)
        {

        }
    }
}