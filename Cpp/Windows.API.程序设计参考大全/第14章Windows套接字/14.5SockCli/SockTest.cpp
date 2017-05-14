// SockTest.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "Winsock2.h"

SOCKET sk;
int err;

void SendTest()
{
	// 	��������
	char szTest[]= "This is an example!";
	int iRet;
	iRet= send(sk,szTest,strlen(szTest),0);
	if(iRet==SOCKET_ERROR)
	{
		//������ ��
	}
	else if(iRet!=strlen(szTest))
		printf("δ�������е�����.\n");   

	// ���䷢�ͻ�����
	char *sendbuf = NULL;
	DWORD dwLength = 64;
	SOCKADDR_IN recipient;

	sendbuf = (char *)GlobalAlloc(GMEM_FIXED, dwLength);
	if (!sendbuf)
	{
		// ... ������
	}
	memset(sendbuf, 'a', dwLength);

	for(int i = 0; i < 10; i++)
	{
		err = sendto(sk, sendbuf, dwLength, 0, (SOCKADDR *)&recipient, sizeof(recipient));
		if (err == SOCKET_ERROR) 
		{
			// ������
		}
		else if (err == 0)
			break;
		else
		{
			// sendto()�ɹ�
		}
	}
	GlobalFree(sendbuf);
}

void RecvTest()
{
	int iRet;
	// ��������
	char szRecv[20];
	iRet = recv(sk,szRecv,20,0);
	if(iRet==SOCKET_ERROR)
	{
		//������
	}
	szRecv[iRet]='\0';  // ��Ϊrecv���������Զ������ݻ���ĩβ��Ϊ����ֹ��('\0')��
						// Ҳ�����ڵ���recv����ǰ�Ƚ���������0(��ZeroMemory��memset)

}

void GetNameTest()
{
	sockaddr_in addr;
	unsigned int addr_len = sizeof(addr);

	// ��ȡ���ص��׽��ֵ�ַ��Ϣ
	if (getsockname(sk, (sockaddr *) &addr, (int *) &addr_len) < 0) 
	{
		// ���������
	}
	else 
	{
		// ����addr��Ϣ
	}

	// ��ȡ�Է����׽��ֵ�ַ��Ϣ
	if (getpeername(sk, (sockaddr *) &addr, (int *) &addr_len) < 0) 
	{
		// ���������
	}
	else 
		{
			// ����addr��Ϣ
		}


}



int _tmain(int argc, _TCHAR* argv[])
{
	WORD wVersionRequested;
	WSADATA wsaData;
	
	 
	wVersionRequested = MAKEWORD( 2, 2 );
	 
	err = WSAStartup(wVersionRequested, &wsaData);
	if ( err != 0 ) {
		printf("�޷��ҵ����õ�WinSock DLL.\n");   
		return -1;
	}
	else
		printf("�ɹ���ʼ��Windows Sockets2.2�汾.\n");   
	
	sk = socket(AF_INET, SOCK_STREAM, 0);
	if(sk== SOCKET_ERROR)
	{
		// ������
	}
	else
		printf("�ɹ�����socket.\n");   



	sockaddr_in sock;

	sock.sin_family = AF_INET;
	sock.sin_port = htons(80);
	sock.sin_addr.s_addr = inet_addr("202.205.210.1");
	if (connect(sk, (sockaddr*) &sock, sizeof(sock) == SOCKET_ERROR))
	{
		//������ ��
	}



	// ���ݹر�
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
	// ...����nResult 

	// �ر�
	closesocket(sk);

	WSACleanup();

	return 0;
}

