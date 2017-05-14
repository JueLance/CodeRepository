// InvertRectDlg.h : header file
//

#if !defined(AFX_INVERTRECTDLG_H__2008E8B3_8609_4B4C_99C4_4322873FD8E7__INCLUDED_)
#define AFX_INVERTRECTDLG_H__2008E8B3_8609_4B4C_99C4_4322873FD8E7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CInvertRectDlg dialog

class CInvertRectDlg : public CDialog
{
// Construction
public:
	CInvertRectDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CInvertRectDlg)
	enum { IDD = IDD_INVERTRECT_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CInvertRectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CInvertRectDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnInvertrect();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_INVERTRECTDLG_H__2008E8B3_8609_4B4C_99C4_4322873FD8E7__INCLUDED_)
