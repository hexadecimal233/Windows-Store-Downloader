using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace WinUtils
{
    public enum TaskDialogProgressBarState : int
    {
        PBST_NORMAL = 0x0001,
        PBST_ERROR = 0x0002,
        PBST_PAUSED = 0x0003
    }

    public enum TASKDIALOG_MESSAGES : uint
    {
        TDM_NAVIGATE_PAGE = 0x0400 + 101,
        TDM_CLICK_BUTTON = 0x0400 + 102, // wParam = Button ID
        TDM_SET_MARQUEE_PROGRESS_BAR = 0x0400 + 103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)
        TDM_SET_PROGRESS_BAR_STATE = 0x0400 + 104, // wParam = new progress state
        TDM_SET_PROGRESS_BAR_RANGE = 0x0400 + 105, // lParam = MAKELPARAM(nMinRange, nMaxRange)
        TDM_SET_PROGRESS_BAR_POS = 0x0400 + 106, // wParam = new position
        TDM_SET_PROGRESS_BAR_MARQUEE = 0x0400 + 107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
        TDM_SET_ELEMENT_TEXT = 0x0400 + 108, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
        TDM_CLICK_RADIO_BUTTON = 0x0400 + 110, // wParam = Radio Button ID
        TDM_ENABLE_BUTTON = 0x0400 + 111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
        TDM_ENABLE_RADIO_BUTTON = 0x0400 + 112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
        TDM_CLICK_VERIFICATION = 0x0400 + 113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
        TDM_UPDATE_ELEMENT_TEXT = 0x0400 + 114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
        TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = 0x0400 + 115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
        TDM_UPDATE_ICON = 0x0400 + 116  // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
    };

    public enum TASKDIALOG_FLAGS : int
    {
        TDF_ENABLE_HYPERLINKS = 0x0001,
        TDF_USE_HICON_MAIN = 0x0002,
        TDF_USE_HICON_FOOTER = 0x0004,
        TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,
        TDF_USE_COMMAND_LINKS = 0x0010,
        TDF_USE_COMMAND_LINKS_NO_ICON = 0x0020,
        TDF_EXPAND_FOOTER_AREA = 0x0040,
        TDF_EXPANDED_BY_DEFAULT = 0x0080,
        TDF_VERIFICATION_FLAG_CHECKED = 0x0100,
        TDF_SHOW_PROGRESS_BAR = 0x0200,
        TDF_SHOW_MARQUEE_PROGRESS_BAR = 0x0400,
        TDF_CALLBACK_TIMER = 0x0800,
        TDF_POSITION_RELATIVE_TO_WINDOW = 0x1000,
        TDF_RTL_LAYOUT = 0x2000,
        TDF_NO_DEFAULT_RADIO_BUTTON = 0x4000,
        TDF_CAN_BE_MINIMIZED = 0x8000,
        TDF_NO_SET_FOREGROUND = 0x00010000, // Don't call SetForegroundWindow() when activating the dialog
        TDF_SIZE_TO_CONTENT = 0x01000000  // used by ShellMessageBox to emulate MessageBox sizing behavior
    };

    public enum TASKDIALOG_COMMON_BUTTON_FLAGS : int
    {
        TDCBF_OK_BUTTON = 0x0001, // selected control return value IDOK
        TDCBF_YES_BUTTON = 0x0002, // selected control return value IDYES
        TDCBF_NO_BUTTON = 0x0004, // selected control return value IDNO
        TDCBF_CANCEL_BUTTON = 0x0008, // selected control return value IDCANCEL
        TDCBF_RETRY_BUTTON = 0x0010, // selected control return value IDRETRY
        TDCBF_CLOSE_BUTTON = 0x0020  // selected control return value IDCLOSE
    };

    public enum TASKDIALOG_ICON : int
    {
        TD_WARNING_ICON = 0xFFFF,
        TD_ERROR_ICON = 0xFFFE,
        TD_INFORMATION_ICON = 0xFFFD,
        TD_SHIELD_ICON = 0xFFFC,

        SecurityShieldBlue = ushort.MaxValue - 4,
        SecurityWarning = ushort.MaxValue - 5,
        SecurityError = ushort.MaxValue - 6,
        SecuritySuccess = ushort.MaxValue - 7,
        SecurityShieldGray = ushort.MaxValue - 8
    }

    public enum TASKDIALOG_NOTIFICATIONS : uint
    {
        TDN_CREATED = 0,
        TDN_NAVIGATED = 1,
        TDN_BUTTON_CLICKED = 2,            // wParam = Button ID
        TDN_HYPERLINK_CLICKED = 3,            // lParam = (LPCWSTR)pszHREF
        TDN_TIMER = 4,            // wParam = Milliseconds since dialog created or timer reset
        TDN_DESTROYED = 5,
        TDN_RADIO_BUTTON_CLICKED = 6,            // wParam = Radio Button ID
        TDN_DIALOG_CONSTRUCTED = 7,
        TDN_VERIFICATION_CLICKED = 8,             // wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0
        TDN_HELP = 9,
        TDN_EXPANDO_BUTTON_CLICKED = 10            // wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
    public struct TASKDIALOGCONFIG
    {
        public int cbSize;
        public IntPtr hwndParent;                             // incorrectly named, this is the owner window, not a parent.
        public IntPtr hInstance;                              // used for MAKEINTRESOURCE() strings
        [MarshalAs(UnmanagedType.I4)]
        public TASKDIALOG_FLAGS dwFlags;            // TASKDIALOG_FLAGS (TDF_XXX) flags
        [MarshalAs(UnmanagedType.I4)]
        public TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons;    // TASKDIALOG_COMMON_BUTTON (TDCBF_XXX) flags

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszWindowTitle;                         // string or MAKEINTRESOURCE()


        public IntPtr hMainIcon;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszMainInstruction;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszContent;
        public int cButtons;
        public IntPtr pButtons;
        public int nDefaultButton;
        public int cRadioButtons;
        public IntPtr pRadioButtons;
        public int nDefaultRadioButton;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszVerificationText;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszExpandedInformation;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszExpandedControlText;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszCollapsedControlText;

        public IntPtr hFooterIcon;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszFooter;
        public TDCallback pfCallback;
        public IntPtr lpCallbackData;
        public uint cxWidth;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
    public struct TASKDIALOG_BUTTON
    {
        public int nButtonID;
        public string pszButtonText;

        public TASKDIALOG_BUTTON(int ID, string Text)
        {
            nButtonID = ID;
            pszButtonText = Text;
        }
    };

    public delegate int TDCallback(IntPtr hwnd, TASKDIALOG_NOTIFICATIONS uNotification, IntPtr wParam, IntPtr lParam, IntPtr dwRefData);

    public class TaskDialogButton : TaskDialogButtonBase {
        public TaskDialogButton(TaskDialog parent, int ID, string Text) : base(parent, ID, Text)
        {
            base._radio = false;
        }

        protected bool _ShowShield = false;
        
        public bool ShowShield
        {
            get
            {
                return _ShowShield;
            }
            set
            {
                _ShowShield = value;

                if (_parent.hWnd != IntPtr.Zero)
                {
                    WinAPI.SendMessage(_parent.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE, (IntPtr)_config.nButtonID, _Enabled ? (IntPtr)1 : IntPtr.Zero);
                }
            }
        }
    }

    public class TaskDialogRadioButton : TaskDialogButtonBase {
        public TaskDialogRadioButton(TaskDialog parent, int ID, string Text) : base(parent, ID, Text)
        {
            base._radio = true;
        }
    }

    public abstract class TaskDialogButtonBase
    {
        protected TASKDIALOG_BUTTON _config;
        protected TaskDialog _parent;
        protected bool _Enabled = true;
        protected bool _radio;

        public TASKDIALOG_BUTTON Config
        {
            get
            {
                return _config;
            }
        }

        public TaskDialog Parent
        {
            get
            {
                return _parent;
            }
        }

        public bool Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                _Enabled = value;

                if (_parent.hWnd != IntPtr.Zero)
                {
                    if (_radio)
                        WinAPI.SendMessage(_parent.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_ENABLE_RADIO_BUTTON, (IntPtr)_config.nButtonID, _Enabled ? (IntPtr)1 : IntPtr.Zero);
                    else
                        WinAPI.SendMessage(_parent.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_ENABLE_BUTTON, (IntPtr)_config.nButtonID, _Enabled ? (IntPtr)1 : IntPtr.Zero);
                }
            }
        }

        public TaskDialogButtonBase(TaskDialog parent, int ID, string Text)
        {
            _config = new TASKDIALOG_BUTTON(ID, Text);
            _parent = parent;
        }
    }

    public class TaskDialog
    {
        public class CallBackArgs
        {
            private IntPtr _hwnd, _wParam, _lParam, _dwRefData;
            private TASKDIALOG_NOTIFICATIONS _uNotification;

            public CallBackArgs(IntPtr hwnd, TASKDIALOG_NOTIFICATIONS uNotification, IntPtr wParam, IntPtr lParam, IntPtr dwRefData)
            {
                _hwnd = hwnd;
                _uNotification = uNotification;
                _wParam = wParam;
                _lParam = lParam;
                _dwRefData = dwRefData;
            }
            public IntPtr hwnd
            {
                get
                {
                    return _hwnd;
                }
            }
            public TASKDIALOG_NOTIFICATIONS uNotification
            {
                get
                {
                    return _uNotification;
                }
            }
            public IntPtr wParam
            {
                get
                {
                    return _wParam;
                }
            }
            public IntPtr lParam
            {
                get
                {
                    return _lParam;
                }
            }
            public IntPtr dwRefData
            {
                get
                {
                    return _dwRefData;
                }
            }

            public object UserData = null;
            public int ReturnValue = 0;
            public bool SkipDefaultHandler = false;
        }
        public class TimerTickArgs
        {
            int _msSinceCreated;
            object _UserData;
            public TimerTickArgs(object UserData, int msSinceCreated)
            {
                _msSinceCreated = msSinceCreated;
                _UserData = UserData;
            }
            public object UserData
            {
                get
                {
                    return _UserData;
                }
            }
            public int msSinceCreated
            {
                get
                {
                    return _msSinceCreated;
                }
            }
            public bool Reset = false;
        }
        public class ButtonClickedArgs
        {
            int _ID;
            object _UserData;
            public ButtonClickedArgs(object UserData, int ID)
            {
                _UserData = UserData;
                _ID = ID;
            }
            public object UserData
            {
                get
                {
                    return _UserData;
                }
            }
            public int ID
            {
                get
                {
                    return _ID;
                }
            }
            public bool PreventClosing = false;
        }

        public delegate void CallBackHandler(TaskDialog sender, CallBackArgs e);
        public delegate void ButtonClickHandler(TaskDialog sender, ButtonClickedArgs e);
        public delegate void HyperLinkClickedHandler(TaskDialog sender, object UserData, string url);
        public delegate void TimerTickHandler(TaskDialog sender, TimerTickArgs e);
        public delegate void CreateHandler(TaskDialog sender, object UserData);
        public delegate void DestroyHandler(TaskDialog sender, object UserData);
        public delegate void ConstructedHandler(TaskDialog sender, object UserData);
        public delegate void ExpandButtonClickedHandler(TaskDialog sender, object UserData, bool Expanded);
        public delegate void NavigatedHandler(TaskDialog sender, object UserData);
        public delegate void RadioButtonSelectedHandler(TaskDialog sender, object UserData, int ID);
        public delegate void CheckBoxClickedHandler(TaskDialog sender, object UserData, bool Checked);


        public event CallBackHandler OnCallBack;
        public event ButtonClickHandler OnButtonClicked;
        public event HyperLinkClickedHandler OnHyperLinkClicked;
        public event TimerTickHandler OnTimerTick;
        public event CreateHandler OnCreate;
        public event DestroyHandler OnDestroy;
        public event ConstructedHandler OnConstructed;
        public event ExpandButtonClickedHandler OnExpandButtonClicked;
        public event NavigatedHandler OnNavigated;
        public event RadioButtonSelectedHandler OnRadioButtonSelected;
        public event CheckBoxClickedHandler OnCheckBoxClicked;


        private TASKDIALOGCONFIG taskDialogConfig = new TASKDIALOGCONFIG();
        private bool _UseCustomIcon = false;
        private bool _UseCustomFooterIcon = false;

        public TaskDialog()
        {
            taskDialogConfig.cbSize = Marshal.SizeOf(typeof(TASKDIALOGCONFIG));
            taskDialogConfig.hInstance = IntPtr.Zero;
            taskDialogConfig.pfCallback = DefaultCallBackProc;
        }

        #region Icon
        /// <summary>
        /// Indicates whether the taskdialog uses a system pre-defined or a user-defined (handle) icon
        /// </summary>
        public bool UseCustomIcon
        {
            get
            {
                return _UseCustomIcon;
            }
        }

        /// <summary>
        /// Indicates whether the taskdialog uses a system pre-defined or a user-defined (handle) footer icon
        /// </summary>
        public bool UseCustomFooterIcon
        {
            get
            {
                return _UseCustomFooterIcon;
            }
        }

        /// <summary>
        /// Set the icon (handle) of the taskdialog, this property is not effective once the taskdialog is shown
        /// </summary>
        public IntPtr Icon
        {
            get
            {
                return taskDialogConfig.hMainIcon;
            }
            set
            {
                this._UseCustomIcon = true;
                taskDialogConfig.hMainIcon = value;
            }
        }

        /// <summary>
        /// Set the icon of the taskdialog, this property is not effective once the taskdialog is shown
        /// </summary>
        public void SetIcon(TASKDIALOG_ICON Icon)
        {
            this._UseCustomIcon = false;
            taskDialogConfig.hMainIcon = (IntPtr)Icon;
        }

        /// <summary>
        /// Set the footer icon (handle) of the taskdialog, this property is not effective once the taskdialog is shown
        /// </summary>
        public IntPtr FooterIcon
        {
            get
            {
                return taskDialogConfig.hFooterIcon;
            }
            set
            {
                this._UseCustomFooterIcon = true;
                taskDialogConfig.hFooterIcon = value;
            }
        }

        /// <summary>
        /// Set the footer icon of the taskdialog, this property is not effective once the taskdialog is shown
        /// </summary>
        public void SetFooterIcon(TASKDIALOG_ICON Icon)
        {
            this._UseCustomFooterIcon = false;
            taskDialogConfig.hFooterIcon = (IntPtr)Icon;
        }
        #endregion

        #region Text
        /// <summary>
        /// Set or retrieve the title of the taskdialog
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return taskDialogConfig.pszWindowTitle;
            }
            set
            {
                taskDialogConfig.pszWindowTitle = value;
            }
        }

        /// <summary>
        /// Set or retrieve the main instruction of the taskdialog
        /// </summary>
        public string MainInstruction
        {
            get
            {
                return taskDialogConfig.pszMainInstruction;
            }
            set
            {
                taskDialogConfig.pszMainInstruction = value;
                if (this.hWnd != IntPtr.Zero)
                {
                    IntPtr strAdd = Marshal.StringToHGlobalUni(taskDialogConfig.pszMainInstruction);
                    WinAPI.SendMessage(this.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_ELEMENT_TEXT, (IntPtr)3, strAdd);
                    Marshal.FreeHGlobal(strAdd);
                }
            }
        }

        /// <summary>
        /// Set or retrieve the content of the taskdialog
        /// </summary>
        public string Content
        {
            get
            {
                return taskDialogConfig.pszContent;
            }
            set
            {
                taskDialogConfig.pszContent = value;
                if (this.hWnd != IntPtr.Zero)
                {
                    IntPtr strAdd = Marshal.StringToHGlobalUni(taskDialogConfig.pszContent);
                    WinAPI.SendMessage(this.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_ELEMENT_TEXT, (IntPtr)0, strAdd);
                    Marshal.FreeHGlobal(strAdd);
                }
            }
        }

        /// <summary>
        /// Set or retrieve the expanded information of the taskdialog
        /// </summary>
        public string ExpandedInformation
        {
            get
            {
                return taskDialogConfig.pszExpandedInformation;
            }
            set
            {
                taskDialogConfig.pszExpandedInformation = value;
                if (this.hWnd != IntPtr.Zero)
                {
                    IntPtr strAdd = Marshal.StringToHGlobalUni(taskDialogConfig.pszExpandedInformation);
                    WinAPI.SendMessage(this.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_ELEMENT_TEXT, (IntPtr)1, strAdd);
                    Marshal.FreeHGlobal(strAdd);
                }
            }
        }

        /// <summary>
        /// Set or retrieve the expanded control text of the taskdialog
        /// </summary>
        public string ExpandedControlText
        {
            get
            {
                return taskDialogConfig.pszExpandedControlText;
            }
            set
            {
                taskDialogConfig.pszExpandedControlText = value;
            }
        }

        /// <summary>
        /// Set or retrieve the collapsed control text of the taskdialog
        /// </summary>
        public string CollapsedControlText
        {
            get
            {
                return taskDialogConfig.pszCollapsedControlText;
            }
            set
            {
                taskDialogConfig.pszCollapsedControlText = value;
            }
        }

        /// <summary>
        /// Set or retrieve the footer text of the taskdialog
        /// </summary>
        public string FooterText
        {
            get
            {
                return taskDialogConfig.pszFooter;
            }
            set
            {
                taskDialogConfig.pszFooter = value;
                if (this.hWnd != IntPtr.Zero)
                {
                    IntPtr strAdd = Marshal.StringToHGlobalUni(taskDialogConfig.pszFooter);
                    WinAPI.SendMessage(this.hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_ELEMENT_TEXT, (IntPtr)2, strAdd);
                    Marshal.FreeHGlobal(strAdd);
                }
            }
        }
        #endregion

        /// <summary>
        /// Set or retrieve the configuration of common buttons shown on the task dialog,
        /// changing this property after the taskdialog is shown will not affect its appearence
        /// </summary>
        public TASKDIALOG_COMMON_BUTTON_FLAGS CommonButtons
        {
            get
            {
                return taskDialogConfig.dwCommonButtons;
            }
            set
            {
                taskDialogConfig.dwCommonButtons = value;
            }
        }

        #region Buttons
        public bool UseCommandLinks = false;
        public bool RemoveCommandLinksIcons = false;

        private List<TaskDialogButton> Buttons = new List<TaskDialogButton>();

        public TaskDialogButton AddButton(int ID, string Text)
        {
            TaskDialogButton btn = new TaskDialogButton(this, ID, Text);
            Buttons.Add(btn);
            return btn;
        }

        public TaskDialogButton GetButton(int ID)
        {
            foreach (TaskDialogButton btn in Buttons)
                if (btn.Config.nButtonID == ID)
                {
                    return btn;
                }

            return null;
        }

        public void RemoveButton(TaskDialogButton btn)
        {
            Buttons.Remove(btn);
        }

        public void RemoveButton(int ID)
        {
            foreach (TaskDialogButton btn in Buttons)
                if (btn.Config.nButtonID == ID)
                {
                    Buttons.Remove(btn);
                }
        }

        public void RemoveAllButtons()
        {
            Buttons.Clear();
        }
        #endregion

        #region RadioButtons
        public bool NoDefaultRadioButton = false;

        public List<TaskDialogRadioButton> RadioButtons = new List<TaskDialogRadioButton>();

        public TaskDialogRadioButton AddRadioButton(int ID, string Text)
        {
            TaskDialogRadioButton btn = new TaskDialogRadioButton(this, ID, Text);
            RadioButtons.Add(btn);
            return btn;
        }

        public TaskDialogRadioButton GetRadioButton(int ID)
        {
            foreach (TaskDialogRadioButton btn in RadioButtons)
                if (btn.Config.nButtonID == ID)
                {
                    return btn;
                }

            return null;
        }

        public void RemoveRadioButton(TaskDialogRadioButton btn)
        {
            RadioButtons.Remove(btn);
        }

        public void RemoveRadioButton(int ID)
        {
            foreach (TaskDialogRadioButton btn in RadioButtons)
                if (btn.Config.nButtonID == ID)
                {
                    RadioButtons.Remove(btn);
                }
        }

        public void RemoveAllRadioButtons()
        {
            RadioButtons.Clear();
        }


        public int SelectedRadioButton
        {
            get
            {
                return taskDialogConfig.nDefaultRadioButton;
            }
            set
            {
                taskDialogConfig.nDefaultRadioButton = value;
            }
        }

        public int DefaultButton
        {
            get
            {
                return taskDialogConfig.nDefaultButton;
            }
            set
            {
                taskDialogConfig.nDefaultButton = value;
            }
        }
        #endregion

        #region CheckBox
        protected bool _CheckBoxChecked = false;

        public bool CheckBoxChecked
        {
            get
            {
                return _CheckBoxChecked;
            }
            set
            {
                _CheckBoxChecked = value;

                if (hWnd != IntPtr.Zero)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_CLICK_VERIFICATION, _CheckBoxChecked ? (IntPtr)1 : IntPtr.Zero, IntPtr.Zero);
            }
        }

        public void CheckBoxGetKeyBoardFocus()
        {
            if (hWnd != IntPtr.Zero)
                WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_CLICK_VERIFICATION, _CheckBoxChecked ? (IntPtr)1 : IntPtr.Zero, (IntPtr)1);
        }

        public string CheckBoxText
        {
            get
            {
                return taskDialogConfig.pszVerificationText;
            }
            set
            {
                taskDialogConfig.pszVerificationText = value;
            }
        }
        #endregion

        #region ProgressBar
        public bool ShowProgressBar = false;

        protected bool _MarqueeProgressBar = false;
        /// <summary>
        /// Indicates whether the progress bar of the task dialog should be displayed in marquee mode
        /// </summary>
        public bool MarqueeProgressBar
        {
            get
            {
                return _MarqueeProgressBar;
            }
            set
            {
                _MarqueeProgressBar = value;
                if (this.hWnd != IntPtr.Zero)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_MARQUEE_PROGRESS_BAR, _MarqueeProgressBar ? (IntPtr)1 : IntPtr.Zero, IntPtr.Zero);
            }
        }

        protected bool _MarqueeDisplayStarted = true;
        public bool MarqueeDisplayStarted
        {
            get
            {
                return _MarqueeDisplayStarted;
            }
            set
            {
                _MarqueeDisplayStarted = value;
                if (this.hWnd != IntPtr.Zero)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_PROGRESS_BAR_MARQUEE, _MarqueeDisplayStarted ? (IntPtr)1 : IntPtr.Zero, IntPtr.Zero);
            }
        }

        protected int _ProgressBarValue = 0;
        /// <summary>
        /// Set the value of the progress bar [0,100], this property is useless if using marquee mode
        /// </summary>
        public int ProgressBarValue
        {
            get
            {
                return _ProgressBarValue;
            }
            set
            {
                _ProgressBarValue = value;

                if (this.hWnd != IntPtr.Zero)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_PROGRESS_BAR_POS, (IntPtr)_ProgressBarValue, IntPtr.Zero);
            }
        }

        protected TaskDialogProgressBarState _ProgressBarState;
        /// <summary>
        /// Set the state of the progress bar, If using marquee mode, make sure set this to PBST_NORMAL
        /// </summary>
        public TaskDialogProgressBarState ProgressBarState
        {
            get
            {
                return _ProgressBarState;
            }
            set
            {
                _ProgressBarState = value;

                if (this.hWnd != IntPtr.Zero)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_PROGRESS_BAR_STATE, (IntPtr)_ProgressBarState, IntPtr.Zero);
            }
        }

        #endregion

        #region Misc
        public bool EnableHyperLinks = false;
        public bool ControlBox = true;
        public bool ExpandFooterArea = true;
        public bool ExpandFooterAreaByDefault = false;
        public bool EnableCallbackTimer = false;
        public bool PositionRelativeToParent = false;
        public bool MinimizeBox = false;
        public bool RTL = false;
        public IntPtr hWnd = IntPtr.Zero;

        public TDCallback DefaultCallBackProc
        {
            get
            {
                return DefaultCallBackHandler;
            }
        }

        public TDCallback CallBackProc
        {
            get
            {
                return taskDialogConfig.pfCallback;
            }
            set
            {
                taskDialogConfig.pfCallback = value;
            }
        }

        public IntPtr Tag
        {
            get
            {
                return taskDialogConfig.lpCallbackData;
            }
            set
            {
                taskDialogConfig.lpCallbackData = value;
            }
        }
        #endregion

        public int ShowDialog()
        {
            return ShowDialog(IntPtr.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShowDialog(IntPtr Parent)
        {
            taskDialogConfig.hwndParent = Parent;

            taskDialogConfig.dwFlags = 0;


            if (EnableHyperLinks) 
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_ENABLE_HYPERLINKS;

            if (_UseCustomIcon)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_USE_HICON_MAIN;

            if (_UseCustomFooterIcon)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_USE_HICON_FOOTER;

            if (ControlBox) 
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION;

            if (UseCommandLinks)
            {
                if (RemoveCommandLinksIcons)
                    taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS_NO_ICON;
                else
                    taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS;
            }
                
            if (ExpandFooterArea)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_EXPAND_FOOTER_AREA;

            if (ExpandFooterAreaByDefault)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_EXPANDED_BY_DEFAULT;

            if (_CheckBoxChecked)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_VERIFICATION_FLAG_CHECKED;

            if (ShowProgressBar)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_SHOW_PROGRESS_BAR;

            if (_MarqueeProgressBar)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_SHOW_MARQUEE_PROGRESS_BAR;

            if (EnableCallbackTimer)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_CALLBACK_TIMER;

            if (PositionRelativeToParent)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_POSITION_RELATIVE_TO_WINDOW;

            if (RTL)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_RTL_LAYOUT;

            if (NoDefaultRadioButton)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_NO_DEFAULT_RADIO_BUTTON;

            if (MinimizeBox)
                taskDialogConfig.dwFlags |= TASKDIALOG_FLAGS.TDF_CAN_BE_MINIMIZED;






            int size = Marshal.SizeOf(typeof(TASKDIALOG_BUTTON));
            taskDialogConfig.cButtons = Buttons.Count;
            taskDialogConfig.pButtons = Marshal.AllocHGlobal(Buttons.Count * size);
            IEnumerator ie = Buttons.GetEnumerator();
            int offset = 0;
            while (ie.MoveNext())
            {
                Marshal.StructureToPtr(((TaskDialogButton)ie.Current).Config, (IntPtr)((long)taskDialogConfig.pButtons + offset), false);
                offset += size;
            }

            taskDialogConfig.cRadioButtons = RadioButtons.Count;
            taskDialogConfig.pRadioButtons = Marshal.AllocHGlobal(RadioButtons.Count * size);
            ie = RadioButtons.GetEnumerator();
            offset = 0;
            while (ie.MoveNext())
            {
                Marshal.StructureToPtr(((TaskDialogRadioButton)ie.Current).Config, (IntPtr)((long)taskDialogConfig.pRadioButtons + offset), false);
                offset += size;
            }


            int nButtonPressed = 0;
            int pnRadioButton = 0;

            int ret = WinAPI.TaskDialogIndirect(ref taskDialogConfig, ref nButtonPressed, ref pnRadioButton, ref _CheckBoxChecked);

            taskDialogConfig.nDefaultRadioButton = pnRadioButton;

            Marshal.FreeHGlobal(taskDialogConfig.pButtons);
            Marshal.FreeHGlobal(taskDialogConfig.pRadioButtons);

            return nButtonPressed;
        }

        public int DefaultCallBackHandler(IntPtr hwnd, TASKDIALOG_NOTIFICATIONS uNotification, IntPtr wParam, IntPtr lParam, IntPtr dwRefData)
        {
            CallBackArgs args = new CallBackArgs(hwnd, uNotification, wParam, lParam, dwRefData);
            if (OnCallBack != null)
            {
                OnCallBack(this, args);

                if (args.SkipDefaultHandler)
                    return args.ReturnValue;
            }
      

            switch (uNotification)
            {
                case TASKDIALOG_NOTIFICATIONS.TDN_BUTTON_CLICKED:
                    if (OnButtonClicked != null)
                    {
                        ButtonClickedArgs barg = new ButtonClickedArgs(args.UserData, (int)wParam);
                        OnButtonClicked(this, barg);
                        return barg.PreventClosing ? 1 : 0;
                    }
                    else
                        return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_CREATED:
                    UpdateControlsOnCreate();
                    if (OnCreate != null)
                        OnCreate(this, args.UserData);
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_DESTROYED:
                    this.hWnd = IntPtr.Zero;
                    if (OnDestroy != null)
                        OnDestroy(this, args.UserData);
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_DIALOG_CONSTRUCTED:
                    this.hWnd = hwnd;
                    if (OnConstructed != null)
                        OnConstructed(this, args.UserData);
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_EXPANDO_BUTTON_CLICKED:
                    if (OnExpandButtonClicked != null)
                        OnExpandButtonClicked(this, args.UserData, wParam != IntPtr.Zero);
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_HYPERLINK_CLICKED:
                    if (OnHyperLinkClicked != null)
                        OnHyperLinkClicked(this, args.UserData, Marshal.PtrToStringUni(lParam));
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_NAVIGATED:
                    if (OnNavigated != null)
                        OnNavigated(this, args.UserData);
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_RADIO_BUTTON_CLICKED:
                    SelectedRadioButton = (int)wParam;
                    if (OnRadioButtonSelected != null)
                        OnRadioButtonSelected(this, args.UserData, SelectedRadioButton);
                    return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_TIMER:
                    if (OnTimerTick != null)
                    {
                        TimerTickArgs tArg = new TimerTickArgs(args.UserData, (int)wParam);
                        OnTimerTick(this, tArg);
                        return tArg.Reset ? 1 : 0;
                    }
                    else
                        return 0;

                case TASKDIALOG_NOTIFICATIONS.TDN_VERIFICATION_CLICKED:
                    if (OnCheckBoxClicked != null)
                        OnCheckBoxClicked(this, args.UserData, wParam != IntPtr.Zero);
                    return 0;

                default:
                    return 0;
            }
        }

        private void UpdateControlsOnCreate()
        {
            WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_PROGRESS_BAR_POS, (IntPtr)_ProgressBarValue, IntPtr.Zero);
            WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_PROGRESS_BAR_STATE, (IntPtr)_ProgressBarState, IntPtr.Zero);

            WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_MARQUEE_PROGRESS_BAR, _MarqueeProgressBar ? (IntPtr)1 : IntPtr.Zero, IntPtr.Zero);
            WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_PROGRESS_BAR_MARQUEE, _MarqueeDisplayStarted ? (IntPtr)1 : IntPtr.Zero, IntPtr.Zero);

            foreach (TaskDialogButton btn in Buttons)
            {
                if (!btn.Enabled)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_ENABLE_BUTTON, (IntPtr)btn.Config.nButtonID, IntPtr.Zero);
                if (btn.ShowShield)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE, (IntPtr)btn.Config.nButtonID, (IntPtr)1);
            }
            foreach (TaskDialogRadioButton btn in RadioButtons)
            {
                if (!btn.Enabled)
                    WinAPI.SendMessage(hWnd, (uint)TASKDIALOG_MESSAGES.TDM_ENABLE_RADIO_BUTTON, (IntPtr)btn.Config.nButtonID, IntPtr.Zero);
            }
        }
    }
}
