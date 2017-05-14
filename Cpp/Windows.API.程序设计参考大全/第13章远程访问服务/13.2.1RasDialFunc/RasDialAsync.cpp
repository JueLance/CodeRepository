// RasTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"

// 回调函数RasDialFunc
void WINAPI RasDialFunc(UINT unHsg, RASCONNSTATE rasconnstate, DWORD dwError)
{ 
    char szRasString[256];  // Buffer for error string 
    if(dwError)
    { 
        RasGetErrorString((UINT)dwError, szRasString, 256); 
        printf("Error: %d - %s\n", dwError, szRasString);
        return; 
    }
    
    switch(rasconnstate)
    { 
        case RASCS_ConnectDevice: 
            printf("正连接设备...\n"); 
            break; 
        case RASCS_DeviceConnected: 
            printf("设备已连接.\n"); 
            break; 
        // 处理其它连接活动 
        // ...
        default: 
            printf("未监测RAS活动. \n"); 
            break; 
    } 
} 

int _tmain(int argc, _TCHAR* argv[])
{
	// 异步调用方式1
	DWORD Ret; 
	RASDIALPARAMS RasDialParams; 
	HRASCONN hRasConn; 

	// 总是设置dwSize 为RASDIALPARAMS结构的大小
	RasDialParams.dwSize = sizeof(RASDIALPARAMS);
	// 设置szEntryName为空字符串将允许RasDial使用缺省拨号属性
	lstrcpy(RasDialParams.szEntryName, ""); 
	lstrcpy(RasDialParams.szPhoneNumber, "010-88888888");
	lstrcpy(RasDialParams.szUserName, "myUserName");
	lstrcpy(RasDialParams.szPassword, "myPassword");
	lstrcpy(RasDialParams.szDomain, "myDomain");
	hRasConn = NULL; 

	if ((Ret = RasDial(NULL, NULL, &RasDialParams, 0, &RasDialFunc, &hRasConn)) != 0) 
	{ 
		printf("RasDial失败：错误代码 %d\n", Ret); 
		return -1;
	}
	// RasDial进行中，执行其它任务
	printf("RasDial进行中"); 
}
