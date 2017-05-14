// RasTest.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"

// �ص�����RasDialFunc
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
            printf("�������豸...\n"); 
            break; 
        case RASCS_DeviceConnected: 
            printf("�豸������.\n"); 
            break; 
        // �����������ӻ 
        // ...
        default: 
            printf("δ���RAS�. \n"); 
            break; 
    } 
} 

int _tmain(int argc, _TCHAR* argv[])
{
	// �첽���÷�ʽ1
	DWORD Ret; 
	RASDIALPARAMS RasDialParams; 
	HRASCONN hRasConn; 

	// ��������dwSize ΪRASDIALPARAMS�ṹ�Ĵ�С
	RasDialParams.dwSize = sizeof(RASDIALPARAMS);
	// ����szEntryNameΪ���ַ���������RasDialʹ��ȱʡ��������
	lstrcpy(RasDialParams.szEntryName, ""); 
	lstrcpy(RasDialParams.szPhoneNumber, "010-88888888");
	lstrcpy(RasDialParams.szUserName, "myUserName");
	lstrcpy(RasDialParams.szPassword, "myPassword");
	lstrcpy(RasDialParams.szDomain, "myDomain");
	hRasConn = NULL; 

	if ((Ret = RasDial(NULL, NULL, &RasDialParams, 0, &RasDialFunc, &hRasConn)) != 0) 
	{ 
		printf("RasDialʧ�ܣ�������� %d\n", Ret); 
		return -1;
	}
	// RasDial�����У�ִ����������
	printf("RasDial������"); 
}
