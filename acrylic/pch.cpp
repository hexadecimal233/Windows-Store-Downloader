// pch.cpp: 与预编译标头对应的源文件

#include "pch.h"


// 当使用预编译的头时，需要使用此源文件，编译才能成功。

void SetBlur(HWND hWnd,DWORD gradientColor)
{
    HMODULE hUser = GetModuleHandle(L"user32.dll");
    if (hUser)
    {   
        
        pfnSetWindowCompositionAttribute setWindowCompositionAttribute = (pfnSetWindowCompositionAttribute)GetProcAddress(hUser, "SetWindowCompositionAttribute");
        if (setWindowCompositionAttribute)
        {
            ACCENT_POLICY accent = { ACCENT_ENABLE_ACRYLICBLURBEHIND, 0, gradientColor, 0 };
            WINDOWCOMPOSITIONATTRIBDATA data;
            data.Attrib = WCA_ACCENT_POLICY;
            data.pvData = &accent;
            data.cbData = sizeof(accent);
            setWindowCompositionAttribute(hWnd, &data);
        }
    }
}