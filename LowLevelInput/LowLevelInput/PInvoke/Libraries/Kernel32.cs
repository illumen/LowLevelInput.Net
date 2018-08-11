using System;
using System.Security;
using System.Runtime.InteropServices;

using LowLevelInput.PInvoke.Types;

namespace LowLevelInput.PInvoke.Libraries
{
    [SuppressUnmanagedCodeSecurity()]
    internal static class Kernel32
    {
        public static GetCurrentThreadId_t GetCurrentThreadId = WinApi.GetMethod<GetCurrentThreadId_t>("kernel32.dll", "GetCurrentThreadId");
        public static CloseHandle_t CloseHandle = WinApi.GetMethod<CloseHandle_t>("kernel32.dll", "CloseHandle");
        public static OpenProcess_t OpenProcess = WinApi.GetMethod<OpenProcess_t>("kernel32.dll", "OpenProcess");
        public static VirtualAllocEx_t VirtualAllocEx = WinApi.GetMethod<VirtualAllocEx_t>("kernel32.dll", "VirtualAllocEx");
        public static VirtualProtect_t VirtualProtect = WinApi.GetMethod<VirtualProtect_t>("kernel32.dll", "VirtualProtect");
        public static ReadProcessMemory_t ReadProcessMemory = WinApi.GetMethod<ReadProcessMemory_t>("kernel32.dll", "ReadProcessMemory");
        public static WriteProcessMemory_t WriteProcessMemory = WinApi.GetMethod<WriteProcessMemory_t>("kernel32.dll", "WriteProcessMemory");

        public delegate uint GetCurrentThreadId_t();
        public delegate int CloseHandle_t(IntPtr hObject);
        public delegate IntPtr OpenProcess_t(ProcessAccessFlags processAccessFlags, int bInheritHandle, int processId);
        public delegate IntPtr VirtualAllocEx_t(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, AllocationType allocationType, MemoryProtectionFlags memoryProtectionFlags);
        public delegate int VirtualProtect_t(IntPtr lpAddress, IntPtr dwSize, MemoryProtectionFlags flNewProtect, ref MemoryProtectionFlags lpflOldProtect);
        public delegate int ReadProcessMemory_t(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);
        public delegate int WriteProcessMemory_t(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);
    }
}