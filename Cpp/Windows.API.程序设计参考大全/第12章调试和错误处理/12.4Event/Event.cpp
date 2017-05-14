// Event.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "windows.h"
#include "winbase.h"

int _tmain(int argc, _TCHAR* argv[])
{
	HANDLE h;
 
	// ע���¼�Դ
	h = RegisterEventSource(NULL,       // uses local computer 
			TEXT("EventSamplApp"));     // source name 
	if (h == NULL) 
	{
		printf("RegisterEventSourceʧ�ܡ�\n"); 
		return -1;
	}

	// �����¼�

	const char* szMsg[1];
	szMsg[0] = "���󱨸�����...";
	if (!ReportEvent(h,           // event log handle 
            EVENTLOG_ERROR_TYPE,  // event type 
            0,                    // category zero 
            1,                    // event identifier 
            NULL,                 // no user security identifier 
            1,                    // one substitution string 
            0,                    // no data 
            szMsg,                // pointer to string array 
            NULL))                // pointer to data 
	{
		printf("�����¼�ʧ�ܡ�\n"); 
		return -1;
	}


	// ע���¼�Դ
	DeregisterEventSource(h); 


	//------------------------------------------------------------------------------------


	// ���¼���־
	h = OpenEventLog( NULL,    // use local computer
		     "Application");   // source name
	if (h == NULL) 
	{
		printf("���¼���־ʧ�ܡ�\n"); 
		return -1;
	}

	// ��ȡϵͳ�¼���־��¼���� 
	DWORD cRecords; 
	if (!GetNumberOfEventLogRecords(h, &cRecords)) 
	{
		printf("��ȡ�¼���־��¼��ʧ�ܡ�\n"); 
		return -1;
	}
	printf("���� %d ��Ӧ�ó����¼���־.\n", cRecords); 


	EVENTLOGRECORD *pevlr; 
	BYTE bBuffer[255]; 
	DWORD dwRead, dwNeeded, dwThisRecord; 
	
	pevlr = (EVENTLOGRECORD *) &bBuffer; 

	// ����¼���־�ļ�¼��
	GetOldestEventLogRecord(h, &dwThisRecord);

	// ��ȡ�¼���־
	while (ReadEventLog(h,                // event log handle 
				EVENTLOG_FORWARDS_READ |  // reads forward 
				EVENTLOG_SEQUENTIAL_READ, // sequential read 
				0,            // ignored for sequential reads 
				pevlr,        // pointer to buffer 
				255,          // size of buffer 
				&dwRead,      // number of bytes read 
				&dwNeeded))   // bytes in next record 
	{
		while (dwRead > 0) 
		{ 
			// ��ӡ��¼�����¼���ʾ�������ͺ�Դ���ơ�
			printf("%02d  �¼�ID: 0x%08X ",  dwThisRecord++, pevlr->EventID); 
			printf("EventType: %d Source: %s\n", 
				pevlr->EventType, (LPSTR) ((LPBYTE) pevlr + 
				sizeof(EVENTLOGRECORD))); 

			dwRead -= pevlr->Length; 
			pevlr = (EVENTLOGRECORD *) 
				((LPBYTE) pevlr + pevlr->Length); 
		} 

		pevlr = (EVENTLOGRECORD *) &bBuffer; 
	} 


	// �����־�����ݵ�c:\eventlog.bak
	ClearEventLog(h, "c:\\eventlog.bak");

	// �ر��¼���־
	CloseEventLog(h); 


	return 0;
}

