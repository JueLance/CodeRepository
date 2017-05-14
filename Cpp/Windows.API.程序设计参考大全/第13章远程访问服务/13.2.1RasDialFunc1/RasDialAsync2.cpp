// RasTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"

// 回调函数RasDialFunc1
void WINAPI RasDialFunc1(UINT unHsg, RASCONNSTATE rasconnstate, DWORD dwError)
{ 
    char szRasString[256];  // Buffer for error string 
    if(dwError)
    { 
        RasGetErrorString((UINT)dwError, szRasString, 256); 
        printf("Error: %d - %s\n", dwError, szRasString);
        return; 
    }

    switch (rasconnstate)
    {
        case RASCS_OpenPort:
        case RASCS_PortOpened:
            printf("正在打开端口...\n"); 
            break;
        case RASCS_Authenticate:
        case RASCS_AuthNotify:
        case RASCS_AuthRetry:
        case RASCS_AuthCallback:
        case RASCS_AuthChangePassword:
        case RASCS_AuthProject:
        case RASCS_AuthLinkSpeed:
        case RASCS_AuthAck:
        case RASCS_ReAuthenticate:
        case RASCS_Authenticated:
        case RASCS_StartAuthentication:
        case RASCS_CallbackComplete:
            printf("正在验证用户名和密码...\n"); 
            break;
        case RASCS_LogonNetwork:
            printf("正在登录...\n"); 
            break;
        case RASCS_Connected:
            printf("连结成功！\n"); 
            return;
        case RASCS_Disconnected:
            printf("连结已断开！\n"); 
            return;
        case RASCS_ConnectDevice:
        default:
            printf("正在拨号...\n"); /*** update status with "Dialing" ***/
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

	if ((Ret = RasDial(NULL, NULL, &RasDialParams, 0, &RasDialFunc1, &hRasConn)) != 0) 
	{ 
		printf("RasDial失败：错误代码 %d\n", Ret); 
		return -1;
	}
	// RasDial进行中，执行其它任务
	printf("RasDial进行中"); 
}
