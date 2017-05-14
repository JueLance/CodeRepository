// FindFirstVolume.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream.h>


int main(int argc, char* argv[])
{
    char lpszVolumeName[256];
	HANDLE hVolume = FindFirstVolume(lpszVolumeName, 255);
	cout<<lpszVolumeName<<endl;
	while(FindNextVolume(hVolume, lpszVolumeName, 255))
	{
		cout<<lpszVolumeName<<endl;
	}
	FindVolumeClose(hVolume);

	return 0;
}
