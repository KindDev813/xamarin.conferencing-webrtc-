﻿using WebRTC.Abstraction;

namespace WebRTC.iOS.Demo
{
    public class ARDFileCaptureController : FileVideoCapturer
    {
        private readonly string[] Files =
        {
            "foreman.mp4",
            "SampleVideo_1280x720_10mb.mp4"
        };

        private bool _hasStarted;
        private int _currentFile;

        public ARDFileCaptureController(IVideoSource videoSource) : base(videoSource)
        {
        }

        public void Toggle()
        {
            _currentFile = _currentFile == 0 ? 1 : 0;
            StopCapture();
            StartCapture();
        }

        public override void StartCapture()
        {
            if (_hasStarted)
                return;

            _hasStarted = true;
            StartCapturingFromFileNamed(Files[_currentFile]);
        }

        public override void StopCapture()
        {
            base.StopCapture();
            _hasStarted = false;
        }
    }
}
