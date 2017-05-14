#include "stdafx.h"
#include "windows.h"
#include "winbase.h"
#include "WinError.h"

int main(int argc, char* argv[])
{
    // �����Ըý���ʱ��ִ�е������ʱ����Output����������"DebugString"
    OutputDebugString("DebugString");

	// ���ô������
	SetLastError(ERROR_INVALID_PARAMETER);
	DWORD Err = GetLastError(); 
	if(Err == ERROR_INVALID_PARAMETER) 
	{
		printf("GetLassError: %d.", Err);
	}
	
	// ���ô�����뼰����
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
	 
	// ��ʾ������Ϣ 
	MessageBox( NULL, (LPCTSTR)lpMsgBuf, "������Ϣ", MB_OK | MB_ICONINFORMATION ); 
	 
	// Free the buffer. 
	LocalFree( lpMsgBuf );


    // ��2000Hz��Ƶ�ʷ���1���beep
	Beep(2000, 1000);

	// ����MB_ICONQUESTION������
	MessageBeep(MB_ICONQUESTION);

	// ����������Ӧ�ó����˳��Ի���
    FatalAppExit(0, "�������󣬳��򼴽���ֹ��");

	return 0;
}