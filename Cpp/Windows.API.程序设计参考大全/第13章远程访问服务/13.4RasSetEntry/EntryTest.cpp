// RasTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "windows.h"
#include "Ras.h"
#include "WinError.h"

bool NewEntryTest(PCHAR lpszName)
{
	DWORD dwSize,
		dwError;
	TCHAR szError[100];
	RASENTRY RasEntry;
	RASDIALPARAMS  RasDialParams;

	// 验证连接条目名称的格式
	if (dwError = RasValidateEntryName (NULL, lpszName))
	{
		wsprintf (szError, TEXT("连接条目名称的格式有误！")
					TEXT(" Error %ld"), dwError);  
		return FALSE;
	}

	// 初始化 RASENTRY 结构
	memset(&RasEntry, 0, sizeof (RASENTRY));

	dwSize = sizeof (RASENTRY);
	RasEntry.dwSize = dwSize;

	// 获取条目属性
	if (dwError = RasGetEntryProperties (NULL, TEXT(""),      
						&RasEntry, &dwSize, NULL, NULL))  
	{
		wsprintf (szError, TEXT("无法获取缺省条目属性！")
					TEXT(" Error %ld"), dwError);
		return FALSE;
	}

	// 此处插入填充RASENTRY结构的代码.
	// ...

	// 创建新的电话簿条目
	if (dwError = RasSetEntryProperties (NULL, lpszName, 
						&RasEntry, sizeof (RASENTRY), NULL, 0))
	{
		wsprintf (szError, TEXT("无法创建电话簿条目属性！")
					TEXT(" Error %ld"), dwError);
		return FALSE;
	}

	// 初始化 RASDIALPARAMS 结构
	memset (&RasDialParams, 0, sizeof (RASDIALPARAMS));
	RasDialParams.dwSize = sizeof (RASDIALPARAMS);
	_tcscpy (RasDialParams.szEntryName, lpszName);

	// 此处插入填充 RASDIALPARAMS 结构的代码
	// ...

	// 修改连接
	if (dwError = RasSetEntryDialParams (NULL, &RasDialParams, FALSE))
	{
		wsprintf (szError, TEXT("无法设置连接信息！")
					TEXT(" Error %ld"), dwError);
		return FALSE;
	}

	return TRUE;
}

bool DeleteEntry(PCHAR lpszName)
{
	int nRet = RasDeleteEntry(NULL, lpszName);
	if (nRet != ERROR_SUCCESS)
	{
		printf("RasDeleteEntry failed: Error = %d\n", nRet);
		return FALSE;
	}
	else
	{
		printf("Entry %s deleted successfully\n", lpszName);
		return TRUE;
	}
}

bool RenameEntry()
{
	DWORD dwErr = ERROR_SUCCESS;
    PCHAR pszOldName = "RAS Connection 1";
    PCHAR pszNewName = "RAS Connection 2";
    
	dwErr = RasValidateEntryName(NULL, pszNewName);
    if (ERROR_SUCCESS != dwErr)
    {
        printf("RasValidateEntryName failed: Error = %d\n", dwErr);
        return FALSE;
    }
	RasRenameEntry(NULL, pszOldName, pszNewName);
	return TRUE;
}

void EnumEntris()
{
    DWORD dwCb = sizeof(RASENTRYNAME);
    DWORD dwErr = ERROR_SUCCESS;
    DWORD dwRetries = 5;
    DWORD dwEntries = 0;
    RASENTRYNAME* lpRasEntryName = NULL;

    //
    // Loop through in case the information from RAS changes between calls.
    //
    while (dwRetries--)
    {
        //
        // If the memory is allocated, free it.
        //
        if (NULL != lpRasEntryName)
        {
            HeapFree(GetProcessHeap(), 0, lpRasEntryName);
            lpRasEntryName = NULL;
        }
        //
        // Allocate the size need for the RAS structure.
        //
        lpRasEntryName = (RASENTRYNAME*)HeapAlloc(GetProcessHeap(), 0, dwCb);
        if (NULL == lpRasEntryName)
        {
            dwErr = ERROR_NOT_ENOUGH_MEMORY;
            break;
        }
        //
        // Set the structure size for version checking purposes.
        //
        lpRasEntryName->dwSize = sizeof(RASENTRYNAME);
        //
        // Call the RAS API, bail on the loop if we are successful or an unknown
        // error occurs.
        //
        dwErr = RasEnumEntries(
                    NULL,
                    NULL,
                    lpRasEntryName,
                    &dwCb,
                    &dwEntries);
    }
    //
    // In the success case print the names of the entries.
    //
    if (ERROR_SUCCESS == dwErr)
    {
        DWORD i;

        printf("Phone-book entries in the default phone book:\n\n");
        for (i = 0; i < dwEntries; i++)
        {
            printf("%s\n", lpRasEntryName[i].szEntryName);
        }
    }
    else
    {
        printf("RasEnumEntries failed: Error = %d\n", dwErr);
    }
    //
    // Free the memory if necessary.
    //
    if (NULL != lpRasEntryName)
    {
        HeapFree(GetProcessHeap(), 0, lpRasEntryName);
        lpRasEntryName = NULL;
    }
}


int _tmain(int argc, _TCHAR* argv[])
{
	NewEntryTest("RAS Connection 1");
	RenameEntry();
	DeleteEntry("RAS Connection 2");
	EnumEntris();
}



