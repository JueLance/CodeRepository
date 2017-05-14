// SockTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "Winsock2.h"

int _tmain(int argc, _TCHAR* argv[])
{
	WORD wVersionRequested;
	WSADATA wsaData;
	int err;
	 
	wVersionRequested = MAKEWORD( 2, 2 );
	 
	err = WSAStartup(wVersionRequested, &wsaData);
	if ( err != 0 ) {
		printf("无法找到可用的WinSock DLL.\n");   
		return -1;
	}
	else
		printf("成功初始化Windows Sockets2.2版本.\n");   
	
	SOCKET hServer;

	hServer = socket(AF_INET, SOCK_STREAM, 0);
	if(hServer== SOCKET_ERROR)
	{
		// 错误处理
	}
	else
		printf("成功创建server socket.\n");   


	//存放ip地址的结构体
	sockaddr_in local;

	// 填充服务器的ip地址和端口号
	local.sin_family=AF_INET; //Address family
	local.sin_addr.s_addr=INADDR_ANY; //Wild card IP address
	local.sin_port=htons((u_short)8888); //port to use

	// 绑定服务器的ip地址和端口号
	if(bind(hServer, (sockaddr*)&local, sizeof(local))!=0)
	{
		return 0;
	}

	// 监听客户端请求，最大同时连接数10
	if(listen(hServer, 10) != 0)
	{
		return 0;
	}

	SOCKET client;
	sockaddr_in from;
	PCHAR temp = NULL;
	int fromlen = sizeof(from);

	// 接受一个连接请求，并返回一个同客户端交互的socket给变量client
	client = accept(hServer, (struct sockaddr*)&from, &fromlen);
	// 得到客户端的ip地址，并写入缓冲区
	sprintf(temp, "Your IP is %s\r\n", inet_ntoa(from.sin_addr));



	// 从容关闭
	if(shutdown(hServer, SD_SEND) != SOCKET_ERROR)
	{
		char buf[1024];
		int nRecv = 0;
		do
		{
			nRecv = recv(hServer, buf, 1024, 0);
		} while (!(nRecv == 0 || nRecv == SOCKET_ERROR));
	}

	// 关闭
	closesocket(hServer);



	WSACleanup();

	return 0;
}

