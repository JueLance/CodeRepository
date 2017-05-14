// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//
#include <windows.h>
#if !defined(AFX_STDAFX_H__20C5E672_7AD1_4899_9CE4_834F3D099C3A__INCLUDED_)
#define AFX_STDAFX_H__20C5E672_7AD1_4899_9CE4_834F3D099C3A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifdef __cplusplus
extern "C" {
#endif
WINBASEAPI
HANDLE
WINAPI
FindFirstVolumeA(
    LPTSTR lpszVolumeName,
	DWORD cchBufferLength
    );

WINBASEAPI
BOOL
WINAPI
FindNextVolumeA(
    HANDLE hFindVolume,
	LPTSTR lpszVolumeName,
	DWORD cchBufferLength
    );

WINBASEAPI
HANDLE
WINAPI
FindFirstVolumeW(
    LPTSTR lpszVolumeName,
	DWORD cchBufferLength
    );

WINBASEAPI
BOOL
WINAPI
FindNextVolumeW(
    HANDLE hFindVolume,
	LPTSTR lpszVolumeName,
	DWORD cchBufferLength
    );
#ifdef UNICODE
#define FindFirstVolume  FindFirstVolumeW
#else
#define FindFirstVolume  FindFirstVolumeA
#endif // !UNICODE

#ifdef UNICODE
#define FindNextVolume  FindNextVolumeW
#else
#define FindNextVolume  FindNextVolumeA
#endif // !UNICODE

WINBASEAPI
BOOL
WINAPI
FindVolumeClose(
    HANDLE hFindVolume
    );
#ifdef __cplusplus
};
#endif

// TODO: reference additional headers your program requires here

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__20C5E672_7AD1_4899_9CE4_834F3D099C3A__INCLUDED_)
