// SockTest.cpp : �������̨Ӧ�ó������ڵ㡣
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
		printf("�޷��ҵ����õ�WinSock DLL.\n");   
		return -1;
	}
	else
		printf("�ɹ���ʼ��Windows Sockets2.2�汾.\n");   
	
	SOCKET hServer;

	hServer = socket(AF_INET, SOCK_STREAM, 0);
	if(hServer== SOCKET_ERROR)
	{
		// ������
	}
	else
		printf("�ɹ�����server socket.\n");   


	//���ip��ַ�Ľṹ��
	sockaddr_in local;

	// ����������ip��ַ�Ͷ˿ں�
	local.sin_family=AF_INET; //Address family
	local.sin_addr.s_addr=INADDR_ANY; //Wild card IP address
	local.sin_port=htons((u_short)8888); //port to use

	// �󶨷�������ip��ַ�Ͷ˿ں�
	if(bind(hServer, (sockaddr*)&local, sizeof(local))!=0)
	{
		return 0;
	}

	// �����ͻ����������ͬʱ������10
	if(listen(hServer, 10) != 0)
	{
		return 0;
	}

	SOCKET client;
	sockaddr_in from;
	PCHAR temp = NULL;
	int fromlen = sizeof(from);

	// ����һ���������󣬲�����һ��ͬ�ͻ��˽�����socket������client
	client = accept(hServer, (struct sockaddr*)&from, &fromlen);
	// �õ��ͻ��˵�ip��ַ����д�뻺����
	sprintf(temp, "Your IP is %s\r\n", inet_ntoa(from.sin_addr));



	// ���ݹر�
	if(shutdown(hServer, SD_SEND) != SOCKET_ERROR)
	{
		char buf[1024];
		int nRecv = 0;
		do
		{
			nRecv = recv(hServer, buf, 1024, 0);
		} while (!(nRecv == 0 || nRecv == SOCKET_ERROR));
	}

	// �ر�
	closesocket(hServer);



	WSACleanup();

	return 0;
}

