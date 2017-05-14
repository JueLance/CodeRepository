// RasTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"

int _tmain(int argc, _TCHAR* argv[])
{
	// 同步调用方式
	RASDIALPARAMS RasDialParams;
	// 总是设置dwSize 为RASDIALPARAMS结构的大小
	RasDialParams.dwSize = sizeof(RASDIALPARAMS);
	HRASCONN hRasConn = NULL; 
	// 设置szEntryName为空字符串将允许RasDial使用缺省拨号属性
	lstrcpy(RasDialParams.szEntryName, ""); 
	lstrcpy(RasDialParams.szPhoneNumber, "010-88888888");
	lstrcpy(RasDialParams.szUserName, "myUserName");
	lstrcpy(RasDialParams.szPassword, "myPassword");
	lstrcpy(RasDialParams.szDomain, "myDomain");
	// 同步方式调用RasDial(第五个参数为NULL)
	DWORD Ret = RasDial(NULL, NULL, &RasDialParams, 0, NULL, &hRasConn);
	if (Ret != 0) 
	{ 
		printf("RasDial失败: Error = %d\n", Ret);
		return -1;
	}

	// 获取连接状态
	RASCONNSTATUS RasStatus;
	RasStatus.dwSize = sizeof (RASCONNSTATUS);
	DWORD dwReturn = RasGetConnectStatus (hRasConn, &RasStatus);
	if (dwReturn)
	{
		printf("RasGetConnectStatus失败: Error = %d\n", dwReturn);
		return -1;
	} 


	RasHangUp(hRasConn);
}

