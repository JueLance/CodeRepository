// HeapCreate.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include <iostream.h>


int main(int argc, char* argv[])
{
	//������
	HANDLE hHeap = HeapCreate(
		HEAP_GENERATE_EXCEPTIONS,	//�ų�����
		10 << 10,					//��ʼ��10K
		10 << 20);					//��ֹ��10K
	if(hHeap != NULL)
	{
		//�����Ŀ�
		LPVOID pLarge = HeapAlloc(
			hHeap,
			HEAP_ZERO_MEMORY,
			1024);
		//����С�Ŀ�
		LPVOID pSmall = HeapAlloc(
			hHeap,
			HEAP_ZERO_MEMORY,
			1);
		PROCESS_HEAP_ENTRY phe;
		ZeroMemory(&phe, sizeof(phe));
		HeapLock(hHeap);
		while(HeapWalk(hHeap, &phe))
		{
			if(phe.lpData == pLarge)
			{
				cout<<"Found large block"<<endl;
			}
			else if(phe.lpData == pSmall)
			{
				cout<<"Found small block"<<endl;
			}
			else
			{
				cout<<"Anonymous block"<<endl;
			}
		}
		HeapUnlock(hHeap);
		HeapFree(hHeap, 0, pLarge);
		pLarge = NULL;
		HeapFree(hHeap, 0, pSmall);
		pSmall = NULL;
	}

	return 0;
}
