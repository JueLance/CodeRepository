// HeapCreate.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include <iostream.h>


int main(int argc, char* argv[])
{
	//创建堆
	HANDLE hHeap = HeapCreate(
		HEAP_GENERATE_EXCEPTIONS,	//排除例外
		10 << 10,					//起始于10K
		10 << 20);					//终止于10K
	if(hHeap != NULL)
	{
		//分配大的块
		LPVOID pLarge = HeapAlloc(
			hHeap,
			HEAP_ZERO_MEMORY,
			1024);
		//分配小的块
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
