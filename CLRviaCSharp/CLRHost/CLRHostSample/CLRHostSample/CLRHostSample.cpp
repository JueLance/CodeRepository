// CLRHostSample.cpp : Defines the entry point for the console application.
//


#pragma once

#include "targetver.h"

#include <iostream>
#include <sstream>
#include <fstream>
#include <cmath>
#include <cstring>
#include <stdlib.h>
#include <stdio.h>
#include <errno.h>
#include <stdio.h>
#include <tchar.h>
#include <SDKDDKVer.h>
#include <windows.h>  

#include <metahost.h>  
#include <mscoree.h>  
#pragma comment(lib, "mscoree.lib")  


//int main()
//{
//    return 0;
//}

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    ICLRMetaHost        *pMetaHost = nullptr;
    ICLRMetaHostPolicy  *pMetaHostPolicy = nullptr;
    ICLRRuntimeHost     *pRuntimeHost = nullptr;
    ICLRRuntimeInfo     *pRuntimeInfo = nullptr;


    HRESULT hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*)&pMetaHost);

    hr = pMetaHost->GetRuntime(L"v4.0.30319", IID_PPV_ARGS(&pRuntimeInfo));

    if (FAILED(hr))
    {
        goto cleanup;
    }

    hr = pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_PPV_ARGS(&pRuntimeHost));

    hr = pRuntimeHost->Start();

    DWORD dwRet = 0;
    hr = pRuntimeHost->ExecuteInDefaultAppDomain(L"SampleManagedApp.exe",//程序集路径，需要在默认AppDomain中运行的程序
        L"SampleManagedApp.Program", //类名，需要完全限定
        L"Test",//方法名
        L"Hello World!",//方法参数
        &dwRet);//返回值

    cout <<"C# Console Application的返回值:"<< dwRet << endl;

    hr = pRuntimeHost->Stop();

    cin.get();

cleanup:
    if (pRuntimeInfo != nullptr)
    {
        pRuntimeInfo->Release();
        pRuntimeInfo = nullptr;
    }

    if (pRuntimeHost != nullptr)
    {
        pRuntimeHost->Release();
        pRuntimeHost = nullptr;
    }

    if (pMetaHost != nullptr)
    {
        pMetaHost->Release();
        pMetaHost = nullptr;
    }
}
