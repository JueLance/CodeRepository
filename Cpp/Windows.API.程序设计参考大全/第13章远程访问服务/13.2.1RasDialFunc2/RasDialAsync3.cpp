// RasTest.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"

// �ص�����RasDialFunc1
DWORD WINAPI RasDialFunc2(
    DWORD dwCallbackId, DWORD dwSubEntry, HRASCONN hrasconn,
    UINT unMsg, RASCONNSTATE rascs,
    DWORD dwError, DWORD dwExtendedError)
{ 
    char szRasString[256];  // Buffer for error string 
    if(dwError)
    { 
        RasGetErrorString((UINT)dwError, szRasString, 256); 
        printf("Error: %d - %s\n", dwError, szRasString);
        return 0; 
    }

    switch (rascs)
    {
        case RASCS_OpenPort:
        case RASCS_PortOpened:
            printf("���ڴ򿪶˿�...\n"); 
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
            printf("������֤�û���������...\n"); 
            break;
        case RASCS_LogonNetwork:
            printf("���ڵ�¼...\n"); 
            break;
        case RASCS_Connected:
            printf("����ɹ���\n"); 
            return 0;
        case RASCS_Disconnected:
            printf("�����ѶϿ���\n"); 
            return 0;
        case RASCS_ConnectDevice:
        default:
            printf("���ڲ���...\n"); /*** update status with "Dialing" ***/
            break;
    }
	return 1;
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

	if ((Ret = RasDial(NULL, NULL, &RasDialParams, 0, &RasDialFunc2, &hRasConn)) != 0) 
	{ 
		printf("RasDialʧ�ܣ�������� %d\n", Ret); 
		return -1;
	}
	// RasDial�����У�ִ����������
	printf("RasDial������"); 
}
