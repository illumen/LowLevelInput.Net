using System;
using System.Diagnostics;

using LowLevelInput.PInvoke;
using LowLevelInput.PInvoke.Libraries;
using LowLevelInput.PInvoke.Types;

namespace LowLevelInput.DebuggerSupport
{
    /// <summary>
    /// 
    /// </summary>
    public static class DebugHelper
    {
        private static object _lock = new object();

        private static bool _x64 = IntPtr.Size != 4;

        private static IntPtr _shellcode_ptr;
        private static IntPtr _thread_id_blacklist_ptr;
        private static IntPtr _blacklist_table_size;

        /// <summary>
        /// JMP [Address] // &Address
        /// </summary>
        private static byte[] JMP_BYTES = new byte[] { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };

        /// <summary>
        /// Enables the debug support.
        /// </summary>
        public static void EnableDebugSupport()
        {
            if (_x64)
            {
                _enable_debug_support_x64();
            }
            else
            {
                _enable_debug_support_x86();
            }
        }

        internal static void AddThreadId(uint thread_id)
        {
            if (_thread_id_blacklist_ptr == IntPtr.Zero) return;
            if (_blacklist_table_size == IntPtr.Zero) return;

            lock (_lock)
            {
                if (_x64)
                {
                    _add_thread_id_x64(thread_id);
                }
                else
                {
                    _add_thread_id_x86(thread_id);
                }
            }
        }

        internal static void RemoveThreadId(uint thread_id)
        {
            if (_thread_id_blacklist_ptr == IntPtr.Zero) return;
            if (_blacklist_table_size == IntPtr.Zero) return;

            lock (_lock)
            {
                if (_x64)
                {
                    _remove_thread_id_x64(thread_id);
                }
                else
                {
                    _remove_thread_id_x86(thread_id);
                }
            }
        }

        private static void _enable_debug_support_x86()
        {
            IntPtr hProcess = Kernel32.OpenProcess(ProcessAccessFlags.VirtualMemoryOperation | ProcessAccessFlags.VirtualMemoryRead | ProcessAccessFlags.VirtualMemoryWrite, 0, Process.GetCurrentProcess().Id);

            byte[] shellcode = Shellcode.GetShellcode();

            _shellcode_ptr = Kernel32.VirtualAllocEx(hProcess, IntPtr.Zero, shellcode.Length, AllocationType.Commit | AllocationType.Reserve, MemoryProtectionFlags.ExecuteReadWrite);
            _thread_id_blacklist_ptr = Kernel32.VirtualAllocEx(hProcess, IntPtr.Zero, 1024, AllocationType.Commit | AllocationType.Reserve, MemoryProtectionFlags.ExecuteReadWrite);
            _blacklist_table_size = Kernel32.VirtualAllocEx(hProcess, IntPtr.Zero, 1024, AllocationType.Commit | AllocationType.Reserve, MemoryProtectionFlags.ExecuteReadWrite);

            Kernel32.WriteProcessMemory(hProcess, _shellcode_ptr, shellcode, shellcode.Length, IntPtr.Zero);

            Kernel32.WriteProcessMemory(hProcess, _shellcode_ptr + Shellcode.GetBlacklistPlaceholderOffset(), BitConverter.GetBytes(_thread_id_blacklist_ptr.ToInt32()), 4, IntPtr.Zero);

        }

        private static void _enable_debug_support_x64()
        {

        }

        private static void _add_thread_id_x86(uint thread_id)
        {

        }

        private static void _add_thread_id_x64(uint thread_id)
        {

        }

        private static void _remove_thread_id_x86(uint thread_id)
        {

        }

        private static void _remove_thread_id_x64(uint thread_id)
        {

        }
    }
}
