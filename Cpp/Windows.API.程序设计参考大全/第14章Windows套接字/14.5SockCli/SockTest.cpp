// SockTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "Winsock2.h"

SOCKET sk;
int err;

void SendTest()
{
	// 	发送数据
	char szTest[]= "This is an example!";
	int iRet;
	iRet= send(sk,szTest,strlen(szTest),0);
	if(iRet==SOCKET_ERROR)
	{
		//错误处理 
	}
	else if(iRet!=strlen(szTest))
		printf("未发送所有的数据.\n");   

	// 分配发送缓冲区
	char *sendbuf = NULL;
	DWORD dwLength = 64;
	SOCKADDR_IN recipient;

	sendbuf = (char *)GlobalAlloc(GMEM_FIXED, dwLength);
	if (!sendbuf)
	{
		// ... 错误检查
	}
	memset(sendbuf, 'a', dwLength);

	for(int i = 0; i < 10; i++)
	{
		err = sendto(sk, sendbuf, dwLength, 0, (SOCKADDR *)&recipient, sizeof(recipient));
		if (err == SOCKET_ERROR) 
		{
			// 错误处理
		}
		else if (err == 0)
			break;
		else
		{
			// sendto()成功
		}
	}
	GlobalFree(sendbuf);
}

void RecvTest()
{
	int iRet;
	// 接收数据
	char szRecv[20];
	iRet = recv(sk,szRecv,20,0);
	if(iRet==SOCKET_ERROR)
	{
		//错误处理
	}
	szRecv[iRet]='\0';  // 因为recv函数不会自动将数据缓冲末尾设为空中止符('\0')，
						// 也可以在调用recv函数前先将缓冲区清0(用ZeroMemory或memset)

}

void GetNameTest()
{
	sockaddr_in addr;
	unsigned int addr_len = sizeof(addr);

	// 获取本地的套接字地址信息
	if (getsockname(sk, (sockaddr *) &addr, (int *) &addr_len) < 0) 
	{
		// …处理错误
	}
	else 
	{
		// 处理addr信息
	}

	// 获取对方的套接字地址信息
	if (getpeername(sk, (sockaddr *) &addr, (int *) &addr_len) < 0) 
	{
		// …处理错误
	}
	else 
		{
			// 处理addr信息
		}


}



int _tmain(int argc, _TCHAR* argv[])
{
	WORD wVersionRequested;
	WSADATA wsaData;
	
	 
	wVersionRequested = MAKEWORD( 2, 2 );
	 
	err = WSAStartup(wVersionRequested, &wsaData);
	if ( err != 0 ) {
		printf("无法找到可用的WinSock DLL.\n");   
		return -1;
	}
	else
		printf("成功初始化Windows Sockets2.2版本.\n");   
	
	sk = socket(AF_INET, SOCK_STREAM, 0);
	if(sk== SOCKET_ERROR)
	{
		// 错误处理
	}
	else
		printf("成功创建socket.\n");   



	sockaddr_in sock;

	sock.sin_family = AF_INET;
	sock.sin_port = htons(80);
	sock.sin_addr.s_addr = inet_addr("202.205.210.1");
	if (connect(sk, (sockaddr*) &sock, sizeof(sock) == SOCKET_ERROR))
	{
		//错误处理 
	}



	// 从容关闭
	if(shutdown(sk, SD_SEND) != SOCKET_ERROR)
	{
		char buf[1024];
		int nRecv = 0;
		do
		{
			nRecv = recv(sk, buf, 1024, 0);
		} while (!(nRecv == 0 || nRecv == SOCKET_ERROR));
	}

	err = WSAGetLastError();
	// ...处理nResult 

	// 关闭
	closesocket(sk);

	WSACleanup();

	return 0;
}

