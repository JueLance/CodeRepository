// Event.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "windows.h"
#include "winbase.h"

int _tmain(int argc, _TCHAR* argv[])
{
	HANDLE h;
 
	// 注册事件源
	h = RegisterEventSource(NULL,       // uses local computer 
			TEXT("EventSamplApp"));     // source name 
	if (h == NULL) 
	{
		printf("RegisterEventSource失败。\n"); 
		return -1;
	}

	// 报告事件

	const char* szMsg[1];
	szMsg[0] = "错误报告内容...";
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
		printf("报告事件失败。\n"); 
		return -1;
	}


	// 注销事件源
	DeregisterEventSource(h); 


	//------------------------------------------------------------------------------------


	// 打开事件日志
	h = OpenEventLog( NULL,    // use local computer
		     "Application");   // source name
	if (h == NULL) 
	{
		printf("打开事件日志失败。\n"); 
		return -1;
	}

	// 获取系统事件日志记录数。 
	DWORD cRecords; 
	if (!GetNumberOfEventLogRecords(h, &cRecords)) 
	{
		printf("获取事件日志记录数失败。\n"); 
		return -1;
	}
	printf("共有 %d 条应用程序事件日志.\n", cRecords); 


	EVENTLOGRECORD *pevlr; 
	BYTE bBuffer[255]; 
	DWORD dwRead, dwNeeded, dwThisRecord; 
	
	pevlr = (EVENTLOGRECORD *) &bBuffer; 

	// 最久事件日志的记录号
	GetOldestEventLogRecord(h, &dwThisRecord);

	// 读取事件日志
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
			// 打印记录数，事件标示符，类型和源名称。
			printf("%02d  事件ID: 0x%08X ",  dwThisRecord++, pevlr->EventID); 
			printf("EventType: %d Source: %s\n", 
				pevlr->EventType, (LPSTR) ((LPBYTE) pevlr + 
				sizeof(EVENTLOGRECORD))); 

			dwRead -= pevlr->Length; 
			pevlr = (EVENTLOGRECORD *) 
				((LPBYTE) pevlr + pevlr->Length); 
		} 

		pevlr = (EVENTLOGRECORD *) &bBuffer; 
	} 


	// 清除日志并备份到c:\eventlog.bak
	ClearEventLog(h, "c:\\eventlog.bak");

	// 关闭事件日志
	CloseEventLog(h); 


	return 0;
}

