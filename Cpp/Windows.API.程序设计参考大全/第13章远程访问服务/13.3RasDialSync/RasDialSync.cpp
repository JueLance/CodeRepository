// RasTest.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"

int _tmain(int argc, _TCHAR* argv[])
{
	// ͬ�����÷�ʽ
	RASDIALPARAMS RasDialParams;
	// ��������dwSize ΪRASDIALPARAMS�ṹ�Ĵ�С
	RasDialParams.dwSize = sizeof(RASDIALPARAMS);
	HRASCONN hRasConn = NULL; 
	// ����szEntryNameΪ���ַ���������RasDialʹ��ȱʡ��������
	lstrcpy(RasDialParams.szEntryName, ""); 
	lstrcpy(RasDialParams.szPhoneNumber, "010-88888888");
	lstrcpy(RasDialParams.szUserName, "myUserName");
	lstrcpy(RasDialParams.szPassword, "myPassword");
	lstrcpy(RasDialParams.szDomain, "myDomain");
	// ͬ����ʽ����RasDial(���������ΪNULL)
	DWORD Ret = RasDial(NULL, NULL, &RasDialParams, 0, NULL, &hRasConn);
	if (Ret != 0) 
	{ 
		printf("RasDialʧ��: Error = %d\n", Ret);
		return -1;
	}

	// ��ȡ����״̬
	RASCONNSTATUS RasStatus;
	RasStatus.dwSize = sizeof (RASCONNSTATUS);
	DWORD dwReturn = RasGetConnectStatus (hRasConn, &RasStatus);
	if (dwReturn)
	{
		printf("RasGetConnectStatusʧ��: Error = %d\n", dwReturn);
		return -1;
	} 


	RasHangUp(hRasConn);
}

