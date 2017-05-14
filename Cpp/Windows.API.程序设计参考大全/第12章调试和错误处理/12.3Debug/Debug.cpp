#include "stdafx.h"
#include "windows.h"
#include "winbase.h"
#include "WinError.h"

int main(int argc, char* argv[])
{
    // 当调试该进程时，执行到该语句时将向Output窗口中输入"DebugString"
    OutputDebugString("DebugString");

	// 设置错误代码
	SetLastError(ERROR_INVALID_PARAMETER);
	DWORD Err = GetLastError(); 
	if(Err == ERROR_INVALID_PARAMETER) 
	{
		printf("GetLassError: %d.", Err);
	}
	
	// 设置错误代码及类型
	SetLastErrorEx(ERROR_INVALID_PARAMETER, SLE_ERROR);
	LPVOID lpMsgBuf; 
	FormatMessage( 
		FORMAT_MESSAGE_ALLOCATE_BUFFER | 
		FORMAT_MESSAGE_FROM_SYSTEM | 
		FORMAT_MESSAGE_IGNORE_INSERTS, 
		NULL, 
		GetLastError(), 
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), // Default language 
		(LPTSTR) &lpMsgBuf, 
		0, 
		NULL 
	); 
	 
	// 显示错误信息 
	MessageBox( NULL, (LPCTSTR)lpMsgBuf, "错误信息", MB_OK | MB_ICONINFORMATION ); 
	 
	// Free the buffer. 
	LocalFree( lpMsgBuf );


    // 以2000Hz的频率发出1秒的beep
	Beep(2000, 1000);

	// 播放MB_ICONQUESTION的声音
	MessageBeep(MB_ICONQUESTION);

	// 弹出致命的应用程序退出对话框
    FatalAppExit(0, "致命错误，程序即将终止。");

	return 0;
}