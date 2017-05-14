// FlashWindowExDlg.h : header file
//

#if !defined(AFX_FLASHWINDOWEXDLG_H__E338AB5B_EF75_4099_B45A_3E5088E3F7C7__INCLUDED_)
#define AFX_FLASHWINDOWEXDLG_H__E338AB5B_EF75_4099_B45A_3E5088E3F7C7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CFlashWindowExDlg dialog

class CFlashWindowExDlg : public CDialog
{
// Construction
public:
	CFlashWindowExDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CFlashWindowExDlg)
	enum { IDD = IDD_FLASHWINDOWEX_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFlashWindowExDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CFlashWindowExDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnFlashwindowex();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FLASHWINDOWEXDLG_H__E338AB5B_EF75_4099_B45A_3E5088E3F7C7__INCLUDED_)
