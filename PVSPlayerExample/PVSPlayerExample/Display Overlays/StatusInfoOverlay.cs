﻿#region Usings

using PVS.MediaPlayer;
using System;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class StatusInfoOverlay : OverlayForm, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'StatusInfo'
        Shows some information about the player and the playing media.
        
        */

        // ******************************** Fields

        #region Fields

        private MainWindow      _baseForm;
        private Player          _basePlayer;
        private OverlayMode     _baseOverlayMode;
        private bool            _disposed;

        #endregion

        // ******************************** Initialize & Form event handling

        #region Initialize & Form and Player event handling

        // Main
        public StatusInfoOverlay(MainWindow baseForm, Player basePlayer)
        {
            InitializeComponent();

            _baseForm   = baseForm;
            _basePlayer = basePlayer;
            versionLabel.Text = Player.VersionString + " (" + (IntPtr.Size == 8 ? "64": "32") + "-bit)";

            // Pass on drag and drop to main form (see below):
            AllowDrop   = true;
        }

        // Drag and Drop - uses main window methods (handled in source file: DragDrop.cs)
        protected override void OnDragEnter(DragEventArgs e) { _baseForm.DoOnDragEnter(e); }
        protected override void OnDragOver(DragEventArgs e) { _baseForm.DoOnDragOver(e); }
        protected override void OnDragLeave(EventArgs e) { _baseForm.DoOnDragLeave(); }
        protected override void OnDragDrop(DragEventArgs e) { _baseForm.DoOnDragDrop(e); }

        // Called when the form is shown or hidden
        private void StatusInfoOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _baseOverlayMode = _basePlayer.Overlay.Mode;
                if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Display;
                else _baseForm.SetOverlayDisplayMode();

                SetPlayerEventHandlers();
                SetAllInfo();

                MouseDown += _basePlayer.Display.Drag_MouseDown;

                _basePlayer.Overlay.Blend = OverlayBlend.Opaque;
            }
            else
            {
                RemovePlayerEventHandlers();

                if (_baseOverlayMode == OverlayMode.Video)
                {
                    if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Video;
                    else _baseForm.SetOverlayVideoMode();
                }

                MouseDown -= _basePlayer.Display.Drag_MouseDown;

                _basePlayer.Overlay.Blend = OverlayBlend.None;
            }
        }

        private void SetPlayerEventHandlers()
        {
            // Handle "All"
            _basePlayer.Events.MediaStarted += SetAllInfoEventHandler;

            // Handle "Status"
            _basePlayer.Events.MediaPausedChanged += SetStatusInfoEventHandler;

            // Handle "Media"
            // TODO
            //_basePlayer.Events.MediaStartStopPositionChanged += SetMediaInfoEventHandler;
            _basePlayer.Events.MediaRepeatChanged += SetMediaInfoEventHandler;
            _basePlayer.Events.MediaSpeedChanged += SetMediaInfoEventHandler;

            // Handle "Video"
            // TODO
            //_basePlayer.Events.MediaVideoEnableChanged += SetVideoInfoEventHandler;
            _basePlayer.Events.MediaVideoBoundsChanged += SetVideoInfoEventHandler;
            SizeChanged += SetVideoDisplayInfoEventHandler; // also handles "Display" (Size)

            // Handle "Audio"
            _basePlayer.Events.MediaAudioMuteChanged += SetAudioInfoEventHandler;
            _basePlayer.Events.MediaAudioVolumeChanged += SetAudioInfoEventHandler;
            _basePlayer.Events.MediaAudioBalanceChanged += SetAudioInfoEventHandler;

            // Handle "Display"
            _basePlayer.Events.MediaDisplayChanged += SetVideoDisplayInfoEventHandler;
            _basePlayer.Events.MediaDisplayModeChanged += SetVideoDisplayInfoEventHandler;
            _basePlayer.Events.MediaFullScreenChanged += SetVideoDisplayInfoEventHandler;
            _basePlayer.Events.MediaFullScreenModeChanged += SetVideoDisplayInfoEventHandler;
        }

        private void RemovePlayerEventHandlers()
        {
            _basePlayer.Events.MediaStarted -= SetAllInfoEventHandler;

            _basePlayer.Events.MediaPausedChanged -= SetStatusInfoEventHandler;

            // TODO
            //_basePlayer.Events.MediaStartStopPositionChanged -= SetMediaInfoEventHandler;
            _basePlayer.Events.MediaRepeatChanged -= SetMediaInfoEventHandler;
            _basePlayer.Events.MediaSpeedChanged -= SetMediaInfoEventHandler;

            // TODO
            //_basePlayer.Events.MediaVideoEnabledChanged -= SetVideoInfoEventHandler;
            _basePlayer.Events.MediaVideoBoundsChanged -= SetVideoInfoEventHandler;
            SizeChanged -= SetVideoDisplayInfoEventHandler; // also handles "Display" (Size)

            _basePlayer.Events.MediaAudioMuteChanged -= SetAudioInfoEventHandler;
            _basePlayer.Events.MediaAudioVolumeChanged -= SetAudioInfoEventHandler;
            _basePlayer.Events.MediaAudioBalanceChanged -= SetAudioInfoEventHandler;

            _basePlayer.Events.MediaDisplayChanged -= SetVideoDisplayInfoEventHandler;
            _basePlayer.Events.MediaDisplayModeChanged -= SetVideoDisplayInfoEventHandler;
            _basePlayer.Events.MediaFullScreenChanged -= SetVideoDisplayInfoEventHandler;
            _basePlayer.Events.MediaFullScreenModeChanged -= SetVideoDisplayInfoEventHandler;
        }

        // The EventHandlers:

        void SetAllInfoEventHandler(object sender, EventArgs e)
        {
            SetAllInfo();
        }

        void SetStatusInfoEventHandler(object sender, EventArgs e)
        {
            SetStatusInfo();
        }

        void SetMediaInfoEventHandler(object sender, EventArgs e)
        {
            SetMediaInfo();
        }

        void SetVideoInfoEventHandler(object sender, EventArgs e)
        {
            SetVideoInfo();
        }

        void SetAudioInfoEventHandler(object sender, EventArgs e)
        {
            SetAudioInfo();
        }

        void SetVideoDisplayInfoEventHandler(object sender, EventArgs e)
        {
            SetVideoInfo(); // for videosize
            SetDisplayInfo();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _baseForm = null;
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool HasMenu
        {
            get { return false; }
        }

        public bool MenuEnabled
        {
            get { return false; }
            set { }
        }

        public void MediaStopped()
        {
            if (Visible) SetAllInfo();
        }

        #endregion

        // ******************************** Set the Info

        #region Set the Info

        private void SetAllInfo()
        {
            SuspendLayout();
            SetStatusInfo();
            SetMediaInfo();
            SetVideoInfo();
            SetAudioInfo();
            SetDisplayInfo();
            ResumeLayout();
        }

        private void SetStatusInfo()
        {
            if (_basePlayer.Playing) statusLabel.Text = _basePlayer.Paused ? "Paused" : "Playing";
            else statusLabel.Text = "No Media";
        }

        private void SetMediaInfo()
        {
            if (_basePlayer.Playing)
            {
                mediaLabel.Text = _basePlayer.Media.GetName(MediaName.FileName);
                durationLabel.Text = _basePlayer.Media.GetDuration(MediaPart.BeginToEnd).ToString().Substring(0, 8);

                startLabel.Text = _basePlayer.Media.StartTime.TotalSeconds == 0 ? "Begin of Media" : _basePlayer.Media.StartTime.ToString().Substring(0, 8);
                endLabel.Text = _basePlayer.Media.StopTime.TotalSeconds == 0 ? "End of Media" : _basePlayer.Media.StopTime.ToString().Substring(0, 8);

                repeatLabel.Text = _basePlayer.Repeat ? "Yes" : "No";
                if (_basePlayer.Speed.Rate == 1.0f) speedLabel.Text = "1.00 (Normal)";
                else speedLabel.Text = _basePlayer.Speed.Rate.ToString("0.00#") + " (" + (_basePlayer.Speed.Rate / 0.01).ToString("0") + "%)";
            }
            else
            {
                mediaLabel.Text = "-";
                durationLabel.Text = "-";
                startLabel.Text = "-";
                endLabel.Text = "-";
                repeatLabel.Text = "-";
                speedLabel.Text = "-";
            }
        }

        private void SetVideoInfo()
        {
            if (_basePlayer.Video.Present)
            {
                videoLabel.Text = "Present";
                videoEnabledLabel.Text = "Yes"; // _basePlayer.Video.Enabled ? "Yes" : "No"; // TODO
                originalSizeLabel.Text = _basePlayer.Media.VideoSourceSize.ToString().TrimStart('{').TrimEnd('}');
                currentSizeLabel.Text = _basePlayer.Video.Bounds.ToString().TrimStart('{').TrimEnd('}');
                frameRateLabel.Text = _basePlayer.Media.VideoFrameRate.ToString("0.##") + " frames per second";
            }
            else
            {
                videoLabel.Text = _basePlayer.Playing ? "Not Present" : "-";
                videoEnabledLabel.Text = "-";
                originalSizeLabel.Text = "-";
                currentSizeLabel.Text = "-";
                frameRateLabel.Text = "-";
            }
        }

        private void SetAudioInfo()
        {
            if (_basePlayer.Audio.Present)
            {
                audioLabel.Text = "Present";
                audioEnabledLabel.Text = _basePlayer.Audio.Enabled ? "Yes" : "No";

                volumeLabel.Text = (_basePlayer.Audio.Volume).ToString("0.00");
                switch (_basePlayer.Audio.Volume)
                {
                    case 1.0f:
                        volumeLabel.Text += " (Maximum)";
                        break;
                    case 0:
                        volumeLabel.Text += " (Mute)";
                        break;
                    default:
                        volumeLabel.Text += " (" + (_basePlayer.Audio.Volume / 0.01).ToString("0") + "%)";
                        break;
                }

                balanceLabel.Text = (_basePlayer.Audio.Balance).ToString("0.00");
                if (_basePlayer.Audio.Balance == 0) balanceLabel.Text += " (Center)";
                else
                {
                    if (_basePlayer.Audio.Balance < 0) balanceLabel.Text += " (Left " + (_basePlayer.Audio.Balance * -100).ToString("0") + "%)";
                    else balanceLabel.Text += " (Right " + (_basePlayer.Audio.Balance * 100).ToString("0") + "%)";
                }
            }
            else
            {
                audioLabel.Text = _basePlayer.Playing ? "Not Present" : "-";
                audioEnabledLabel.Text = "-";
                volumeLabel.Text = "-";
                balanceLabel.Text = "-";
            }
        }

        private void SetDisplayInfo()
        {
            if (_basePlayer.Display != null)
            {
                displayLabel.Text = _basePlayer.Display.Window.Name + " (" + _basePlayer.Display.Window.GetType() + ")";
                displaySizeLabel.Text = _basePlayer.Display.Window.Size.ToString().TrimStart('{').TrimEnd('}');
                displayModeLabel.Text = _basePlayer.Display.Mode.ToString();
                fullScreenLabel.Text = _basePlayer.FullScreen ? "FullScreen " + _basePlayer.FullScreenMode : "Window";
            }
            else
            {
                displayLabel.Text = "None";
                displaySizeLabel.Text = "-";
                displayModeLabel.Text = "-";
                fullScreenLabel.Text = "-";
            }
        }

        #endregion


        // ******************************** Fading Example

        #region Fading Example

        // should be controlled by a timer, not by doevents and sleep
        // But, normally you would only use fade in or fade out, so you don't have to use this construction with doevents and sleep at all.
        // 0.99 and 0.01 are used instead of 0 and 1 because of the precision issue with floats
        private void FadeOutButton_Click(object sender, EventArgs e)
		{
            float  _oldVolume       = _basePlayer.Audio.Volume;
            double _oldSaturation   = _basePlayer.Video.Saturation;
            double _oldOpacity      = Opacity;

            Cursor = Cursors.WaitCursor;

            _basePlayer.Audio.VolumeTo(1, 1);
            while (_basePlayer.Audio.Volume < 0.99f) Application.DoEvents();

            _basePlayer.Events.MediaAudioVolumeChanged += Fade_MediaAudioVolumeChanged;
            Opacity = 1.0 - _basePlayer.Audio.Volume;

            _basePlayer.Audio.VolumeTo(0, 60);

            while (_basePlayer.Audio.Volume > 0.01) Application.DoEvents();
            System.Threading.Thread.Sleep(2000);

			_basePlayer.Audio.VolumeTo(1);

			while (_basePlayer.Audio.Volume < 0.99) Application.DoEvents();
            System.Threading.Thread.Sleep(2000);

            _basePlayer.Events.MediaAudioVolumeChanged -= Fade_MediaAudioVolumeChanged;

			_basePlayer.Audio.VolumeTo(_oldVolume, 20);
            _basePlayer.Video.Saturation = _oldSaturation;
            Opacity = _oldOpacity;

            Cursor = Cursors.Default;
        }

		private void Fade_MediaAudioVolumeChanged(object sender, EventArgs e)
		{
			Opacity = 1.0 - _basePlayer.Audio.Volume;
			// You could add this:
			//_basePlayer.Video.Saturation = _basePlayer.Audio.Volume - 1.0;


			// If you want to fade a video without using a display overlay, use for example:

			//double fadeValue = _basePlayer.Audio.Volume - 1.0;
			//_basePlayer.Video.Brightness = fadeValue;
			//_basePlayer.Video.Contrast = fadeValue;
			//_basePlayer.Video.Saturation = fadeValue;
		}

		#endregion
	}
}
