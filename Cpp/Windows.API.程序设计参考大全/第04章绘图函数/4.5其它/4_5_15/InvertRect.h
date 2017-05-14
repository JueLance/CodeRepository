// InvertRect.h : main header file for the INVERTRECT application
//

#if !defined(AFX_INVERTRECT_H__BF2294BD_CA33_4621_AA7E_83EB0EB02349__INCLUDED_)
#define AFX_INVERTRECT_H__BF2294BD_CA33_4621_AA7E_83EB0EB02349__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CInvertRectApp:
// See InvertRect.cpp for the implementation of this class
//

class CInvertRectApp : public CWinApp
{
public:
	CInvertRectApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CInvertRectApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CInvertRectApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_INVERTRECT_H__BF2294BD_CA33_4621_AA7E_83EB0EB02349__INCLUDED_)
