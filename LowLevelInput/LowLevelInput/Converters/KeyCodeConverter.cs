﻿using System.Collections.Generic;

using LowLevelInput.Hooks;

namespace LowLevelInput.Converters
{
    /// <summary>
    ///     Provides converter methods for VirtualKeyCodes
    /// </summary>
    public static class KeyCodeConverter
    {
        private static readonly string[] KeyCodeMap =
        {
            "HOTKEY",
            "LBUTTON",
            "RBUTTON",
            "CANCEL",
            "MBUTTON",
            "XBUTTON1",
            "XBUTTON2",
            "",
            "BACK",
            "TAB",
            "",
            "",
            "CLEAR",
            "RETURN",
            "",
            "",
            "SHIFT",
            "CONTROL",
            "MENU",
            "PAUSE",
            "CAPITAL",
            "HANGUL",
            "HANGUL",
            "JUNJA",
            "FINAL",
            "HANJA",
            "HANJA",
            "ESCAPE",
            "CONVERT",
            "NONCONVERT",
            "ACCEPT",
            "MODECHANGE",
            "SPACE",
            "PRIOR",
            "NEXT",
            "END",
            "HOME",
            "LEFT",
            "UP",
            "RIGHT",
            "DOWN",
            "SELECT",
            "PRINT",
            "EXECUTE",
            "SNAPSHOT",
            "INSERT",
            "DELETE",
            "HELP",
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "LWIN",
            "RWIN",
            "APPS",
            "",
            "SLEEP",
            "NUMPAD0",
            "NUMPAD1",
            "NUMPAD2",
            "NUMPAD3",
            "NUMPAD4",
            "NUMPAD5",
            "NUMPAD6",
            "NUMPAD7",
            "NUMPAD8",
            "NUMPAD9",
            "MULTIPLY",
            "ADD",
            "SEPARATOR",
            "SUBTRACT",
            "DECIMAL",
            "DIVIDE",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "NUMLOCK",
            "SCROLL",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "LSHIFT",
            "RSHIFT",
            "LCONTROL",
            "RCONTROL",
            "LMENU",
            "RMENU",
            "BROWSER_BACK",
            "BROWSER_FORWARD",
            "BROWSER_REFRESH",
            "BROWSER_STOP",
            "BROWSER_SEARCH",
            "BROWSER_FAVORITES",
            "BROWSER_HOME",
            "VOLUME_MUTE",
            "VOLUME_DOWN",
            "VOLUME_UP",
            "MEDIA_NEXT_TRACK",
            "MEDIA_PREV_TRACK",
            "MEDIA_STOP",
            "MEDIA_PLAY_PAUSE",
            "LAUNCH_MAIL",
            "LAUNCH_MEDIA_SELECT",
            "LAUNCH_APP1",
            "LAUNCH_APP2",
            "",
            "",
            "OEM_1",
            "OEM_PLUS",
            "OEM_COMMA",
            "OEM_MINUS",
            "OEM_PERIOD",
            "OEM_2",
            "OEM_3",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "OEM_4",
            "OEM_5",
            "OEM_6",
            "OEM_7",
            "OEM_8",
            "",
            "",
            "OEM_102",
            "",
            "",
            "PROCESSKEY",
            "",
            "PACKET",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "ATTN",
            "CRSEL",
            "EXSEL",
            "EREOF",
            "PLAY",
            "ZOOM",
            "NONAME",
            "PA1",
            "OEM_CLEAR"
        };

        /// <summary>
        ///     Enumerates <c>VirtualKeyCode</c> and it's <c>string</c> representation.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<VirtualKeyCode, string>> EnumerateVirtualKeyCodes()
        {
            for (int i = 0; i < KeyCodeMap.Length; i++)
            {
                if (string.IsNullOrEmpty(KeyCodeMap[i])) continue;
                if (string.IsNullOrWhiteSpace(KeyCodeMap[i])) continue;

                yield return new KeyValuePair<VirtualKeyCode, string>((VirtualKeyCode) i, KeyCodeMap[i]);
            }
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents a <c>VirtualKeyCode</c>.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>A <see cref="System.String" /> that represents a <c>VirtualKeyCode</c>.</returns>
        public static string ToString(VirtualKeyCode code)
        {
            int index = (int) code;

            if (index < 0) return string.Empty;
            if (index >= KeyCodeMap.Length) return string.Empty;

            return KeyCodeMap[index];
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public static string ToString(int index)
        {
            if (index < 0) return string.Empty;
            if (index >= KeyCodeMap.Length) return string.Empty;

            return KeyCodeMap[index];
        }

        /// <summary>
        ///     Converts a string to it's corresponding VirtualKeyCode
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static VirtualKeyCode ToVirtualKeyCode(string name)
        {
            if (string.IsNullOrEmpty(name)) return VirtualKeyCode.Invalid;
            if (string.IsNullOrWhiteSpace(name)) return VirtualKeyCode.Invalid;

            string tmp = name.ToUpper();

            for (int i = 0; i < KeyCodeMap.Length; i++)
                if (tmp == KeyCodeMap[i]) return (VirtualKeyCode) i;

            return VirtualKeyCode.Invalid;
        }

        /// <summary>
        ///     To the virtual key code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static VirtualKeyCode ToVirtualKeyCode(int code)
        {
            if (code < 0) return VirtualKeyCode.Invalid;
            if (code >= KeyCodeMap.Length) return VirtualKeyCode.Invalid;

            return (VirtualKeyCode) code;
        }
    }
}